using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HoursTracking.ViewModel;

namespace HoursTracking.View
{
    /// <summary>
    /// Логика взаимодействия для AtestationPage.xaml
    /// </summary>
    public partial class AtestationPage : Page
    {
        public static AtestationPage Instance { get; private set;}
        public AtestationPage()
        {
            InitializeComponent();
            Instance = this;
            DataContext = new AtestationViewModel();        
        }
    }
}
