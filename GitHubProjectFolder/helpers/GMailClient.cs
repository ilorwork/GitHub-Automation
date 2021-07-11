using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ActiveUp.Net.Mail;
using GitHub.config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GitHub.helpers
{
    public class GMailClient : BasePage
    {
        //Make sure to use Sign in with App Passwords (instead of 2FA): https://support.google.com/accounts/answer/185833
        //Make sure 2FA is enabled so that app password will be enabled.

        private Imap4Client _client;
        private const string MailServer = "imap.gmail.com";
        private const int Port = 993;
        private const string Email = "githubcsharptest@gmail.com";
        private const string AppPassword = "";// need to add API Key.
        //private readonly Regex _linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public GMailClient()
            
        {
            Log("Step: GMailClient constructor is starting !");
            Client.ConnectSsl(MailServer, Port);
            Log("Step: Client.ConnectSsl(mailServer, port)");
            Client.Login(Email, AppPassword);
            Log("Step: Client.Login(email, appPassword)");
        }

        public IEnumerable<Message> SearchMessages(string recipient, string subject)
        {
            var mailbox = Client.SelectMailbox("inbox");
            Log($"Passed step: Client.SelectMailbox()");
            var messages = mailbox.SearchParse($"TO \"{recipient}\" SUBJECT \"{subject}\"");

            Log($"Passed step: mails.SearchParse() returned {messages.Count} results");
            return messages.Cast<Message>();
        }

        protected Imap4Client Client => _client ?? (_client = new Imap4Client());

        // public string GetEmailVerificationLink(string mailAddress)
        // {
        //     var result = WaitForMessage(mailAddress, "eToro email verification");
        //
        //     foreach (Match m in _linkParser.Matches(result.BodyHtml.Text))
        //     {
        //         if (!m.ToString().Contains("?evertoken="))
        //             continue;
        //
        //         var link = CleanLinkUrl(m);
        //         return ModifyEmailVerificationLinkToCurrentEnvironment(link);
        //     }
        //     throw new Exception($"Didn't find email verification for mail: {mailAddress}");
        // }
        //
        // public string GetResetPasswordLink(string mailAddress)
        // {
        //     // TODO: remove duplication between this method and GetEmailVerificationLink
        //     var message = WaitForMessage(mailAddress, "eToro account new password");
        //
        //     foreach (Match m in _linkParser.Matches(message.BodyHtml.Text))
        //     {
        //         if (!m.ToString().Contains("?RecoveryToken="))
        //             continue;
        //
        //         var link = CleanLinkUrl(m);
        //         return ModifyResetPasswordLinkToCurrentEnvironment(link);
        //     }
        //     throw new Exception($"Didn't find reset password email for mail: {mailAddress}");
        // }

        // private static string ModifyEmailVerificationLinkToCurrentEnvironment(string link)
        // {
        //     return link.Replace(link.Substring(0, link.IndexOf("/accounts/email/verify", StringComparison.Ordinal)), Base._config.Url.EtoroEndPoint);
        // }
        //
        // private static string ModifyResetPasswordLinkToCurrentEnvironment(string link)
        // {
        //     // TODO: remove duplication between this method and ModifyEmailVerificationLinkToCurrentEnvironment (consider using UriBuilder for that)
        //     return link.Replace(link.Substring(0, link.IndexOf("/accounts/forgot-password/", StringComparison.Ordinal)), Base._config.Url.EtoroEndPoint);
        // }

        private Message WaitForMessage(string mailAddress, string expectedSubject)
        {
            return WaitWhileNull(Driver,() =>
            {
                var message = SearchMessages(mailAddress, expectedSubject).FirstOrDefault();
                Log($"Step: SearchMessages(...) was passed !");

                return message;
            }, 60, $"Message with subject '{expectedSubject}' and recipient '{mailAddress}' was not received");
        }

        string CleanLinkUrl(Match match)
        {
            string link = match.ToString().Replace("amp;", "");
            //TODO: need a better fix for removing html elements from email's text
            if (link.Contains("<"))
                link = link.Substring(0, link.IndexOf('<'));
            return link;
        }

        private TResult WaitWhileNull<TResult>(IWebDriver webDriver, Func<TResult> condition, int timeout, string failureMessage)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Message = failureMessage;
            return wait.Until(drv => condition());
        }
        public bool GetFirstVerificationEmail(string subject)
        {
            var result = WaitForMessage(Email, $"{subject}");

            if (result.BodyHtml.Text.Contains(subject))
            {
                Log(result.BodyHtml.Text);
                return true;
            }
            throw new Exception($"Didn't find email with subject: {subject} for mail: {Email}");
        }
    }
}
