using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        public string Type { get; set; }
    }
}
