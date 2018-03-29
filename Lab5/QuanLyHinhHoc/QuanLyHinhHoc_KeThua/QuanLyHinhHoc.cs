using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc_KeThua
{
	class QuanLyHinhHoc
	{
		DanhSachHinhHoc DS_HH = new DanhSachHinhHoc();

		//Các hàm phân loại hình trong danh sách
		public DanhSachHinhHoc Tim_DS_HV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item is HinhVuong)
					kq.Them(item);
			return kq;
		}

		public DanhSachHinhHoc Tim_DS_HCN(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item is HinhCN)
					kq.Them(item);
			return kq;
		}

		public DanhSachHinhHoc Tim_DS_HT(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item is HinhTron)
					kq.Them(item);
			return kq;
		}

		//Các hàm thực hiện chức năng của menu
		public DanhSachHinhHoc Tim_HV_DT_Max(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			DanhSachHinhHoc DS = Tim_DS_HV(a);
			float max = DS.TimMax_DT();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == max)
					kq.Them(item);
			return kq;
		}

		public DanhSachHinhHoc Tim_HCN_DT_Min(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			DanhSachHinhHoc DS = Tim_DS_HCN(a);
			float min = DS.TimMin_DT();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == min)
					kq.Them(item);
			return kq;
		}

		public DanhSachHinhHoc Tim_HT_BK_Max(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc kq = new DanhSachHinhHoc();
			DanhSachHinhHoc DS = Tim_DS_HT(a);
			float max = DS.TimMax_BK();
			foreach (var item in a.DS_HH)
				if (item is HinhTron)
				{
					HinhTron t = (HinhTron)item;
					if (t.bk == max)
						kq.Them(item);
				}
			return kq;
		}

		public DanhSachHinhHoc SapXep_HV_Tang_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HV(a);
			DS.DS_HH.Sort((x, y) => x.Tinh_ChuVi().CompareTo(y.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc SapXep_HV_Giam_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HV(a);
			DS.DS_HH.Sort((x, y) => y.Tinh_ChuVi().CompareTo(x.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc SapXep_HT_Tang_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HT(a);
			DS.DS_HH.Sort((x, y) => x.Tinh_ChuVi().CompareTo(y.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc SapXep_HT_Giam_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HT(a);
			DS.DS_HH.Sort((x, y) => y.Tinh_ChuVi().CompareTo(x.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc SapXep_HCN_Tang_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HCN(a);
			DS.DS_HH.Sort((x, y) => x.Tinh_ChuVi().CompareTo(y.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc SapXep_HCN_Giam_CV(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = Tim_DS_HCN(a);
			DS.DS_HH.Sort((x, y) => y.Tinh_ChuVi().CompareTo(x.Tinh_ChuVi()));
			return DS;
		}

		public DanhSachHinhHoc Tim_Hinh_DT_Max(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = new DanhSachHinhHoc();
			float max = a.TimMax_DT();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == max)
					DS.Them(item);
			return DS;
		}

		public DanhSachHinhHoc Tim_Hinh_DT_Min(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = new DanhSachHinhHoc();
			float min = a.TimMin_DT();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == min)
					DS.Them(item);
			return DS;
		}

		public DanhSachHinhHoc Tim_Hinh_CV_Max(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = new DanhSachHinhHoc();
			float max = a.TimMax_CV();
			foreach (var item in a.DS_HH)
				if (item.Tinh_ChuVi() == max)
					DS.Them(item);
			return DS;
		}

		public DanhSachHinhHoc Tim_Hinh_CV_Min(DanhSachHinhHoc a)
		{
			DanhSachHinhHoc DS = new DanhSachHinhHoc();
			float min = a.TimMin_CV();
			foreach (var item in a.DS_HH)
				if (item.Tinh_ChuVi() == min)
					DS.Them(item);
			return DS;
		}

		public DanhSachHinhHoc HienThi_Hinh_DT_Tang(DanhSachHinhHoc a)
		{
			a.DS_HH.Sort((x, y) => x.Tinh_DienTich().CompareTo(y.Tinh_DienTich()));
			return a;
		}

		public DanhSachHinhHoc HienThi_Hinh_DT_Giam(DanhSachHinhHoc a)
		{
			a.DS_HH.Sort((x, y) => y.Tinh_DienTich().CompareTo(x.Tinh_DienTich()));
			return a;
		}

		public DanhSachHinhHoc HienThi_Hinh_CV_Tang(DanhSachHinhHoc a)
		{
			a.DS_HH.Sort((x, y) => x.Tinh_ChuVi().CompareTo(y.Tinh_ChuVi()));
			return a;
		}

		public DanhSachHinhHoc HienThi_Hinh_CV_Giam(DanhSachHinhHoc a)
		{
			a.DS_HH.Sort((x, y) => y.Tinh_ChuVi().CompareTo(x.Tinh_ChuVi()));
			return a;
		}

		public void Xoa_Hinh_DT_Max(DanhSachHinhHoc a)
		{
			float max = a.TimMax_DT();
			DanhSachHinhHoc DS_Xoa = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == max)
					DS_Xoa.Them(item);
			foreach (var item in DS_Xoa.DS_HH)
				a.Xoa(item);
		}

		public void Xoa_Hinh_DT_Min(DanhSachHinhHoc a)
		{
			float min = a.TimMin_DT();
			DanhSachHinhHoc DS_Xoa = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item.Tinh_DienTich() == min)
					DS_Xoa.Them(item);
			foreach (var item in DS_Xoa.DS_HH)
				a.Xoa(item);
		}

		public void Xoa_Hinh_CV_Max(DanhSachHinhHoc a)
		{
			float max = a.TimMax_CV();
			DanhSachHinhHoc DS_Xoa = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item.Tinh_ChuVi() == max)
					DS_Xoa.Them(item);
			foreach (var item in DS_Xoa.DS_HH)
				a.Xoa(item);
		}

		public void Xoa_Hinh_CV_Min(DanhSachHinhHoc a)
		{
			float min = a.TimMin_CV();
			DanhSachHinhHoc DS_Xoa = new DanhSachHinhHoc();
			foreach (var item in a.DS_HH)
				if (item.Tinh_ChuVi() == min)
					DS_Xoa.Them(item);
			foreach (var item in DS_Xoa.DS_HH)
				a.Xoa(item);
		}
	}
}
