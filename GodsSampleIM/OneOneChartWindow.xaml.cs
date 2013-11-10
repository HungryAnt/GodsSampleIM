using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GodsSampleIM.Models;

namespace GodsSampleIM
{
    /// <summary>
    /// OneOneChartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OneOneChartWindow : Window
    {
        public OneOneChartWindow()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.DataContext = new ContactPerson("Gods_巨蚁", "I love coding");
            }
        }
    }
}
