using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proj.Core.Domain
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [Required(ErrorMessage ="Proszę podać ulicę")]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Proszę podać number domu")]
        [MaxLength(50)]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Proszę podać numer mieszkania")]
        [MaxLength(50)]
        public string FlatNumber { get;  set; }
        [Required(ErrorMessage = "Proszę podać kod pocztowy")]
        [RegularExpression("^[_0-9]{2}-[_0-9]{3}$",ErrorMessage ="Zły format kodu pocztowego")]
        public string PostOfficeCode { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto")]
        [MaxLength(50)]
        public string Town { get;  set; }
        [Required(ErrorMessage = "Proszę podać kraj")]
        [MaxLength(50)]
        public string Country { get;  set; }
        
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        [JsonIgnore]
        public Contact Contact { get; set; }
        public Address()
        {

        }
        public Address(int addressid, string street, string houseNumber,
            string flatNumber, string postOfficeCode, string town,
            string country, int contactID)
        {
            AddressID = addressid;
            SetStreet(street);
            SetHouseNumber(houseNumber);
            SetFlatNumber(flatNumber);
            SetPostOfficeCode(postOfficeCode);
            SetTown(town);
            SetCountry(country);
            this.ContactID = contactID;
            
        }
        public void SetStreet(string streetParam)
        {
            //if(streetParam == "x")
            //{

            //}
            //if (string.IsNullOrWhiteSpace(streetParam))
            //{
            //    throw new Exception($"Street parameter is not given");
            //}
            Street = streetParam;
        }
        public void SetHouseNumber(string houseNumberParam)
        {
            //if (string.IsNullOrWhiteSpace(houseNumberParam))
            //{
            //    throw new Exception($"House number parameter is not given");
            //}
            HouseNumber = houseNumberParam;
        }
        public void SetFlatNumber(string flatNumberParam)
        {
            ////if (string.IsNullOrWhiteSpace(flatNumberParam))
            ////{
            ////    throw new Exception($"Flat number parameter is not given");
            ////}
            FlatNumber = flatNumberParam;
        }
        public void SetPostOfficeCode(string postOfficeCodeParam)
        {
            //if (string.IsNullOrWhiteSpace(postOfficeCodeParam))
            //{
            //    throw new Exception($"Post Office Code parameter is not given");
            //}
            PostOfficeCode = postOfficeCodeParam;
        }
        public void SetTown(string townParam)
        {
            //if (string.IsNullOrWhiteSpace(townParam))
            //{
            //    throw new Exception($"Town parameter is not given");
            //}

            Town = townParam;
        }
        public void SetCountry(string countryParam)
        {
            //if (string.IsNullOrWhiteSpace(countryParam))
            //{
            //    throw new Exception($"Country parameter is not given");
            //}
            Country = countryParam;
        }
        
        public void SetNonIdData(Address address)
        {
            
            this.Street = address.Street;
            this.HouseNumber = address.HouseNumber;
            this.FlatNumber = address.FlatNumber;
            this.PostOfficeCode = address.PostOfficeCode;
            this.Town = address.Town;
            this.Country = address.Country;

        }
    }
}
