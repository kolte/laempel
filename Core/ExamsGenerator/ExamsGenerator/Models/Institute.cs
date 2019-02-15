using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Institute
    {
        public Institute()
        {
            Class = new HashSet<Class>();
        }

        public int InstituteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
