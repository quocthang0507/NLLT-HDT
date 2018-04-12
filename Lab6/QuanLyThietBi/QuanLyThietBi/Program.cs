using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	class Program
	{
		enum Menu
		{
			Thoat, Nhap_Tay, Nhap_File, Tim_MT_Gia_MinMax, Tim_MA_Gia_MinMax, Dem_co_Gia_X, HienThi_TangGiam_Gia, SapXep, Tim_TB_CPU_MaxMin, Dem_CPU_SuDung_Nhieu, Dem_RAM_Khong_SD, Dem_RAM_TheoLoai, Xoa_1_Loai_RAM, Xoa_TB_RAM_GiaX, Tim_LK_SD_Max
		}

		static void Main(string[] args)
		{
			//Danh sách
			DanhSachThietBi DS_TB = new DanhSachThietBi();
			DanhSachLinhKien DS_LK = new DanhSachLinhKien();
			DanhSachTanSuat DS_TS = new DanhSachTanSuat();
			//Thực hiện chức năng
			QuanLyThietBi QL = new QuanLyThietBi();
			//Lưu kêt quả
			DanhSachThietBi DS = new DanhSachThietBi();
			float gia;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("".PadRight(20) + "HE THONG CHUC NANG");
				Console.WriteLine("0.Thoat khoi chuong trinh");
				Console.WriteLine("1.Nhap du lieu bang tay");
				Console.WriteLine("2.Nhap du lieu tu file");
				Console.WriteLine("3.Tim may tinh co gia re nhat, cao nhat.");
				Console.WriteLine("4.Tim may anh co gia cao nhat re nhat.");
				Console.WriteLine("5.Dem so luong may tinh, may anh co gia la x.");
				Console.WriteLine("6.Hien thi ca hai thiet bi theo chieu tang, giam cua gia");
				Console.WriteLine("7.Sap xep may tinh chieu tang, giam cua gia");
				Console.WriteLine("8.Tim thiet bi co gia CPU cao nhat, thap nhat");
				Console.WriteLine("9.Dem so luong CPU duoc nhieu thiet bi su dung nhat");
				Console.WriteLine("10.Dem so luong RAM khong duoc thiet bi nao su dung.");
				Console.WriteLine("11.Dem so luong RAM su dung theo tung loai RAM.");
				Console.WriteLine("12.Xoa mot loai RAM theo gia.");
				Console.WriteLine("13.Xoa tat ca cac thiet bi su dung RAM co gia la x.");
				Console.WriteLine("14.Tim linh kien duoc su dung nhieu nhat");
				Console.Write("\nNhap so thu tu chuc nang can thuc hien: ");
				Menu menu = (Menu)int.Parse(Console.ReadLine());
				Console.Clear();
				switch (menu)
				{
					case Menu.Thoat:
						return;
					case Menu.Nhap_Tay:
						Console.WriteLine("1.Nhap du lieu bang tay\n");
						DS_TB.NhapBangTay();
						DS_TB.Xuat();
						break;
					case Menu.Nhap_File:
						Console.WriteLine("2.Nhap du lieu tu file\n");
						DS_TB.NhapTuFile();
						DS_LK.NhapTuFile();
						DS_TS.KhoiTao(DS_LK);
						DS_TS.CapNhat_ToanBo(DS_TB);
						DS_TB.Xuat();
						break;
					case Menu.Tim_MT_Gia_MinMax:
						Console.WriteLine("3.Tim may tinh co gia re nhat, cao nhat\n");
						DS = QL.PhanLoai_ThietBi(DS_TB, (int)PhanLoai.MayTinh);
						Console.WriteLine("May tinh co gia re nhat la:");
						QL.Tim_ThietBi_TheoGia(DS, DS.Tim_Min((int)Gia.TongGia), (int)Gia.TongGia).Xuat();
						Console.WriteLine("May tinh co gia cao nhat la:");
						QL.Tim_ThietBi_TheoGia(DS, DS.Tim_Max((int)Gia.TongGia), (int)Gia.TongGia).Xuat(); break;
					case Menu.Tim_MA_Gia_MinMax:
						Console.WriteLine("4.Tim may anh co gia cao nhat re nhat\n");
						DS = QL.PhanLoai_ThietBi(DS_TB, (int)PhanLoai.MayAnh);
						Console.WriteLine("May anh co gia re nhat la:");
						QL.Tim_ThietBi_TheoGia(DS, DS.Tim_Min((int)Gia.TongGia), (int)Gia.TongGia).Xuat();
						Console.WriteLine("May anh co gia cao nhat la:");
						QL.Tim_ThietBi_TheoGia(DS, DS.Tim_Max((int)Gia.TongGia), (int)Gia.TongGia).Xuat();
						break;
					case Menu.Dem_co_Gia_X:
						Console.WriteLine("5.Dem so luong may tinh, may anh co gia la x\n");
						Console.WriteLine("Danh sach thiet bi:");
						DS_TB.Xuat();
						Console.Write("Nhap gia: x = ");
						gia = float.Parse(Console.ReadLine());
						Console.WriteLine("\nDa tim thay co {0} thiet bi co gia la {1}", QL.Tim_ThietBi_TheoGia(DS_TB, gia, (int)Gia.TongGia).Dem(), gia);
						break;
					case Menu.HienThi_TangGiam_Gia:
						Console.WriteLine("6.Hien thi ca hai thiet bi theo chieu tang, giam cua gia\n");
						Console.WriteLine("Danh sach ban dau:");
						DS_TB.Xuat();
						Console.Write("Nhan phim bat ky de tiep tuc...");
						Console.ReadKey();
						Console.WriteLine("Danh sach theo chieu tang cua gia:");
						QL.SapXep(DS_TB, (int)ThuTu.Tang);
						DS_TB.Xuat();
						Console.Write("Nhan phim bat ky de tiep tuc...");
						Console.ReadKey();
						Console.WriteLine("Danh sach theo chieu giam cua gia:");
						QL.SapXep(DS_TB, (int)ThuTu.Giam);
						DS_TB.Xuat();
						break;
					case Menu.SapXep:
						Console.WriteLine("7.Sap xep may tinh chieu tang, giam cua gia\n");
						Console.WriteLine("Danh sach may tinh ban dau:");
						DS = QL.PhanLoai_ThietBi(DS_TB, (int)PhanLoai.MayTinh);
						DS.Xuat();
						Console.Write("Nhan phim bat ky de tiep tuc...");
						Console.ReadKey();
						Console.WriteLine("Danh sach may tinh theo chieu tang cua gia:");
						QL.SapXep(DS, (int)ThuTu.Tang);
						DS.Xuat();
						Console.Write("Nhan phim bat ky de tiep tuc...");
						Console.ReadKey();
						Console.WriteLine("Danh sach may tinh theo chieu giam cua gia:");
						QL.SapXep(DS, (int)ThuTu.Giam);
						DS.Xuat();
						break;
					case Menu.Tim_TB_CPU_MaxMin:
						Console.WriteLine("8.Tim thiet bi co gia CPU cao nhat, thap nhat\n");
						Console.WriteLine("Danh sach thiet bi:");
						DS_TB.Xuat();
						Console.WriteLine("Thiet bi co gia CPU cao nhat la: ");
						QL.Tim_ThietBi_TheoGia(DS_TB, DS_TB.Tim_Max((int)Gia.GiaCPU), (int)Gia.GiaCPU).Xuat();
						Console.WriteLine("Thiet bi co gia CPU thap nhat la: ");
						QL.Tim_ThietBi_TheoGia(DS_TB, DS_TB.Tim_Min((int)Gia.GiaCPU), (int)Gia.GiaCPU).Xuat();
						break;
					case Menu.Dem_CPU_SuDung_Nhieu:
						Console.WriteLine("9.Dem so luong CPU duoc nhieu thiet bi su dung nhat\n");
						DS_TB.Xuat();
						Console.WriteLine("Co {0} CPU su dung nhieu nhat", QL.Tim_LinhKien_SuDung_MucDo(DS_TS, (int)LinhKien.CPU, DS_TS.Tim_Max_CPU()).Dem());
						QL.Tim_LinhKien_SuDung_MucDo(DS_TS, (int)LinhKien.CPU, DS_TS.Tim_Max_CPU()).Xuat();
						break;
					case Menu.Dem_RAM_Khong_SD:
						Console.WriteLine("10.Dem so luong RAM khong duoc thiet bi nao su dung\n");
						DS_TB.Xuat();
						Console.WriteLine("Co {0} RAM khong duoc su dung", QL.Tim_LinhKien_SuDung_MucDo(DS_TS, (int)LinhKien.RAM, 0).Dem());
						QL.Tim_LinhKien_SuDung_MucDo(DS_TS, (int)LinhKien.RAM, 0).Xuat();
						break;
					case Menu.Dem_RAM_TheoLoai:
						Console.WriteLine("11.Dem so luong RAM su dung theo tung loai RAM\n");
						QL.HienThi_SL_SuDung_RAM(DS_TS);
						break;
					case Menu.Xoa_1_Loai_RAM:
						Console.WriteLine("12.Xoa mot loai RAM theo gia\n");
						Console.WriteLine("Danh sach linh kien ban dau:");
						DS_LK.Xuat();
						Console.Write("Nhap gia RAM: x = ");
						gia = float.Parse(Console.ReadLine());
						Console.WriteLine("\nDanh sach linh kien moi:");
						DS_LK.Xoa_RAM(gia);
						DS_LK.Xuat();
						break;
					case Menu.Xoa_TB_RAM_GiaX:
						Console.WriteLine("13.Xoa tat ca cac thiet bi su dung RAM co gia la x\n");
						Console.WriteLine("Danh sach thiet bi ban dau:");
						DS_TB.Xuat();
						Console.Write("Nhap gia RAM: x = ");
						gia = float.Parse(Console.ReadLine());
						Console.WriteLine("\nDanh sach thiet bi moi:");
						DS_TB.Xoa_ThietBi_RAM_GiaX(gia);
						DS_TB.Xuat();
						break;
					case Menu.Tim_LK_SD_Max:
						Console.WriteLine("14.Tim linh kien duoc su dung nhieu nhat\n");
						Console.WriteLine("Linh kien duoc su dung nhieu nhat la:");
						QL.Tim_LinhKien_SuDung_MucDo(DS_TS, (int)LinhKien.TatCa, DS_TS.listPair.Max(t => t.SoLan)).Xuat();
						break;
					default:
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
