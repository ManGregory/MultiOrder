using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;
using MultiOrderWin.Models;
using MultiOrderWin.Properties;

namespace MultiOrderWin
{
    public partial class SemesterForm : Form
    {
        private readonly MediaContext _db = new MediaContext();
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public SemesterForm()
        {
            InitializeComponent();
            // загрузка семестров из базы
            _db.Semesters.Load();
            BindingList<Semester> gridBindingList = _db.Semesters.Local.ToBindingList();
            _gridBindingSource.DataSource = gridBindingList;
            gridSemesters.DataSource = _gridBindingSource;
            bindingNavigator1.BindingSource = _gridBindingSource;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
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

        private void gridSemesters_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show(Resources.GridDataErrorMessage);
        }

        private void SemesterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
