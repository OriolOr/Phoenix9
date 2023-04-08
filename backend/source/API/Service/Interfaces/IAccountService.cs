using OriolOr.Maneko.API.Domain;
using OriolOr.Maneko.API.Domain.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.API.Service.Interfaces
{
    public interface IAccountService
    {
        public double GetCurrentBalanceFromDb(UserCredentials userCredentials);

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials);
    }
}
