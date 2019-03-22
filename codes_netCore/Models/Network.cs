using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace codes_netCore.Models
{
    public class Network
    {
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int ColorId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual Color Color { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Code> Codes { get; set; }
    }
}
