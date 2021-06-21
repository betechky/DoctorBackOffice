using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoctorOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
       
        private readonly ILogger<DoctorsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
           return _context.Doctors.ToList();
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            var doctor = _context.Doctors.Find(id);
            return doctor;
        }
        // Post api/<DoctorsController>
        [HttpPost]
        public void Post([FromBody] Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Doctor doctorObj)
        {
            var doctor = _context.Doctors.Find(id);
            doctor.Name = doctorObj.Name;
            
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
