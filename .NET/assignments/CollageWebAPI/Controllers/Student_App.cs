using CollageWebAPI.Data.Repository;
using CollageWebAPI.Models;
using CollageWebAPI.Models.mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollageWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Student_App : Controller
    {
        public readonly ICollageRepository<Student> _IstudentRepository;

        public Student_App(ICollageRepository<Student> _studentrepository)
        {
            _IstudentRepository = _studentrepository;
        }

        [Authorize(Roles = "Admin,Student")]
        [HttpGet("getallstudents")]
        public async Task<ActionResult<IEnumerable<Student>>> getstudents()
        {
            var student = await _IstudentRepository.GetAll();
            return Ok(student);

        }
        [Authorize(Roles = "Admin,Student")]
        [HttpGet("{id:int}", Name = "getstudentbyid")]
        public async Task<ActionResult<Student>> getstudentbyid(int id)
        {
            if (id <= 0) return BadRequest();
            var student = await _IstudentRepository.getbyidAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [Authorize(Roles = "Admin,Student")]
        [HttpGet("{Name:alpha}", Name = "getstudentsbyname")] //alpha for routing
        public async Task<ActionResult<Student>> getstudentbyname(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var student = await _IstudentRepository.getbynameAsync("Name", name);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Createnewstudent")]

        public async Task<ActionResult<Student>> createStudentAsync([FromBody] StudentDTO Model)
        {
            
            var a = new Student
            {
                Name = Model.Name,
                RollNumber = Model.RollNumber,
                Email = Model.Email,
                Phone = Model.Phone,
                Address = Model.Address,
                DateOfBirth = Model.DateOfBirth,
                Gender = Model.Gender,
                CourseId = Model.CourseId,           
            };
            if (a== null) return BadRequest();
            var b = await _IstudentRepository.createAsync(a);
            return Ok(b);
        }

        [Authorize(Roles = "Admin,Student")]
        [HttpPut("Update")]

        public async Task<ActionResult<Student>> UpdateStudent([FromBody] StudentDTO Model)
        {
            if (Model == null || Model.StudentId <= 0) return BadRequest();
            var existing = await _IstudentRepository.getbyidAsync(Model.StudentId);
            if (existing == null) return NotFound($"Student with ID {Model.StudentId} not found.");
            existing.Name = Model.Name;
            existing.Email = Model.Email;
            existing.Address = Model.Address;
            existing.DateOfBirth = Model.DateOfBirth;
            existing.Gender = Model.Gender;
            existing.Phone = Model.Phone;
            existing.CourseId = Model.CourseId;
            await _IstudentRepository.UpdateAsync(existing);
            return Ok(existing);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteStudent/{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existing = await _IstudentRepository.getbyidAsync(id);
            if (existing == null)
                return NotFound($"Student with ID {id} not found.");

            bool result = await _IstudentRepository.DeletestudentAsync(existing);
            if (!result)
                return BadRequest("Failed to delete student.");

            return Ok($"Student with ID {id} deleted successfully.");
        }

        [HttpPost("SendOtp")]
        [AllowAnonymous]  // optional — remove if you want it to require authorization
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.name))
            {
                return BadRequest("Invalid input. Please provide name and email.");
            }

            // 1️⃣ Generate random 6-digit OTP
            string otp = _IstudentRepository.Generaterandomnumber(); // if private, make it public or call through another method

            // 2️⃣ Send OTP email
            await _IstudentRepository.SendOtpMail(request.Email, otp, request.name);

            // 3️⃣ Return success message (you can remove OTP in production)
            return Ok(new
            {
                Message = "OTP sent successfully to your email.",
                Otp = otp  // ⚠️ only for testing — don’t return OTP in real apps!
            });
        }
    }
}
