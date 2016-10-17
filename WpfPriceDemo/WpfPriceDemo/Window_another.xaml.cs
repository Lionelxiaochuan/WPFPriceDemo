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
using System.Windows.Shapes;


namespace WpfPriceDemo
{
    /// <summary>
    /// Window_another.xaml 的交互逻辑
    /// </summary>
    public partial class Window_another : Window
    {
        public Window_another()
        {
            InitializeComponent();
            this.DataContext = goodsList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //假数据
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
            //创建数据源
            sizeList = goodsList.Select(s => s.Size).Distinct().Select(s => new Column(s)).ToList();


            //颜色栏
            //创建数据源
            colorList = goodsList.Select(s => s.ColorPic).Distinct().Select(s => new Column(s)).ToList();
                
            
            //提供数据源
            sizeItemsControl.ItemsSource = sizeList;
            colorItemsControl.ItemsSource = colorList;
        }
        /// <summary>
        /// 商品数据
        /// </summary>
        private List<Goods> goodsList;
        /// <summary>
        /// 尺码数据
        /// </summary>
        private List<Column> sizeList;
        /// <summary>
        /// 颜色数据
        /// </summary>
        private List<Column> colorList;

        private void CheckBox_SizeChecked(object sender, RoutedEventArgs e)
        {
            foreach (var sizeItem in sizeList)
            {
                //如果不是所点控件对应的数据源
                if (sizeItem.Data != ((sender as CheckBox).DataContext as Column).Data)
                {
                    sizeItem.IsChecked = false;
                }
            }

            //筛选
            //39号鞋 找到符合39号的所有颜色的鞋
            List<string> colorList = goodsList.Where(s => ((sender as CheckBox).DataContext as Column).Data ==  s.Size )
                                    .Select(s => s.ColorPic).ToList();
            //39号鞋  找到符合39号鞋的所有品牌
            foreach (var item in colorItemsControl.Items)
            {
                if (colorList.Contains((item as Column).Data))
                {
                    (item as Column).IsEnabled = true;
                }
                else
                {
                    (item as Column).IsEnabled = false;
                }
            }


            //要在这里夹加品牌的
        }

        private void CheckBox_colorCheck(object sender, RoutedEventArgs e)
        {
            foreach (var colorItem in colorList)
            {
                //如果不是所点控件对应的数据源
                if (colorItem.Data != ((sender as CheckBox).DataContext as Column).Data)
                {
                    colorItem.IsChecked = false;
                }
            }
            //筛选
            //符合这个颜色的鞋的所有鞋号
            List<string> sizeList = goodsList.Where(s => s.ColorPic == ((sender as CheckBox).DataContext as Column).Data)
                                    .Select(s => s.Size).ToList();

            foreach (var item in sizeItemsControl.Items)
            {
                
                if (sizeList.Contains((item as Column).Data))
                {
                    (item as Column).IsEnabled = true;
                }
                else
                {
                    (item as Column).IsEnabled = false;
                }
            }

            //要在这里加品牌的
        }
        /// <summary>
        /// unchecked 恢复color原始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_SizeUnchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in colorItemsControl.Items)
            {
                (item as Column).IsEnabled = true;
            }
        }

        /// <summary>
        /// unchecked 恢复size原始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_ColorUnchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in sizeItemsControl.Items)
            {
                (item as Column).IsEnabled = true;
            }
        }

        //要在品牌中加颜色的和尺码的
    }
}
