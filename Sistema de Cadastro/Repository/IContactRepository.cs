using Sistema_de_Cadastro.Models;

namespace Sistema_de_Cadastro.Repository
{
    public interface IContactRepository
    {
        ModelContact GetById(int id);
        List<ModelContact> getAll();
        ModelContact Add(ModelContact contact);
        ModelContact Update(ModelContact contact);

        bool Delete(int id);
    }
}
