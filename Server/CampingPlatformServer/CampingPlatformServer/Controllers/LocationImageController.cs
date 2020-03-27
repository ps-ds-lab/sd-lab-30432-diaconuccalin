using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/LocationImage")]
    [ApiController]
    public class LocationImageController : ControllerBase
    {
        private readonly IDataRepository<LocationImage> _dataRepository;

        public LocationImageController(IDataRepository<LocationImage> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/LocationImage
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LocationImage> locationImages = _dataRepository.GetAll();
            return Ok(locationImages);
        }

        // GET: api/LocationImage/5
        [HttpGet("{id}", Name = "GetLocationImage")]
        public IActionResult Get(Guid id)
        {
            LocationImage locationImage = _dataRepository.Get(id);

            if (locationImage == null)
            {
                return NotFound("The location image record couldn't be found.");
            }

            return Ok(locationImage);
        }

        // POST: api/LocationImage
        [HttpPost]
        public IActionResult Post([FromBody] LocationImage locationImage)
        {
            if (locationImage == null)
            {
                return BadRequest("Location image is null.");
            }

            _dataRepository.Add(locationImage);
            return CreatedAtRoute(
                "",
                new { Id = locationImage.Id },
                locationImage);
        }

        // PUT: api/LocationImage/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LocationImage locationImage)
        {
            if (locationImage == null)
            {
                return BadRequest("Location image is null.");
            }

            LocationImage locationImageToUpdate = _dataRepository.Get(id);
            if (locationImageToUpdate == null)
            {
                return NotFound("The location image record couldn't be found.");
            }

            _dataRepository.Update(locationImageToUpdate, locationImage);
            return NoContent();
        }

        // DELETE: api/LocationImage/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            LocationImage locationImage = _dataRepository.Get(id);

            if (locationImage == null)
            {
                return NotFound("The location image record couldn't be found.");
            }

            _dataRepository.Delete(locationImage);
            return NoContent();
        }
    }
}
