using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class EquipmentForm : Form
    {
        private readonly MediaContext _db = new MediaContext();
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public EquipmentForm()
        {
            InitializeComponent();
            LoadEquipments();
            BindGrid();
            gridEquipment.DataSource = _gridBindingSource;
        }

        /// <summary>
        /// Загрузка данных в таблицу
        /// </summary>
        private void BindGrid()
        {
            BindingList<Equipment> gridBindingList = _db.Equipments.Local.ToBindingList();
            gridBindingList.AllowEdit = gridBindingList.AllowNew = false;
            gridBindingList.AllowRemove = true;
            _gridBindingSource.DataSource = gridBindingList;
        }

        /// <summary>
        /// Загрузка оборудования из базы
        /// </summary>
        private void LoadEquipments()
        {
            _db.Equipments.Include(e => e.Classroom).Load();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _gridBindingSource.RemoveCurrent();
            Save();
        }

        /// <summary>
        /// Редактирование оборудования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_gridBindingSource.Current != null)
            {
                using (var addEquipmentForm = new AddEquipmentForm(_gridBindingSource.Current as Equipment))
                {
                    if (addEquipmentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        Save();
                        LoadEquipments();
                        _gridBindingSource.ResetCurrentItem();
                    }
                }
            }
        }

        /// <summary>
        /// Добавление оборудования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addEquipmentForm = new AddEquipmentForm())
            {
                if (addEquipmentForm.ShowDialog(this) == DialogResult.OK)
                {
                    _db.Equipments.Add(addEquipmentForm.Equipment);
                    Save();
                    LoadEquipments();
                }
            }
        }

        /// <summary>
        /// Загрузка доступного или всего оборудования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAvailable.Checked)
            {                
                _gridBindingSource.DataSource = DbHelper.GetAvailableEquipment((int)numPair.Value, edDate.Value, _db);
            }
            else
            {
                LoadEquipments();
                BindGrid();
            }
            pnlControls.Enabled = !chkAvailable.Checked;
        }

        private void numPair_ValueChanged(object sender, EventArgs e)
        {
            if (chkAvailable.Checked)
            {
                _gridBindingSource.DataSource = DbHelper.GetAvailableEquipment((int)numPair.Value, edDate.Value, _db);
            }
        }
    }
}
