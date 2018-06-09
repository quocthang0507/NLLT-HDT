using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhanSo
{
	class Program
	{
		enum Menu
		{
			Thoat, Nhap_File, Nhap_Tay, Dem_Am, Dem_Duong, Dem_TuX, Dem_TuY,
			Max_Am, Min_Am, Max_Duong, Min_Duong, Tim_Am, Tim_Duong, Tim_VTx, Tim_VT_AmDuong,
			Tong_Am, Tong_Duong, Tong_TuX, Tong_MauX, Xoa_VT, Xoa_Dau, Xoa_Cuoi, Xoa_x, Xoa_TuX, Xoa_MauX,
			Xoa_GiongDau, Xoa_GiongCuoi, Xoa_Min, Xoa_NhieuVT, Chen_VT, Chen_Dau, Xoa_Am, Xoa_Duong,
			SapXep
		}
		static void Main(string[] args)
		{
			MangPhanSo ds = new MangPhanSo();
			MangPhanSo mangAm = new MangPhanSo();
			MangPhanSo mangDuong = new MangPhanSo();
			MangPhanSo mangKQ = new MangPhanSo();
			int tuSo, mauSo, a;
			PhanSo x = new PhanSo();
			int[] kq = new int[100];
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Nhap {0} : Thoat khoi chuong trinh", (int)Menu.Thoat);
				Console.WriteLine("Nhap {0} : Nhap mot mang phan so tu tap tin", (int)Menu.Nhap_File);
				Console.WriteLine("Nhap {0} : Nhap mot mang phan so bang tay", (int)Menu.Nhap_Tay);
				Console.WriteLine("Nhap {0} : Dem so phan so am trong mang", (int)Menu.Dem_Am);
				Console.WriteLine("Nhap {0} : Dem so phan so duong trong mang", (int)Menu.Dem_Duong);
				Console.WriteLine("Nhap {0} : Dem phan so co tu la x trong mang", (int)Menu.Dem_TuX);
				Console.WriteLine("Nhap {0} : Dem phan so co tu la y trong mang", (int)Menu.Dem_TuY);
				Console.WriteLine("Nhap {0} : Tim phan so am lon nhat", (int)Menu.Max_Am);
				Console.WriteLine("Nhap {0} : Tim phan so am nho nhat", (int)Menu.Min_Am);
				Console.WriteLine("Nhap {0} : Tim phan so duong lon nhat", (int)Menu.Max_Duong);
				Console.WriteLine("Nhap {0} : Tim phan so duong nho nhat", (int)Menu.Min_Duong);
				Console.WriteLine("Nhap {0} : Tim tat ca cac phan so am trong mang ", (int)Menu.Tim_Am);
				Console.WriteLine("Nhap {0} : Tim tat ca cac phan so duong trong mang", (int)Menu.Tim_Duong);
				Console.WriteLine("Nhap {0} : Tim tat ca vi tri cua phan so x trong mang", (int)Menu.Tim_VTx);
				Console.WriteLine("Nhap {0} : Tim tat ca vi tri cua phan so am, duong trong mang", (int)Menu.Tim_VT_AmDuong);
				Console.WriteLine("Nhap {0} : Tong tat ca cac phan so am trong mang", (int)Menu.Tong_Am);
				Console.WriteLine("Nhap {0} : Tong cac phan so duong trong mang", (int)Menu.Tong_Duong);
				Console.WriteLine("Nhap {0} : Tong tat ca phan so co tu la x", (int)Menu.Tong_TuX);
				Console.WriteLine("Nhap {0} : Tong tat ca phan so co mau la x", (int)Menu.Tong_MauX);
				Console.WriteLine("Nhap {0} : Xoa mot phan so tai vi tri vt trong mang", (int)Menu.Xoa_VT);
				Console.WriteLine("Nhap {0} : Xoa phan so dau tien trong mang", (int)Menu.Xoa_Dau);
				Console.WriteLine("Nhap {0} : Xoa phan so cuoi cung trong mang", (int)Menu.Xoa_Cuoi);
				Console.WriteLine("Nhap {0} : Xoa phan so x trong mang", (int)Menu.Xoa_x);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so co tu la x", (int)Menu.Xoa_TuX);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so co mau la x", (int)Menu.Xoa_MauX);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so co gia tri giong phan so dau tien trong mang.", (int)Menu.Xoa_GiongDau);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so co gia tri giong phan so cuoi cung trong mang.", (int)Menu.Xoa_GiongCuoi);
				Console.WriteLine("Nhap {0} : Xoa tat ca cac phan so nho nhat ", (int)Menu.Xoa_Min);
				Console.WriteLine("Nhap {0} : Xoa cac phan tu tai cac vi tri (vi tri duoc luu trong mang)", (int)Menu.Xoa_NhieuVT);
				Console.WriteLine("Nhap {0} : Them mot phan so tai vi tri vt trong mang", (int)Menu.Chen_VT);
				Console.WriteLine("Nhap {0} : Them phan so dau tien trong mang", (int)Menu.Chen_Dau);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so am trong mang", (int)Menu.Xoa_Am);
				Console.WriteLine("Nhap {0} : Xoa tat ca phan so duong trong mang", (int)Menu.Xoa_Duong);
				Console.WriteLine("Nhap {0} : Sap xep phan so theo chieu tang, giam, tang theo mau, tu, giam theo mau tu", (int)Menu.SapXep);
				Console.Write("\nNhap so thu tu chuc nang: ");
				Menu menu = (Menu)int.Parse(Console.ReadLine());
				switch (menu)
				{
					case Menu.Thoat:
						return;
					case Menu.Nhap_File:
						ds.NhapTuFile();
						ds.RutGon();
						ds.Xuat();
						break;
					case Menu.Nhap_Tay:
						ds.Nhap();
						ds.RutGon();
						ds.Xuat();
						break;
					case Menu.Dem_Am:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Mang phan so am:");
						mangAm = ds.MangAm();
						mangAm.Xuat();
						Console.WriteLine("Co {0} phan so am trong mang", mangAm.length);
						break;
					case Menu.Dem_Duong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Mang phan so duong:");
						mangDuong = ds.MangDuong();
						mangDuong.Xuat();
						Console.WriteLine("Co {0} phan so duong trong mang", mangDuong.length);
						break;
					case Menu.Dem_TuX:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.Write("Nhap tu so can tim: ");
						tuSo = int.Parse(Console.ReadLine());
						Console.WriteLine("Co {0} phan so co tu la {1} trong mang", ds.Tim_TuX(tuSo).length, tuSo);
						break;
					case Menu.Dem_TuY:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.Write("Nhap tu so can tim: ");
						tuSo = int.Parse(Console.ReadLine());
						Console.WriteLine("Co {0} phan so co tu la {1} trong mang", ds.Tim_TuX(tuSo).length, tuSo);
						break;
					case Menu.Max_Am:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangAm = ds.MangAm();
						Console.WriteLine("Mang phan so am:");
						mangAm.Xuat();
						Console.Write("Phan so am lon nhat cua mang la: {0}", mangAm.Tim_Max());
						break;
					case Menu.Min_Am:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangAm = ds.MangAm();
						Console.WriteLine("Mang phan so am:");
						mangAm.Xuat();
						Console.Write("Phan so am nho nhat cua mang la: {0}", mangAm.Tim_Min());
						break;
					case Menu.Max_Duong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangDuong = ds.MangDuong();
						Console.WriteLine("Mang phan so duong:");
						mangDuong.Xuat();
						Console.Write("Phan so duong lon nhat cua mang la: {0}", mangDuong.Tim_Max());
						break;
					case Menu.Min_Duong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangDuong = ds.MangDuong();
						Console.WriteLine("Mang phan so duong:");
						mangDuong.Xuat();
						Console.Write("Phan so duong nho nhat cua mang la: {0}", mangDuong.Tim_Min());
						break;
					case Menu.Tim_Am:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangAm = ds.MangAm();
						Console.WriteLine("Mang phan so am:");
						mangAm.Xuat();
						break;
					case Menu.Tim_Duong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						mangDuong = ds.MangDuong();
						Console.WriteLine("Mang phan so duong:");
						mangDuong.Xuat();
						break;
					case Menu.Tim_VTx:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Nhap phan so x: ");
						x.Nhap_PhanSo();
						kq = ds.Tim_VTx(x);
						if (kq.Length == 0)
							Console.WriteLine("Khong ton tai phan so x o trong mang");
						else
						{
							Console.WriteLine("Vi tri phan so x la: ");
							for (int i = 0; i < kq.Length; i++)
								Console.Write(kq[i] + "\t");
						}
						break;
					case Menu.Tim_VT_AmDuong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						kq = ds.Tim_VT_Am();
						Console.WriteLine("Mang vi tri cac phan so am: ");
						for (int i = 0; i < kq.Length; i++)
							Console.Write(kq[i] + "\t");
						Array.Clear(kq, 0, kq.Length);
						kq = ds.Tim_VT_Duong();
						Console.WriteLine();
						Console.WriteLine("Mang vi tri cac phan so duong: ");
						for (int i = 0; i < kq.Length; i++)
							Console.Write(kq[i] + "\t");
						break;
					case Menu.Tong_Am:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						mangAm = ds.MangAm();
						Console.WriteLine("Mang phan so am: ");
						mangAm.Xuat();
						Console.WriteLine("Tong gia tri cua mang am la {0}", mangAm.Tong());
						break;
					case Menu.Tong_Duong:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						mangDuong = ds.MangDuong();
						Console.WriteLine("Mang phan so duong: ");
						mangDuong.Xuat();
						Console.WriteLine("Tong gia tri cua mang duong la {0}", mangDuong.Tong());
						break;
					case Menu.Tong_TuX:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						Console.Write("Nhap tu so x can tinh tong: ");
						mangKQ = ds.Tim_TuX(int.Parse(Console.ReadLine()));
						if (mangKQ.length == 0)
							Console.WriteLine("Khong ton tai phan so co tu so la x");
						else
						{
							Console.WriteLine("Mang ket qua: ");
							mangKQ.Xuat();
							Console.WriteLine("Tong gia tri cua mang ket qua la {0}", mangKQ.Tong());
						}
						break;
					case Menu.Tong_MauX:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						Console.Write("Nhap mau so x can tinh tong: ");
						mangKQ = ds.Tim_MauX(int.Parse(Console.ReadLine()));
						if (mangKQ.length == 0)
							Console.WriteLine("Khong ton tai phan so co tu so la x");
						else
						{
							Console.WriteLine("Mang ket qua: ");
							mangKQ.Xuat();
							Console.WriteLine("Tong gia tri cua mang ket qua la {0}", mangKQ.Tong());
						}
						break;
					case Menu.Xoa_VT:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.Write("Nhap vi tri can xoa: ");
						if (ds.Xoa_VT(int.Parse(Console.ReadLine())))
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Vi tri can xoa khong hop le");
						break;
					case Menu.Xoa_Dau:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						ds.Xoa_VT(0);
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Xoa_Cuoi:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						ds.Xoa_VT(ds.length);
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Xoa_x:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Nhap phan so x can xoa: ");
						x.Nhap_PhanSo();
						if (ds.Xoa_x(x))
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Khong ton tai phan so x trong mang");
						break;
					case Menu.Xoa_TuX:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.Write("Nhap tu so x can xoa: ");
						tuSo = int.Parse(Console.ReadLine());
						if (ds.Xoa_tuX(tuSo))
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Khong ton tai tu so x trong mang");
						break;
					case Menu.Xoa_MauX:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.Write("Nhap mau so x can xoa: ");
						mauSo = int.Parse(Console.ReadLine());
						if (ds.Xoa_mauX(mauSo))
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Khong ton tai mau so x trong mang");
						break;
					case Menu.Xoa_GiongDau:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						ds.Xoa_GiongDau();
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Xoa_GiongCuoi:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						ds.Xoa_GiongCuoi();
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Xoa_Min:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						Console.WriteLine("Phan so nho nhat trong mang la " + ds.Tim_Min().ToString());
						Console.WriteLine("Mang moi: ");
						ds.Xoa_x(ds.Tim_Min());
						ds.Xuat();
						break;
					case Menu.Xoa_NhieuVT:
						Console.WriteLine("Mang hien hanh: ");
						ds.Xuat();
						Console.Write("Nhap kich thuoc mang n can xoa: ");
						a = int.Parse(Console.ReadLine());
						for (int i = 0; i < a; i++)
						{
							Console.Write("Nhap a[{0}] = ", i);
							kq[i] = int.Parse(Console.ReadLine());
						}
						ds.Xoa_MangVT(kq, a);
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Chen_VT:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Nhap phan so x can chen: ");
						x.Nhap_PhanSo();
						Console.Write("Vi tri phan so x can chen la: ");
						if (ds.Chen_VT(x, int.Parse(Console.ReadLine())))
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Vi tri can chen khong hop le");
						break;
					case Menu.Chen_Dau:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Nhap phan so x can chen: ");
						x.Nhap_PhanSo();
						ds.Chen_VT(x, 0);
						Console.WriteLine("Mang moi: ");
						ds.Xuat();
						break;
					case Menu.Xoa_Am:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						if (ds.Xoa_Am())
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Mang khong ton tai phan so am");
						break;
					case Menu.Xoa_Duong:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						if (ds.Xoa_Duong())
						{
							Console.WriteLine("Mang moi: ");
							ds.Xuat();
						}
						else Console.WriteLine("Mang khong ton tai phan so duong");
						break;
					case Menu.SapXep:
						Console.WriteLine("Mang hien hanh:");
						ds.Xuat();
						Console.WriteLine("Sap tang: ");
						ds.SapXep_Tang();
						ds.Xuat();
						Console.WriteLine("Sap tang tu so: ");
						ds.SapXep_TangTu();
						ds.Xuat();
						Console.WriteLine("Sap tang mau so: ");
						ds.SapXep_TangMau();
						ds.Xuat();
						Console.WriteLine("Sap giam: ");
						ds.SapXep_Giam();
						ds.Xuat();
						Console.WriteLine("Sap giam tu so: ");
						ds.SapXep_GiamTu();
						ds.Xuat();
						Console.WriteLine("Sap giam mau so: ");
						ds.SapXep_GiamMau();
						ds.Xuat();
						break;
					default:
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
