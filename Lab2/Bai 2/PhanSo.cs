using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhanSo
{
	class PhanSo
	{
		public int tuSo;
		public int mauSo;

		public PhanSo()
		{
			mauSo = 1;
		}

		/// <summary>
		/// Nhập phân số từ bàn phím
		/// </summary>
		public void Nhap_PhanSo()
		{
			Console.Write("Nhap tu so: ");
			tuSo = int.Parse(Console.ReadLine());
			do
			{
				Console.Write("Nhap mau so (>0): ");
				mauSo = int.Parse(Console.ReadLine());
			} while (mauSo <= 0);
		}

		/// <summary>
		/// Tạo phân số với tử và mẫu sẵn có
		/// </summary>
		/// <param name="tuSo">Tử số</param>
		/// <param name="mauSo">Mẫu số</param>
		public PhanSo(int tu, int mau)
		{
			tuSo = tu;
			mauSo = mau;
		}

		/// <summary>
		/// Tạo phân số từ một số
		/// </summary>
		/// <param name="so">Số</param>
		public PhanSo(int tu)
		{
			tuSo = tu;
			mauSo = 1;
		}

		/// <summary>
		/// Tạo phân số mới giống phân số tham chiếu
		/// </summary>
		/// <param name="PhanSo">Phân số tham chiếu</param>
		public PhanSo(PhanSo a)
		{
			tuSo = a.tuSo;
			mauSo = a.mauSo;
		}

		public override string ToString()
		{
			string kq = "";
			if (tuSo == 0)
				return "0";
			if (mauSo == 1)
				return tuSo.ToString();
			kq += tuSo.ToString() + "/" + mauSo.ToString();
			return kq;
		}

		public int UCLN(int a, int b)
		{
			int r;
			a = Math.Abs(a);
			b = Math.Abs(b);
			while (b > 0)
			{
				r = a % b;
				a = b;
				b = r;
			}
			return Math.Abs(a);
		}

		public int BCNN(int a, int b)
		{
			return Math.Abs((a * b) / UCLN(a, b));
		}

		public void RutGon(PhanSo a)
		{
			int d;
			d = UCLN(Math.Abs(a.tuSo), a.mauSo);
			a.mauSo /= (int)d;
			a.tuSo /= (int)d;
		}

		public void QuyDong(PhanSo a, PhanSo b)
		{
			int d;
			RutGon(a);
			RutGon(b);
			d = BCNN(a.mauSo, b.mauSo);
			a.tuSo *= (d / a.mauSo);
			b.tuSo *= (d / b.mauSo);
			a.mauSo = b.mauSo = d;
		}

		public PhanSo Cong(PhanSo a, PhanSo b)
		{
			PhanSo kq = new PhanSo();
			QuyDong(a, b);
			kq.tuSo = a.tuSo + b.tuSo;
			kq.mauSo = a.mauSo;
			RutGon(kq);
			return kq;
		}
		public PhanSo Cong(PhanSo a)
		{
			return Cong(this, a);
		}

		public static PhanSo operator +(PhanSo a, PhanSo b)
		{
			return a.Cong(b);
		}
		public PhanSo Tru(PhanSo a, PhanSo b)
		{
			PhanSo kq = new PhanSo();
			QuyDong(a, b);
			kq.tuSo = a.tuSo - b.tuSo;
			kq.mauSo = a.mauSo;
			RutGon(kq);
			return kq;
		}
		public PhanSo Tru(PhanSo a)
		{
			return Tru(this, a);
		}
		public static PhanSo operator -(PhanSo a, PhanSo b)
		{
			return a.Tru(b);
		}

		public PhanSo Nhan(PhanSo a, PhanSo b)
		{
			PhanSo kq = new PhanSo();
			RutGon(a);
			RutGon(b);
			kq.tuSo = a.tuSo * b.tuSo;
			kq.mauSo = a.mauSo * b.mauSo;
			RutGon(kq);
			return kq;
		}
		public PhanSo Nhan(PhanSo a)
		{
			return Nhan(this, a);
		}

		public static PhanSo operator *(PhanSo a, PhanSo b)
		{
			return a.Nhan(b);
		}

		public PhanSo Chia(PhanSo a, PhanSo b)
		{
			PhanSo kq = new PhanSo();
			RutGon(a);
			RutGon(b);
			int tu, mau;
			tu = a.tuSo * b.mauSo;
			mau = a.mauSo * b.tuSo;
			if (mau < 0)
			{
				tu = -tu;
				mau = -mau;
			}
			kq.tuSo = tu;
			kq.mauSo = Math.Abs(mau);
			RutGon(kq);
			return kq;
		}
		public PhanSo Chia(PhanSo a)
		{
			return Chia(this, a);
		}

		public static PhanSo operator /(PhanSo a, PhanSo b)
		{
			return a.Chia(b);
		}
		public static bool operator ==(PhanSo a, PhanSo b)
		{
			a.QuyDong(a, b);
			return (a.tuSo == b.tuSo);
		}
		public static bool operator !=(PhanSo a, PhanSo b)
		{
			a.QuyDong(a, b);
			return (a.tuSo != b.tuSo);
		}
		public static bool operator >(PhanSo a, PhanSo b)
		{
			a.QuyDong(a, b);
			return (a.tuSo > b.tuSo);
		}
		public static bool operator <(PhanSo a, PhanSo b)
		{
			a.QuyDong(a, b);
			return (a.tuSo < b.tuSo);
		}
	}
}
