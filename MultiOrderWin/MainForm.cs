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

namespace MultiOrderWin
{
    public partial class MainForm : Form
    {
        private MediaContext _db;
        private readonly LoginForm _form;

        public MainForm(LoginForm form)
        {
            InitializeComponent();
            _form = form;
            Closed += (sender, args) => _form.Close();
        }
    }
}
