using System.ComponentModel.DataAnnotations;

namespace plumsail_back.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
    }
}
