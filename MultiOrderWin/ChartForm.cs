using System.Windows.Forms;

namespace MultiOrderWin
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
            wb.Navigate("about:blank");
            wb.DocumentText = "";
            cmbPeriod.Items.AddRange(new []{"Неделя", "Месяц", "Семестр"});
            cmbPeriod.SelectedIndex = 0;
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
    }
}
