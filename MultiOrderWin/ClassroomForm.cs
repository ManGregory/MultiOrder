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
    public partial class ClassroomForm : Form
    {
        private readonly MediaContext _db = new MediaContext();
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public ClassroomForm()
        {
            InitializeComponent();
            _db.Classrooms.Load();
            BindingList<Classroom> gridBindingList = _db.Classrooms.Local.ToBindingList();
            _gridBindingSource.DataSource = gridBindingList;           
            gridClassrooms.DataSource = _gridBindingSource;
            gridClassrooms.Columns[0].Width = gridClassrooms.Width - 50;
            bnClassrooms.BindingSource = _gridBindingSource;
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

        private void gridClassrooms_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show(Resources.GridDataErrorMessage);
        }

        private void ClassroomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
