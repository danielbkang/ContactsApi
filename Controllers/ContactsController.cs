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

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(long id, Contact contact)
        {
            var localContact = _contactService.Get(contact.Id);

            if (localContact == null)
            {
                return NotFound();
            }

            _contactService.Update(contact);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(long id)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Delete(id);

            return NoContent();
        }
    }
}