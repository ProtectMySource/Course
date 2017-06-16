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

        //kiem tra khi thời gian đào tạo thay đổi
        public string checkThoigiandaotao(double newtime, int ctdt)
        {
            DBEntities db = new DBEntities();
            ThongTinChung_CTDT find = db.ThongTinChung_CTDT.Single(x => x.ChuongTrinhDaoTao_Id == ctdt);
            List<MonHoc> findcourse = db.MonHocs.Where(x => x.ChuongTrinhDaoTao_Id == ctdt).ToList();
            if ((newtime != find.ThoiGianDaoTao)&&(findcourse.Count>0))
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }

        // xu li khi thoi gian thay doi
        public void handleThoigiandaotao(int ctdt)
        {
            DBEntities db = new DBEntities();
            db.SP_THOIGIANDAOTAO_HANDLE(ctdt);
        }


        
        
    }
}
