using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
	class SoPhuc
	{
		public double phanThuc;
		public double phanAo;

		#region
		public SoPhuc()
		{

		}

		public void Nhap_SoPhuc()
		{
			Console.Write("Nhap phan thuc : ");
			this.phanThuc = double.Parse(Console.ReadLine());
			Console.Write("Nhap phan ao : ");
			this.phanAo = double.Parse(Console.ReadLine());
		}

		public SoPhuc(double thuc, double ao)
		{
			this.phanThuc = thuc;
			this.phanAo = ao;
		}

		public SoPhuc(SoPhuc a)
		{
			this.phanThuc = a.phanThuc;
			this.phanAo = a.phanAo;
		}
		#endregion

		public override string ToString()
		{
			if (this.phanAo < 0)
				return this.phanThuc.ToString() + "-" + Math.Abs(this.phanAo).ToString() + "i";
			return this.phanThuc.ToString() + "+" + this.phanAo.ToString() + "i";
		}

		public static double Modun(SoPhuc a)
		{
			return Math.Sqrt(Math.Pow(a.phanThuc, 2) + Math.Pow(a.phanAo, 2));
		}

		public string SoPhuc_LienHop()
		{
			if (this.phanAo < 0)
				return this.phanThuc.ToString() + "+" + Math.Abs(this.phanAo).ToString() + "i";
			return this.phanThuc.ToString() + "-" + this.phanAo.ToString() + "i";
		}

		public static string Cong(SoPhuc a, SoPhuc b)
		{
			double phanThuc = a.phanThuc + b.phanThuc;
			double phanAo = a.phanAo + b.phanAo;
			if (phanAo < 0)
				return phanThuc.ToString() + "-" + Math.Abs(phanAo).ToString() + "i";
			return phanThuc.ToString() + "+" + phanAo.ToString() + "i";
		}

		public static string Tru(SoPhuc a, SoPhuc b)
		{
			double phanThuc = a.phanThuc - b.phanThuc;
			double phanAo = a.phanAo - b.phanAo;
			if (phanAo < 0)
				return phanThuc.ToString() + "-" + Math.Abs(phanAo).ToString() + "i";
			return phanThuc.ToString() + "+" + phanAo.ToString() + "i";
		}

		public static string Nhan(SoPhuc a, SoPhuc b)
		{
			double phanThuc = a.phanThuc * b.phanThuc - a.phanAo * b.phanAo;
			double phanAo = a.phanThuc * b.phanAo + b.phanThuc * a.phanAo;
			if (phanAo < 0)
				return phanThuc.ToString() + "-" + Math.Abs(phanAo).ToString() + "i";
			return phanThuc.ToString() + "+" + phanAo.ToString() + "i";
		}

		public static string Chia(SoPhuc a, SoPhuc b)
		{
			SoPhuc lienHop_b = new SoPhuc();
			lienHop_b.phanThuc = b.phanThuc;
			lienHop_b.phanAo = -b.phanAo;
			return "\n" + Nhan(a, lienHop_b) + "\n-------\n" + Nhan(b, lienHop_b);
		}
	}
}
