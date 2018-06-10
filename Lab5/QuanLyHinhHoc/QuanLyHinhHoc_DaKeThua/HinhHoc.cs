using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc_DaKeThua
{
	public interface IHinhHoc
	{
		float Tinh_ChuVi();
		float Tinh_DienTich();
	}

	class HinhTron : IHinhHoc
	{
		float banKinh;
		public float bk
		{
			get { return banKinh; }
		}
		public HinhTron()
		{

		}

		public HinhTron(float banKinh)
		{
			this.banKinh = banKinh;
		}

		public float Tinh_ChuVi()
		{
			return (float)Math.PI * banKinh * 2;
		}

		public float Tinh_DienTich()
		{
			return (float)Math.PI * banKinh * banKinh;
		}

		public override string ToString()
		{
			return string.Format("Hinh tron: Ban kinh {0}, Dien tich {1}, Chu vi {2}", banKinh, Tinh_DienTich(), Tinh_ChuVi());
		}
	}

	class HinhVuong : IHinhHoc
	{
		float canh;
		public HinhVuong()
		{

		}

		public HinhVuong(float canh)
		{
			this.canh = canh;
		}

		public float Tinh_ChuVi()
		{
			return canh * 4;
		}

		public float Tinh_DienTich()
		{
			return canh * canh;
		}

		public override string ToString()
		{
			return string.Format("Hinh vuong: Canh {0}, Dien tich {1}, Chu vi {2}", canh, Tinh_DienTich(), Tinh_ChuVi());
		}
	}

	class HinhCN : IHinhHoc
	{
		float chieuDai;
		float chieuRong;
		public HinhCN()
		{

		}

		public HinhCN(float chieuDai, float chieuRong)
		{
			this.chieuDai = chieuDai;
			this.chieuRong = chieuRong;
		}

		public float Tinh_ChuVi()
		{
			return (chieuDai + chieuRong) * 2;
		}

		public float Tinh_DienTich()
		{
			return chieuDai * chieuRong;
		}
		public override string ToString()
		{
			return string.Format("Hinh chu nhat: Chieu dai {0}, Chieu rong {1}, Dien tich {2}, Chu vi {3}", chieuDai, chieuRong, Tinh_DienTich(), Tinh_ChuVi());
		}
	}
}
