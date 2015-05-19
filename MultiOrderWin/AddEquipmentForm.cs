using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class AddEquipmentForm : Form
    {
        public Equipment Equipment { get; set; }
        private MediaContext _db = new MediaContext();

        public AddEquipmentForm()
        {
            InitializeComponent();
            BindClassroms();
            Text = "Добавление оборудования";
        }

        private void BindClassroms()
        {
            _db.Classrooms.Load();
            var classrooms = _db.Classrooms.Local.Select(s => s).ToList();
            classrooms.Insert(0, Classroom.Empty);
            cmbClassrooms.DataSource = classrooms;
        }

        public AddEquipmentForm(Equipment equipment) : this()
        {
            Equipment = equipment;
            Text = "Редактирование оборудования";
            LoadEquipment(equipment);
        }

        private void LoadEquipment(Equipment equipment)
        {
            txtName.Text = equipment.Name;
            numAmount.Value = equipment.Amount;
            SelectClassroom(equipment.Classroom);
        }

        private void SelectClassroom(Classroom classroom)
        {
            foreach (var item in cmbClassrooms.Items)
            {
                var currentClassroom = item as Classroom;
                if ((currentClassroom != null) && (classroom != null) && (currentClassroom.Id == classroom.Id))
                {
                    cmbClassrooms.SelectedItem = item;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Equipment == null) Equipment = new Equipment();
            Equipment.Name = txtName.Text;
            Equipment.Amount = (int)numAmount.Value;
            Equipment.ClassroomId = (cmbClassrooms.SelectedIndex > 0 ? (cmbClassrooms.SelectedItem as Classroom).Id : (int?)null);
        }
    }
}
