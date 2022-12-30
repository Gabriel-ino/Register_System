using Sistema_de_Cadastro.Models;

namespace Sistema_de_Cadastro.Repository
{
    public interface IUserRepository
    {
        UserModel GetById(int id);
        List<UserModel> GetAll();

        UserModel Add(UserModel userModel);

        UserModel Update(UserModel userModel);

        bool Delete(int id);
    }
}
