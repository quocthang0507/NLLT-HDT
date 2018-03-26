using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class HinhChuNhat
	{
		private float chieuDai;
		public float cDai
		{
			get { return chieuDai; }
			set { chieuDai = value; }
		}
		private float chieuRong;
		public float cRong
		{
			get { return chieuRong; }
			set { chieuRong = value; }
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

		public HinhChuNhat()
		{

		}

		public HinhChuNhat(float chieuDai, float chieuRong)
		{
			cDai = chieuDai;
			cRong = chieuRong;
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public void Nhap()
		{
			do
			{
				Console.Write("Nhap do dai cua chieu dai: ");
				cDai = float.Parse(Console.ReadLine());
				Console.Write("Nhap do dai cua chieu rong: ");
				cRong = float.Parse(Console.ReadLine());
			} while (cDai < 0 || cRong < 0);
			Tinh_ChuVi();
			Tinh_DienTich();
		}

		public override string ToString()
		{
			return string.Format("Hinh chu nhat: Chieu dai {0}, Chieu rong {1}, Dien tich {2}, Chu vi {3}", chieuDai, chieuRong, dienTich, chuVi);
		}

		public void Tinh_ChuVi()
		{
			cVi = (chieuDai + chieuRong) * 2;
		}

		public void Tinh_DienTich()
		{
			dTich = chieuRong * chieuDai;
		}
	}
}
