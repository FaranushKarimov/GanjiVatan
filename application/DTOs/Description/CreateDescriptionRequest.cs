using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Description
{
    public class CreateDescriptionRequest
    {
        public string TextTJ { get; set; }
        public string TextEN { get; set; }
        public int CategoryId { get; set; }
    }
}
