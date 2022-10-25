namespace SIBKMNET_WebApp.Repositories.Data
{
    public class AccountRepositoryBase2
    {

        // Forgot Password
        public ForgotPass Forgot(Forgot forgot)
        {
            var defpass = Hashing.HashPassword(forgot.DefPass);
            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x => x.User.Employee.Email.Equals(forgot.Email));
            var verify = Hashing.ValidataPassword(forgot.Default, defpass);

            if (verify)
            {
                var fpass = new ForgotPass()
                {
                    Id = data.User.Employee.Id,
                    Role = data.Role.Name,
                    Email = data.User.Employee.Email,

                };
                return fpass;
            }
        }
    }
}