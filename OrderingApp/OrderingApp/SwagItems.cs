using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingApp
{
    public class SwagItems
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string Color { get; set; }

        public string Gender { get; set; }
        public string Size { get; set; }
        public DateTime Date { get; set; }
        
        public string Address { get; set; }
       









    }
}
