using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Map.Model
{
    public class RefreshBox
    {
        public static void RefreshComboBox(ComboBox comboBox)
        {
            int selectedIndex = comboBox.SelectedIndex;
            comboBox.SelectedIndex = -1;
            comboBox.Items.Refresh();
            comboBox.SelectedIndex = selectedIndex;
        }
    }
}
