using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
	class Program
	{
		static void Main(string[] args)
		{
			SoPhuc a = new SoPhuc();
			SoPhuc b = new SoPhuc();
			Console.WriteLine("Nhap so phuc dau tien : ");
			a.Nhap_SoPhuc();
			Console.WriteLine("\nNhap so phuc tiep theo : ");
			b.Nhap_SoPhuc();
			Console.WriteLine("Cac phep toan tren so phuc: ");
			Console.WriteLine("So phuc lien hop cua " + a.ToString() + " = " + a.SoPhuc_LienHop());
			Console.WriteLine("So phuc lien hop cua " + b.ToString() + " = " + b.SoPhuc_LienHop());
			Console.WriteLine(a.ToString() + " + " + b.ToString() + " = " + SoPhuc.Cong(a, b));
			Console.WriteLine(a.ToString() + " - " + b.ToString() + " = " + SoPhuc.Tru(a, b));
			Console.WriteLine(a.ToString() + " x " + b.ToString() + " = " + SoPhuc.Nhan(a, b));
			Console.WriteLine(a.ToString() + " / " + b.ToString() + " = " + SoPhuc.Chia(a, b));
			Console.ReadLine();
		}
	}
}
