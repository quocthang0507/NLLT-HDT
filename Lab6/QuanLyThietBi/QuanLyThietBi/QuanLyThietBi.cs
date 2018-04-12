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

	enum LinhKien
	{
		TatCa, RAM, CPU
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
					default:
						break;
				}
			return kq;
		}

		public DanhSachThietBi Tim_ThietBi_TheoGia(DanhSachThietBi a, float gia, int loai)
		{
			DanhSachThietBi kq = new DanhSachThietBi();
			foreach (var item in a.DS)
				switch ((Gia)loai)
				{
					case Gia.TongGia:
						if (item.TinhGia() == gia)
							kq.Them(item);
						break;
					case Gia.GiaCPU:
						if (item.GiaCPU == gia)
							kq.Them(item);
						break;
					case Gia.GiaRAM:
						if (item.GiaRAM == gia)
							kq.Them(item);
						break;
					default:
						break;
				}
			return kq;
		}

		public void SapXep(DanhSachThietBi a, int thuTu)
		{
			switch ((ThuTu)thuTu)
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

		public DanhSachLinhKien Tim_LinhKien_SuDung_MucDo(DanhSachTanSuat a, int linhKien, int soLan)
		{
			DanhSachLinhKien kq = new DanhSachLinhKien();
			foreach (var item in a.listPair)
				switch ((LinhKien)linhKien)
				{
					case LinhKien.TatCa:
						if (item.SoLan == soLan)
							kq.Them(item.linhKien);
						break;
					case LinhKien.RAM:
						if (item.linhKien is RAM && item.SoLan == soLan)
							kq.Them(item.linhKien);
						break;
					case LinhKien.CPU:
						if (item.linhKien is CPU && item.SoLan == soLan)
							kq.Them(item.linhKien);
						break;
					default:
						break;
				}
			return kq;
		}

		public void HienThi_SL_SuDung_RAM(DanhSachTanSuat a)
		{
			foreach (var item in a.listPair)
				if (item.linhKien is RAM)
					Console.WriteLine(item);
		}
	}
}
