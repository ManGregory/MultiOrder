using System.Windows.Forms;

namespace MultiOrderWin
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
            cmbPeriod.Items.AddRange(new []{"Неделя", "Месяц", "Семестр"});
            cmbPeriod.SelectedIndex = 0;
        }
    }
}
