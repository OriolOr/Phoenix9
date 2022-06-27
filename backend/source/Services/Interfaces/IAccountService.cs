using OriolOr.Maneko.Domain;
using OriolOr.Maneko.Domain.IdentityManagement;
using System.Collections.ObjectModel;

namespace OriolOr.Maneko.Services.Interfaces
{
    public interface IAccountService
    {
        public double GetCurrentBalanceFromDb(UserCredentials userCredentials);

        public Collection<YearBalance> GetYearBalanceFromDb(UserCredentials userCredentials);
    }
}
