using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class AddEquipmentToOrderForm : Form
    {
        public OrdersEquipment OrdersEquipment { get; set; }

        private MediaContext _db = new MediaContext();

        /// <summary>
        /// Данные заявки, с какой по какую пары, дата заявки
        /// </summary>
        private Tuple<int, int, DateTime> _orderParams;
        /// <summary>
        /// Список оборудования которое уже добавлено в заявку
        /// </summary>
        private List<Equipment> _addedEquipments = new List<Equipment>();

        public AddEquipmentToOrderForm(List<Equipment> addedEquipments, Tuple<int, int, DateTime> orderParams)
        {
            InitializeComponent();
            Text = "Добавление оборудования к заявке";
            _orderParams = orderParams;
            _addedEquipments = addedEquipments;
            BindEquipments();
        }

        /// <summary>
        /// Загрузка доступного оборудования
        /// </summary>
        private void BindEquipments()
        {
            // Получаем доступное оборудование по указанным параметрам
            var availableEquipment = DbHelper.GetAvailableEquipment(_orderParams.Item1, _orderParams.Item2,
                _orderParams.Item3, _db).ToList();
            // Убираем оборудование, которое уже есть в заявке
            availableEquipment =
                availableEquipment.Where(
                    a =>
                        _addedEquipments.All(a1 => a.Id != a1.Id)).ToList();
            cmbEquipment.DataSource = availableEquipment;
        }

        /// <summary>
        /// Редактирование заявляемого оборудования
        /// </summary>
        /// <param name="ordersEquipment">Заявляемое оборудование</param>
        /// <param name="addedEquipments">Оборудование, которое уже заявлено</param>
        /// <param name="orderParams">Параметры заявки</param>
        public AddEquipmentToOrderForm(OrdersEquipment ordersEquipment, List<Equipment> addedEquipments, Tuple<int, int, DateTime> orderParams)
            : this(addedEquipments, orderParams)
        {
            OrdersEquipment = ordersEquipment;
            if (OrdersEquipment != null)
            {
                // вставка редактируемого оборудования в список для отображения
                var availableEquipment = cmbEquipment.DataSource as List<Equipment>;
                if (availableEquipment != null)
                    availableEquipment.Insert(0, _db.Equipments.Find(OrdersEquipment.EquipmentId));
                cmbEquipment.DataSource = null;
                cmbEquipment.DataSource = availableEquipment;
            }
            Text = "Редактирования оборудования в заявке";
            LoadOrderEquipment();
        }

        /// <summary>
        /// Заполнение элементов формы
        /// </summary>
        private void LoadOrderEquipment()
        {
            numAmount.Value = OrdersEquipment.Amount;
            SelectEquipment();
        }

        /// <summary>
        /// Выбор оборудования из списка
        /// </summary>
        private void SelectEquipment()
        {
            foreach (var item in cmbEquipment.Items)
            {
                var equipment = item as Equipment;
                if ((equipment != null) && (equipment.Id == OrdersEquipment.EquipmentId))
                {
                    cmbEquipment.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // проверка количества
            if (CheckAmount())
            {
                // заполнение данных
                if (OrdersEquipment == null) OrdersEquipment = new OrdersEquipment();
                OrdersEquipment.Amount = (int) numAmount.Value;
                var equipment = cmbEquipment.SelectedItem as Equipment;
                if (equipment != null)
                {
                    OrdersEquipment.EquipmentId = equipment.Id;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Введенное количество превышает допустимое");
                DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// Проверка заявляемого количества
        /// </summary>
        /// <returns></returns>
        private bool CheckAmount()
        {
            var res = true;
            var equipment = cmbEquipment.SelectedItem as Equipment;
            if (equipment != null)
            {
                if (equipment.Amount < numAmount.Value)
                {
                    res = false;
                }
            }
            return res;
        }

        /// <summary>
        /// Загрузка доступного количества
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var equipment = cmbEquipment.SelectedItem as Equipment;
            if (equipment != null)
            {
                lblAvailableAmount.Text = string.Format("Доступное количество: {0}", equipment.Amount);
            }
        }
    }
}
