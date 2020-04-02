using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDataRepository<Location> _dataRepository;

        public LocationController(IDataRepository<Location> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Location
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Location> locations = _dataRepository.GetAll();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult Get(Guid id)
        {
            Location location = _dataRepository.Get(id);

            if (location == null)
            {
                return NotFound("The location record couldn't be found.");
            }

            return Ok(location);
        }

        // POST: api/Location
        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Location is null.");
            }

            _dataRepository.Add(location);
            return CreatedAtRoute(
                "",
                new { Id = location.Id },
                location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Location is null.");
            }

            Location locationToUpdate = _dataRepository.Get(id);
            if (locationToUpdate == null)
            {
                return NotFound("The location record couldn't be found.");
            }

            _dataRepository.Update(locationToUpdate, location);
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Location location = _dataRepository.Get(id);

            if (location == null)
            {
                return NotFound("The location record couldn't be found.");
            }

            _dataRepository.Delete(location);
            return NoContent();
        }
    }
}
