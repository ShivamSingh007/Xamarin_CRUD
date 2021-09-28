using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace CRUD.Models
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}
