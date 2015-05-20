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
    public partial class AddOrderForm : Form
    {
        public Order Order { get; set; }
        private readonly MediaContext _db = new MediaContext();

        public AddOrderForm()
        {
            InitializeComponent();
            Text = "Добавление заявки";
            LoadWeeks();
            LoadPeriods();
            BindClassrooms();
            BindEquipments();
        }

        private void BindEquipments()
        {
            _db.Equipments.Load();
            var equipments = _db.Equipments.Local.Select(s => s).ToList();
            cmbEquipments.DataSource = equipments;
        }

        private void BindClassrooms()
        {
            _db.Classrooms.Load();
            var classrooms = _db.Classrooms.Local.Select(s => s).ToList();
            cmbClassrooms.DataSource = classrooms;
        }

        private void LoadPeriods()
        {
            cmbPeriods.Items.Clear();
            cmbPeriods.Items.AddRange(new [] {"День", "Месяц", "Семестр"});
            cmbPeriods.SelectedIndex = 0;
        }

        private void LoadWeeks()
        {
            cmbWeeks.Items.Clear();
            cmbWeeks.Items.AddRange(new [] {"1 неделя", "2 неделя", "1 и 2 неделя"});
            cmbWeeks.SelectedIndex = 0;
        }

        public AddOrderForm(Order order) : this()
        {
            Order = order;
            Text = "Редактирование заявки";
            LoadOrder(order);
        }

        private void LoadOrder(Order order)
        {
            edDate.Value = order.Date;
            numFromPair.Value = order.FromPair;
            numToPair.Value = order.ToPair;
            numAmount.Value = order.Amount;
            SelectClassroom(order.ClassroomId);
            SelectEquipment(order.EquipmentId);
            SelectWeek(order.WeekNumber);
            SelectPeriod(order.Period);
        }

        private void SelectPeriod(string period)
        {
            foreach (var item in cmbPeriods.Items)
            {
                if (item.ToString().Trim() == period.Trim())
                {
                    cmbPeriods.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectWeek(string weekNumber)
        {
            foreach (var item in cmbWeeks.Items)
            {
                if (item.ToString().Trim() == weekNumber.Trim())
                {
                    cmbWeeks.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectEquipment(int equipmentId)
        {
            foreach (var item in cmbEquipments.Items)
            {
                var equipment = item as Equipment;
                if ((equipment != null) && (equipment.Id == equipmentId))
                {
                    cmbEquipments.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectClassroom(int classroomId)
        {
            foreach (var item in cmbClassrooms.Items)
            {
                var classroom = item as Classroom;
                if ((classroom != null) && (classroom.Id == classroomId))
                {
                    cmbClassrooms.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Order == null) Order = new Order();
            Order.Date = edDate.Value;
            Order.FromPair = (int)numFromPair.Value;
            Order.ToPair = (int)numToPair.Value;
            Order.ClassroomId = (cmbClassrooms.SelectedItem as Classroom).Id;
            Order.EquipmentId = (cmbEquipments.SelectedItem as Equipment).Id;
            Order.Amount = (int)numAmount.Value;
            Order.UserId = Current.CurrentUser.Id;
            Order.Period = cmbPeriods.SelectedItem.ToString();
            Order.WeekNumber = cmbWeeks.SelectedItem.ToString();
        }
    }
}
