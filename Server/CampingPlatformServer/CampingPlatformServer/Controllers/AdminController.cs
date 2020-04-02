using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDataRepository<Admin> _dataRepository;

        public AdminController(IDataRepository<Admin> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Admin
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Admin> admins = _dataRepository.GetAll();
            return Ok(admins);
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "GetAdmin")]
        public IActionResult Get(Guid id)
        {
            Admin admin = _dataRepository.Get(id);

            if (admin == null)
            {
                return NotFound("The admin record couldn't be found.");
            }

            return Ok(admin);
        }

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin is null.");
            }

            _dataRepository.Add(admin);
            return CreatedAtRoute(
                "",
                new { Id = admin.Id },
                admin);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin is null.");
            }

            Admin adminToUpdate = _dataRepository.Get(id);
            if (adminToUpdate == null)
            {
                return NotFound("The admin record couldn't be found.");
            }

            _dataRepository.Update(adminToUpdate, admin);
            return NoContent();
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Admin admin = _dataRepository.Get(id);

            if (admin == null)
            {
                return NotFound("The admin record couldn't be found.");
            }

            _dataRepository.Delete(admin);
            return NoContent();
        }
    }
}
