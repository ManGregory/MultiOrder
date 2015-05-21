using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
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
        private List<OrdersEquipment> _equipmentList = new List<OrdersEquipment>();
        private bool _isEditable;

        public AddOrderForm()
        {
            InitializeComponent();
            _isEditable = true;
            Text = "Добавление заявки";
            Order = new Order();
            LoadWeeks();
            LoadPeriods();
            BindClassrooms();
            gridEquipments.AutoGenerateColumns = false;
        }

        private void BindEquipments()
        {
            if (Order != null)
            {
                gridEquipments.Rows.Clear();
                LoadFromClassroom();
                if (Order.OrdersEquipment != null)
                {
                    foreach (var orderEquipment in Order.OrdersEquipment)
                    {
                        var equipment = _db.Equipments.Find(orderEquipment.EquipmentId);
                        if (equipment != null)
                        {
                            var row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell {Value = equipment.Name});
                            row.Cells.Add(new DataGridViewTextBoxCell {Value = orderEquipment.Amount});
                            row.Cells.Add(new DataGridViewTextBoxCell {Value = orderEquipment.OrderId});
                            row.Cells.Add(new DataGridViewTextBoxCell {Value = orderEquipment.EquipmentId});
                            row.Cells.Add(new DataGridViewTextBoxCell {Value = 0});
                            gridEquipments.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void LoadFromClassroom()
        {
            var classroom = cmbClassrooms.SelectedItem as Classroom;
            if (classroom != null)
            {
                var equipments = _db.Equipments.Where(e => e.ClassroomId == classroom.Id);
                foreach (var equipment in equipments)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = equipment.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = equipment.Amount });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = -1 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = -1 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = 1 });
                    gridEquipments.Rows.Add(row);
                }
            }
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
            SetWeekNumber();
        }

        private void SetWeekNumber()
        {
            var weekNumber = DbHelper.GetWeekNumber(edDate.Value, _db);
            cmbWeeks.SelectedIndex = weekNumber - 1;
        }

        public AddOrderForm(Order order, bool isEditable) : this()
        {
            Order = order;
            Text = "Редактирование заявки";
            LoadOrder(order);
            _isEditable = isEditable;
            EnableOrderGui();
        }

        private void EnableOrderGui()
        {
            grpOrderInfo.Enabled = _isEditable;
            btnSave.Enabled = _isEditable;
        }

        private void LoadOrder(Order order)
        {
            edDate.Value = order.Date;
            numFromPair.Value = order.FromPair;
            numToPair.Value = order.ToPair;
            SelectClassroom(order.ClassroomId);
            SelectWeek(order.WeekNumber);
            SelectPeriod(order.Period);
            BindEquipments();
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
            if (Check())
            {
                Order.Date = edDate.Value;
                Order.FromPair = (int) numFromPair.Value;
                Order.ToPair = (int) numToPair.Value;
                Order.ClassroomId = (cmbClassrooms.SelectedItem as Classroom).Id;
                Order.UserId = Current.CurrentUser.Id;
                Order.Period = cmbPeriods.SelectedItem.ToString();
                Order.WeekNumber = cmbWeeks.SelectedItem.ToString();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private bool Check()
        {
            if ((edDate.Value - DateTime.Now).TotalDays <= 2)
            {
                MessageBox.Show("Дата подачи заявки должна быть больше текущей, как минимум на два дня");
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addEquipmentToOrderForm = new AddEquipmentToOrderForm(GetAddedEquipments(), GetOrderParams()))
            {
                if (addEquipmentToOrderForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Order.OrdersEquipment == null) Order.OrdersEquipment = new EntityCollection<OrdersEquipment>();
                    Order.OrdersEquipment.Add(addEquipmentToOrderForm.OrdersEquipment);
                    BindEquipments();
                }
            }
        }

        private Tuple<int, int, DateTime> GetOrderParams()
        {
            return new Tuple<int, int, DateTime>((int) numFromPair.Value, (int) numToPair.Value, edDate.Value);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridEquipments.CurrentRow != null)
            {
                var orderId = (int)gridEquipments.CurrentRow.Cells["OrderId"].Value;
                var equipmentId = (int)gridEquipments.CurrentRow.Cells["EquipmentId"].Value;
                var currentOrderEquipment =
                    Order.OrdersEquipment.FirstOrDefault(o => o.OrderId == orderId && o.EquipmentId == equipmentId);
                using (
                    var addEquipmentToOrderForm = new AddEquipmentToOrderForm(currentOrderEquipment,
                        GetAddedEquipments(),
                        GetOrderParams()))
                {
                    if (addEquipmentToOrderForm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Order.OrdersEquipment == null)
                            Order.OrdersEquipment = new EntityCollection<OrdersEquipment>();
                        Order.OrdersEquipment.Add(addEquipmentToOrderForm.OrdersEquipment);
                        BindEquipments();
                    }
                }
            }
        }

        private List<Equipment> GetAddedEquipments()
        {
            if (Order.OrdersEquipment == null)
            {
                return new List<Equipment>();
            }
            return Order.OrdersEquipment.Select(oe => new Equipment {Id = oe.EquipmentId}).ToList();
        }

        private void cmbClassrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEquipments();
        }

        private void gridEquipments_SelectionChanged(object sender, EventArgs e)
        {
            EnableGui();
        }

        private void EnableGui()
        {
            var currentRow = gridEquipments.CurrentRow;
            if (currentRow != null)
            {
                btnEdit.Enabled = btnRemove.Enabled =
                    (int)currentRow.Cells["IsFromClassroom"].Value == 0;
            }
        }

        private void cmbPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbWeeks.Enabled = cmbPeriods.SelectedIndex > 0;
        }

        private void edDate_ValueChanged(object sender, EventArgs e)
        {
            SetWeekNumber();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gridEquipments.CurrentRow != null)
            {
                var orderId = (int) gridEquipments.CurrentRow.Cells["OrderId"].Value;
                var equipmentId = (int) gridEquipments.CurrentRow.Cells["EquipmentId"].Value;
                var currentOrderEquipment =
                    Order.OrdersEquipment.FirstOrDefault(o => o.OrderId == orderId && o.EquipmentId == equipmentId);
                Order.OrdersEquipment.Remove(currentOrderEquipment);
                BindEquipments();
            }
        }
    }
}
