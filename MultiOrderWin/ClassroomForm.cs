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
        // подключение к базе
        private readonly MediaContext _db = new MediaContext();
        // байндинг для таблицы
        private readonly BindingSource _gridBindingSource = new BindingSource();

        public ClassroomForm()
        {
            InitializeComponent();
            // загрзузка аудиторий из базы
            _db.Classrooms.Load();
            // получение байндинга
            BindingList<Classroom> gridBindingList = _db.Classrooms.Local.ToBindingList();
            // связываем таблицу с байндингом
            _gridBindingSource.DataSource = gridBindingList;           
            gridClassrooms.DataSource = _gridBindingSource;
            gridClassrooms.Columns[0].Width = gridClassrooms.Width - 50;
            bnClassrooms.BindingSource = _gridBindingSource;
        }

        /// <summary>
        /// Сохранение данных в базе
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
        /// Обработка ошибок ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
