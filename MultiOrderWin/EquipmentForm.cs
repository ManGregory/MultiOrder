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
using MultiOrderWin.Properties;

namespace MultiOrderWin
{
    public partial class EquipmentForm : Form
    {
        private readonly MediaContext _db = new MediaContext();
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public EquipmentForm()
        {
            InitializeComponent();
            BindGrid();
            BindingList<Equipment> gridBindingList = _db.Equipments.Local.ToBindingList();
            gridBindingList.AllowEdit = gridBindingList.AllowNew = false;
            gridBindingList.AllowRemove = true;
            _gridBindingSource.DataSource = gridBindingList;
            gridEquipment.DataSource = _gridBindingSource;
        }

        private void BindGrid()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_gridBindingSource.Current != null)
            {
                using (var addEquipmentForm = new AddEquipmentForm(_gridBindingSource.Current as Equipment))
                {
                    if (addEquipmentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        Save();
                        BindGrid();
                        _gridBindingSource.ResetCurrentItem();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addEquipmentForm = new AddEquipmentForm())
            {
                if (addEquipmentForm.ShowDialog(this) == DialogResult.OK)
                {
                    _db.Equipments.Add(addEquipmentForm.Equipment);
                    Save();
                    BindGrid();
                }
            }
        }
    }
}
