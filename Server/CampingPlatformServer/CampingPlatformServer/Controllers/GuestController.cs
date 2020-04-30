using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IDataRepository<Guest> _dataRepository;

        public GuestController(IDataRepository<Guest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Guest
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Guest> guests = _dataRepository.GetAll();
            return Ok(guests);
        }

        // GET: api/Guest/5
        [HttpGet("{id}", Name = "GetGuest")]
        public IActionResult Get(Guid id)
        {
            Guest guest = _dataRepository.Get(id);

            if(guest == null)
            {
                return NotFound("The Guest record couldn't be found.");
            }

            return Ok(guest);
        }

        // POST: api/Guest
        [HttpPost]
        public IActionResult Post([FromBody] Guest guest)
        {
            if(guest == null)
            {
                return BadRequest("Guest is null.");
            }

            _dataRepository.Add(guest);
            return CreatedAtRoute(
                "",
                new { Id = guest.Id },
                guest);
        }

        // PUT: api/Guest/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Guest guest)
        {
            if(guest == null)
            {
                return BadRequest("Guest is null.");
            }

            Guest guestToUpdate = _dataRepository.Get(id);
            if(guestToUpdate == null)
            {
                return NotFound("The guest record couldn't be found.");
            }

            _dataRepository.Update(guestToUpdate, guest);
            return NoContent();
        }

        // DELETE: api/Guest/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Guest guest = _dataRepository.Get(id);

            if(guest == null)
            {
                return NotFound("The guest record couldn't be found.");
            }

            _dataRepository.Delete(guest);
            return NoContent();
        }
    }
}
