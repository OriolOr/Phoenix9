using MongoDB.Driver;
using Newtonsoft.Json;
using OriolOr.Maneko.ExternalCom;
using OriolOr.Maneko.Infrastructure.Properties;
using OriolOr.Maneko.Domain;
using System.Collections.ObjectModel;
using OriolOr.Maneko.Domain.IdentityManagement;

namespace OriolOr.Maneko.Infrastructure
{
    public static class MongoDbConfigurator
    {
        public static IMongoClient? MongoClient;
        public static IMongoDatabase? DataBase;

        public static void InitializeDataBase() {
            MongoClient = new MongoClient("mongodb://localhost:27017");
            DataBase = MongoClient.GetDatabase("ManekoDataBase");

            InitializeMongoDbCollection(DataBase, "AccountData");
            InitializeMongoDbCollection(DataBase, "UserData");
            LoadAccountData(DataBase);
            LoadUserData(DataBase);
        }


        public static double GetAccountCurrentBalance()
        {

            var collection = DataBase.GetCollection<Account>("AccountData");

            var accDocument = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault();
            return accDocument.CurrentBalance;
        }

        public static Collection<YearBalance> GetYearBalance()
        {
            var collection = DataBase.GetCollection<Account>("AccountData");

            var accDocument = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault();
            return accDocument.YearHistory;
        }

        public static void UpdateCurrentbalance(WebScrapper webScrapper)
        {
            var collection = DataBase.GetCollection<Account>("AccountData");

            var accDocument = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault();
            //Check last update 
            if (DateTime.Now.Day != accDocument.LastUpdate.Day)
            {
                webScrapper.ScrapCurrentBalance();
            }
   
        }


        private static void InitializeMongoDbCollection(IMongoDatabase dataBase, string collectionName)
        {
            var collectionsList = dataBase.ListCollectionNames().ToList();

            if (!collectionsList.Contains(collectionName)) dataBase.CreateCollection(collectionName);
        }

        private static void LoadUserData(IMongoDatabase database) {
            
            var collection = database.GetCollection<UserCredentials>("UserData");
            var nDocuments = collection.CountDocuments(FilterDefinition<UserCredentials>.Empty);

            if ( nDocuments == 0)
            {
                UserCredentials userData = JsonConvert.DeserializeObject<Collection<UserCredentials>>(Resources.UserData).FirstOrDefault();
                collection.InsertOne(userData);

            }

        }

        private static void LoadAccountData(IMongoDatabase database)
        {
            var collection = database.GetCollection<Account>("AccountData");
            var nDocuments = collection.CountDocuments(FilterDefinition<Account>.Empty);
            var accDocumentLastUpdate = new DateTime();

            if (nDocuments != 0)
            {
                accDocumentLastUpdate = collection.Find(FilterDefinition<Account>.Empty).FirstOrDefault().LastUpdate;
            }
            

            if (accDocumentLastUpdate.Day != DateTime.Now.Day)
            {
                UserCredentials userCredentials = new UserCredentials()
                {
                };

                WebScrapper webscrapper = new WebScrapper(userCredentials);

                Account account = new Account()
                {
                    CurrentBalance = webscrapper.ScrapCurrentBalance(),
                    AccountNumberId = webscrapper.ScrapAccountId(),
                    LastUpdate = DateTime.Now      
                };

                var newYearBalance = new YearBalance();
                newYearBalance.Year = 2022;
                newYearBalance.MonthBalances = JsonConvert.DeserializeObject<Collection<MonthBalance>>(Resources.BankData);

                account.YearHistory.Add(newYearBalance);

                collection.InsertOne(account);
            }
           
        }

    }
}