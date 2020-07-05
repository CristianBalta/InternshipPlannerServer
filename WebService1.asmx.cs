using InternshipPlannerServer.Models;
using InternshipPlannerServer.Services;
using System;
using System.Web.Services;
using System.Net.Mail;
using javax.jws;

namespace InternshipPlannerServer
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DatabaseSettings settings = new DatabaseSettings();

        [System.Web.Services.WebMethod]
        public String SendEmail(String senderAddress, String senderPassword, String subject, String body, String pathToFile, String destination)
        {
            try
            {
                


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(senderAddress);
                mail.To.Add(destination);
                mail.Subject = subject;
                mail.Body = body;

                if(pathToFile != "")
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(pathToFile);
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(senderAddress, senderPassword);
                SmtpServer.EnableSsl = true;

                
                    SmtpServer.Send(mail);

                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "Sent!";

        }

        [System.Web.Services.WebMethod]

        public User Login(String email, string password)
        {
            UserService _userService = new UserService(settings);

            User status = _userService.Login(email, password);

            if (status == null)

                return null;

            else

                return status;
        }

        [System.Web.Services.WebMethod]

        public User Register(string name, string city, string telephone, String email, string password)
        {

            User user = new User();

            user.Email = email;
            user.City = city;
            user.Telephone = telephone;
            user.Name = name;
            user.Password = password;

            UserService _userService = new UserService(settings);

            User status = _userService.Create(user);

                return status;
        }

        [System.Web.Services.WebMethod]

        public User GetCurrentUser(string id)
        {

            User user = new User();

            UserService _userService = new UserService(settings);

            User status = _userService.GetUser(id);

            return status;
        }


        [System.Web.Services.WebMethod]

        public User UpdateCurrentUser(string id, User userIn)
        {

            User user = userIn;

            UserService _userService = new UserService(settings);

            _userService.UpdateUser(id, userIn);

            return userIn;
        }


        [System.Web.Services.WebMethod]

        public Internship GetUserInternships(string internshipId)
        {
            InternshipService _internshipService = new InternshipService(settings);

            return _internshipService.GetInternship(internshipId);
        }


        [System.Web.Services.WebMethod]

        public Status GetInternshipStatus(string statusID)
        {
            StatusService _statusService = new StatusService(settings);

            return _statusService.GetStatus(statusID);
        }



        [System.Web.Services.WebMethod]

        public string DeleteCurrentInternship(string internshipId)
        {
            InternshipService _internshipService = new InternshipService(settings);

            _internshipService.DeleteInternship(internshipId);
            return "Deleted!";

        }


        [System.Web.Services.WebMethod]

        public string DeleteCurrentStatus(string statusID)
        {
            StatusService _statusService = new StatusService(settings);

            _statusService.DeleteStatus(statusID);
            return "Deleted!";
        }


        [System.Web.Services.WebMethod]

        public void CreateAnIntership(string company, string position, string paid, string city, string email, string description)
        {
            InternshipService _internshipService = new InternshipService(settings);

            Internship internship = new Internship();

            internship.City = city;
            internship.Company = company;
            internship.Position = position;
            internship.Paid = paid;
            internship.Email = email;
            internship.Description = description;


            _internshipService.CreateInternship(internship);
        }

        [System.Web.Services.WebMethod]
        public void CreateAStatus(string events, string descripton, string progress)
        {
            StatusService _statusService = new StatusService(settings);

            Status status = new Status();

            status.Description = descripton;
            status.Event = events;
            status.Progress = progress;

            _statusService.CreateStatus(status);


        }

        [System.Web.Services.WebMethod]

        public void UpdateCurrentStatus(string id, Status statusIn)
        {

            Status status = statusIn;

            StatusService _statusService = new StatusService(settings);

            _statusService.UpdateStatus(id, statusIn);

        }

        [System.Web.Services.WebMethod]

        public void UpdateCurrentInternship(string id, Internship internshipIn)
        {

            Internship internship = internshipIn;

            InternshipService _internshipService = new InternshipService(settings);

            _internshipService.UpdateInternship(id, internshipIn);

        }




    }

}


