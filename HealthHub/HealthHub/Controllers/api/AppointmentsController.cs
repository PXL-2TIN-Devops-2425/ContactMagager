using HealthHub.AppLogic;
using HealthHub.Domain;
using HealthHub.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HealthHub.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_appointmentsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(_appointmentsRepository.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok(_appointmentsRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(appointment);
            }
            _appointmentsRepository.Add(appointment);
            return CreatedAtAction(nameof(Create) , new {id = appointment.Id} , appointment);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Appointment updatedAppointment)
        {
            Appointment a = _appointmentsRepository.GetById(id);
            a.AppointmentDate = updatedAppointment.AppointmentDate;
            a.PatientNationalNumber = updatedAppointment.PatientNationalNumber;
            a.Reason = updatedAppointment.Reason;
            a.Doctor = updatedAppointment.Doctor;
            _appointmentsRepository.Update(a);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Appointment? a = _appointmentsRepository.GetById(id);
            if (a == null)
            {
                return NotFound();
            }
           
            _appointmentsRepository.Delete(a);
            return NoContent();
        }
        [HttpGet("doctor/{doctorId}")]
        public IActionResult GetAppointmentsForDoctor(int doctorId)
        {
            _appointmentsRepository.GetAppointmentsForDoctor(doctorId);
            return Ok();
        }
        [HttpGet("patient/{patientNationalNumber}")]
        public IActionResult GetAppointmentsForPatient(string patientNationalNumber)
        {
            throw new NotImplementedException();
        }
        [HttpGet("upcoming")]
        public IActionResult GetUpcomingAppointments([FromQuery] int daysAhead)
        {
            throw new NotImplementedException();
        }
    }
}
