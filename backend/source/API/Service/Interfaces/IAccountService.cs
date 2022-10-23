using OriolOr.Maneko.API.Models;
using OriolOr.Maneko.API.Models.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IAccountService
    {
        public double GetCurrentBalanceFromDb(UserCredentials userCredentials);

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials);
    }
}
