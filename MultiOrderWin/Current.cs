using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiOrderWin.Models;

namespace MultiOrderWin
{
    /// <summary>
    /// Класс для хранения информации по текущему пользователю
    /// </summary>
    static class Current
    {
        public static User CurrentUser { get; set; }
    }
}
