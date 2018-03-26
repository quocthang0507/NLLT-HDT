using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class HinhVuong
	{
		private float canh;
		public float c
		{
			get { return canh; }
			set { canh = value; }
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

		public HinhVuong()
		{

		}

		public HinhVuong(float canh)
		{
			c = canh;
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public void Nhap()
		{
			do
			{
				Console.Write("Nhap vao do dai canh: ");
				c = float.Parse(Console.ReadLine());
			} while (c < 0);
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public override string ToString()
		{
			return string.Format("Hinh vuong: Canh {0}, Dien tich {1}, Chu vi {2}", canh, dienTich, chuVi);
		}

		public void Tinh_ChuVi()
		{
			cVi = 4 * canh;
		}

		public void Tinh_DienTich()
		{
			dTich = canh * canh;
		}
	}
}
