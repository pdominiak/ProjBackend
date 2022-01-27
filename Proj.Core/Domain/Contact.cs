using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj.Core.Domain
{
    public class Contact
    {
        [Required]
        [Key]
        public int ContactID { get; set; }
        [Required(ErrorMessage = "Podaj swoje imie")]
        [MaxLength(50)]
        [RegularExpression("^[A-Z]{1}[a-z]+", ErrorMessage ="Imie musi sie skladac z liter i zaczynac z wielkiej litery")]
        public string FirstName {get;protected set;}
        [Required(ErrorMessage ="Podaj swoje nazwisko")]
        [MaxLength(50)]
        [RegularExpression("^[A-Z]{1}[a-z]+", ErrorMessage = "Nazwisko musi sie skladac z liter i zaczynac z wielkiej litery")]
        public string LastName {get;protected set;}
        [Required(ErrorMessage = "Podaj swoj numer telefonu")]
        [MaxLength(50)]
        [RegularExpression("^[0-9]{9}$",ErrorMessage ="Zly format numeru telefonu")]
        public string PhoneNumber {get;protected set;}
        [Required(ErrorMessage ="Podaj swoj email")]
        [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+", ErrorMessage ="Zly format maila")]
        [MaxLength(50)]
        public string Email {get;protected set;}
        
        public ICollection<Address> Addresses { get; protected set; } //icollection
        public Contact(int contactID, string firstName, string lastName,
        string phoneNumber, string email){
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            ContactID = contactID;
            Addresses = new List<Address>();
        }
        public void SetPhoneNumber(string newPhoneNumber)
        {
            if(string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                throw new Exception($"New phone number not given");
            }
            PhoneNumber = newPhoneNumber;
        }
        public void SetEmail(string newEmail)
        {
            if(string.IsNullOrWhiteSpace(newEmail))
            {
                throw new Exception($"New phone number not given");
            }
            Email = newEmail;
        }
        public void AddAddress(Address address)
        {
            if (!Addresses.Contains(address))
            {
                Addresses.Add(address);
            }
        }
        public void setNonIdData(Contact contact)
        {
            this.FirstName = contact.FirstName;
            this.LastName = contact.LastName;
            this.PhoneNumber = contact.PhoneNumber;
            this.Email = contact.Email;
        }
        
        

    }
}