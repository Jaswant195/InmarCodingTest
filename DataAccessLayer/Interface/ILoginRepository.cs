using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ILoginRepository
    {
        Task<object> Login(LoginViewModel loginViewModel);
    }
}
