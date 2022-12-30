using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Cadastro.Models;

namespace Sistema_de_Cadastro.Data
{
    public class BaseContext: DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options): base(options) {
            
        }

        public DbSet<ModelContact> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }
}
