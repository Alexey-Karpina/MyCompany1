using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private DataManager dm = new DataManager();
        public Form1()
        {
            InitializeComponent();
        }
        private void FillDepartments()
        {
            var deps = dm.Departments.ToList();
            DepList.Items.Clear();
            foreach (var item in deps)
            {
                DepList.Items.Add(item);
            }
            DepList.DisplayMember = "Name";
            DepList.SelectedIndex = 0;
        }
        private void FillEmployees(int dep_id)
        {
            var emps = dm.Employees.Where(x => x.DepId == dep_id).ToList();
            EmpList.Items.Clear();
            foreach (var item in emps)
            {
                EmpList.Items.Add(item);
            }
            EmpList.DisplayMember = "Name";
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDepartments();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DepList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elem = DepList.SelectedItem as Department;
            int id = elem.Id;
            FillEmployees(id);

        }

        private void EmpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elem = EmpList.SelectedItem as Employee;
            var emp_id = elem.Id;
            Photo.Image = Image.FromFile(elem.Photo);
            Name.Text = elem.Name;
            Birth.Value = elem.Birth;
            Entry.Value = elem.Entry;
            Free.Text = elem.Fire;
            Pos.Text = elem.Position;
            Salary.Text = elem.Salary.ToString();
        }

        private void Photo_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
