using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public enum PhoneType
    {
        Personal = 1,
        Work = 2
    }

    public class ContactPhone
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Number { get; set; }

        public int ContactId { get; set; }

        [NotMapped]
        public virtual Contact? Contact { get; set; }
    }
}
