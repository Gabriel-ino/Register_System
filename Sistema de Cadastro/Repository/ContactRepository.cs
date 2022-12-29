using Sistema_de_Cadastro.Data;
using Sistema_de_Cadastro.Models;

namespace Sistema_de_Cadastro.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BaseContext _baseContext;
        public ContactRepository(BaseContext baseContext) {
            _baseContext = baseContext;
            
        }
        public ModelContact Add(ModelContact contact)

        {
            // Insert on database
            _baseContext.Contacts.Add(contact);
            _baseContext.SaveChanges();
            return contact;

        }

        public bool Delete(int id)
        {
            ModelContact dbContact = GetById(id);
            if (dbContact == null)
            {
                throw new Exception("Contact not found");
            }

            _baseContext.Contacts.Remove(dbContact);
            _baseContext.SaveChanges();

            return true;
        }

        public List<ModelContact> getAll()
        {
            return _baseContext.Contacts.ToList();
        }

        public ModelContact GetById(int id)
        {

            return _baseContext.Contacts.FirstOrDefault(
                    x => x.Id == id
                );
        }

        public ModelContact Update(ModelContact passedContact)
        {
            ModelContact dbContact = GetById(passedContact.Id);
            
            if(dbContact == null)
            {
                throw new Exception("Something got wrong");
            }

            dbContact.Name = passedContact.Name;
            dbContact.Email= passedContact.Email;
            dbContact.Contact = passedContact.Contact;

            _baseContext.Contacts.Update(dbContact);
            _baseContext.SaveChanges();

            return dbContact;
            
        }
    }
}
