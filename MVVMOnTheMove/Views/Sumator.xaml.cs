using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVMOnTheMove.ViewModels;

namespace MVVMOnTheMove.Views
{
    /// <summary>
    /// Interaction logic for Sumator.xaml
    /// </summary>
    public partial class Sumator : UserControl
    {
        public Sumator()
        {
            InitializeComponent();
        }

        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModelSumator).CalculateResult(tbFirst.Text, tbSecond.Text, '-');
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModelSumator).CalculateResult(tbFirst.Text, tbSecond.Text, '+');
       

        }
    }
}
