using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3._2
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
			bool kq = NguyenTo(n);
			if (kq)
				Console.WriteLine("Day la so nguyen to");
			else
				Console.WriteLine("Day khong phai la so nguyen to");
			Console.ReadLine();
		}

		private static bool NguyenTo(int n)
		{
			for (int i = 2; i < n; i++)
				if (n % i == 0)
					return false;
			return true;
		}
	}
}
