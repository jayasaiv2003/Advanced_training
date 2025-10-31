using CollageWebAPI.Models;

namespace CollageWebAPI.Data.Repository
{
    public interface ICollageRepository<T> where T: class
    {
        Task<List<T>> GetAll();

        Task<List<Course>> GetAllCourses();


        Task<T> getbyidAsync(int id);
        // Task<T> getbynameAsync(string Name);
        Task<T> getbynameAsync(string propertyName, string value);



        Task<T> createAsync(T dbRecord);

        Task<T> UpdateAsync(T dbRecord);

        Task<bool> DeletestudentAsync(T dbRecord);

        Task<bool> DeletecourseAsync(int id);

        string Generaterandomnumber();  // To generate 6-digit OTP
        Task SendOtpMail(string Email, string otptext, string name);  // To send OTP mail
    }
}
