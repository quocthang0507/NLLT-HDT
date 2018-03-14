using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3._4
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			do
			{
				Console.Write("Nhap vao so nguyen duong n: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 0);
			TinhTong(n);
			Console.ReadLine();
		}

		private static void TinhTong(int n)
		{
			int odd = 0, even = 0;
			for (int i = 0; i <= n; i++)
			{
				if (i % 2 == 0)
					even += i;
				else odd += i;
			}
			Console.WriteLine("Tong cac so chan {0}, tong cac so le {1}", even, odd);
		}
	}
}
