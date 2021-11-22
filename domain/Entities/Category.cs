using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Название категории превышает диапазон")]
        public string CategoryRU { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Category name exceeds range")]
        public string CategoryEN { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Category> SubCategories { get; set; }
        public IEnumerable<Description> Descriptions { get; set; }
    }
}
