using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Description> Descriptions { get; set; }
    }
}
