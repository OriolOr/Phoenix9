using MongoDB.Driver;
using Newtonsoft.Json;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using OriolOr.Maneko.API.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using OriolOr.Maneko.API.Properties;
using System.IdentityModel.Tokens.Jwt;

namespace OriolOr.Maneko.API.Infrastructure
{
    public class UserDataRepository : IUserDataRepository
    {
        public string CollectionName => "UserData";
        private IMongoCollection<UserCredentials> UserDataCollection;

        public UserDataRepository()
        {
            this.UserDataCollection = MongoDbConfigurator.DataBase.GetCollection<UserCredentials>(this.CollectionName);
        }


        public void AddUser(UserCredentials userCredentials)
        {
            this.UserDataCollection.InsertOne(userCredentials);
        }

        public void LoadUserData(IMongoDatabase database)
        {

            var nDocuments = this.UserDataCollection.CountDocuments(FilterDefinition<UserCredentials>.Empty);

            if (nDocuments == 0)
            {
                UserCredentials userData = JsonConvert.DeserializeObject<Collection<UserCredentials>>(Resources.UserData).FirstOrDefault();
                this.UserDataCollection.InsertOne(userData);
            }

        }

        public string GetUserToken(string userName) => this.UserDataCollection.Find(usr => usr.UserName == userName).FirstOrDefault().Token.Value.ToString();

        public IEnumerable<string>  GetAllTokens() => this.UserDataCollection.Find(FilterDefinition<UserCredentials>.Empty).ToList().Select(u =>  u.Token.Value).ToList();

       
        public void SetUserToken(string userName, string token)
        {
            var userDoc = this.UserDataCollection.Find(usr => usr.UserName == userName).FirstOrDefault();

            userDoc.Token = new UserToken()
            {
                Value = token

            };

            this.UserDataCollection.ReplaceOne(usr => usr.UserName == userName, userDoc);
     
        }



        public bool CheckUsernameExists(string userName)
        {
            var docFind = false;

            var nDocuments = this.UserDataCollection.Find(usr => usr.UserName == userName).CountDocuments();
             
            if (nDocuments == 1) docFind = true;

            else docFind = false;

            return docFind;

        }
        public string GetPasswordEncoded(string userName) 
            => this.UserDataCollection.Find(usr => usr.UserName == userName).FirstOrDefault<UserCredentials>().Password;

    }
}
