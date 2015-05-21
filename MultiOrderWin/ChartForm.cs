using System.Threading;
using System.Windows.Forms;

namespace MultiOrderWin
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
            wb.Navigate("about:blank");
            cmbPeriod.Items.AddRange(new []{"Неделя", "Месяц", "Семестр"});            
            cmbPeriod.SelectedIndex = 0;
            Thread.Sleep(1000);
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            wb.DocumentText = DbHelper.GetOrderChart(cmbPeriod.SelectedIndex, edDate.Value);
        }

        private void edDate_ValueChanged(object sender, System.EventArgs e)
        {
            LoadChart();
        }

        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }
    }
}
