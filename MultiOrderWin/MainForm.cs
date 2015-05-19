using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class MainForm : Form
    {
        private MediaContext _db = new MediaContext();
        private readonly LoginForm _form;

        public MainForm(LoginForm form)
        {
            InitializeComponent();
            _form = form;
            Closed += (sender, args) => _form.Close();
            gridOrders.DataSource = _db.Orders.Local.ToBindingList();
        }

        private void miSemesters_Click(object sender, EventArgs e)
        {
            using (var semesterForm = new SemesterForm())
            {
                semesterForm.ShowDialog(this);
            }
        }

        private void miClassrooms_Click(object sender, EventArgs e)
        {
            using (var classroomForm = new ClassroomForm())
            {
                classroomForm.ShowDialog(this);
            }
        }

        private void miEquipment_Click(object sender, EventArgs e)
        {
            using (var equipmentForm = new EquipmentForm())
            {
                equipmentForm.ShowDialog(this);
            }
        }

        private void miUsers_Click(object sender, EventArgs e)
        {
            using (var usersForm = new UsersForm())
            {
                usersForm.ShowDialog(this);
            }
        }
    }
}
