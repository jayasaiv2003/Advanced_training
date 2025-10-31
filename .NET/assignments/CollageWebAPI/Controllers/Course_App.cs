using CollageWebAPI.Data.Repository;
using CollageWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollageWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Course_App : Controller
    {
        private readonly ICollageRepository<Course> _courseRepository;

        public Course_App(ICollageRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        
        [HttpGet("getallcourses")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            //var courses = await _courseRepository.GetAll();
            var courses = await _courseRepository.GetAllCourses();
            return Ok(courses);
        }

        
        [HttpGet("{id:int}", Name = "GetCourseById")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Course ID");

            var course = await _courseRepository.getbyidAsync(id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(course);
        }

       
        [HttpGet("{name:alpha}", Name = "GetCourseByName")]
        public async Task<ActionResult<Course>> GetCourseByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Course name is required.");

            var course = await _courseRepository.getbynameAsync("CourseName", name);
            if (course == null)
                return NotFound($"Course with name '{name}' not found.");

            return Ok(course);
        }

        
        [HttpPost("Createnewcourse")]
        [Authorize(Roles = "Admin")]


        public async Task<ActionResult<Course>> CreateCourseAsync([FromBody] CourseDTO model)
        {
            if (model == null)
                return BadRequest("Invalid course data.");

            var newCourse = new Course
            {
                CourseId = model.CourseId,
                CourseCode = model.CourseCode,
                CourseName = model.CourseName,
                Department = model.Department,
                Semester = model.Semester,

            };

            var createdCourse = await _courseRepository.createAsync(newCourse);
            return Ok(createdCourse);
        }

        // ✅ UPDATE existing course
        [HttpPut("UpdateCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Course>> UpdateCourseAsync([FromBody] CourseDTO model)
        {
            if (model == null || model.CourseId <= 0)
                return BadRequest("Invalid course data.");

            var existingCourse = await _courseRepository.getbyidAsync(model.CourseId);
            if (existingCourse == null)
                return NotFound($"Course with ID {model.CourseId} not found.");

            existingCourse.CourseId = model.CourseId;
            existingCourse.CourseCode = model.CourseCode;   
            existingCourse.CourseName = model.CourseName;
            existingCourse.Department = model.Department;
            existingCourse.Semester = model.Semester;

            await _courseRepository.UpdateAsync(existingCourse);
            return Ok(existingCourse);
        }

        
        [HttpDelete("DeleteCourse/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCourseAsync(int id)
        {
            var existingCourse = await _courseRepository.getbyidAsync(id);
            if (existingCourse == null)
                return NotFound($"Course with ID {id} not found.");

            bool deleted = await _courseRepository.DeletecourseAsync(id);
            if (!deleted)
                return BadRequest("Failed to delete course.");

            return Ok($"Course with ID {id} deleted successfully.");
        }
    }
}
