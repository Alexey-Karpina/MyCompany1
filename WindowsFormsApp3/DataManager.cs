using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApp3
{
    class DataManager
    {
        private BinaryFormatter bf = new BinaryFormatter();
        private string Path1 = @"..\..\Data\departments.dat";
        private string Path2 = @"..\..\Data\employees.dat";
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
        public DataManager()
        {
            Departments = new List<Department>();
            Employees = new List<Employee>();
            // Only once!!!
            InitData();
            SaveDepartments();
            SaveEmployees();
            LoadDepartmnets();
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            using (FileStream fs = new FileStream(Path2, FileMode.Open))
            {
                Employees = (List<Employee>)bf.Deserialize(fs);
            }
        }
        private void LoadDepartmnets()
        {
            using (FileStream fs = new FileStream(Path1, FileMode.Open))
            {
                Departments = (List<Department>)bf.Deserialize(fs);
            }
        }
        private void SaveEmployees()
        {
            using (FileStream fs = new FileStream(Path2, FileMode.Create))
            {
                bf.Serialize(fs, Employees);
            }

        }
        private void SaveDepartments()
        {
            using (FileStream fs = new FileStream(Path1, FileMode.Create))
            {
                bf.Serialize(fs, Departments);
            }

        }
        private void InitData()
        {
            Departments.Add(new Department { Id = 1, Name = "Компьютерный отдел" });
            Departments.Add(new Department { Id = 2, Name = "Финансовый отдел" });
            Departments.Add(new Department { Id = 3, Name = "Юридический отдел" });

            Employees.Add(new Employee
            {
                Id = 1,
                Name = "Иваненко Иван",
                Photo = @"..\..\Photo\p1.jpg",
                Birth = new DateTime(1990, 1, 15),
                Entry = new DateTime(2015, 3, 3),
                Fire = "-",
                Position = "Разработчик",
                Salary = 2000,
                DepId = 1
            });
            Employees.Add(new Employee
            {
                Id = 2,
                Name = "Пупкин Петр",
                Photo = @"..\..\Photo\p2.jpg",
                Birth = new DateTime(1988, 5, 18),
                Entry = new DateTime(2018, 2, 1),
                Fire = "-",
                Position = "Финансист",
                Salary = 800,
                DepId = 2
            });
            Employees.Add(new Employee
            {
                Id = 3,
                Name = "Дмитров Дмитрий",
                Photo = @"..\..\Photo\p3.jpg",
                Birth = new DateTime(1983, 7, 25),
                Entry = new DateTime(2010, 9, 22),
                Fire = "-",
                Position = "Юрист",
                Salary = 1500,
                DepId = 3
            });
        }

    }
}
