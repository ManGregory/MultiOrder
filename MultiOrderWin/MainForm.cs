using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
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
            // загрузка заявок из базы
            var bindingList = _db.Orders.Local.ToBindingList();
            bindingList.AllowEdit = bindingList.AllowNew = false;
            _bindingSource.PositionChanged += (sender, args) => UpdateEnabled();
            _bindingSource.DataSource = bindingList;            
            gridOrders.DataSource = _bindingSource;
            var dataGridViewColumn = gridOrders.Columns["Date"];
            // изменение формата даты
            if (dataGridViewColumn != null) dataGridViewColumn.DefaultCellStyle.Format = "D";
            // изменение интерфейса в зависимости от прав пользователя
            SetRights();
            if (Current.CurrentUser.IsAdmin)
            {
                var newOrdersCount = _db.Orders.Count(o => !o.IsSigned);
                if (newOrdersCount > 0)
                {
                    MessageBox.Show(string.Format("Есть новые заявки. Количество - {0}", newOrdersCount));
                }
            }
        }

        private void SetRights()
        {
            // Пользователи не могут видет отчеты и справочники
            if (!Current.CurrentUser.IsAdmin)
            {
                miCatalogs.Visible = miReports.Visible = false;
            }
        }

        /// <summary>
        /// Вызов формы для ввода семестров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miSemesters_Click(object sender, EventArgs e)
        {
            using (var semesterForm = new SemesterForm())
            {
                semesterForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Вызов формы для ввода аудиторий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miClassrooms_Click(object sender, EventArgs e)
        {
            using (var classroomForm = new ClassroomForm())
            {
                classroomForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Вызов формы для ввода оборудования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miEquipment_Click(object sender, EventArgs e)
        {
            using (var equipmentForm = new EquipmentForm())
            {
                equipmentForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Вызов форма для ввода пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miUsers_Click(object sender, EventArgs e)
        {
            using (var usersForm = new UsersForm())
            {
                usersForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Добавление заявки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addOrderForm = new AddOrderForm(true))
            {
                if (addOrderForm.ShowDialog(this) == DialogResult.OK)
                {
                    AddOrder(addOrderForm.Order);
                    Save();
                    BindGrid();
                }
            }
        }

        /// <summary>
        /// Добавление заявки базу в зависимости от периодов
        /// </summary>
        /// <param name="order"></param>
        private void AddOrder(Order order)
        {
            if (order.Period.Contains("Месяц") || order.Period.Contains("Семестр"))
            {
                // добавляем исходную заявку
                _db.Orders.Add(order);
                _db.SaveChanges();
                // добавляем все остальные заявки в зависимотси от периода
                AddOrderForPeriod(order);
            }
            else
            {
                _db.Orders.Add(order);
            }
        }

        /// <summary>
        /// Добавляем заявки на указанный период
        /// </summary>
        /// <param name="order"></param>
        private void AddOrderForPeriod(Order order)
        {
            var date = order.Date.AddDays(7);
            DateTime endDate = date;
            if (order.Period.Contains("Месяц"))
            {
                // конечная дата + 1 месяц
                endDate = order.Date.AddMonths(1);                             
            } 
            else if (order.Period.Contains("Семестр"))
            {
                // конечная дата из базы
                var firstOrDefault = _db.Semesters.FirstOrDefault(s => order.Date >= s.BeginDate && order.Date <= s.EndDate);
                if (firstOrDefault != null)
                    endDate = firstOrDefault.EndDate;
            }
            DbHelper.AddMultipleOrders(order, date, endDate, _db);
        }

        /// <summary>
        /// Загрузка заявок
        /// </summary>
        private void BindGrid()
        {
            _db.Orders.Include(o => o.Classroom).Include(o => o.User).Load();
        }

        /// <summary>
        /// Сохранение информации в базу
        /// </summary>
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

        /// <summary>
        /// Редактирование существующей заявки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current != null)
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
        }

        /// <summary>
        /// Удаление заявки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var order = _bindingSource.Current as Order;
            if ((order != null) && (!order.IsSigned))
            {
                _db.Orders.Remove(order);
                Save();
                UpdateEnabled();
                gridOrders.Refresh();
                LoadEquipment(null);
            }
        }

        /// <summary>
        /// Обновление интерфейса
        /// </summary>
        private void UpdateEnabled()
        {
            var order = _bindingSource.Current as Order;
            if (order != null)
            {
                // пользователь может редактировать только свои заявки
                btnRemove.Enabled =
                    btnEdit.Enabled =
                        ((Current.CurrentUser.IsAdmin) && (!order.IsSigned)) ||
                        ((Current.CurrentUser.Id == order.UserId) && (!order.IsSigned));
                btnSign.Enabled = (Current.CurrentUser.IsAdmin);
                btnSign.Text = order.IsSigned ? "Отменить утверждение" : "Утвердить";
            }
        }

        /// <summary>
        /// Утверждение и отмена утверждения для заявок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // утверждаем или отменяем все связанные заявки
            foreach (var o in _db.Orders.Where(or1 => or1.ParentId == order.Id))
            {
                o.IsSigned = order.IsSigned;
            }
        }

        /// <summary>
        /// Форматирования ячейки в зависимости от статуса заявки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Загрузка оборудования связанного с заявкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridOrders_SelectionChanged(object sender, EventArgs e)
        {
            var order = _bindingSource.Current as Order;
            if (order != null) LoadEquipment(order);
        }

        /// <summary>
        /// Загрузка оборудования связанного с заявкой
        /// </summary>
        /// <param name="order"></param>
        private void LoadEquipment(Order order)
        {
            gridEquipment.Rows.Clear();
            if (order != null)
            {
                // выбираем оборудование связанное с заявкой
                var equipments =
                    _db.OrdersEquipments.Include(oe => oe.Equipment).Where(oe => oe.OrderId == order.Id).ToList();
                // добавляем строки в таблицу
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

        /// <summary>
        /// Просмотр заявки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current != null)
            {
                using (var addOrderForm = new AddOrderForm(_bindingSource.Current as Order, false))
                {
                    addOrderForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Отчет о количестве заявок пользователя в разрезе месяцев
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miOrderUsers_Click(object sender, EventArgs e)
        {
            using (var reportForn = new OrderUserReport())
            {
                reportForn.ShowDialog(this);
            }
        }

        /// <summary>
        /// График заявок на оборудование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miChartMulti_Click(object sender, EventArgs e)
        {
            using (var chartForm = new ChartForm())
            {
                chartForm.ShowDialog(this);
            }
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            using (var abouForm = new AboutForm())
            {
                abouForm.ShowDialog(this);
            }
        }
    }
}
