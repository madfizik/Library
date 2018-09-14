using Library.BLL.Interface;
using Library.DAL.Repositories;

namespace Library.BLL.EFService
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
