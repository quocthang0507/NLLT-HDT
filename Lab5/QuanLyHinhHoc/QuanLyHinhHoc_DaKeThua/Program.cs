using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc_DaKeThua
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
			DanhSachHinhHoc DS_HH = new DanhSachHinhHoc();
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
						DS_HH.NhapBangTay();
						DS_HH.Xuat_DS();
						break;
					case Menu.Nhap_TuFile:
						Console.WriteLine("2.Nhap tu file\n");
						DS_HH.DocTuFile();
						DS_HH.Xuat_DS();
						break;
					case Menu.Tim_HV_S_Max:
						Console.WriteLine("3.Tim hinh vuong co dien tich lon nhat\n");
						QL_HH.Tim_HV_DT_Max(DS_HH).Xuat_DS();
						break;
					case Menu.Tim_HCN_S_Min:
						Console.WriteLine("4.Tim hinh chu nhat co dien tich nho nhat\n");
						QL_HH.Tim_HCN_DT_Min(DS_HH).Xuat_DS();
						break;
					case Menu.Tim_HT_R_Max:
						Console.WriteLine("5.Tim hinh tron co ban kinh lon nhat.\n");
						QL_HH.Tim_HT_BK_Max(DS_HH).Xuat_DS();
						break;
					case Menu.SapXep_DSHV:
						Console.WriteLine("6.Sap xep danh sach hinh vuong theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.Tim_DS_HV(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu tang chu vi:");
						QL_HH.SapXep_HV_Tang_CV(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu giam chu vi:");
						QL_HH.SapXep_HV_Giam_CV(DS_HH).Xuat_DS();
						break;
					case Menu.SapXep_DSHT:
						Console.WriteLine("7.Sap xep danh sach hinh tron theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.Tim_DS_HT(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu tang chu vi:");
						QL_HH.SapXep_HT_Tang_CV(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu giam chu vi:");
						QL_HH.SapXep_HT_Giam_CV(DS_HH).Xuat_DS();
						break;
					case Menu.SapXep_DSHCN:
						Console.WriteLine("8.Sap xep danh sach hinh chu nhat theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						QL_HH.Tim_DS_HCN(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu tang chu vi:");
						QL_HH.SapXep_HCN_Tang_CV(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh vuong sap xep theo chieu giam chu vi:");
						QL_HH.SapXep_HCN_Giam_CV(DS_HH).Xuat_DS();
						break;
					case Menu.Tim_Hinh_S_MaxMin:
						Console.WriteLine("9.Tim cac hinh co dien tich lon nhat, nho nhat\n");
						Console.WriteLine("Hinh co dien tich lon nhat la:");
						QL_HH.Tim_Hinh_DT_Max(DS_HH).Xuat_DS();
						Console.WriteLine("Hinh co dien tich nho nhat la:");
						QL_HH.Tim_Hinh_DT_Min(DS_HH).Xuat_DS();
						break;
					case Menu.Tim_Hinh_C_MaxMin:
						Console.WriteLine("10.Tim cac hinh co chu vi lon nhat, nho nhat\n");
						Console.WriteLine("Hinh co chu vi lon nhat la:");
						QL_HH.Tim_Hinh_CV_Max(DS_HH).Xuat_DS();
						Console.WriteLine("Hinh co chu vi nho nhat la:");
						QL_HH.Tim_Hinh_CV_Min(DS_HH).Xuat_DS();
						break;
					case Menu.HienThi_Hinh_S_TangGiam:
						Console.WriteLine("11.Hien thi tat ca cac hinh theo chieu tang, giam cua dien tich\n");
						Console.WriteLine("Danh sach ban dau:");
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach hinh theo chieu tang dien tich:");
						QL_HH.HienThi_Hinh_DT_Tang(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh theo chieu giam dien tich:");
						QL_HH.HienThi_Hinh_DT_Giam(DS_HH).Xuat_DS();
						break;
					case Menu.HienThi_Hinh_C_TangGiam:
						Console.WriteLine("12.Hien thi tat ca cac hinh theo chieu tang, giam cua chu vi\n");
						Console.WriteLine("Danh sach ban dau:");
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach hinh theo chieu tang chu vi:");
						QL_HH.HienThi_Hinh_DT_Tang(DS_HH).Xuat_DS();
						Console.WriteLine("Danh sach hinh theo chieu giam chu vi:");
						QL_HH.HienThi_Hinh_DT_Giam(DS_HH).Xuat_DS();
						break;
					case Menu.Xoa_Hinh_S_MaxMin:
						Console.WriteLine("13.Xoa cac hinh co dien tich nho nhat, lon nhat\n");
						Console.WriteLine("Danh sach ban dau:");
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach sau khi xoa hinh co dien tich lon nhat:");
						QL_HH.Xoa_Hinh_DT_Max(DS_HH);
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach sau khi xoa hinh co dien tich nho nhat:");
						QL_HH.Xoa_Hinh_DT_Min(DS_HH);
						DS_HH.Xuat_DS();
						break;
					case Menu.Xoa_Hinh_C_MaxMin:
						Console.WriteLine("14.Xoa cac hinh co chu vi nho nhat, lon nhat\n");
						Console.WriteLine("Danh sach ban dau:");
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach sau khi xoa hinh co chu vi lon nhat:");
						QL_HH.Xoa_Hinh_CV_Max(DS_HH);
						DS_HH.Xuat_DS();
						Console.WriteLine("Danh sach sau khi xoa hinh co chu vi nho nhat:");
						QL_HH.Xoa_Hinh_CV_Min(DS_HH);
						DS_HH.Xuat_DS();
						break;
					default:
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
