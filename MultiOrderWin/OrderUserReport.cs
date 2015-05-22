using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    public partial class OrderUserReport : Form
    {
        public OrderUserReport()
        {
            InitializeComponent();
            txtSign.Text = "Иванов А.А.";
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
                reportViewer1.LocalReport.SetParameters(
                    new[]
                    {
                        new ReportParameter("Year", numYear.Value.ToString()),
                        new ReportParameter("Sign", txtSign.Text) 
                    });
                OrderUserBindingSource.DataSource = orderUsers.ToList();
                reportViewer1.RefreshReport();
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
