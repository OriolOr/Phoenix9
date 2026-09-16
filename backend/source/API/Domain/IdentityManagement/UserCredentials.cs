namespace OriolOr.Maneko.API.Domain.IdentityManagement
{
    public class UserCredentials
    {
        public string? UserName;
        public string? Password;
        public string? AccountId;
        public RoleType Role;
        public UserToken Token;
    }
}
