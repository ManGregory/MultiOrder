﻿using System;
using System.Linq;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class OrderUserReport : Form
    {
        public OrderUserReport()
        {
            InitializeComponent();
            numYear.Value = DateTime.Now.Year;
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        /// <summary>
        /// Загрузка отчета из базы
        /// </summary>
        private void LoadReport()
        {            
            using (var db = new MediaContext())
            {
                var orderUsers =  DbHelper.GetUsersOrderInMonths((int) numYear.Value, db);
                gridReport.DataSource = orderUsers.ToList();
            }
        }
    }
}