using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public DateTime? Birthdate { get; set; }
       
        [Column(TypeName = "varchar(100)")]
        public string Company { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Image { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string? Profile { get; set; }
        public virtual Address Address { get; set; }
        public ICollection<ContactPhone> Phones{ get; set;}

    }
}
