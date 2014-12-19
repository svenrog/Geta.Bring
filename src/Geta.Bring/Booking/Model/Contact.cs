using System;

namespace Geta.Bring.Booking.Model
{
    public class Contact
    {
        public Contact(string name, string email, string phoneNumber)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (email == null) throw new ArgumentNullException("email");
            if (phoneNumber == null) throw new ArgumentNullException("phoneNumber");
            PhoneNumber = phoneNumber;
            Email = email;
            Name = name;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}