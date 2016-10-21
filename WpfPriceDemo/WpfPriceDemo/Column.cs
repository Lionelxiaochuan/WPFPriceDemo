using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 栏目的数据抽象
/// </summary>
namespace WpfPriceDemo
{
    public class Column
    {
        public Column() { }

        public Column(List<Item> items, string name = "")
        {
            Items = items;

            foreach (var item in items)
            {
                item.Parent = this;
            }
        }
        /// <summary>
        /// 所有子项
        /// </summary>
        public List<Item> Items { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        //private List<Item> items;

        //private string name;
    }
}
