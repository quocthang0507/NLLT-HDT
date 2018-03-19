using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class Program
	{
		enum Menu
		{
			Thoat,
			Tim_Max_Min_TB_TP,
			Tim_Min_TB_KH,
			Tim_Max_Min_TB_Duong,
			SapXep_KH,
			SapXep_TP,
			Tim_Thang_KhongTB,
			Tim_KH_GT,
			Xoa_KH_Tinh,
			Them_SDT_CMND,
			Tim_Max_Min_Ngay_KH,
			HienThi_TheoMau
		}
		static void Main(string[] args)
		{
			QuanLyThueBao QuanLy_TB = new QuanLyThueBao();
			QuanLy_TB.NhapTuFile();
			//Khởi tạo dùng cho lưu kết quả
			List<string> kq = new List<string>();
			List<KhachHang> kq_kh = new List<KhachHang>();
			string[] ds;
			List<int> thang;
			string tenTinh;
			//Xuất menu
			while (true)
			{
				Console.Clear();
				Console.WriteLine("".PadRight(30) + "HE THONG CHUC NANG");
				Console.WriteLine("0. Thoat khoi chuong trinh");
				Console.WriteLine("1. Tim thanh pho co nhieu thue bao nhat, co it thue bao nhat.");
				Console.WriteLine("2. Tim thue bao so huu it so dien thoai nhat.");
				Console.WriteLine("3. Tim duong co it thue bao, nhieu thue bao nhat.");
				Console.WriteLine("4. Sap xep khach hang tang giam theo ho ten, so luong so dien thoai so huu.");
				Console.WriteLine("5. Hien thi danh sach cac thanh pho theo chieu tang, giam cua so luong thue bao.");
				Console.WriteLine("6. Tim thang khong co thue bao nao dang ky.");
				Console.WriteLine("7. Tim tat ca cac khach hang theo gioi tinh.");
				Console.WriteLine("8. Xoa tat ca khach hang thuoc mot tinh nao do.");
				Console.WriteLine("9. Tat ca khach hang nao sinh thang 1 thi duoc tang them mot so dien thoai moi co so la cmnd.");
				Console.WriteLine("10. Tim ngay co nhieu khach hang dang ky nhat, it nguoi dang ky nhat.");
				Console.WriteLine("11. Thong ke va hien thi du lieu theo tung tinh va moi tinh hien thi theo thanh pho theo mau");
				Console.Write("\nNhap so thu tu chuc nang: ");
				Menu menu = (Menu)int.Parse(Console.ReadLine());
				Console.Clear();
				//Xử lý menu
				switch (menu)
				{
					case Menu.Thoat:
						Console.WriteLine("0. Thoat khoi chuong trinh");
						return;
					case Menu.Tim_Max_Min_TB_TP:
						Console.WriteLine("1. Tim thanh pho co nhieu thue bao nhat, co it thue bao nhat.");
						Console.WriteLine("Thanh pho co nhieu thue bao nhat la: ");
						kq = QuanLy_TB.Tim_DS_ThanhPho_NhieuThueBao();
						foreach (var item in kq)
							Console.WriteLine(item);
						kq = QuanLy_TB.Tim_DS_ThanhPho_ItThueBao();
						Console.WriteLine("Thanh pho co it thue bao nhat la: ");
						foreach (var item in kq)
							Console.WriteLine(item);
						break;
					case Menu.Tim_Min_TB_KH:
						Console.WriteLine("2. Tim thue bao so huu it so dien thoai nhat.");
						Console.WriteLine("Danh sach chu thue bao so huu it so dien thoai nhat:");
						kq_kh = QuanLy_TB.Tim_TB_ItDienThoai();
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						break;
					case Menu.Tim_Max_Min_TB_Duong:
						Console.WriteLine("3. Tim duong co it thue bao, nhieu thue bao nhat.");
						Console.WriteLine("Con duong co nhieu thue bao nhat la: ");
						kq = QuanLy_TB.Tim_DS_ConDuong_NhieuThueBao();
						foreach (var item in kq)
							Console.WriteLine(item);
						kq = QuanLy_TB.Tim_DS_ConDuong_ItThueBao();
						Console.WriteLine("Con duong co it thue bao nhat la: ");
						foreach (var item in kq)
							Console.WriteLine(item);
						break;
					case Menu.SapXep_KH:
						Console.WriteLine("4. Sap xep khach hang tang giam theo ho ten, so luong so dien thoai so huu.");
						Console.WriteLine("Danh sach theo chieu tang cua ten");
						QuanLy_TB.SapXep_Tang_Ten();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("Danh sach theo chieu giam cua ten");
						QuanLy_TB.SapXep_Giam_HoTen();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("Danh sach theo chieu tang cua so luong thue bao");
						QuanLy_TB.SapXep_Tang_SoThueBao();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("Danh sach theo chieu giam cua so luong thue bao");
						QuanLy_TB.SapXep_Giam_SoThueBao();
						Console.WriteLine(QuanLy_TB.DS_KH);
						break;
					case Menu.SapXep_TP:
						Console.WriteLine("5. Hien thi danh sach cac thanh pho theo chieu tang, giam cua so luong thue bao.");
						ds = QuanLy_TB.SapXep_TP_Tang_SoThueBao();
						Console.WriteLine("Danh sach cac thanh pho theo chieu tang dan so thue bao:");
						foreach (var item in ds)
							Console.WriteLine(item);
						ds = QuanLy_TB.SapXep_TP_Giam_SoThueBao();
						Console.WriteLine("Danh sach cac thanh pho theo chieu tang dan so thue bao:");
						foreach (var item in ds)
							Console.WriteLine(item);
						break;
					case Menu.Tim_Thang_KhongTB:
						Console.WriteLine("6. Tim thang khong co thue bao nao dang ky.");
						Console.Write("Cac thang khong co thue bao nao dang ky la: ");
						thang = QuanLy_TB.Tim_Thang_KhongCoTB();
						foreach (var item in thang)
							Console.Write(item + "\t");
						break;
					case Menu.Tim_KH_GT:
						Console.WriteLine("7. Tim tat ca cac khach hang theo gioi tinh.");
						Console.WriteLine("Danh sach khach hang NAM:");
						kq_kh = QuanLy_TB.Tim_DS_KhachHang_GT((GioiTinh)0);
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						Console.WriteLine("\nDanh sach khach hang NU:");
						kq_kh = QuanLy_TB.Tim_DS_KhachHang_GT((GioiTinh)1);
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						break;
					case Menu.Xoa_KH_Tinh:
						Console.WriteLine("8. Xoa tat ca khach hang thuoc mot tinh nao do.");
						Console.Write("Nhap ten tinh can xoa : ");
						tenTinh = " " + Console.ReadLine();
						Console.WriteLine("Danh sach khach hang ban dau: ");
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.WriteLine("\nDanh sach khach hang moi: ");
						QuanLy_TB.Xoa_KH_Tinh(tenTinh);
						Console.WriteLine(QuanLy_TB.DS_KH);
						break;
					case Menu.Them_SDT_CMND:
						Console.WriteLine("9. Tat ca khach hang nao sinh thang 1 thi duoc tang them mot so dien thoai moi co so la cmnd.");
						QuanLy_TB.Them_SoDienThoai_NeuSinhThang1();
						Console.WriteLine(QuanLy_TB.DS_TB);
						break;
					case Menu.Tim_Max_Min_Ngay_KH:
						Console.WriteLine("10. Tim ngay co nhieu khach hang dang ky nhat, it nguoi dang ky nhat.");
						Console.WriteLine("Ngay co nhieu nguoi dang ky nhat");
						foreach (var item in QuanLy_TB.Tim_NgayDK_Nhieu())
							Console.Write(item + "\t");
						Console.WriteLine("\nNgay co it nguoi dang ky nhat");
						foreach (var item in QuanLy_TB.Tim_NgayDK_It())
							Console.Write(item + "\t");
						break;
					case Menu.HienThi_TheoMau:
						Console.WriteLine("11. Thong ke va hien thi du lieu theo tung tinh va moi tinh hien thi theo thanh pho theo mau");
						kq = QuanLy_TB.Tim_DS_Tinh();
						foreach (var item in kq)
						{
							Console.WriteLine(QuanLy_TB.Xuat_DS_ThongKe_TheoTinh(item));
							Console.WriteLine("\n==========================");
							Console.ReadKey();
						}
						break;
					default:
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
