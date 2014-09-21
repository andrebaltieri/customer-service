using CustomerService.Resources.Customer;
using CustomerService.Utils.Settings;
using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CustomerService.Domain
{
    public class Customer
    {
        public Customer() {}
        public Customer(string firstName, string lastName, string email)
        {
            Contract.Requires<ArgumentNullException>(firstName.Length <= 3, CustomerMessages.FirstNameIsInvalid);
            Contract.Requires<ArgumentNullException>(lastName.Length <= 3, CustomerMessages.LastNameIsInvalid);
            Contract.Requires<InvalidCastException>(Regex.IsMatch(email, RegexSettingsHelper.REGEX_EMAIL), CustomerMessages.EmailIsInvalid);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
