using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class Program
	{
		enum Menu
		{
			Thoat,
			Nhap_BangTay,
			Nhap_TuFile,
			Tim_HV_S_Max,
			Tim_HCN_S_Min,
			Tim_HT_R_Max,
			SapXep_DSHV,
			SapXep_DSHT,
			SapXep_DSHCN,
			Tim_Hinh_S_MaxMin,
			Tim_Hinh_C_MaxMin,
			HienThi_Hinh_S_TangGiam,
			HienThi_Hinh_C_TangGiam,
			Xoa_Hinh_S_MaxMin,
			Xoa_Hinh_C_MaxMin
		}
		static void Main(string[] args)
		{
			QuanLyHinhHoc QL_HH = new QuanLyHinhHoc();
			while (true)
			{
				Console.Clear();
				Console.WriteLine("".PadRight(20) + "HE THONG CHUC NANG");
				Console.WriteLine("0. Thoat khoi chuong trinh ");
				Console.WriteLine("1. Nhap bang tay ");
				Console.WriteLine("2. Nhap tu file ");
				Console.WriteLine("3. Tim hinh vuong co dien tich lon nhat ");
				Console.WriteLine("4. Tim hinh chu nhat co dien tich nho nhat ");
				Console.WriteLine("5. Tim hinh tron co ban kinh lon nhat. ");
				Console.WriteLine("6. Sap xep danh sach hinh vuong theo chieu tang, giam cua chu vi ");
				Console.WriteLine("7. Sap xep danh sach hinh tron theo chieu tang, giam cua chu vi ");
				Console.WriteLine("8. Sap xep danh sach hinh chu nhat theo chieu tang, giam cua chu vi ");
				Console.WriteLine("9. Tim cac hinh co dien tich lon nhat, nho nhat ");
				Console.WriteLine("10. Tim cac hinh co chu vi lon nhat, nho nhat ");
				Console.WriteLine("11. Hien thi tat ca cac hinh theo chieu tang, giam cua dien tich ");
				Console.WriteLine("12. Hien thi tat ca cac hinh theo chieu tang, giam cua chu vi ");
				Console.WriteLine("13. Xoa cac hinh co dien tich nho nhat, lon nhat ");
				Console.WriteLine("14. Xoa cac hinh co chu vi nho nhat, lon nhat ");
				Console.Write("\nNhap so thu tu chuc nang can thuc hien: ");
				Menu menu = (Menu)int.Parse(Console.ReadLine());
				Console.Clear();
				switch (menu)
				{
					case Menu.Thoat:
						Console.WriteLine("0.Thoat khoi chuong trinh\n");
						return;
					case Menu.Nhap_BangTay:
						Console.WriteLine("1.Nhap bang tay\n");
						QL_HH.NhapBangTay();
						QL_HH.Xuat();
						break;
					case Menu.Nhap_TuFile:
						Console.WriteLine("2.Nhap tu file\n");
						QL_HH.DocTuFile();
						QL_HH.Xuat();
						break;
					case Menu.Tim_HV_S_Max:
						Console.WriteLine("3.Tim hinh vuong co dien tich lon nhat\n");
						QL_HH.DS_HV.Xuat();
						Console.WriteLine("\nHinh vuong co dien tich lon nhat la: ");
						foreach (var item in QL_HH.Tim_HV_S_Max())
							Console.WriteLine(item);
						break;
					case Menu.Tim_HCN_S_Min:
						Console.WriteLine("4.Tim hinh chu nhat co dien tich nho nhat\n");
						QL_HH.DS_HCN.Xuat();
						Console.WriteLine("\nHinh chu nhat co dien tich nho nhat la: ");
						foreach (var item in QL_HH.Tim_HCN_S_Min())
							Console.WriteLine(item);
						break;
					case Menu.Tim_HT_R_Max:
						Console.WriteLine("5.Tim hinh tron co ban kinh lon nhat.\n");
						QL_HH.DS_HT.Xuat();
						Console.WriteLine("\nHinh tron co ban kinh lon nhat la: ");
						foreach (var item in QL_HH.Tim_HT_R_Max())
							Console.WriteLine(item);
						break;
					case Menu.SapXep_DSHV:
						Console.WriteLine("6.Sap xep danh sach hinh vuong theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.DS_HV.Xuat();
						QL_HH.SapXep_DSHV_Tang_CV();
						Console.WriteLine("Danh sach sap xep theo chieu tang chu vi:");
						QL_HH.DS_HV.Xuat();
						QL_HH.SapXep_DSHV_Giam_CV();
						Console.WriteLine("Danh sach sap xep theo chieu giam chu vi:");
						QL_HH.DS_HV.Xuat();
						break;
					case Menu.SapXep_DSHT:
						Console.WriteLine("7.Sap xep danh sach hinh tron theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.DS_HT.Xuat();
						QL_HH.SapXep_DSHT_Tang_CV();
						Console.WriteLine("Danh sach sap xep theo chieu tang chu vi:");
						QL_HH.DS_HT.Xuat();
						QL_HH.SapXep_DSHT_Giam_CV();
						Console.WriteLine("Danh sach sap xep theo chieu giam chu vi:");
						QL_HH.DS_HT.Xuat();
						break;
					case Menu.SapXep_DSHCN:
						Console.WriteLine("8.Sap xep danh sach hinh chu nhat theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.DS_HCN.Xuat();
						QL_HH.SapXep_DSHCN_Tang_CV();
						Console.WriteLine("Danh sach sap xep theo chieu tang chu vi:");
						QL_HH.DS_HCN.Xuat();
						QL_HH.SapXep_DSHCN_Giam_CV();
						Console.WriteLine("Danh sach sap xep theo chieu giam chu vi:");
						QL_HH.DS_HCN.Xuat();
						break;
					case Menu.Tim_Hinh_S_MaxMin:
						Console.WriteLine("9.Tim cac hinh co dien tich lon nhat, nho nhat\n");
						Console.WriteLine("Hinh co dien tich lon nhat la:");
						QL_HH.Tim_Hinh_S_Max();
						Console.WriteLine("Hinh co dien tich nho nhat la:");
						QL_HH.Tim_Hinh_S_Min();
						break;
					case Menu.Tim_Hinh_C_MaxMin:
						Console.WriteLine("10.Tim cac hinh co chu vi lon nhat, nho nhat\n");
						break;
					case Menu.HienThi_Hinh_S_TangGiam:
						Console.WriteLine("11.Hien thi tat ca cac hinh theo chieu tang, giam cua dien tich\n");
						break;
					case Menu.HienThi_Hinh_C_TangGiam:
						Console.WriteLine("12.Hien thi tat ca cac hinh theo chieu tang, giam cua chu vi\n");
						break;
					case Menu.Xoa_Hinh_S_MaxMin:
						Console.WriteLine("13.Xoa cac hinh co dien tich nho nhat, lon nhat\n");
						break;
					case Menu.Xoa_Hinh_C_MaxMin:
						Console.WriteLine("14.Xoa cac hinh co chu vi nho nhat, lon nhat\n");
						break;
					default:
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
