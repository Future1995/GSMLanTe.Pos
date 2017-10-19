using GSMLanTe.Model;
using GSMLanTe.POS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLanTe.POS.BLL
{
    public class GoodsService
    {
        GoodsDal dal = new GoodsDal();
        public DataSet GetGoodsAll()
        {
            return dal.GetGoodsAll();
        }
        public bool UpdateGoodsInfo(Goods goods) 
        {
         return   dal.UpdateGoodsInfo(goods);
        }
    }
}
