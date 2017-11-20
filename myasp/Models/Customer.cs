using System.ComponentModel.DataAnnotations;

namespace myasp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}