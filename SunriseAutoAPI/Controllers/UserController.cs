using APIsConsummers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SunriseAutoAPI.Services;
using System;
using System.Collections.Generic;

namespace SunriseAutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<User>> Get()
        {
            return Ok(_userService.Get());
        }

        [HttpGet("GetByCPF/{unformattedCpf}")]
        public ActionResult<User> Get(string unformattedCpf)
        {
            var user = _userService.Get(Utils.FormatCPF(unformattedCpf));
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Post(UserDTO u)
        {
            if (!Utils.CPFIsValid(u.UnformattedCPF)) return BadRequest("Invalid CPF.");

            string formattedCpf = Utils.FormatCPF(u.UnformattedCPF);

            if (_userService.Get(formattedCpf) != null) return Unauthorized("User already exists.");

            var address = ViaCepAPIConsummer.GetAdress(u.Address.ZipCode).Result;
            if (address.ZipCode == null) return NotFound();

            User user = new()
            {
                CPF = formattedCpf,
                Name = u.Name.ToUpper(),
                DtBirth = u.DtBirth,
                Status = false,
                Address = new Address
                {
                    ZipCode = address.ZipCode,
                    Street = address.Street.ToUpper(),
                    Number = u.Address.Number,
                    Complement = u.Address.Complement.ToUpper(),
                    City = address.City.ToUpper(),
                    State = address.State.ToUpper()
                }
            };
            if((DateTime.Today - user.DtBirth.AddYears(18)).Days < 0)
                return BadRequest();

            return Ok(_userService.Create(user));
        }

        [HttpPut("Update")]
        public ActionResult<User> Put(UserUpdateDTO u)
        {
            if (!Utils.CPFIsValid(u.UnformattedCPF)) return BadRequest("Invalid CPF.");

            string formattedCpf = Utils.FormatCPF(u.UnformattedCPF);

            var user = _userService.Get(formattedCpf);
            if (user == null) return BadRequest("User doesn't exists.");

            var address = ViaCepAPIConsummer.GetAdress(u.NewAddress.ZipCode).Result;
            if (address.ZipCode == null) return NotFound();

            user.Name = u.NewName.ToUpper();
            user.Address = new Address
            {
                ZipCode = address.ZipCode,
                Street = address.Street.ToUpper(),
                Number = u.NewAddress.Number,
                Complement = u.NewAddress.Complement.ToUpper(),
                City = address.City.ToUpper(),
                State = address.State.ToUpper()
            };

            _userService.Replace(formattedCpf, user);
            return Ok(user);
        }
    }
}
