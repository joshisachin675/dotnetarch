using IDScan.ViewModel;
using System.Threading.Tasks;

namespace IDScan.Application.Repositories
{
    public interface IAccountRepository
    {
        UserDTO CheckUserExistWithEmailAndAdd(UserDTO emailId);
    }
}
