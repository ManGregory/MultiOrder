using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace MultiOrderWin
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            // получаем текущую строку подключения из файла конфигурации
            var connectionString = ConfigurationManager.ConnectionStrings["MultiOrderConnectionString"].ConnectionString;
            // создаем класс для построения строки подключения
            var builder = new SqlConnectionStringBuilder(connectionString);
            // заполняем элементы интерфейса 
            txtServerName.Text = builder.DataSource;
            txtDbName.Text = builder.InitialCatalog;
            txtUserName.Text = builder.UserID;
            txtPassword.Text = builder.Password;
            chkWindowsAuthentification.Checked = builder.IntegratedSecurity;
        }

        private void chkWindowsAuthentification_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = 
                txtPassword.Enabled = 
                    !chkWindowsAuthentification.Checked;
        }

        /// <summary>
        /// Сохранение строки подключения в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // создаем клас для построения строки подключения
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = txtServerName.Text,
                InitialCatalog = txtDbName.Text,
                IntegratedSecurity = chkWindowsAuthentification.Checked,
                UserID = txtUserName.Text,
                Password = txtPassword.Text
            };
            // сохраняем строку в файл
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["MultiOrderConnectionString"].ConnectionString =
                builder.ToString();
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
