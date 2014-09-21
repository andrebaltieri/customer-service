using CustomerService.Resources.User;
using CustomerService.Utils.Security;
using CustomerService.Utils.Settings;
using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CustomerService.Domain
{
    public class User
    {
        public User(string username, string password)
        {
            Contract.Requires<InvalidCastException>(Regex.IsMatch(username, RegexSettingsHelper.REGEX_USERNAME), UserMessages.UsernameIsInvalid);
            Contract.Requires<InvalidCastException>(Regex.IsMatch(password, RegexSettingsHelper.REGEX_PASSWORD), UserMessages.PasswordIsInvalid);

            this.Username = username;
            this.Password = password;
        }

        protected User() { }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
