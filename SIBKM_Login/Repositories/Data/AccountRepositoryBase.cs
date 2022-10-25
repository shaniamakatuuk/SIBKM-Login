namespace SIBKMNET_WebApp.Repositories.Data
{
    public class AccountRepositoryBase
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
            var verify = Hashing.ValidatePassword(forgot.Default, defpass);

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

            // Change Password

            public int ChangePassword(int id, ChangePass changePass)
            {
                var passlama = changePass.PassLama;
                var passbaru = changePass.PassBaru;
                var data = myContext.UserRoles
                    .Include(x => x.Role)
                    .Include(x => x.User)
                    .Include(x => x.User.Employee)
                    .FirstOrDefault(x => x.User.Employee.Email.Equals(changePass.Email));
                var data1 = myContext.Users.Find(data.UserId);

                var verify = Hashing.ValidatePassword(changePass.PassLama, data.User.Password);
                if (verify)
                {
                    data1.Password = Hashing.HashPassword(passbaru);
                    myContext.Entry(data1).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    return result;
                }
                return 0;
            }
        }
    }
}