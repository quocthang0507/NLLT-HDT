using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc_KeThua
{
	abstract class HinhHoc
	{
		public abstract float Tinh_DienTich();
		public abstract float Tinh_ChuVi();
	}

	class HinhTron : HinhHoc
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

		public override float Tinh_DienTich()
		{
			return (float)Math.PI * banKinh * banKinh;
		}

		public override float Tinh_ChuVi()
		{
			return (float)Math.PI * 2 * banKinh;
		}

		public override string ToString()
		{
			return string.Format("Hinh tron: Ban kinh {0}, Dien tich {1}, Chu vi {2}", banKinh, Tinh_DienTich(), Tinh_ChuVi());
		}
	}

	class HinhVuong : HinhHoc
	{
		float canh;

		public HinhVuong()
		{

		}

		public HinhVuong(float canh)
		{
			this.canh = canh;
		}

		public override float Tinh_DienTich()
		{
			return (float)Math.Pow(canh, 2);
		}

		public override float Tinh_ChuVi()
		{
			return canh * 4;
		}

		public override string ToString()
		{
			return string.Format("Hinh vuong: Canh {0}, Dien tich {1}, Chu vi {2}", canh, Tinh_DienTich(), Tinh_ChuVi());
		}
	}

	class HinhCN : HinhHoc
	{
		float chieuRong;
		float chieuDai;
		public HinhCN()
		{

		}

		public HinhCN(float chieuDai, float chieuRong)
		{
			this.chieuRong = chieuRong;
			this.chieuDai = chieuDai;
		}

		public override float Tinh_DienTich()
		{
			return chieuRong * chieuDai;
		}

		public override float Tinh_ChuVi()
		{
			return 2 * (chieuRong + chieuDai);
		}

		public override string ToString()
		{
			return string.Format("Hinh chu nhat: Chieu dai {0}, Chieu rong {1}, Dien tich {2}, Chu vi {3}", chieuDai, chieuRong, Tinh_DienTich(), Tinh_ChuVi());
		}
	}
}
