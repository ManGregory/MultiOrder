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
            SetRights();
        }

        private void SetRights()
        {
            if (!Current.CurrentUser.IsAdmin)
            {
                miCatalogs.Visible = false;
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
                    _db.Orders.Add(addOrderForm.Order);
                    Save();
                    BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            _db.Orders.Include(o => o.Classroom).Include(o => o.Equipment).Include(o => o.User).Load();
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
            using (var addOrderForm = new AddOrderForm(_bindingSource.Current as Order))
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
                Save();
                UpdateEnabled();
                gridOrders.Refresh();
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
                Save();
                UpdateEnabled();
                gridOrders.Refresh();
            }
        }

        private void gridOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var order = _bindingSource[e.RowIndex] as Order;
            if (order != null)
            {
                if (order.IsSigned)
                {
                    gridOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Orange, BackColor = Color.Blue };
                }
                else
                {
                    gridOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = gridOrders.DefaultCellStyle;
                }
            }            
        }
    }
}
