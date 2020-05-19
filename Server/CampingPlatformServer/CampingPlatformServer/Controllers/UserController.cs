using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CampingPlatformServer.Model.Users;
using CampingPlatformServer.Services;
using CampingPlatformServer.Helpers;
using CampingPlatformServer.Model;
using Microsoft.AspNetCore.Identity;
using CampingPlatformServer.Model.Repository;
using System.Diagnostics;

namespace CampingPlatformServer.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IDataRepository<Host> _hostRepo;
        private IDataRepository<Location> _locationRepo;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserService userService,
            IDataRepository<Location> locationRepo,
            IDataRepository<Host> hostRepo,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _locationRepo = locationRepo;
            _hostRepo = hostRepo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Role = user.Role,
                CorrespondingID = user.CorrespondingID,
                Token = tokenString
            });
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost("registerAdmin")]
        public IActionResult RegisterAdmin([FromBody]RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Role = Role.Admin;

            try
            {
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("registerHost")]
        public IActionResult RegisterHost([FromBody]RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Role = Role.Host;

            try
            {
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("registerGuest")]
        public IActionResult RegisterGuest([FromBody]RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Role = Role.Guest;

            try
            {
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);

            return Ok(model);
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<UserModel>(user);

            return Ok(model);
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UpdateModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userService.GetById(id);

            if (user.Role == "Host")
            {
                var host = _hostRepo.Get(user.CorrespondingID);

                var locations = _locationRepo.GetAll();
                foreach (Location location in locations)
                {
                    if (location.HostId == id)
                    {
                        var toDel = _locationRepo.Get(location.Id);
                        _locationRepo.Delete(toDel);
                    }
                }

                if(host != null)
                    _hostRepo.Delete(host);
            }

            _userService.Delete(id);
            return Ok();
        }
    }
}
