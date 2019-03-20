using System.Collections.Generic;

namespace codes_netCore.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Hex { get; set; }

        public virtual ICollection<Network> Networks { get; set; }
    }
}
