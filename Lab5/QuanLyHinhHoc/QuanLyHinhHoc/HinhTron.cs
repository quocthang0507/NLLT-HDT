using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class HinhTron
	{
		private float banKinh;
		public float bKinh
		{
			get { return banKinh; }
			set { banKinh = value; }
		}
		private float chuVi;
		public float cVi
		{
			get { return chuVi; }
			set { chuVi = value; }
		}
		private float dienTich;
		public float dTich
		{
			get { return dienTich; }
			set { dienTich = value; }
		}

		public HinhTron()
		{

		}

		public HinhTron(float banKinh)
		{
			bKinh = banKinh;
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public void Nhap()
		{
			do
			{
				Console.Write("Nhap vao do dai ban kinh: ");
				bKinh = float.Parse(Console.ReadLine());
			} while (banKinh < 0);
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public override string ToString()
		{
			return string.Format("\tHinh tron: Ban kinh {0}, Dien tich {1}, Chu vi {2}", banKinh, dienTich, chuVi);
		}

		public void Tinh_ChuVi()
		{
			cVi = banKinh * 2 * (float)Math.PI;
		}

		public void Tinh_DienTich()
		{
			dTich = banKinh * banKinh * (float)Math.PI;
		}
	}
}
