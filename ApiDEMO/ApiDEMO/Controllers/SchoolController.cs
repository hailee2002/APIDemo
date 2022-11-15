using ApiDEMO.Data;
using ApiDEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly MyDbContext _context;        
        public SchoolController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var SList = _context.School.ToList();
            return Ok(SList);
        }
        [HttpGet("{MSSV}")]
        public IActionResult GetByM(Int32 MSSV)
        {
            var ms = _context.School.SingleOrDefault(s => s.MSSV == MSSV);
            if (ms != null)
            {
                return Ok(ms);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(SchoolModel model)
        {
            try
            {
                var ms = new School
                {
                    SchoolName = model.SchoolName,
                    Major = model.Major
                };
                _context.Add(ms);
                _context.SaveChanges();
                return Ok(ms);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{MSSV}")]
        public IActionResult UpdateByMS(Int32 MSSV, SchoolModel model)
        {
            var ms = _context.School.SingleOrDefault(s => s.MSSV == MSSV);
            if (ms != null)
            {
                ms.SchoolName = model.SchoolName;
                ms.Major = model.Major;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
              
        }
        [HttpDelete("{MSSV}")]
        public IActionResult Delete(Int32 MSSV)
        {
            try
            {
                var sv = _context.School.SingleOrDefault(s => s.MSSV == MSSV);
                if (sv!= null)
                {
                    _context.Remove(sv);
                    _context.SaveChanges();
                    return Ok();
                }else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
