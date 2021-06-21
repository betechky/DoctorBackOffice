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
    public class IntakeFormsController : ControllerBase
    {
       
        private readonly ILogger<IntakeFormsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public IntakeFormsController(ILogger<IntakeFormsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IntakeForm> Get()
        {
           return _context.IntakeForms.ToList();
        }

      
        [HttpGet("{id}")]
        public IntakeForm Get(int id)
        {
            var intakeForm = _context.IntakeForms.Find(id);
            return intakeForm;
        }
        // Post api/<DoctorsController>
        [HttpPost]
        public void Post([FromBody] IntakeForm value)
        {
            int id = 1;  
            if (_context.IntakeForms.ToList().Count != 0)
                id = _context.IntakeForms.Max(p => p.Id) +1; 
            
            IntakeForm newIntakeForm = new IntakeForm
            {
                Id = id,
                Ailment = value.Ailment,
                DoctorId = value.DoctorId,
                PatientId = value.PatientId
            };

            _context.IntakeForms.Add(newIntakeForm);
            _context.SaveChanges();
        }

 
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] IntakeForm intakeObj)
        // {
        //     var intakeform = _context.Doctors.Find(id);
        //     intakeform.Name = intakeObj.Name;
            
        // }

      
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //     var intakeform = _context.IntakeForms.Find(id);
        //     _context.Intakeforms.Remove(intakeform);
        //     _context.SaveChanges();
        // }
    }
}
