using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly LoginForm _loginForm;
        private BindingSource _bindingSource = new BindingSource();

        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            Closed += (sender, args) => _loginForm.Close();
            BindGrid();
            var bindingList = _db.Orders.Local.ToBindingList();
            bindingList.AllowEdit = bindingList.AllowNew = false;
            _bindingSource.PositionChanged += (sender, args) => UpdateEnabled();
            _bindingSource.DataSource = bindingList;            
            gridOrders.DataSource = _bindingSource;
            var dataGridViewColumn = gridOrders.Columns["Date"];
            if (dataGridViewColumn != null) dataGridViewColumn.DefaultCellStyle.Format = "D";
            SetRights();
        }

        private void SetRights()
        {
            if (!Current.CurrentUser.IsAdmin)
            {
                miCatalogs.Visible = miReports.Visible = false;
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addOrderForm = new AddOrderForm())
            {
                if (addOrderForm.ShowDialog(this) == DialogResult.OK)
                {
                    AddOrder(addOrderForm.Order);
                    Save();
                    BindGrid();
                }
            }
        }

        private void AddOrder(Order order)
        {
            if (order.Period.Contains("Месяц") || order.Period.Contains("Семестр"))
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                AddOrderForPeriod(order);
            }
            else
            {
                _db.Orders.Add(order);
            }
        }

        private void AddOrderForPeriod(Order order)
        {
            var date = order.Date.AddDays(7);
            DateTime endDate = date;
            if (order.Period.Contains("Месяц"))
            {
                endDate = order.Date.AddMonths(1);                             
            } 
            else if (order.Period.Contains("Семестр"))
            {
                var firstOrDefault = _db.Semesters.FirstOrDefault(s => order.Date >= s.BeginDate && order.Date <= s.EndDate);
                if (firstOrDefault != null)
                    endDate = firstOrDefault.EndDate;
            }
            DbHelper.AddMultipleOrders(order, date, endDate, _db);
        }

        private void BindGrid()
        {
            _db.Orders.Include(o => o.Classroom).Include(o => o.User).Load();
        }

        private void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (var addOrderForm = new AddOrderForm(_bindingSource.Current as Order, true))
            {
                if (addOrderForm.ShowDialog(this) == DialogResult.OK)
                {                        
                    Save();
                    BindGrid();
                    _bindingSource.ResetCurrentItem();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var order = _bindingSource.Current as Order;
            if ((order != null) && (!order.IsSigned))
            {
                _db.Orders.Remove(order);
                //RemoveLinked(order);
                Save();
                UpdateEnabled();
                gridOrders.Refresh();
                LoadEquipment(null);
            }
        }

        private void RemoveLinked(Order order)
        {
            foreach (var o in _db.Orders.Where(o1 => o1.ParentId == order.Id))
            {
                _db.Orders.Remove(o);
            }
        }

        private void UpdateEnabled()
        {
            var order = _bindingSource.Current as Order;
            if (order != null)
            {
                btnRemove.Enabled =
                    btnEdit.Enabled =
                        ((Current.CurrentUser.IsAdmin) && (!order.IsSigned)) ||
                        ((Current.CurrentUser.Id == order.UserId) && (!order.IsSigned));
                btnSign.Enabled = (Current.CurrentUser.IsAdmin);
                btnSign.Text = order.IsSigned ? "Отменить утверждение" : "Утвердить";
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            var order = _bindingSource.Current as Order;
            if ((order != null))
            {
                order.IsSigned = !order.IsSigned;
                SignLinked(order);
                Save();
                UpdateEnabled();
                gridOrders.Refresh();
            }
        }

        private void SignLinked(Order order)
        {
            foreach (var o in _db.Orders.Where(or1 => or1.ParentId == order.Id))
            {
                o.IsSigned = order.IsSigned;
            }
        }

        private void gridOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var order = _bindingSource[e.RowIndex] as Order;
            if (order != null)
            {
                gridOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style =
                    order.IsSigned
                        ? new DataGridViewCellStyle {ForeColor = Color.Black, BackColor = Color.LightGreen}
                        : gridOrders.DefaultCellStyle;
            }            
        }

        private void gridOrders_SelectionChanged(object sender, EventArgs e)
        {
            var order = _bindingSource.Current as Order;
            if (order != null) LoadEquipment(order);
        }

        private void LoadEquipment(Order order)
        {
            gridEquipment.Rows.Clear();
            if (order != null)
            {
                var equipments =
                    _db.OrdersEquipments.Include(oe => oe.Equipment).Where(oe => oe.OrderId == order.Id).ToList();
                foreach (var equipment in equipments)
                {
                    var row = new DataGridViewRow();
                    row.Cells.AddRange(
                        new DataGridViewTextBoxCell {Value = equipment.Equipment.Name},
                        new DataGridViewTextBoxCell {Value = equipment.Amount});
                    gridEquipment.Rows.Add(row);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            using (var addOrderForm = new AddOrderForm(_bindingSource.Current as Order, false))
            {
                addOrderForm.ShowDialog();
            }
        }

        private void miOrderUsers_Click(object sender, EventArgs e)
        {
            using (var reportForn = new OrderUserReport())
            {
                reportForn.ShowDialog(this);
            }
        }
    }
}
