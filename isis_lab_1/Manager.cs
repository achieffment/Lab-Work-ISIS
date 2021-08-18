using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace isis_lab_1
{
    class Manager
    {
        public static Frame MainFrame { get; set; }

        public static bool isVisibleAdminPage = true;

        public static bool isVisibleServicesPage = true;

        public static MainWindow mainWindow;
    }
}
