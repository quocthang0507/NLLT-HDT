using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	enum PhanLoai
	{
		MayTinh, MayAnh
	}

	enum ThuTu
	{
		Tang, Giam
	}

	class QuanLyThietBi
	{
		public DanhSachThietBi PhanLoai_ThietBi(DanhSachThietBi DS, int loai)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			switch ((PhanLoai)loai)
			{
				case PhanLoai.MayTinh:
					foreach (var item in DS.DS)
						if (item is MayTinh)
							kq.Them(item);
					break;
				case PhanLoai.MayAnh:
					foreach (var item in DS.DS)
						if (item is MayAnh)
							kq.Them(item);
					break;
				default:
					break;
			}
			return kq;
		}

		public DanhSachThietBi Tim_ThietBi_TheoGia(DanhSachThietBi a, float gia)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			foreach (var item in a.DS)
				if (item.TinhGia() == gia)
					kq.Them(item);
			return kq;
		}

		public void SapXep(DanhSachThietBi a, int tt)
		{
			switch ((ThuTu)tt)
			{
				case ThuTu.Tang:
					a.DS.Sort((x, y) => x.TinhGia().CompareTo(y.TinhGia()));
					break;
				case ThuTu.Giam:
					a.DS.Sort((x, y) => y.TinhGia().CompareTo(x.TinhGia()));
					break;
				default:
					break;
			}
		}

		public DanhSachThietBi Tim_ThietBi_TheoGiaCPU(DanhSachThietBi a, float gia)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			foreach (var item in a.DS)
				if (item.TinhGia() == gia)
					kq.Them(item);
			return kq;
		}

	}
}
