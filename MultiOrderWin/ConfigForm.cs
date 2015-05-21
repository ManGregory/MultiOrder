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
            var connectionString = ConfigurationManager.ConnectionStrings["MultiOrderConnectionString"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(connectionString);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = txtServerName.Text,
                InitialCatalog = txtDbName.Text,
                IntegratedSecurity = chkWindowsAuthentification.Checked,
                UserID = txtUserName.Text,
                Password = txtPassword.Text
            };
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["MultiOrderConnectionString"].ConnectionString =
                builder.ToString();
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
