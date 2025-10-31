using System.Threading.Tasks;
using CollageWebAPI.Models; // ✅ adjust namespace based on your folder

using CollageWebAPI.Models.mail;

namespace CollageWebAPI.Data.Repository
{
    public interface IemailService
    {
        Task SendEmail(MailRequest mailrequest);
    }
}
