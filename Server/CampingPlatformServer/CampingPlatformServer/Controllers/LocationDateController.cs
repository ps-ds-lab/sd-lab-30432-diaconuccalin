using CampingPlatformServer.Helpers;
using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/locationDates")]
    [ApiController]
    public class LocationDateController : ControllerBase
    {
        private readonly IDataRepository<LocationDate> _dataRepository;

        public LocationDateController(IDataRepository<LocationDate> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/LocationDate
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LocationDate> locationDates = _dataRepository.GetAll();
            return Ok(locationDates);
        }

        // GET: api/LocationDate/5
        [Authorize]
        [HttpGet("{id}", Name = "GetLocationDate")]
        public IActionResult Get(Guid id)
        {
            LocationDate locationDate = _dataRepository.Get(id);

            if (locationDate == null)
            {
                return NotFound("The location date record couldn't be found.");
            }

            return Ok(locationDate);
        }

        // POST: api/LocationDate
        [Authorize(Roles = Role.Host)]
        [HttpPost]
        public IActionResult Post([FromBody] LocationDate locationDate)
        {
            if (locationDate == null)
            {
                return BadRequest("Location date is null.");
            }

            _dataRepository.Add(locationDate);
            return CreatedAtRoute(
                "",
                new { Id = locationDate.Id },
                locationDate);
        }

        // PUT: api/LocationDate/5
        [Authorize(Roles = Role.Host)]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LocationDate locationDate)
        {
            if (locationDate == null)
            {
                return BadRequest("Location date is null.");
            }

            LocationDate locationDateToUpdate = _dataRepository.Get(id);
            if (locationDateToUpdate == null)
            {
                return NotFound("The location date record couldn't be found.");
            }

            _dataRepository.Update(locationDateToUpdate, locationDate);
            return NoContent();
        }

        // DELETE: api/LocationDate/5
        [Authorize(Roles = Role.Host)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            LocationDate locationDate = _dataRepository.Get(id);

            if (locationDate == null)
            {
                return NotFound("The location date record couldn't be found.");
            }

            _dataRepository.Delete(locationDate);
            return NoContent();
        }
    }
}
