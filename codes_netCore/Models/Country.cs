using System.Collections.Generic;

namespace codes_netCore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Network> Networks { get; set; }
        public virtual ICollection<Code> Codes { get; set; }
    }
}
