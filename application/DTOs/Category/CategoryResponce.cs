using System;
using System.Collections.Generic;
using System.Text;

namespace application.DTOs.Category
{
    public class CategoryResponce
    {
        public int Id { get; set; }
        public string CategoryRU { get; set; }
        public string CategoryEN { get; set; }
        public IEnumerable<CategoryResponce> SubCategories { get; set; }
    }
}
