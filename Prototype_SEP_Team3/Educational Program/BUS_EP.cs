using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Educational_Program
{
    class BUS_EP
    {
        //kiểm tra thời gian đào tạo
        public bool getThoigiandaotao(double newtime,int ctdt)
        {
            DBEntities db = new DBEntities();
            ThongTinChung_CTDT check = db.ThongTinChung_CTDT.Single(x=>x.ChuongTrinhDaoTao_Id==ctdt);
            if (newtime == check.ThoiGianDaoTao)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Xử lí khi thời gian đào tạo 
        public void handleThoigiandaotao(double newtime, int ctdt)
        {

        }
    }
}
