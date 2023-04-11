using MongoDB.Driver;
using Newtonsoft.Json;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using OriolOr.Maneko.API.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using OriolOr.Maneko.API.Properties;

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

        public void LoadUserData(IMongoDatabase database)
        {

            var nDocuments = this.UserDataCollection.CountDocuments(FilterDefinition<UserCredentials>.Empty);

            if (nDocuments == 0)
            {
                UserCredentials userData = JsonConvert.DeserializeObject<Collection<UserCredentials>>(Resources.UserData).FirstOrDefault();
                this.UserDataCollection.InsertOne(userData);
            }

        }


        //toDo
        public void SetUserToken(string userName)
        {
            var userDoc = this.UserDataCollection.Find(usr => usr.UserName == userName); 

            var Userv
        
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
