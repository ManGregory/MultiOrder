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
            // установка инициализатора для базы
            Database.SetInitializer(new MediaContextInitializer());
            txtLogin.Focus();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            // проверка прав пользователя
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

        /// <summary>
        /// Поиск пользователя в базе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь</returns>
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

        /// <summary>
        /// Вызов форма для отображения подключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, System.EventArgs e)
        {
            using (var configForm = new ConfigForm())
            {
                configForm.ShowDialog(this);
            }
        }
    }
}
