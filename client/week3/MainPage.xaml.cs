using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace week3
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Hi i will add this to test =.=
        public MainPage()
        {
            this.InitializeComponent();
            t_class.Items.Add("教务1班");
            t_class.Items.Add("教务2班");
            t_class.Items.Add("教务3班");
            t_class.Items.Add("教务4班");
            t_class.Items.Add("教务5班");

        }
        public bool isValidDate(int y, int m, int d) {
            bool leapyear = ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0);
            bool pass = true;
            if (y > 1000 && y <= 2014 && m > 0 && m <= 12 && d > 0 && d <= 31)
            {
                if (m == 4 || m == 6 || m == 9 || m == 11)
                    pass = (d <= 30);
                else if (leapyear && m == 2)
                    pass = (d <= 29);
                else if (!leapyear && m == 2)
                    pass = (d <= 28);

            }
            else
                pass = false;
            return pass;
        }
        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            t_name.Text = "";
            t_id.Text = "";
            t_class.SelectedIndex = -1;
            male.IsChecked = null;
            female.IsChecked = null;
            t_year.Text = "";
            t_month.Text = "";
            t_day.Text = "";

        }

        private void sure_Click(object sender, RoutedEventArgs e)
        {
           string pattern = @"^\d*$";
           if (!Regex.IsMatch(t_id.Text, pattern))
               t_id.Text = "";
           if (!(Regex.IsMatch(t_year.Text, pattern) &&
                Regex.IsMatch(t_year.Text, pattern) && Regex.IsMatch(t_year.Text, pattern)))
           {
               t_year.Text = "";
               t_month.Text = "";
               t_day.Text = "";
           }
           else if (!isValidDate(Convert.ToInt32(t_year.Text), Convert.ToInt32(t_month.Text), Convert.ToInt32(t_day.Text)))
           {
               t_year.Text = "";
               t_month.Text = "";
               t_day.Text = "";
           }

        }
        
    }
}
