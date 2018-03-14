using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3._1
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			Console.Write("Nhap vao so nguyen am n: ");
			n = int.Parse(Console.ReadLine());
			if (n > 0)
			{
				Console.WriteLine("Phai nhap vao so nguyen am");
				Console.ReadLine();
				return;
			}
			int kq = TinhTong(n);
			Console.WriteLine("Ket qua tong so nguyen am {0} la {1}", n, kq);
			Console.ReadLine();
		}

		private static int TinhTong(int n)
		{
			int kq = 0, i = n;
			while (i <= 0)
			{
				kq += i;
				i++;
			}
			return kq;
		}
	}
}
