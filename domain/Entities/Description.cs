using System;
using System.Collections.Generic;
using System.Text;

namespace domain.Entities
{
    public class Description
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
