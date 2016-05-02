using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using TMD.Web.Helper;

namespace tourPakistan
{
    public class Utility
    {
        public const string MemberRoleId = "3";
        public const string MemberRoleName = "Member";

        public const string AdminRoleId = "1";
        public const string AdminRoleName = "Admin";
        
        public const string ConfigEmail = "ConfigEmail";
        public const string ProductConfiguration = "ProductConfiguration";
        public const string MaxDiscount = "MaxDiscount";
        public static void SendEmailAsync(string email, string subject, string body)
        {

            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string fromPwd = ConfigurationManager.AppSettings["FromPassword"];
            string fromDisplayName = ConfigurationManager.AppSettings["FromDisplayNameA"];
            //string cc = ConfigurationManager.AppSettings["CC"];
            //string bcc = ConfigurationManager.AppSettings["BCC"];

            //Getting the file from config, to send
            MailMessage oEmail = new MailMessage
            {
                From = new MailAddress(fromAddress, fromDisplayName),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High
            };
            oEmail.To.Add(email);
            string smtpServer = ConfigurationManager.AppSettings["SMTPServer"];
            string smtpPort = ConfigurationManager.AppSettings["SMTPPort"];
            string enableSsl = ConfigurationManager.AppSettings["EnableSSL"];
            SmtpClient client = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort))
            {
                EnableSsl = enableSsl == "1",
                Credentials = new NetworkCredential(fromAddress, fromPwd)
            };

            //client.Send(oEmail);

        }
        public bool SendSms(string smsText, string mobileNo)
        {
            
            string username = ConfigurationManager.AppSettings["MobileUsername"];
            string password = ConfigurationManager.AppSettings["MobilePassword"];
            string senderId = ConfigurationManager.AppSettings["SenderID"];

            WebRequest smsRequest =
                WebRequest.Create("http://www.jawalbsms.ws/api.php/sendsms?user=" + username + "&pass=" +
                                  password +
                                  "&to=" + mobileNo + "&message=" + smsText +
                                  "&sender=" + senderId);
            WebResponse smsRequestResponse = smsRequest.GetResponse();
            Stream smsDataStream = smsRequestResponse.GetResponseStream();
            StreamReader smsReader = new StreamReader(smsDataStream);
            string smsResponse = smsReader.ReadToEnd();

            if (smsResponse.ToLower().Contains("success"))
            {
                return true;
            }
            return false;
        }

        public static Stream ResizeImage(Image image, ImageFormat format, int width, int height, bool preserveAspectRatio = true)
        {
            ImageHelper.ImageRotation(image);
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)width / (float)originalWidth;
                float percentHeight = (float)height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = width;
                newHeight = height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            //return newImage;
            var stream = new MemoryStream();
            newImage.Save(stream, format);
            stream.Position = 0;
            return stream;


        }

        public static ImageFormat GetImageFormat(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return ImageFormat.Png;
            }
            contentType = contentType.Split('/')[1].ToLower();
            switch (contentType)
            {
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "jpg":
                    return ImageFormat.Jpeg;
                default:
                    return ImageFormat.Png;
            }
        }
    }
}