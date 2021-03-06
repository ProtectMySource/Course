﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Educational_Program
{
    public partial class GUI_EP : Form
    {
        DBEntities db;
        ThongTinChung_CTDT load;

        int checkck;

        private List<string> mtc = new List<string>();
        private List<string> mtct_pc = new List<string>();
        private List<string> mtct_kt = new List<string>();
        private List<string> mtct_kn = new List<string>();
        private List<string> mtct_td = new List<string>();     

        string itemcontent = "";
        int itemposition = 0;

        int idctdt;

        BUS_EP bus = new BUS_EP();

        public GUI_EP(int id)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            string c = Directory.GetCurrentDirectory();
            wbCơsởvậtchất.Navigate(Path.Combine(c,"Educational Program\\EPCkeditor.html"));
            wbKhốilượngkt.Navigate(Path.Combine(c, "Educational Program\\EPCkeditor.html"));
            wbĐốitượng.Navigate(Path.Combine(c, "Educational Program\\EPCkeditor.html"));
            wbQuytrình.Navigate(Path.Combine(c, "Educational Program\\EPCkeditor.html"));


            btnMụctiêu_hủy.Visible = false;
            btnMụctiêu_sửa.Visible = false;
            idctdt = id;

            db = new DBEntities();
           
            loadCTDT();


            
            
            
        }
        //LOAD FORM
        private void loadCTDT()
        {
            load = db.ThongTinChung_CTDT.Single(x => x.Id == idctdt);
            //Thông tin chung
            txtTên.Text = load.TenChuongTrinh;
            txtTênEL.Text = load.TenTiengAnh;
            if (load.TrinhDo == "Đại học")
            {
                cboTrìnhđộ.SelectedIndex = 0;
            }
            else
            {
                cboTrìnhđộ.SelectedIndex = 1;
            }
            txtNgành.Text = load.Nganh;
            txtLoạiđàotạo.Text = load.LoaiHinh;

            //Mục tiêu đào tạo
            List<MucTieuDaoTao> muctieulst = db.MucTieuDaoTaos.ToList();
            for(int i=0;i<muctieulst.Count;i++)
            {
                if (muctieulst[i].Loai == "Chung")
                {
                    mtc.Add(muctieulst[i].NoiDung);
                }
                if (muctieulst[i].Loai == "Phẩm chất")
                {
                    mtct_pc.Add(muctieulst[i].NoiDung);
                }
                if (muctieulst[i].Loai == "Kiến thức")
                {
                    mtct_kt.Add(muctieulst[i].NoiDung);
                }
                if (muctieulst[i].Loai == "Kĩ năng")
                {
                    mtct_kn.Add(muctieulst[i].NoiDung);
                }
                if (muctieulst[i].Loai == "Thái độ")
                {
                    mtct_td.Add(muctieulst[i].NoiDung);
                }
            }
            ShowMuctieudaotao();

            //Nhiều mục
            nThờigian_năm.Value = (decimal)load.ThoiGianDaoTao.Value;
            nThangđiểm.Value = (decimal)load.ThangDiem;
                 
            //quản lí môn học
            loadCourseview();
            //load ckeditor
            
            

        }

        //SET UP MỤC LỤC
        private void ClickKehoachgiangday(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 5;
        }

        private void HoverMucluc(object sender, EventArgs e)
        {
            msMụclục.ShowDropDown();
        }

        private void ClickThôngtinchung(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 0;
        }

        private void ClickMuctieudaotao(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 1;
        }

        private void ClickThoigiandaotao(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        private void ClickKhoiluongkienthuc(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        private void ClickDoituongtuyensinh(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        private void ClickQuytrinhdaotao(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        private void ClickThangdiem(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        private void ClickNoidungchuongtrinh(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 4;
        }

        private void ClickHuongdanthuchien(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 6;
        }

        private void ClickDanhsachgiaovien(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 7;
        }

        private void ClickCosovatchat(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 8;
        }


        private void quảnLíMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 3;
        }


        //NÚT PREVIOUS
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tclMain.SelectedIndex > 0)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex - 1;
            }

        }

        //NÚT NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tclMain.SelectedIndex < 8)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex + 1;
            }
            if (checkck == 0)
            {
                object[] klktlst = new object[1] { load.KhoiLuongKienThucToanKhoa };
                object klkt = wbKhốilượngkt.Document.InvokeScript("setcontent", klktlst);
                object[] dtlst = new object[1] { load.DoiTuongTuyenSinh.ToString() };
                object dt = wbĐốitượng.Document.InvokeScript("setcontent", dtlst);
                object[] qtlst = new object[1] { load.QuyTrinhDaoTao.ToString() };
                object qt = wbQuytrình.Document.InvokeScript("setcontent", qtlst);
                object[] csvclst = new object[1] { load.CoSoVatChat.ToString() };
                object csvc = wbCơsởvậtchất.Document.InvokeScript("setcontent", csvclst);

                checkck = 1;
            }
        }

        //MỤC TIÊU ĐÀO TẠO
        //nút nhập
        //nút xóa
        private void btnĐàotạo_add_Click(object sender, EventArgs e)
        {
            //kiem tra chức năng
            if (btnĐàotạo_add.Text == ">>>")
            {
                //làm sạch view
                lwĐàotạo_view.Items.Clear();
                // lấy, kiểm tra dữ liệu
                string lv = cboĐàotạo_level.Text;

                if (lv != "")
                {
                    if (txtĐàotạo_content.Text != "")
                    {
                        if (lv == "Mục tiêu chung")
                        {
                            mtc.Add(txtĐàotạo_content.Text.Trim());
                        }
                        if (lv == "Mục tiêu cụ thể - Phẩm chất")
                        {
                            mtct_pc.Add(txtĐàotạo_content.Text.Trim());
                        }
                        if (lv == "Mục tiêu cụ thể - Kiến thức")
                        {
                            mtct_kt.Add(txtĐàotạo_content.Text.Trim());
                        }
                        if (lv == "Mục tiêu cụ thể - Kĩ năng")
                        {
                            mtct_kn.Add(txtĐàotạo_content.Text.Trim());
                        }
                        if (lv == "Mục tiêu cụ thể - Thái độ")
                        {
                            mtct_td.Add(txtĐàotạo_content.Text.Trim());
                        }
                        //show list view 
                        ShowMuctieudaotao();
                        txtĐàotạo_content.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền nội dung");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mục cần điền");
                }
            }
            //Xóa item
            if (btnĐàotạo_add.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {

                    //thuc hien xoa
                    DeleteItem(itemcontent, itemposition);

                    //vẽ lại view
                    lwĐàotạo_view.Items.Clear();
                    ShowMuctieudaotao();

                    //làm sạch content
                    txtĐàotạo_content.Text = "";

                    //visible 2 nút sửa, hủy
                    btnMụctiêu_sửa.Visible = false;
                    btnMụctiêu_hủy.Visible = false;
                    btnĐàotạo_add.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã xóa đối tượng thành công");
                }


            }



        }


        //MỤC TIÊU ĐÀO TẠO
        //Hàm vẽ list view
        private void ShowMuctieudaotao()
        {
            lwĐàotạo_view.Items.Add("+ Mục tiêu chung: ");
            for (int i = 0; i < mtc.Count; i++)
            {
                lwĐàotạo_view.Items.Add("\n     - " + mtc[i]);
            }
            lwĐàotạo_view.Items.Add("+ Mục tiêu cụ thể: ");
            lwĐàotạo_view.Items.Add("\n     1. Phẩm chất");
            for (int i = 0; i < mtct_pc.Count; i++)
            {
                lwĐàotạo_view.Items.Add("\n         1."+(i+1)+"  " + mtct_pc[i]);
            }
            lwĐàotạo_view.Items.Add("\n     2. Kiến thức");
            for (int i = 0; i < mtct_kt.Count; i++)
            {
                lwĐàotạo_view.Items.Add("\n         2." + (i + 1) + "  " + mtct_kt[i]);
            }
            lwĐàotạo_view.Items.Add("\n     3. Kĩ năng");
            for (int i = 0; i < mtct_kn.Count; i++)
            {
                lwĐàotạo_view.Items.Add("\n         3." + (i + 1) + "  " + mtct_kn[i]);
            }

            lwĐàotạo_view.Items.Add("\n     4. Thái độ");
            for (int i = 0; i < mtct_td.Count; i++)
            {
                lwĐàotạo_view.Items.Add("\n         4." + (i + 1) + "  " + mtct_td[i]);
            }
        }

        //MỤC TIÊU ĐÀO TẠO
        //load dữ liệu item dc chọn trong view
        private void lwĐàotạo_view_DoubleClick(object sender, EventArgs e)
        {
            if (lwĐàotạo_view.SelectedItems.Count == 1)
            {
                if ((lwĐàotạo_view.SelectedItem.ToString() != "+ Mục tiêu chung: ") && (lwĐàotạo_view.SelectedItem.ToString() != "+ Mục tiêu cụ thể: ") && (lwĐàotạo_view.SelectedItem.ToString() != "\n     1. Phẩm chất") && (lwĐàotạo_view.SelectedItem.ToString() != "\n     2. Kiến thức") && (lwĐàotạo_view.SelectedItem.ToString() != "\n     3. Kĩ năng") && (lwĐàotạo_view.SelectedItem.ToString() != "\n     4. Thái độ"))
                {
                    btnMụctiêu_sửa.Visible = true;
                    btnMụctiêu_hủy.Visible = true;
                    btnĐàotạo_add.Text = "Xóa";

                    itemposition = lwĐàotạo_view.SelectedIndex;

                    int s1 = 0;
                    int s2 = mtc.Count + 2;
                    int s3 = s2 + mtct_pc.Count + 1;
                    int s4 = s3 + mtct_kt.Count + 1;
                    int s5 = s4 + mtct_kn.Count + 1;

                    int[] arr = new[] { s1, s2, s3, s4, s5 };

                    int selectindex = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        if ((itemposition > arr[i]) && (itemposition < arr[i + 1]))
                        {
                            if (i == 0)
                            {
                                selectindex = 0;
                                txtĐàotạo_content.Text = lwĐàotạo_view.SelectedItem.ToString().Replace("\n     - ", "");
                                break;
                            }
                            if (i == 1)
                            {
                                selectindex = 1;
                                txtĐàotạo_content.Text = lwĐàotạo_view.SelectedItem.ToString().Replace("\n         ", "");                                
                                if (txtĐàotạo_content.Text.Substring(3, 1) == " ")
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(5, txtĐàotạo_content.Text.Length - 5);
                                }
                                else
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(6, txtĐàotạo_content.Text.Length - 6);
                                }
                                break;
                            }
                            if (i == 2)
                            {
                                selectindex = 2;
                                txtĐàotạo_content.Text = lwĐàotạo_view.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtĐàotạo_content.Text.Substring(3, 1) == " ")
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(5, txtĐàotạo_content.Text.Length - 5);
                                }
                                else
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(6, txtĐàotạo_content.Text.Length - 6);
                                }
                                break;
                            }
                            if (i == 3)
                            {
                                selectindex = 3;
                                txtĐàotạo_content.Text = lwĐàotạo_view.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtĐàotạo_content.Text.Substring(3, 1) == " ")
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(5, txtĐàotạo_content.Text.Length - 5);
                                }
                                else
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(6, txtĐàotạo_content.Text.Length - 6);
                                }
                                break;
                            }

                        }
                        else
                        {
                            if (i == 3)
                            {
                                selectindex = 4;
                                txtĐàotạo_content.Text = lwĐàotạo_view.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtĐàotạo_content.Text.Substring(3, 1) == " ")
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(5, txtĐàotạo_content.Text.Length - 5);
                                }
                                else
                                {
                                    txtĐàotạo_content.Text = txtĐàotạo_content.Text.Substring(6, txtĐàotạo_content.Text.Length - 6);
                                }
                            }
                        }
                    }

                    itemcontent = txtĐàotạo_content.Text.Trim();
                    
                    cboĐàotạo_level.SelectedIndex = selectindex;
                }

            }
        }

        //MỤC TIÊU ĐÀO TẠO
        //Nút hủy edit/xóa trong view
        private void btnMụctiêu_hủy_Click(object sender, EventArgs e)
        {
            btnĐàotạo_add.Text = ">>>";
            btnMụctiêu_sửa.Visible = false;
            btnMụctiêu_hủy.Visible = false;

            txtĐàotạo_content.Text = "";
        }

        //MỤC TIÊU ĐÀO TẠO
        //Thuật toán xóa
        private void DeleteItem(string item, int local)
        {
            int s1 = 0;
            int s2 = mtc.Count + 2;
            int s3 = s2 + mtct_pc.Count + 1;
            int s4 = s3 + mtct_kt.Count + 1;
            int s5 = s4 + mtct_kn.Count + 1;

            int[] arr = new[] { s1, s2, s3, s4, s5 };

            for (int i = 0; i < 4; i++)
            {
                if ((local > arr[i]) && (local < arr[i + 1]))
                {
                    if (i == 0)
                    {
                        mtc.Remove(item);
                        break;
                    }
                    if (i == 1)
                    {
                        mtct_pc.Remove(item);
                        break;
                    }
                    if (i == 2)
                    {
                        mtct_kt.Remove(item);
                        break;
                    }
                    if (i == 3)
                    {
                        mtct_kn.Remove(item);
                        break;
                    }

                }
                else
                {
                    if (i == 3)
                    {
                        mtct_td.Remove(item);
                    }
                }
            }

        }


        //MỤC TIÊU ĐÀO TẠO
        //Thuật toán sửa item trong view
        private void EditItem(string item, int position, ComboBox cbo)
        {

            // tìm ra list cũ
            int s1 = 0;
            int s2 = mtc.Count + 2;
            int s3 = s2 + mtct_pc.Count + 1;
            int s4 = s3 + mtct_kt.Count + 1;
            int s5 = s4 + mtct_kn.Count + 1;

            int[] arr = new[] { s1, s2, s3, s4, s5 };

            List<List<string>> sum_arr = new List<List<string>> { mtc, mtct_pc, mtct_kt, mtct_kn, mtct_td };

            List<string> work = new List<string>();

            int editint = 0;

            for (int g = 0; g < 4; g++)
            {
                if ((position > arr[g]) && (position < arr[g + 1]))
                {
                    work = sum_arr[g];
                    editint = g;
                    break;
                }
                else
                {
                    if (g == 3)
                    {
                        work = sum_arr[g + 1];
                        editint = g + 1;
                    }
                }
            }

            //Trường hợp edit list cũ
            if ((cbo.SelectedIndex == editint) && (editint == 0))
            {
                work[position - 1] = txtĐàotạo_content.Text.Trim();
            }
            else
            {
                if ((cbo.SelectedIndex == editint) && (editint == 1))
                {
                    work[position - (3 + mtc.Count)] = txtĐàotạo_content.Text.Trim();
                }
                else
                {
                    if ((cbo.SelectedIndex == editint) && (editint == 2))
                    {
                        work[position - (4 + mtc.Count + mtct_pc.Count)] = txtĐàotạo_content.Text.Trim();
                    }
                    else
                    {
                        if ((cbo.SelectedIndex == editint) && (editint == 3))
                        {
                            work[position - (5 + mtc.Count + mtct_pc.Count + mtct_kt.Count)] = txtĐàotạo_content.Text.Trim();
                        }
                        else
                        {
                            if ((cbo.SelectedIndex == editint) && (editint == 4))
                            {
                                work[position - (6 + mtc.Count + mtct_pc.Count + mtct_kt.Count + mtct_kn.Count)] = txtĐàotạo_content.Text.Trim();
                            }
                            
                        }
                    }
                }

            }

            //Trường hợp edit list khác
            if (cbo.SelectedIndex != editint)
            {
                DeleteItem(itemcontent, itemposition);
                sum_arr[cbo.SelectedIndex].Add(txtĐàotạo_content.Text.Trim());

            }



        }

        //MỤC TIÊU ĐÀO TẠO
        //Nút sửa
        private void btnMụctiêu_sửa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtĐàotạo_content.Text != "")
                {
                    //Xóa sach item trong view
                    lwĐàotạo_view.Items.Clear();

                    //Chạy thuật toán edit
                    EditItem(itemcontent, itemposition, cboĐàotạo_level);

                    //xóa content
                    txtĐàotạo_content.Text = "";

                    //vẽ lại view
                    ShowMuctieudaotao();

                    //visible 2 nút sửa, hủy           
                    btnMụctiêu_sửa.Visible = false;
                    btnMụctiêu_hủy.Visible = false;
                    btnĐàotạo_add.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã sửa đối tượng thành công");
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }
               
            }



        }

        
       

        //QUẢN LÍ MÔN HỌC
        //Mở giao diện quản lí môn học
        //Lấy course từ giao diện quán lí môn học
        private void btnQuanlimonhoc_add_Click(object sender, EventArgs e)
        {
            // Mở giao diện
            if (nThờigian_năm.Value != 0)
            {
                GUI_Course a = new GUI_Course(0, idctdt, (int)(nThờigian_năm.Value*2));
                a.ShowDialog();
                loadCourseview();
            }
            else
            {
                MessageBox.Show("Thời gian đào tạo chưa được cập nhật");
            }
                
            
        }

        //QUẢN LÍ MÔN HỌC
        //Load lại bảng môn học

        private void loadCourseview()
        {
            DBEntities db = new DBEntities();
            List<SP_MONHOC_VIEW_Result> arr = db.SP_MONHOC_VIEW(idctdt).ToList();
            dgwQuảnlí.DataSource = arr;

            dgwQuảnlí.Columns[0].Visible = false;

            dgwQuảnlí.Columns[1].HeaderText = "Mã môn học";
            dgwQuảnlí.Columns[2].HeaderText = "Mã Chương trình đào tạo";
            dgwQuảnlí.Columns[3].HeaderText = "Tên môn học";
            dgwQuảnlí.Columns[4].HeaderText = "Tên tiếng Anh";
            dgwQuảnlí.Columns[5].HeaderText = "Loại kiến thức";
            dgwQuảnlí.Columns[6].HeaderText = "Số tín chỉ";
            dgwQuảnlí.Columns[7].HeaderText = "Học kỳ giảng dạy";
            dgwQuảnlí.Columns[8].HeaderText = "Giảng viên phụ trách";
            dgwQuảnlí.Columns[9].HeaderText = "Nội dung vắn tắt";
            dgwQuảnlí.Columns[10].HeaderText = "Số giờ lý thuyết";
            dgwQuảnlí.Columns[11].HeaderText = "Số giờ thực hành";

            dgwQuảnlí.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //QUẢN LÍ MÔN HỌC
        //Mở gian diện quản lí môn học khi edit
        private void dgwQuảnlí_DoubleClick(object sender, EventArgs e)
        {
            if (dgwQuảnlí.SelectedRows.Count == 1)
            {
                var rs = dgwQuảnlí.SelectedRows[0];
                var cell = rs.Cells["Id"];
                int id = (int)cell.Value;
                if (nThờigian_năm.Value!=0)
                {
                    GUI_Course a = new GUI_Course(id, idctdt, (int)(nThờigian_năm.Value * 2));
                    a.ShowDialog();
                    loadCourseview();
                }
                else
                {
                    MessageBox.Show("Thời gian đào tạo chưa được cập nhật");
                }
                
            }
        }

        //NHIỀU MỤC
        //Xử lí khi người dùng thay đổi thời gian đào tạo của chương trình
        private void nThờigian_năm_ValueChanged(object sender, EventArgs e)
        {            
            string rs = bus.checkThoigiandaotao((double)nThờigian_năm.Value,idctdt);
            if (rs == "false")
            {
               DialogResult msrs =  MessageBox.Show("Nếu thay đổi đối tượng này, học kì giảng dạy của các môn học sẽ đưa về Học kì 1, đồng thời tất cả quan hệ môn tiên quyết cũng bị hủy. Bạn có chắc chắn muốn thực hiện điều này không?", "Cảnh báo", MessageBoxButtons.YesNo);
               if (msrs == System.Windows.Forms.DialogResult.Yes)
               {
                   bus.handleThoigiandaotao(idctdt);
               }
               nThờigian_họckì.Value = (int)(nThờigian_năm.Value * 2);
            }
            else
            {
                nThờigian_họckì.Value = (int)(nThờigian_năm.Value * 2);
            }
        }

        //Edit CTDT
        private void btnSave_Click(object sender, EventArgs e)
        {
            load.TenChuongTrinh = txtTên.Text;
            load.TenTiengAnh = txtTênEL.Text;
            load.TrinhDo = cboTrìnhđộ.Text;
            load.Nganh = txtNgành.Text ;
            load.LoaiHinh = txtLoạiđàotạo.Text;

            //Mục tiêu đào tạo
            db.SP_MUCTIEUDAOTAO_DEL(idctdt);
            for (int i = 0; i < mtc.Count; i++)
            {
                MucTieuDaoTao add = new MucTieuDaoTao();
                add.Loai = "Chung";
                add.NoiDung = mtc[i];
                add.STT = i+1;
                add.ChuongTrinhDaoTao_Id = idctdt;
                db.MucTieuDaoTaos.Add(add);
                db.SaveChanges();
            }
            for (int i = 0; i < mtct_pc.Count; i++)
            {
                MucTieuDaoTao add = new MucTieuDaoTao();
                add.Loai = "Phẩm chất";
                add.NoiDung = mtct_pc[i];
                add.STT = i + 1;
                add.ChuongTrinhDaoTao_Id = idctdt;
                db.MucTieuDaoTaos.Add(add);
                db.SaveChanges();
            }
            for (int i = 0; i < mtct_kt.Count; i++)
            {
                MucTieuDaoTao add = new MucTieuDaoTao();
                add.Loai = "Kiến thức";
                add.NoiDung = mtct_kt[i];
                add.STT = i + 1;
                add.ChuongTrinhDaoTao_Id = idctdt;
                db.MucTieuDaoTaos.Add(add);
                db.SaveChanges();
            }
            for (int i = 0; i < mtct_kn.Count; i++)
            {
                MucTieuDaoTao add = new MucTieuDaoTao();
                add.Loai = "Kĩ năng";
                add.NoiDung = mtct_kn[i];
                add.STT = i + 1;
                add.ChuongTrinhDaoTao_Id = idctdt;
                db.MucTieuDaoTaos.Add(add);
                db.SaveChanges();
            }
            for (int i = 0; i < mtct_td.Count; i++)
            {
                MucTieuDaoTao add = new MucTieuDaoTao();
                add.Loai = "Thái độ";
                add.NoiDung = mtct_td[i];
                add.STT = i + 1;
                add.ChuongTrinhDaoTao_Id = idctdt;
                db.MucTieuDaoTaos.Add(add);
                db.SaveChanges();
            }

            //Nhiều mục
            load.ThoiGianDaoTao = (double)nThờigian_năm.Value;
            load.ThangDiem = (int)nThangđiểm.Value;
            object klkt = this.wbKhốilượngkt.Document.InvokeScript("getcontent").ToString();
            load.KhoiLuongKienThucToanKhoa = klkt.ToString();
            object dt = wbĐốitượng.Document.InvokeScript("getcontent");
            load.DoiTuongTuyenSinh = dt.ToString();
            object qt = wbQuytrình.Document.InvokeScript("getcontent");
            load.QuyTrinhDaoTao = qt.ToString();

            //quản lí môn học
            //cở sở vật chất
            object csvc = wbCơsởvậtchất.Document.InvokeScript("getcontent");
            load.CoSoVatChat = csvc.ToString();
            db.SaveChanges();
            MessageBox.Show("Chỉnh sửa thành công");
            this.Close();
        }

        private void btnNhieumuc_Click(object sender, EventArgs e)
        {
            
        }
       

        
    }
}
