using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1610207_LaQuocThang
{
	enum PhanLoai
	{
		MayTinh, MayAnh, DienThoai
	}

	class QuanLyThietBi
	{
		public DanhSachThietBi PhanLoai_ThietBi(DanhSachThietBi DS, int loai)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			foreach (var item in DS.DS)
				switch ((PhanLoai)loai)
				{
					case PhanLoai.MayTinh:
						if (item is MayTinh)
							kq.Them(item);
						break;
					case PhanLoai.MayAnh:
						if (item is MayAnh)
							kq.Them(item);
						break;
					case PhanLoai.DienThoai:
						if (item is DienThoai)
							kq.Them(item);
						break;
					default:
						break;
				}
			return kq;
		}

		public DanhSachThietBi Cau1_Tim_DienThoai_It_CPU(DanhSachThietBi a)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			foreach (var item in a.DS)
			{
				DienThoai t = (DienThoai)item;
				foreach (var lk in t.DS_LK)
				{
					if (lk is CPU && lk.SoLuong == 1)
						kq.Them(item);
				}
			}
			return kq;
		}

		public DanhSachLinhKien Tim_CPU_SuDung_MucDo(DanhSachTanSuat a, int soLan)
		{
			DanhSachLinhKien kq = new DanhSachLinhKien();
			foreach (var item in a.listPair)
				if (item.linhKien is CPU && item.SoLan == soLan)
					kq.Them(item.linhKien);
			return kq;
		}

		public DanhSachLinhKien Cau3_TimCPU_SuDungNhieuNhat(DanhSachTanSuat a, int max)
		{
			return Tim_CPU_SuDung_MucDo(a, max);
		}

		public DanhSachLinhKien Cau4_TimCPU_KhongDuocSuDung(DanhSachTanSuat a)
		{
			return Tim_CPU_SuDung_MucDo(a, 0);
		}
	}
}
