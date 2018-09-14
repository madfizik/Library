using Library.BLL.DTO;
using Library.BLL.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.BLL.Interface
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
    }
}
