using System.Threading.Tasks;
using IDScan.ViewModel;

namespace IDScan.Application.UseCases.User
{
    public interface IAccountApplication
    {
        UserDTO CheckUserExistWithEmailAndAdd(UserDTO objUser);
    }
}
