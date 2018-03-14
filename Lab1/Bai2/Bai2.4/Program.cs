using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2._4
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			Console.Write("Nhap vao kich thuoc tam giac: ");
			n = int.Parse(Console.ReadLine());
			for (int i = 1; i <= n; i++, Console.WriteLine())
				for (int k = 1; k <= i; k++)
				{
					Console.Write("*");
				}
			Console.ReadLine();
		}
	}
}
