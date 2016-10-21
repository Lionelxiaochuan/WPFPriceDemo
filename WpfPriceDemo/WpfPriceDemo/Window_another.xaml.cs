using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                new Goods("39 2", "NB", 599, "39", "red", 1),

                new Goods("40 3", "NIKE", 599, "40", "black", 1),
                new Goods("40 4", "NB", 599, "40", "red", 1),
                new Goods("40 5", "NIKE", 599, "40", "blue", 1),
                new Goods("40 6", "NIKE", 599, "40", "darkred", 1),

                new Goods("41", "NB", 599, "41", "blackwhite", 1),
                new Goods("41", "NIKE", 599, "41", "red", 1),
                new Goods("41", "NIKE", 599, "41", "black", 1),
                new Goods("41", "NB", 599, "41", "red", 1),
                new Goods("41", "NIKE", 599, "41", "blue", 1),
                new Goods("41", "NB", 599, "41", "darkred", 1),

                new Goods("41", "NIKE", 599,"42", "blackwhite", 1),
                new Goods("41", "NB", 599, "42", "red", 1),
                new Goods("41", "NIKE", 599, "42", "black", 1),
                new Goods("41", "NB", 599, "42", "red", 1),
                new Goods("41", "NIKE", 599, "42", "blue", 1),
                new Goods("41", "NB", 599, "42", "darkred", 1),
                new Goods("41", "NB", 599, "42", "black", 1),
            };
            //鞋码栏
            //创建数据源
            var sizeColumn = new Column(goodsList.Select(s => s.Size).Distinct().Select(s => new Item(s)).ToList());

            //颜色栏
            //创建数据源
            var colorColumn = new Column(goodsList.Select(s => s.ColorPic).Distinct().Select(s => new Item(s)).ToList());

            //品牌栏
            //创建数据源
            var brandColumn = new Column(goodsList.Select(s => s.Brand).Distinct().Select(s => new Item(s)).ToList());
            columns = new List<Column>();
            columns.Add(sizeColumn);
            columns.Add(colorColumn);
            columns.Add(brandColumn);
            columnItemsControl.ItemsSource = columns;

            
        }
        
        


        /// <summary>
        /// 商品数据
        /// </summary>
        private List<Goods> goodsList;


        private List<Column> columns;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //被点击控件对应数据源的column
            Column parentColumn = ((sender as CheckBox).DataContext as Item).Parent;

            foreach (var Item in parentColumn.Items)
            {
                //如果不是所点控件对应的数据源
                if (Item.Data != ((sender as CheckBox).DataContext as Item).Data)
                {
                    Item.IsChecked = false;
                }
            }

            foreach (var column in columns)
            {
                //给不是选中的column做查询 
                if (column != parentColumn)
                {
                    
                }
            }
        }
    }
}
