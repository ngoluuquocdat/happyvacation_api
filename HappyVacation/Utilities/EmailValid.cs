using System.Net.Mail;

namespace HappyVacation.Utilities
{
    public static class EmailValid
    {
        public static bool IsValid(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
