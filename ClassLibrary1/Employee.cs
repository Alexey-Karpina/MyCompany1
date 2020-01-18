using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime Birth { get; set; }
        public DateTime Entry { get; set; }
        public string Fire { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int DepId { get; set; }
    }
}
