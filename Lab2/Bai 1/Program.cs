using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
	class Program
	{
		static void Main(string[] args)
		{
			MaTran a = new MaTran(3, 3);
			a.Nhap();
			Console.WriteLine("\nMa tran a: \n" + a.ToString());
			MaTran b = a;
			Console.WriteLine("\nMa tran b: \n" + b.ToString());
			//a.Tong(b);
			a = MaTran.Tong(a, b);
			Console.WriteLine("\nTong 2 ma tran: \n" + a.ToString());
			Console.Read();
		}
	}
}
