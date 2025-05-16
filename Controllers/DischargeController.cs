using E_Vita_APIs.Models;
using E_Vita_APIs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Vita_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DischargeController : ControllerBase
    {
        private readonly IRepositories<Discharge> _dischargeRepo;

        public DischargeController(IRepositories<Discharge> dischargeRepo)
        {
            _dischargeRepo = dischargeRepo;
        }

        // GET: api/discharge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discharge>>> GetAll()
        {
            var discharges = await _dischargeRepo.GetAllAsync();
            return Ok(discharges);
        }

        // GET: api/discharge/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discharge>> GetById(int id)
        {
            var discharge = await _dischargeRepo.GetByIdAsync(id);
            if (discharge == null)
                return NotFound();

            return Ok(discharge);
        }

        // POST: api/discharge
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Discharge discharge)
        {
            await _dischargeRepo.AddAsync(discharge);
            return Ok(discharge);
        }

        
        

        
    }
}
    

