
using CollageWebAPI.Models;
using CollageWebAPI.Models.mail;
using Microsoft.EntityFrameworkCore;

namespace CollageWebAPI.Data.Repository
{
    public class CollageRepository<T> : ICollageRepository<T> where T : class


    {
        private readonly CollageDbContext _dbcontext;
        private  DbSet<T> _dbSet;
        private readonly IemailService _emailService;

        // Pseudocode plan:
        // 1. Verify the constructor declares an IemailService parameter named 'emailService'.
        // 2. Inside the constructor assign that parameter to the private field '_emailService'.
        // 3. Ensure parameter name spelling and case exactly match the identifier used in assignment.
        // 4. Return the corrected constructor implementation.

        // Replace the constructor in the file with this corrected version.
        public CollageRepository(CollageDbContext dbcontext, IemailService emailService)
        {
            _dbcontext = dbcontext;
            _dbSet = dbcontext.Set<T>();
            _emailService = emailService;
        }

        public async Task<T> createAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbcontext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<bool> DeletestudentAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getbyidAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> getbynameAsync(string propertyName, string value)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, propertyName) == value);
        }

        public async Task<T> UpdateAsync(T dbRecord)
        {
            _dbSet.Update(dbRecord);
            await _dbcontext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<bool> DeletecourseAsync(int id)
        {
            var course = await _dbcontext.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return false;

            // Remove related students first
            if (course.Students != null && course.Students.Any())
            {
                _dbcontext.Students.RemoveRange(course.Students);
            }

            _dbcontext.Courses.Remove(course);
            await _dbcontext.SaveChangesAsync();

            return true;
        }


        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbcontext.Courses.Include(b => b.Students).ToListAsync();
        }

        public string Generaterandomnumber()
        {
            Random random = new Random();
            string randomnum = random.Next(0, 1000000).ToString("D6");
            return randomnum;
        }


        public async Task SendOtpMail(string Email, string otptext, string name)
        {
            var mailrequest = new MailRequest();

            mailrequest.email = Email;
            mailrequest.subject = "thanks for resistering:OTP";
            mailrequest.body = Generatebody(name, otptext);
            this._emailService.SendEmail(mailrequest);


        }

        private string Generatebody(string name, string OTPtext)
        {
            string emailbody = string.Empty;
            emailbody = "<div style='width= 100%; background-color:grey'>";
            emailbody += "<h1>Hi" + name + " , thanks for registering </h1>";
            emailbody += "<h2>Please enter the otp text and conplete the resitraition </h2>";
            emailbody += "<h2>OTP text is  " + OTPtext + "</h2>";
            emailbody = "</div>";

            return emailbody;

        }


    }
}
