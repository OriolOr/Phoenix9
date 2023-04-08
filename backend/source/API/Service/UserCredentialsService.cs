using OriolOr.Maneko.API.Domain.IdentityManagement;
using OriolOr.Maneko.API.Infrastructure;
using OriolOr.Maneko.API.Infrastructure.Interfaces;
using OriolOr.Maneko.API.Service.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OriolOr.Maneko.API.Service
{
    public class UserCredentialsService : IUserCredentialsService
    {
        public IUserDataRepository UserDataRepository; 
        public IAccountDataRepository AccountDataRepository;

        public UserCredentialsService(IUserDataRepository userDataRepository, IAccountDataRepository accountDataRepository)
        {
            this.UserDataRepository = userDataRepository;
            this.AccountDataRepository = accountDataRepository;
        }

        public bool Authenticate(UserCredentials userCredentials)
        {
            bool loginSucced;

            if (UserDataRepository.CheckUsernameExists(userCredentials.UserName))
            {
                var passwordEncoded = this.UserDataRepository.GetPasswordEncoded(userCredentials.UserName);
                if (passwordEncoded == this.EncodeMD5HashPassword(userCredentials.Password))
                {
                    AccountDataRepository.LoadAccountData(MongoDbConfigurator.DataBase, userCredentials);
                    loginSucced = true;
                }
                else loginSucced = false;
                
            }
            else  loginSucced = false;


            return loginSucced;
        }

        private void GenerateToken() { }

        private string EncodeMD5HashPassword(string password)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();

        }
    }
}
