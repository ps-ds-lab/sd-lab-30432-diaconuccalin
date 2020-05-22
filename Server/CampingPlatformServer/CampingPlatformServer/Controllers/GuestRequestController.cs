using CampingPlatformServer.Helpers;
using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/guestRequests")]
    [ApiController]
    public class GuestRequestController : ControllerBase
    {
        private readonly IDataRepository<GuestRequest> _dataRepository;

        public GuestRequestController(IDataRepository<GuestRequest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/GuestRequest
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<GuestRequest> guestRequests = _dataRepository.GetAll();
            return Ok(guestRequests);
        }

        // GET: api/GuestRequest/5
        [Authorize]
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
        [Authorize(Roles = Role.Guest)]
        [HttpPost]
        public IActionResult Post([FromBody] GuestRequest guestRequest)
        {
            if (guestRequest == null)
            {
                return BadRequest("Guest request is null.");
            }

            guestRequest.Accepted = false;

            _dataRepository.Add(guestRequest);
            return CreatedAtRoute(
                "",
                new { Id = guestRequest.Id },
                guestRequest);
        }

        // PUT: api/GuestRequest/5
        [Authorize(Roles = Role.Guest)]
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
        //[Authorize(Roles = Role.Guest + "," + Role.Admin)]
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

        [Authorize]
        [HttpPut("markAccepted/{id}")]
        public IActionResult MarkAccepted(Guid id)
        {
            GuestRequest guestRequest = _dataRepository.Get(id);

            if (guestRequest == null)
            {
                return NotFound("The Guest request record couldn't be found.");
            }

            GuestRequest guestRequestToUpdate = new GuestRequest(); 
            guestRequestToUpdate.Copy(guestRequest);

            guestRequestToUpdate.Accepted = true;
            guestRequest.Accepted = true;

            _dataRepository.Update(guestRequestToUpdate, guestRequest);
            return NoContent();
        }

        [HttpGet("getByLocation/{id}")]
        public IActionResult GetByLocation(Guid id)
        {
            IEnumerable<GuestRequest> allGuestRequests = _dataRepository.GetAll();
            List<GuestRequest> guestRequests = new List<GuestRequest>();

            foreach(GuestRequest guestRequest in allGuestRequests) {
                if (guestRequest.LocationId == id)
                    guestRequests.Add(guestRequest);
            }

            return Ok(guestRequests);
        }
    }
}
