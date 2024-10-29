namespace WebApp.Models.Services;

public class MemoryContactService: IContactService
{
    
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {1, new ContactModel() {Id = 1, Category = Category.Business, FirstName = "Adam", LastName = "Abecki", Email = "adam@wsei.edu.pl", Birth = new DateOnly(2000,10,10), PhoneNumber = "+48 222 222 333"}},
        {2, new ContactModel() {Id = 2, Category = Category.Family, FirstName = "Damian", LastName = "Wysoki", Email = "damian@wsei.edu.pl", Birth = new DateOnly(2004,11,18), PhoneNumber = "+48 423 525 167" }},
        {3, new ContactModel() {Id = 3, Category = Category.Friend, FirstName = "Katarzyna", LastName = "Tuba", Email = "katarzyna@wsei.edu.pl", Birth = new DateOnly(1999,03,04), PhoneNumber = "+48 927 345 867" }}
    };

    private int currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++currentId;
        _contacts.Add(model.Id , model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
              _contacts[model.Id] = model;  
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}