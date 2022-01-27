using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proj.Infrastructure.Service;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using Proj.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Proj.Api.Logger;

namespace Proj.Api.Controllers
{
    [Produces("application/json")]

    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IContactsService _contactsService;
        private IConfiguration _configuration { get; }
        private readonly ICustomLogger logger;
        public ApiController(IContactsService contactsService
            , IConfiguration iConfiguration, ICustomLogger logger )
        {
            _contactsService = contactsService;
            _configuration = iConfiguration;
            this.logger = logger;

        }
        [HttpGet]
        [Route("contacts")]
        public async Task<IActionResult> GetContacts()
        
        {
            logger.Info("api/contacts");
            var list =await _contactsService.GetAllContactsAsync();
            return Json(list);
        }
        [HttpGet]
        [Route("addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var list = await _contactsService.GetAllAddressesAsync();
            return Json(list);
        }
        [HttpGet]
        [Route("contacts/{id}")]
        public async Task<IActionResult> GetContact([FromRoute]int id)
        {
            var contact = await _contactsService.GetContact(id);
            return Json(contact);
        }
        [HttpGet]
        [Route("addresses/{id}")]
        public async Task<IActionResult> GetAddress([FromRoute]int id)
        {
            var address = await _contactsService.GetAddress(id);
            return Json(address);
        }
        [HttpPost]
        [Route("addresses")]
        public async Task<IActionResult> PostAddress([FromBody] Address address )
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }
            await _contactsService.AddAddressAsync(address, 2);
            return Ok();
        }
        [HttpPost]
        [Route("contacts")]
        public async Task<IActionResult> PostContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contactsService.AddContactAsync(contact);         
            return Ok();
        }
        [HttpDelete]
        [Route("contacts/{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {

            await _contactsService.DeleteContactAsync(id);
            return Ok();
        }
        [HttpDelete]
        [Route("addresses/{id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int id)
        {
            await _contactsService.DeleteAddressAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("contacts/{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id
            , [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contactsService.UpdateContactAsync(contact, id);
            return Ok();
        }
        [HttpPut]
        [Route("addresses/{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int id,
            [FromBody] Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contactsService.UpdateAddressAsync(address, id);          
            return Ok();

        }
        
        
     
    }
}
