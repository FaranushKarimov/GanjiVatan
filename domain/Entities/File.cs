using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class File
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Path { get; set; }
        public int ThematicAreaPostId { get; set; }
        public ThematicAreaPost ThematicAreaPost { get; set; }
    }
}
