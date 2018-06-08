using QuanLyPhanSo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Phan so dau tien: ");
			PhanSo a = new PhanSo();
			a.Nhap_PhanSo();
			Console.WriteLine("\nPhan so thu hai: ");
			PhanSo b = new PhanSo();
			b.Nhap_PhanSo();
			Console.Write("\nPhan so dau tien: ");
			Console.WriteLine(a.ToString());
			Console.Write("Phan so thu hai: ");
			Console.WriteLine(b.ToString());
			string A = a.ToString(), B = b.ToString();
			Console.WriteLine("\nCac thao tac tren hai phan so: ");
			PhanSo kq = PhanSo.Cong(a, b);
			Console.WriteLine(A + " + " + B + " = " + kq.ToString());
			kq = PhanSo.Tru(a, b);
			Console.WriteLine(A + " - " + B + " = " + kq.ToString());
			kq = PhanSo.Nhan(a, b);
			Console.WriteLine(A + " x " + B + " = " + kq.ToString());
			kq = PhanSo.Chia(a, b);
			Console.WriteLine(A + " / " + B + " = " + kq.ToString());
			Console.ReadKey();
		}
	}
}