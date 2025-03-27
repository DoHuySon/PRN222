using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Star
    {
        public string Name { get; set; } = null!;    
        public DateTime? Dob {  get; set; }
        public string? Description { get; set; }
        public bool? Male { get; set; }
        public string? Nationality { get; set; }

        public override string ToString()
        {
            return $"{Name} {(Dob.HasValue ? Dob.Value.ToString("MM/dd/yyyy") : "N/A")}  " +
                $"{Description ?? "N/A"} {(Male.HasValue ? (Male.Value ? "True" : "False") : "N/A")} {Nationality ?? "N/A"} ";
        }

    }
}
