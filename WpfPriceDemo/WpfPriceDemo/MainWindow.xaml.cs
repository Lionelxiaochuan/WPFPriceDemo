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

namespace WpfPriceDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            goodsList = new List<Goods>
            {
                new Goods("39 1", "NIKE", 599, "39", "blackwhite", 1),
                new Goods("39 2", "NIKE", 599, "39", "red", 1),

                new Goods("40 3", "NIKE", 599, "40", "black", 1),
                new Goods("40 4", "NIKE", 599, "40", "red", 1),
                new Goods("40 5", "NIKE", 599, "40", "blue", 1),
                new Goods("40 6", "NIKE", 599, "40", "darkred", 1),

                new Goods("41", "NIKE", 599, "41", "blackwhite", 1),
                new Goods("41", "NIKE", 599, "41", "red", 1),
                new Goods("41", "NIKE", 599, "41", "black", 1),
                new Goods("41", "NIKE", 599, "41", "red", 1),
                new Goods("41", "NIKE", 599, "41", "blue", 1),
                new Goods("41", "NIKE", 599, "41", "darkred", 1),

                new Goods("41", "NIKE", 599,"42", "blackwhite", 1),
                new Goods("41", "NIKE", 599, "42", "red", 1),
                new Goods("41", "NIKE", 599, "42", "black", 1),
                new Goods("41", "NIKE", 599, "42", "red", 1),
                new Goods("41", "NIKE", 599, "42", "blue", 1),
                new Goods("41", "NIKE", 599, "42", "darkred", 1),
                new Goods("41", "NIKE", 599, "42", "black", 1),
            };


            //鞋码栏
            List<string> sizeList = (from goods
                                    in goodsList
                                    select goods.Size).Distinct().ToList();
            sizeList = goodsList.Select(s => s.Size).Distinct().ToList();


            foreach (var item in sizeList)
            {
                var checkBox = new CheckBox { Content = item.ToString(), Style = (Style)this.TryFindResource("CheckBoxTaobaoStyle") };
                checkBox.Checked += CheckBox_CheckedSize;
                checkBox.Unchecked += CheckBox_SizeUnchecked;
                sizeWrapPanel.Children.Add(checkBox);
            }


            //颜色栏
            List<string> colorList = (from goods in goodsList select goods.ColorPic).Distinct().ToList();

            foreach (var item in colorList)
            {
                var checkBox = new CheckBox { Content = item.ToString(), Style = (Style)this.TryFindResource("CheckBoxTaobaoStyle") };
                checkBox.Checked += CheckBox_ColorChecked;
                checkBox.Unchecked += CheckBox_ColorUnchecked;
                colorWrapPanel.Children.Add(checkBox);
            }
            ///动态生成是后台做的
            ///
        }

        private void CheckBox_ColorUnchecked(object sender, RoutedEventArgs e)
        {
            //遍历容器中的子控件
            foreach (var control in sizeWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                box.IsEnabled = true;
            }
        }

        private void CheckBox_SizeUnchecked(object sender, RoutedEventArgs e)
        {
            //遍历容器中的子控件
            foreach (var control in colorWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                box.IsEnabled = true;
            }
        }

        private void CheckBox_ColorChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.Source;
            //red为查询条件
            //在goodsList中查询red都有哪些鞋
            List<string> sizeList = (from item 
                                     in goodsList
                                     where item.ColorPic == checkBox.Content.ToString()
                                     select item.Size).Distinct().ToList();
            // 清除其他控件的checked状态
            foreach (var control in colorWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                if (control == checkBox)
                {
                    box.IsChecked = true;
                }
                else
                {
                    box.IsChecked = false;
                }
            }
            // 用以筛选
            foreach (var control in sizeWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                //筛选
                if (sizeList.Contains(box.Content.ToString()))
                {
                    box.IsEnabled = true;
                }
                else
                {
                    box.IsEnabled = false;
                }
            }


        }

        private void CheckBox_CheckedSize(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.Source;
            //以39号鞋为查询条件

            //在goodsList中查询39鞋都有哪些颜色，有颜色的
            List<string> colorList = (from item 
                                      in goodsList
                                      where item.Size == checkBox.Content.ToString()
                                      select item.ColorPic).Distinct().ToList();
            // 清除其他控件的checked状态
            foreach (var control in sizeWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                if (control == checkBox)
                {
                    box.IsChecked = true;
                }
                else
                {
                    box.IsChecked = false;
                }
            }
            //用以筛选
            foreach (var control in colorWrapPanel.Children)
            {
                CheckBox box = (CheckBox)control;
                //筛选
                if (colorList.Contains(box.Content.ToString()))
                {
                    box.IsEnabled = true;
                }
                else
                {
                    box.IsEnabled = false;
                }
            }
        }


        private List<Goods> goodsList;
    }
}
