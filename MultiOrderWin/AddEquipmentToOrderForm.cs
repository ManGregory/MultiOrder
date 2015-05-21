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
    public partial class AddEquipmentToOrderForm : Form
    {
        public OrdersEquipment OrdersEquipment { get; set; }

        private MediaContext _db = new MediaContext();

        private Tuple<int, int, DateTime> _orderParams;
        private List<Equipment> _addedEquipments = new List<Equipment>();

        public AddEquipmentToOrderForm(List<Equipment> addedEquipments, Tuple<int, int, DateTime> orderParams)
        {
            InitializeComponent();
            Text = "Добавление оборудования к заявке";
            _orderParams = orderParams;
            _addedEquipments = addedEquipments;
            BindEquipments();
        }

        private void BindEquipments()
        {
            //_db.Equipments.Load();
            //cmbEquipment.DataSource = _db.Equipments.Local.ToList();
            var availableEquipment = DbHelper.GetAvailableEquipment(_orderParams.Item1, _orderParams.Item2,
                _orderParams.Item3, _db).ToList();
            availableEquipment =
                availableEquipment.Where(
                    a =>
                        _addedEquipments.All(a1 => a.Id != a1.Id)).ToList();
            cmbEquipment.DataSource = availableEquipment;
        }

        public AddEquipmentToOrderForm(OrdersEquipment ordersEquipment, List<Equipment> addedEquipments, Tuple<int, int, DateTime> orderParams)
            : this(addedEquipments, orderParams)
        {
            OrdersEquipment = ordersEquipment;
            if (OrdersEquipment != null)
            {
                var availableEquipment = cmbEquipment.DataSource as List<Equipment>;
                if (availableEquipment != null)
                    availableEquipment.Insert(0, _db.Equipments.Find(OrdersEquipment.EquipmentId));
                cmbEquipment.DataSource = null;
                cmbEquipment.DataSource = availableEquipment;
            }
            Text = "Редактирования оборудования в заявке";
            LoadOrderEquipment();
        }

        private void LoadOrderEquipment()
        {
            numAmount.Value = OrdersEquipment.Amount;
            SelectEquipment();
        }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckAmount())
            {
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
                DialogResult = DialogResult.None;
            }
        }

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
