using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interface
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
