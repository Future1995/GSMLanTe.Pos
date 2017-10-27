using GSMLanTe.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLanTe.POS.DAL
{
    public class MemberPriceDal
    {
        public bool UpdateMemberPrice(MemberPrice memberPrice)
        {

            string sql = @"INSERT into gsm_member_price(goods_id, user_rank, user_price)
                                values(@GoodsId, @UserRank, @UserPrice) 
                                ON DUPLICATE KEY UPDATE user_price = VALUES(user_price)";

            MySqlParameter[] pars = {
                new MySqlParameter("@GoodsId",memberPrice.GoodsId),
                new MySqlParameter("@UserRank",memberPrice.UserRank),
                new MySqlParameter("@UserPrice",memberPrice.UserPrice)
            };
            var result = MySqlHelper.ExecuteNonQuery(AppSetting.ServerConnectionString, sql, pars);

            return result > 0;
        }
    }
}
