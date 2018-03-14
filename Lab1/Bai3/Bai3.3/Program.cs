using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3._3
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			do
			{
				Console.Write("Nhap vao so nguyen duong: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 0);
			if (n >= 0)
			{
				int kq = GiaiThua(n);
				Console.WriteLine("{0}!={1}", n, kq);
			}
			Console.ReadLine();
		}

		private static int GiaiThua(int n)
		{
			if (n > 0)
				return n * GiaiThua(n - 1);
			return 1;
		}
	}
}
