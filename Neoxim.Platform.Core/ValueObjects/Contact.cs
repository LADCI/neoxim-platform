using Neoxim.Platform.SharedKernel;

namespace Neoxim.Platform.Core.ValueObjects
{
    public class Contact : BaseValueObject
    {
        public Contact(string email, string phone, string address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public string Address { get; protected set; }
    }
}