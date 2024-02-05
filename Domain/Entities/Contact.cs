namespace Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Profile { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime Birthdate { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public virtual Address Address { get; set; }

    }
}
