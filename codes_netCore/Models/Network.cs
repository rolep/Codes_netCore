using System.Collections.Generic;

namespace codes_netCore.Models
{
    public class Network
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }

        public virtual Color Color { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Code> Codes { get; set; }
    }
}
