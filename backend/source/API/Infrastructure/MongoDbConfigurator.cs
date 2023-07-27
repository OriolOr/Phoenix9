using MongoDB.Driver;

namespace OriolOr.Maneko.API.Infrastructure
{
    public static class MongoDbConfigurator
    {
        public static IMongoClient? MongoClient;
        public static IMongoDatabase? DataBase;

        public static void InitializeDataBase() {

            MongoClient = new MongoClient("mongodb://localhost:27017");
            DataBase = MongoClient.GetDatabase("ManekoDataBase");
    
            UserDataRepository userDataRepository = new UserDataRepository();
            AccountDataRepository accountDataRepository = new AccountDataRepository();

            InitializeMongoDbCollection(DataBase, accountDataRepository.CollectionName);
            InitializeMongoDbCollection(DataBase, userDataRepository.CollectionName);
            
            userDataRepository.LoadUserData(DataBase);
        }

        private static void InitializeMongoDbCollection(IMongoDatabase dataBase, string collectionName)
        {
            var collectionsList = dataBase.ListCollectionNames().ToList();

            if (!collectionsList.Contains(collectionName)) dataBase.CreateCollection(collectionName);
        }

    }
}