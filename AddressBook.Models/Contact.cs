namespace AddressBook.Models
{
    public sealed class Contact
    {
        public Contact(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }

        //public override bool Equals(object obj)
        //{
        //    return this.Id == (obj as Contact).Id;
        //}\

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Contact other = (Contact)obj;
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} {Phone}";
        }
    }
}
