using Domain.Entities;

namespace WebApi.Test
{
    public class Utils()
    {
        public Contact GetFakeContactForCreate()
        {
            return new Contact()
            {
                Name = "Jhon",
                Company = "Google",
                Birthdate = new DateTime(2000, 3, 1),
                Email = "jhon@gmail.com",
                Image = "",
                Profile = "Developer",
                Address = new Address()
                {
                    State = "Buenos Aires",
                    Street = "Calle 1 1234",
                    Country = "Argentina",
                    City = "La Plata",
                    ZipCode = "1234",
                },
                Phones = new List<ContactPhone>()
                {
                    new ContactPhone() {
                        PhoneType = PhoneType.Personal,
                        Number = "12345" },
                    new ContactPhone() {
                        PhoneType = PhoneType.Work,
                        Number = "67890" }
                }
            };
        }
    }
}
