using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/GuestRequest")]
    [ApiController]
    public class GuestRequestController : ControllerBase
    {
        private readonly IDataRepository<GuestRequest> _dataRepository;

        public GuestRequestController(IDataRepository<GuestRequest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/GuestRequest
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<GuestRequest> guestRequests = _dataRepository.GetAll();
            return Ok(guestRequests);
        }

        // GET: api/GuestRequest/5
        [HttpGet("{id}", Name = "GetGuestRequest")]
        public IActionResult Get(Guid id)
        {
            GuestRequest guestRequest = _dataRepository.Get(id);

            if (guestRequest == null)
            {
                return NotFound("The Guest request record couldn't be found.");
            }

            return Ok(guestRequest);
        }

        // POST: api/GuestRequest
        [HttpPost]
        public IActionResult Post([FromBody] GuestRequest guestRequest)
        {
            if (guestRequest == null)
            {
                return BadRequest("Guest request is null.");
            }

            _dataRepository.Add(guestRequest);
            return CreatedAtRoute(
                "",
                new { Id = guestRequest.Id },
                guestRequest);
        }

        // PUT: api/GuestRequest/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] GuestRequest guestRequest)
        {
            if (guestRequest == null)
            {
                return BadRequest("Guest request is null.");
            }

            GuestRequest guestRequestToUpdate = _dataRepository.Get(id);
            if (guestRequestToUpdate == null)
            {
                return NotFound("The guest request record couldn't be found.");
            }

            _dataRepository.Update(guestRequestToUpdate, guestRequest);
            return NoContent();
        }

        // DELETE: api/GuestRequest/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            GuestRequest guestRequest = _dataRepository.Get(id);

            if (guestRequest == null)
            {
                return NotFound("The guest request record couldn't be found.");
            }

            _dataRepository.Delete(guestRequest);
            return NoContent();
        }
    }
}
