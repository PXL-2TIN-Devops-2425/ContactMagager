using HealthHub.AppLogic;
using HealthHub.Domain;
using HealthHub.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        public readonly IDoctorsRepository _doctorsRepository;
        public DoctorsController(IDoctorsRepository doctorRepository)
        {
            _doctorsRepository = doctorRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_doctorsRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var d = _doctorsRepository.GetById(id);
            if (d == null)
            {
                return NotFound();
            }
            return Ok(d);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _doctorsRepository.Add(doctor);
           return CreatedAtAction(nameof(Create), new { id = doctor.Id }, doctor);


        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Doctor updatedDoctor)
        {
            Doctor? a = _doctorsRepository.GetById(id);
            a.Email = updatedDoctor.Email;
            a.FirstName = updatedDoctor.FirstName;
            a.LastName = updatedDoctor.LastName;
            a.Phone = updatedDoctor.Phone;
            _doctorsRepository.Update(a);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Doctor? a = _doctorsRepository.GetById(id);
            if(a == null)
            {
                return NotFound();
            }
            _doctorsRepository.Delete(id);
            return NoContent();

        }
        [HttpGet("specialty/{specialtyId}")]
        public IActionResult GetDoctorsBySpecialty(int specialtyId)
        {
            IList<Doctor> l = _doctorsRepository.GetDoctorsBySpecialty(specialtyId);    
            return Ok(l);
        }
    }
}
