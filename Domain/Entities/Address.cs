using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string State { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Street { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ZipCode { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
    }
}
