using System.ComponentModel.DataAnnotations;

namespace codes_netCore.Models
{
    public class Codes
    {
        public int Id { get; set; }

        [Required]
        public string[] Values { get; set; }
        [Required]
        public string R { get; set; }

        public int CountryId { get; set; }
        public int NetworkId { get; set; }
    }
}
