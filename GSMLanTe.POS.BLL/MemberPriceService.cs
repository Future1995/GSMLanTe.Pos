using GSMLanTe.Model;
using GSMLanTe.POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLanTe.POS.BLL
{
    public class MemberPriceService
    {
        MemberPriceDal memberPriceDal = new MemberPriceDal();
        public bool UpdateMemberPrice(MemberPrice memberPrice)
        {
            return memberPriceDal.UpdateMemberPrice(memberPrice);
        }
    }
}
