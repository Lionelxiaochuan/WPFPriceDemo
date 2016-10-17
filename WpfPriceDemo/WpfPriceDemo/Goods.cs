using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPriceDemo
{
    public class Goods     
    {
        public Goods()
        { }

        /// <summary>
        /// 构造
        /// </summary>
        public Goods(string id)
        {
            Id = id;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="size"></param>
        /// <param name="color"></param>
        public Goods(string id,string name, int price, string size, string color,int surplus)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            ColorPic = color;
            Surplus = surplus;
        }
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 颜色，物品图片
        /// </summary>
        public string ColorPic { get; set; }
        /// <summary>
        /// 存货
        /// </summary>
        public int Surplus { get; set; }


        
    }
}
