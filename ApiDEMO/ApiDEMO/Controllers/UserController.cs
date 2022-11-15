using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDEMO.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new List<User>();
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(Users);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            try

            {
                {
                    var uSer = Users.SingleOrDefault(u => u.name == name);
                    if (uSer == null)
                    {
                        return NotFound();
                    }
                    return Ok(uSer);
                }
            }
            catch
            {
                return BadRequest();
            }



        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                var USER = new User
                {
                    name = user.name,
                    password = user.password,
                    email = user.email,
                    age = user.age,
                    phone = user.phone
                };
                Users.Add(USER);
                return Ok(new
                {
                    Success = true,
                    Data = USER
                });
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{name}")]
        public IActionResult Update(string name, User userupdate)
        {
            try
            {
                var uSer = Users.SingleOrDefault(u => u.name == name);
                if (uSer == null)
                {
                    return NotFound();
                }
                uSer.name = userupdate.name;
                uSer.password = userupdate.password;
                uSer.email = userupdate.email;
                uSer.age = userupdate.age;
                uSer.phone = userupdate.phone;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                var uSer = Users.SingleOrDefault(u => u.name == name);
                if (uSer == null)
                {
                    return NotFound();
                }
                Users.Remove(uSer);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}



