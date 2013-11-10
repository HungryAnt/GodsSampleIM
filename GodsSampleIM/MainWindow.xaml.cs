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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gods.Fundation;
using GodsSampleIM.Models;

namespace GodsSampleIM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitImagePathConverter();
            InitData();
        }

        void InitImagePathConverter()
        {
            var imagePathConverter = FindResource("ImagePathConverter") as ImagePathConverter;
            imagePathConverter.ImageDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Photos");
        }

        private void InitData()
        {
            //if (DesignerProperties.GetIsInDesignMode(this))
            //{
                
            //}

            var person_1_1 = new ContactPerson("Person_1_1", "Hello world！", "head_01.png");
            var person_1_2 = new ContactPerson("Person_1_2", "", "head_02.png");
            var person_1_3 = new ContactPerson("Person_1_3", "", "head_03.png");

            var person_2_1 = new ContactPerson("Person_2_1", "喵~", "head_04.png");
            var person_2_2 = new ContactPerson("Person_2_2", "", "head_05.png");
            var person_2_3 = new ContactPerson("Person_2_3", "", "head_06.png");

            var contactCategories = new[]
                {
                    new ContactCategory("我的联系人")
                        {
                            ContactPersons = new List<ContactPerson>()
                                {
                                    person_1_1, person_1_2, person_1_3
                                }
                        },
                    new ContactCategory("朋友")
                        {
                            ContactPersons = new List<ContactPerson>()
                                {
                                    person_2_1, person_2_2, person_2_3
                                }
                        },
                    new ContactCategory("陌生人")
                };

            contactTree.ItemsSource = contactCategories;
            //categoryList.ItemsSource = contactCategories;
            
            
        }

        private void contactTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Pn_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Pn_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed &&
                e.ClickCount >= 2)
            {
                var person = contactTree.SelectedItem as ContactPerson;
                if (person != null)
                {
                    OneOneChartWindow chartWindow = new OneOneChartWindow();
                    chartWindow.DataContext = person;
                    chartWindow.Show();
                }
            }
        }
    }
}
