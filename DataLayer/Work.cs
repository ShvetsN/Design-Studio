using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Work
    {
        public int Id { get; set; }
        [StringLength(200)]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
