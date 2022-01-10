using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.ThematicAreaPost
{
    public class FileResponse
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public bool IsMain { get; set; }
    }
}
