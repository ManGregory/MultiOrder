using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;
using MultiOrderWin.Models;
using MultiOrderWin.Properties;

namespace MultiOrderWin
{
    public partial class UsersForm : Form
    {
        private readonly MediaContext _db = new MediaContext();
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public UsersForm()
        {
            InitializeComponent();
            _db.Users.Load();
            BindingList<User> gridBindingList = _db.Users.Local.ToBindingList();
            _gridBindingSource.DataSource = gridBindingList;
            gridSemesters.DataSource = _gridBindingSource;
            bindingNavigator1.BindingSource = _gridBindingSource;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
