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

        public AddEquipmentToOrderForm()
        {
            InitializeComponent();
            Text = "Добавление оборудования к заявке";
            BindEquipments();
        }

        private void BindEquipments()
        {
            _db.Equipments.Load();
            cmbEquipment.DataSource = _db.Equipments.Local.ToList();
        }

        public AddEquipmentToOrderForm(OrdersEquipment ordersEquipment) : this()
        {
            OrdersEquipment = ordersEquipment;
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
            if (OrdersEquipment == null) OrdersEquipment = new OrdersEquipment();
            OrdersEquipment.Amount = (int)numAmount.Value;
            OrdersEquipment.EquipmentId = (cmbEquipment.SelectedItem as Equipment).Id;
        }
    }
}
