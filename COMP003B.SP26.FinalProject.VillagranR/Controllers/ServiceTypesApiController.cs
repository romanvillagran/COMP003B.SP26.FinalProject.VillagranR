using COMP003B.SP26.FinalProject.VillagranR.Data;
using COMP003B.SP26.FinalProject.VillagranR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace COMP003B.SP26.FinalProject.VillagranR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypesApiController : ControllerBase
    {
        private readonly ApplicationDbContext? _context;

        public ServiceTypesApiController(ApplicationDbContext? context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ServiceType>> GetServiceTypes()
        {
            return Ok(_context.serviceTypes.ToList);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ServiceType> GetServiceType(int id)
        {
            var serviceType = _context.serviceTypes.FirstOrDefault(s => s.ServiceTypeId == id);

            if (serviceType is null)
                return NotFound();

            return Ok(serviceType);
        }

        [HttpPost]
        public ActionResult<ServiceType> CreateServiceType(ServiceType serviceType)
        {
            _context.serviceTypes.Add(serviceType);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetServiceTypes), new {id = serviceType.ServiceTypeId }, serviceType);    

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateServiceType(int id, ServiceType updateserviceType)
        {
            var existing = _context.serviceTypes.FirstOrDefault(s => s.ServiceTypeId == id);

            if (existing is null)
                return NotFound();

            existing.ServiceName = updateserviceType.ServiceName;
            existing.Description =  updateserviceType.Description;
            existing.Price = updateserviceType.Price;
            existing.EstimatedHours = updateserviceType.EstimatedHours;
            existing.IsActive = existing.IsActive;

            _context.SaveChanges();

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteServiceType(int id)
        {
            var serviceType = _context.serviceTypes.FirstOrDefault(s => s.ServiceTypeId == id);


            if (serviceType is null) 
                return NotFound();

            _context.serviceTypes.Remove(serviceType);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
