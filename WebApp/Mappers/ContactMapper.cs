using Data.Entities;
using WebApp.Models;

namespace WebApp.Mappers;

public class ContactMapper
{
    public static ContactModel FromEntity(ContactEntity entity)
    {
        return new ContactModel()
        {
            Id = entity.Id,
            FirstName = entity.Name,
            Email = entity.Email,
            PhoneNumber = entity.Phone,
            Birth = entity.Birth,
        };
    }

    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            Name = model.FirstName,
            Email = model.Email,
            Phone = model.PhoneNumber,
            Birth = model.Birth,
        };
    }
}