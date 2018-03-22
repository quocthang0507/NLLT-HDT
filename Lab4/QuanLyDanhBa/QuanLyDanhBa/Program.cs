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
			Xuat,
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
			List<int> thang = new List<int>();
			string tenTinh;
			//Xuất menu
			while (true)
			{
				Console.Clear();
				Console.WriteLine("".PadRight(30, '=') + " HE THONG CHUC NANG " + "".PadRight(30, '='));
				Console.WriteLine("0. Thoat khoi chuong trinh");
				Console.WriteLine("1. Xuat danh sach khach hang va danh sach thue bao");
				Console.WriteLine("2. Tim thanh pho co nhieu thue bao nhat, co it thue bao nhat.");
				Console.WriteLine("3. Tim thue bao so huu it so dien thoai nhat.");
				Console.WriteLine("4. Tim duong co it thue bao, nhieu thue bao nhat.");
				Console.WriteLine("5. Sap xep khach hang tang giam theo ten, so luong so dien thoai so huu.");
				Console.WriteLine("6. Hien thi danh sach cac thanh pho theo chieu tang, giam cua so luong thue bao.");
				Console.WriteLine("7. Tim thang khong co thue bao nao dang ky.");
				Console.WriteLine("8. Tim tat ca cac khach hang theo gioi tinh.");
				Console.WriteLine("9. Xoa tat ca khach hang thuoc mot tinh nao do.");
				Console.WriteLine("10. Tat ca khach hang nao sinh thang 1 thi duoc tang them mot so dien thoai moi co so la cmnd.");
				Console.WriteLine("11. Tim ngay co nhieu khach hang dang ky nhat, it nguoi dang ky nhat.");
				Console.WriteLine("12. Thong ke va hien thi du lieu theo tung tinh va moi tinh hien thi theo thanh pho theo mau");
				Console.WriteLine("".PadRight(80, '='));
				Console.Write("\nNhap so thu tu chuc nang: ");
				Menu menu = (Menu)int.Parse(Console.ReadLine());
				Console.Clear();
				//Xử lý menu
				switch (menu)
				{
					case Menu.Thoat:
						Console.WriteLine("0. Thoat khoi chuong trinh");
						return;
					case Menu.Xuat:
						Console.WriteLine("1. Xuat danh sach khach hang va danh sach thue bao");
						Console.WriteLine("\nDanh sach khach hang:");
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.Write("\nNhan phim bat ky de tiep tuc...");
						Console.ReadKey();
						Console.WriteLine();
						Console.WriteLine("\nDanh sach thue bao:");
						Console.WriteLine(QuanLy_TB.DS_TB);
						break;
					case Menu.Tim_Max_Min_TB_TP:
						Console.WriteLine("2. Tim thanh pho co nhieu thue bao nhat, co it thue bao nhat.");
						Console.WriteLine("\nThanh pho co nhieu thue bao nhat la: ");
						kq = QuanLy_TB.Tim_DS_ThanhPho_NhieuThueBao();
						foreach (var item in kq)
							Console.WriteLine('\t' + item);
						kq = QuanLy_TB.Tim_DS_ThanhPho_ItThueBao();
						Console.WriteLine("\nThanh pho co it thue bao nhat la: ");
						foreach (var item in kq)
							Console.WriteLine('\t' + item);
						break;
					case Menu.Tim_Min_TB_KH:
						Console.WriteLine("3. Tim thue bao so huu it so dien thoai nhat.");
						Console.WriteLine("\nDanh sach chu thue bao so huu it so dien thoai nhat:\n");
						kq_kh = QuanLy_TB.Tim_TB_ItDienThoai();
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						break;
					case Menu.Tim_Max_Min_TB_Duong:
						Console.WriteLine("4. Tim duong co it thue bao, nhieu thue bao nhat.");
						Console.WriteLine("\nCon duong co nhieu thue bao nhat la: ");
						kq = QuanLy_TB.Tim_DS_ConDuong_NhieuThueBao();
						foreach (var item in kq)
							Console.WriteLine('\t' + item);
						kq = QuanLy_TB.Tim_DS_ConDuong_ItThueBao();
						Console.WriteLine("\nCon duong co it thue bao nhat la: ");
						foreach (var item in kq)
							Console.WriteLine('\t' + item);
						break;
					case Menu.SapXep_KH:
						Console.WriteLine("5. Sap xep khach hang tang giam theo ten, so luong so dien thoai so huu.");
						Console.WriteLine("\nDanh sach theo chieu tang cua ten:\n");
						QuanLy_TB.SapXep_Tang_Ten();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("\nDanh sach theo chieu giam cua ten:\n");
						QuanLy_TB.SapXep_Giam_HoTen();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("\nDanh sach theo chieu tang cua so luong thue bao:\n");
						QuanLy_TB.SapXep_Tang_SoThueBao();
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.ReadKey();
						Console.WriteLine("\nDanh sach theo chieu giam cua so luong thue bao:\n");
						QuanLy_TB.SapXep_Giam_SoThueBao();
						Console.WriteLine(QuanLy_TB.DS_KH);
						break;
					case Menu.SapXep_TP:
						Console.WriteLine("6. Hien thi danh sach cac thanh pho theo chieu tang, giam cua so luong thue bao.");
						ds = QuanLy_TB.SapXep_TP_Tang_SoThueBao();
						Console.WriteLine("\nDanh sach cac thanh pho theo chieu tang dan so thue bao:");
						foreach (var item in ds)
							Console.WriteLine(item);
						ds = QuanLy_TB.SapXep_TP_Giam_SoThueBao();
						Console.WriteLine("\nDanh sach cac thanh pho theo chieu tang dan so thue bao:");
						foreach (var item in ds)
							Console.WriteLine(item);
						break;
					case Menu.Tim_Thang_KhongTB:
						Console.WriteLine("7. Tim thang khong co thue bao nao dang ky.");
						Console.Write("\nCac thang khong co thue bao nao dang ky la: \t");
						thang = QuanLy_TB.Tim_Thang_KhongCoTB();
						foreach (var item in thang)
							Console.Write(item + "\t");
						break;
					case Menu.Tim_KH_GT:
						Console.WriteLine("8. Tim tat ca cac khach hang theo gioi tinh.");
						Console.WriteLine("\nDanh sach khach hang NAM:\n");
						kq_kh = QuanLy_TB.Tim_DS_KhachHang_GT((GioiTinh)0);
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						Console.WriteLine("\nDanh sach khach hang NU:\n");
						kq_kh = QuanLy_TB.Tim_DS_KhachHang_GT((GioiTinh)1);
						foreach (var item in kq_kh)
							Console.WriteLine(item);
						break;
					case Menu.Xoa_KH_Tinh:
						Console.WriteLine("9. Xoa tat ca khach hang thuoc mot tinh nao do.");
						Console.Write("\nNhap ten tinh can xoa : ");
						tenTinh = " " + Console.ReadLine();
						Console.WriteLine("\nDanh sach khach hang ban dau: ");
						Console.WriteLine(QuanLy_TB.DS_KH);
						Console.WriteLine("\nDanh sach khach hang moi: ");
						QuanLy_TB.Xoa_KH_Tinh(tenTinh);
						Console.WriteLine(QuanLy_TB.DS_KH);
						break;
					case Menu.Them_SDT_CMND:
						Console.WriteLine("10. Tat ca khach hang nao sinh thang 1 thi duoc tang them mot so dien thoai moi co so la cmnd.");
						QuanLy_TB.Them_SoDienThoai_NeuSinhThang1();
						Console.WriteLine(QuanLy_TB.DS_TB);
						break;
					case Menu.Tim_Max_Min_Ngay_KH:
						Console.WriteLine("11. Tim ngay co nhieu khach hang dang ky nhat, it nguoi dang ky nhat.");
						Console.WriteLine("\nNgay co nhieu nguoi dang ky nhat");
						foreach (var item in QuanLy_TB.Tim_NgayDK_Nhieu())
							Console.Write(item + "\t");
						Console.WriteLine("\nNgay co it nguoi dang ky nhat");
						foreach (var item in QuanLy_TB.Tim_NgayDK_It())
							Console.Write(item + "\t");
						break;
					case Menu.HienThi_TheoMau:
						Console.WriteLine("12. Thong ke va hien thi du lieu theo tung tinh va moi tinh hien thi theo thanh pho theo mau");
						kq = QuanLy_TB.Tim_DS_Tinh();
						foreach (var item in kq)
						{
							Console.WriteLine(QuanLy_TB.Xuat_DS_ThongKe_TheoTinh(item));
							Console.WriteLine("\n".PadRight(20, '='));
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
