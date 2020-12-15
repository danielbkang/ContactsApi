using ContactsApi.Models;
using ContactsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ContactsApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return _contactService.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<Contact> GetContact(long id)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public ActionResult<Contact> Create(Contact contact)
        {
            _contactService.Create(contact);

            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }

    }
}