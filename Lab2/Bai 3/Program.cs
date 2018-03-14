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
			Console.WriteLine(a.ToString() + " + " + b.ToString() + " = " + a.Cong(a, b));
			Console.WriteLine(a.ToString() + " - " + b.ToString() + " = " + a.Tru(a, b));
			Console.WriteLine(a.ToString() + " x " + b.ToString() + " = " + a.Nhan(a, b));
			Console.WriteLine(a.ToString() + " / " + b.ToString() + " = " + a.Chia(a, b));
			Console.ReadLine();
		}
	}
}
