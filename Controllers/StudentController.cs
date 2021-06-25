using ExampleStudentDatabase.Database;
using ExampleStudentDatabase.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleStudentDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDb _context;
        public StudentController(StudentDb context)
        {
            _context = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Students.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(StudentVm viewModel)
        {
            var data = new Student();
            data.Name = viewModel.Name;
            data.Surname = viewModel.Surname;
            _context.Students.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [HttpPut]
        public IActionResult Update(Student model)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return BadRequest("Bu Id-li telebe yoxdur");
            }
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
            {
                return BadRequest("Bu Id-li telebe yoxdur");
            }
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("deleted");
        }
        [Route("id")]
        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            var data = _context.Students.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (data == null)
            {
                return BadRequest("Bu ID-li telebe yoxdur");
            }
            return Ok(data);
        }
    }
}
