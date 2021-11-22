using System;
using System.Collections.Generic;
using System.Text;

namespace application.DTOs.Category
{
    public class CreateCategoryRequest
    {
        public string CategoryRU { get; set; }
        public string CategoryEN { get; set; }
        public int? ParentId { get; set; }
    }
}
