using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1610207_LaQuocThang
{
	class Program
	{
		static void Main(string[] args)
		{
			QuanLyThietBi QL = new QuanLyThietBi();				//Thực hiện chức năng
			DanhSachThietBi DS_TB = new DanhSachThietBi();		//Lưu danh sách thiết bị
			DanhSachLinhKien DS_LK = new DanhSachLinhKien();	//Lưu danh sách linh kiện
			DanhSachLinhKien DS_LK_DT = new DanhSachLinhKien();	//Danh sách linh kiện của điện thoại
			DanhSachThietBi KQ = new DanhSachThietBi();			//Danh sách thiết bị dùng để lưu kết quả
			DanhSachTanSuat DS_TS = new DanhSachTanSuat();		//Danh sách tần suất sử dụng linh kiện
			DanhSachTanSuat DS_TS_DT = new DanhSachTanSuat();	//Danh sách tần suất sử dụng linh kiện của điện thoại
			DS_TB.NhapTuFile(DS_LK_DT);
			DS_LK.NhapTuFile();
			DS_TS.KhoiTao(DS_LK);
			DS_TS.CapNhat_ToanBo(DS_TB);
			DS_TS_DT.KhoiTao(DS_LK_DT);
			DS_TS_DT.CapNhat_ToanBo(QL.PhanLoai_ThietBi(DS_TB, (int)PhanLoai.DienThoai));
			Console.WriteLine("Danh sach thiet bi ban dau: ");
			DS_TB.Xuat();
			//1.	Tìm điện thoại sử dụng ít CPU nhất?
			KQ = QL.Cau1_Tim_DienThoai_It_CPU(QL.PhanLoai_ThietBi(DS_TB, (int)PhanLoai.DienThoai));
			Console.WriteLine("1. Dien thoat co it CPU nhat la:");
			KQ.Xuat();
			//2.	Trong CPU bổ sung thuộc tính loại CPU (loại gồm Intel, AMD,…), tìm loại CPU được nhiều điện thoại sử dụng nhất?
			Console.WriteLine("2. Tim CPU duoc nhieu dien thoai su dung nhat");
			int max = DS_TS_DT.Tim_Max_CPU();
			QL.Cau3_TimCPU_SuDungNhieuNhat(DS_TS_DT, max).Xuat();
			//3.	Tìm loại CPU được sử dụng nhiều nhất bởi tất cả các thiết bị (Máy tính, máy ảnh và điện thoại) ?
			Console.WriteLine("3. Tim CPU duoc nhieu thiet bi su dung nhat");
			int max1 = DS_TS.Tim_Max_CPU();
			QL.Cau3_TimCPU_SuDungNhieuNhat(DS_TS, max1).Xuat();
			//4.	Tìm loại CPU không được sử dụng bởi bất cứ thiết bị nào?
			Console.WriteLine("4. Tim CPU khong duoc thiet bi nao su dung");
			QL.Cau4_TimCPU_KhongDuocSuDung(DS_TS).Xuat();
			Console.ReadKey();
		}
	}
}
