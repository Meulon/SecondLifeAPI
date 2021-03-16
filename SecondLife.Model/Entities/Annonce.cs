using System;
using System.Collections.Generic;
using System.Text;

namespace SecondLife.Model.Entities
{
    public class Annonce
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
