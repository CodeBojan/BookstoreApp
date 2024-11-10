using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookstore.Utility
{
    public static class GUIUtility
    {
        public static void HideCurrentShowNewWindow(Window currentForm, Window newForm)
        {
            currentForm.Hide();
            newForm.Show();
            newForm.Closed += (s, e) => currentForm.Show();
        }
    }
}
