using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Database.SetInitializer(new MediaContextInitializer());
            txtLogin.Focus();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            var user = GetUser(txtLogin.Text, txtPassword.Text);
            if (user != null)
            {
                Current.CurrentUser = user;
                Visible = false;
                var mainForm = new MainForm(this);
                mainForm.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль");
            }
        }

        private User GetUser(string login, string password)
        {
            using (var db = new MediaContext())
            {
                return db.Users.FirstOrDefault(u => u.Name == login && u.Password == password);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnConfig_Click(object sender, System.EventArgs e)
        {
            using (var configForm = new ConfigForm())
            {
                configForm.ShowDialog(this);
            }
        }
    }
}
