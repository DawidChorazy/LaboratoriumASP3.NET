using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please, type in your name!")]
    [MaxLength(length: 20, ErrorMessage = "Name cannot be longer than 20 characters!")]
    [MinLength(length: 1, ErrorMessage = "Name cannot be shorter than 1 character!")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please, type in your name!")]
    [MaxLength(length: 50, ErrorMessage = "Last name cannot be longer than 20 characters!")]
    [MinLength(length: 1, ErrorMessage = "Last name cannot be shorter than 1 character!")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "Adres E-mail")]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly Birth { get; set; }
    
    [Phone]
    [RegularExpression("\\+\\d\\d \\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Enter number: +xx xxx xxx xxx")]
    [Display(Name = "Telefon")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
}