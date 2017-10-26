using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLanTe.Model
{
    public class Goods
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int PCS  { get; set; }
        /// <summary>
        /// 商店库存
        /// </summary>
        public int StorePCS { get; set; }
        public float Price { get; set; }
        public float VipPrice { get; set; }
        /// <summary>
        /// 批发价
        /// </summary>
        public float? WholesalePrice { get; set; }
    }
}
