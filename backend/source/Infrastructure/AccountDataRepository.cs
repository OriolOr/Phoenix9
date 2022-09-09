using MongoDB.Driver;
using Newtonsoft.Json;
using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using OriolOr.Maneko.ExternalCom;
using OriolOr.Maneko.Infrastructure.Interfaces;
using OriolOr.Maneko.Infrastructure.Properties;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Infrastructure
{
    public class AccountDataRepository : IAccountDataRepository
    {
        public string CollectionName => "AccountData";
        private readonly IMongoCollection<Account> UserDataCollection;

        public AccountDataRepository()
        {
        }

        public void LoadAccountData(IMongoDatabase database, UserCredentials userCredentials)
        {
            var collection = database.GetCollection<Account>(this.CollectionName);
            var nDocuments = collection.CountDocuments(FilterDefinition<Account>.Empty);
            var accDocumentLastUpdate = new DateTime();

            if (nDocuments != 0) accDocumentLastUpdate = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault().LastUpdate;
             
            if (accDocumentLastUpdate.Day != DateTime.Now.Day)
            {

                WebScrapper webscrapper = new WebScrapper(userCredentials);

                //CREATE ACCOUNT OBJECT 
                Account account = new Account()
                {
                    CurrentBalance = webscrapper.ScrapCurrentBalance(),
                    AccountNumberId = webscrapper.ScrapAccountId(),
                    LastUpdate = DateTime.Now
                };

                //CREATE OBJECT TO BE INSERED IN DATABASE 
                var newYearBalance = new YearBalance();
                newYearBalance.Year = 2022;
                newYearBalance.MonthBalances = JsonConvert.DeserializeObject<Collection<MonthBalance>>(Resources.BankData);

                account.YearHistory.Add(newYearBalance);

                //INSERT TO DATABASE
                if (this.CheckAccountIdExists(database, account.AccountNumberId))
                {
                    //Update existing element in database 
                    collection.ReplaceOne(ac => ac.AccountNumberId == account.AccountNumberId, account);
                }
                else
                {
                    collection.InsertOne(account);
                }
            }
        }

        public double GetAccountCurrentBalance(IMongoDatabase database)
        {
            var collection = database.GetCollection<Account>(this.CollectionName);

            var accDocument = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault();
            return accDocument.CurrentBalance;
        }

        public Collection<YearBalance> GetYearBalance(IMongoDatabase database)
        {
            var collection = database.GetCollection<Account>(this.CollectionName);

            var accDocument = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault();
            return accDocument.YearHistory;
        }

        private bool CheckAccountIdExists(IMongoDatabase database, string accountId)
        {
            var collection = database.GetCollection<Account>(this.CollectionName);

            var accElements = collection.Find(acc => acc.AccountNumberId == accountId).Count();

            if (accElements == 0)
            {
                return false; 
            }
            else
            {
                return true;
            }

        }
    }

}
