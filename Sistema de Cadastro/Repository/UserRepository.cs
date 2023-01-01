using Microsoft.EntityFrameworkCore;
using Sistema_de_Cadastro.Data;
using Sistema_de_Cadastro.Models;

namespace Sistema_de_Cadastro.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly BaseContext _baseContext;
        public UserRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public UserModel Add(UserModel userModel)
        {
            userModel.CreatedDate = DateTime.Now;
            _baseContext.Users.Add(userModel);
            _baseContext.SaveChanges();

            return userModel;
        }


        public bool Delete(int id)
        {
            UserModel userModel = GetById(id);
            if (userModel == null)
            {
                throw new Exception("Could not find user's data");
            }

            _baseContext.Remove(userModel);
            _baseContext.SaveChanges();

            return true;
        }

        public UserModel Update(UserModel userModel)
        {
            UserModel toUpdateUser = GetById(userModel.Id);
            if (toUpdateUser == null)
            {
                throw new Exception("Something went wrong");
            }

            toUpdateUser.Name = userModel.Name;
            toUpdateUser.Email = userModel.Email;
            toUpdateUser.Login = userModel.Login;
            toUpdateUser.Password = userModel.Password;

            toUpdateUser.LastModifiedDate = DateTime.Now;

            _baseContext.Users.Update(toUpdateUser);
            _baseContext.SaveChanges();

            return toUpdateUser;

        }

        public UserModel GetById(int id)
        {
            return _baseContext.Users.FirstOrDefault(
                     modelContact => modelContact.Id == id

                 );
        }

        public List<UserModel> GetAll()
        {
            return _baseContext.Users.ToList();
        }

        public UserModel? GetByLogin(string login)
        {
            return _baseContext.Users.FirstOrDefault(user => user.Login.ToUpper() == login.ToUpper());
        }
    }
}
