using IDScan.Domain;

namespace IDScan.Application.UseCases.User
{
    public interface IAccountApplication
    {
        UserDTO CheckUserExistWithEmailAndAdd(UserDTO objUser);
    }
}
