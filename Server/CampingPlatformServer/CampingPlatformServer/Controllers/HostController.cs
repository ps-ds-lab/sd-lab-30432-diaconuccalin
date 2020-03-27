using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampingPlatformServer.Controllers
{
    [Route("api/Host")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly IDataRepository<Host> _dataRepository;

        public HostController(IDataRepository<Host> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Host
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Host> hosts = _dataRepository.GetAll();
            return Ok(hosts);
        }

        // GET: api/Host/5
        [HttpGet("{id}", Name = "GetHost")]
        public IActionResult Get(Guid id)
        {
            Host host = _dataRepository.Get(id);

            if (host == null)
            {
                return NotFound("The host record couldn't be found.");
            }

            return Ok(host);
        }

        // POST: api/Host
        [HttpPost]
        public IActionResult Post([FromBody] Host host)
        {
            if (host == null)
            {
                return BadRequest("Host is null.");
            }

            _dataRepository.Add(host);
            return CreatedAtRoute(
                "",
                new { Id = host.Id },
                host);
        }

        // PUT: api/Host/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Host host)
        {
            if (host == null)
            {
                return BadRequest("Host is null.");
            }

            Host hostToUpdate = _dataRepository.Get(id);
            if (hostToUpdate == null)
            {
                return NotFound("The host record couldn't be found.");
            }

            _dataRepository.Update(hostToUpdate, host);
            return NoContent();
        }

        // DELETE: api/Host/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Host host = _dataRepository.Get(id);

            if (host == null)
            {
                return NotFound("The host record couldn't be found.");
            }

            _dataRepository.Delete(host);
            return NoContent();
        }
    }
}
