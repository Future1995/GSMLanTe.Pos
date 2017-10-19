using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using GSMLanTe.Model;

namespace GSMLanTe.POS.DAL
{
    public class GoodsDal
    {
        public DataSet GetGoodsAll()
        {
            //string sql = "SELECT * FROM `gsm_goods` ORDER BY `gsm_goods`.`goods_name` ASC, `gsm_goods`.`goods_sn` ASC";
            //string sql = "SELECT gsm_goods.goods_id, gsm_goods.goods_sn, gsm_goods.goods_name, gsm_goods.goods_number, gsm_goods.tienda_number, gsm_goods.shop_price, gsm_member_price.user_price, gsm_goods.goods_img FROM `gsm_goods`,`gsm_member_price` order by gsm_goods.goods_id asc";
            //string sql = "SELECT g.goods_id, g.goods_sn, g.goods_name, g.goods_number, g.tienda_number, g.shop_price, p.user_price, g.goods_img FROM `gsm_goods` as g inner join `gsm_member_price` as p on g.goods_id = p.goods_id where user_rank in (2,3 ) order by g.goods_id asc";
            string sql = "SELECT g.goods_id, g.goods_sn, g.goods_name, g.goods_number, g.tienda_number, g.shop_price, g.shop_price,p.user_price, p.user_price, g.goods_img FROM `gsm_goods` as g left join `gsm_member_price` as p on g.goods_id = p.goods_id order by g.goods_id asc";
            //string sql = "SELECT gsm_goods.goods_id, gsm_goods.goods_sn, gsm_goods.goods_name, gsm_goods.goods_number, gsm_goods.tienda_number, gsm_goods.shop_price, gsm_member_price.user_price, gsm_goods.goods_img FROM `gsm_goods`,`gsm_member_price` WHERE gsm_goods.goods_id=gsm_member_price.goods_id order by gsm_goods.goods_id asc LIMIT 24";
            //string sql = "SELECT * FROM `gsm_category` ORDER BY `gsm_category`.`cat_id` ASC";
            return MySqlHelper.ExecuteDataset(AppSetting.ServerConnectionString, sql);
        }

        public bool UpdateGoodsInfo(Goods goods)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update  gsm_goods as g,gsm_member_price as p set");
            sb.Append("g.goods_name=@GoodsName,");
            sb.Append("g.goods_number=@GoodsNumber,");
            sb.Append("g.tienda_number=@TiendaNumber,");
            sb.Append("g.shop_price=@ShopPrice,");
            sb.Append("g.user_price=@UserPrice,");
            sb.Append("g.goods_name=@GoodsName");
            sb.Append("where g.goods_id=p.goods.id and g.goods_id=@GoodsId and g.goods_sn=@GoodsNo");
            string sql = sb.ToString();
            MySqlParameter[] pars = {
                new MySqlParameter("@GoodsId",goods.Id),
                new MySqlParameter("@GoodsNo",goods.No),
                new MySqlParameter("@GoodsName",goods.Name),
                new MySqlParameter("@",goods.PCS),
                new MySqlParameter("@",goods.StorePCS),
                new MySqlParameter("@",goods.Price),
                new MySqlParameter("@",goods.VipPrice),
                new MySqlParameter("@",goods.WholesalePrice),
            };
            var result = MySqlHelper.ExecuteNonQuery(AppSetting.ServerConnectionString, sql, pars);

            return result > 0;
        }
        //public DataSet Getlogin()
        //{
        //string sql = "SELECT * FROM `gsm_goods` ORDER BY `gsm_goods`.`goods_name` ASC, `gsm_goods`.`goods_sn` ASC";
        //string sql = "SELECT gsm_goods.goods_id, gsm_goods.goods_sn, gsm_goods.goods_name, gsm_goods.goods_number, gsm_goods.tienda_number, gsm_goods.shop_price, gsm_member_price.user_price, gsm_goods.goods_img FROM `gsm_goods`,`gsm_member_price` WHERE gsm_goods.goods_id=gsm_member_price.goods_id order by gsm_goods.goods_id asc LIMIT 20";
        //string sql = "select * from person where 用户名 = '" + textBox1.Text + "' and  密码= '" + textBox2.Text + "'";
        // return MySqlHelper.ExecuteDataset(ConnectionSetting.ConnectionString, sql);
        //}
        // public DataSet Getsearch()
        //{
        //string sql = "SELECT gsm_goods.goods_id, gsm_goods.goods_sn, gsm_goods.goods_name, gsm_goods.goods_number, gsm_goods.tienda_number, gsm_goods.shop_price, gsm_member_price.user_price, gsm_goods.goods_img FROM `gsm_goods`where `goods_name`like  '%" + Form1.sechs.Text + "'%";
        // return MySqlHelper.ExecuteDataset(ConnectionSetting.ConnectionString, sql);
        //}
    }
}