using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFamController : ControllerBase
    {
        private readonly IRepositories<Contact_fam> _contactFamRepo;

        public ContactFamController(IRepositories<Contact_fam> contactFamRepo)
        {
            _contactFamRepo = contactFamRepo;
        }

        // GET: api/contactfam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact_fam>>> GetAll()
        {
            var list = await _contactFamRepo.GetAllAsync();
            return Ok(list);
        }

        // GET: api/contactfam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact_fam>> GetById(int id)
        {
            var contact = await _contactFamRepo.GetByIdAsync(id);
            if (contact == null )
                return NotFound();

            return Ok(contact);
        }

        // POST: api/contactfam
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Contact_fam contactFam)
        {
            await _contactFamRepo.AddAsync(contactFam);
            return Ok(contactFam);
        }

       

       
    }
}
    

