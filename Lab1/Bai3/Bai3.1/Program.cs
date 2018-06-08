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
			do
			{
				Console.Write("Nhap vao so nguyen am n: ");
				n = int.Parse(Console.ReadLine());
			} while (n >= 0);
			int kq = TinhTong(n);
			Console.WriteLine("Ket qua tong so nguyen am tu {0} den -1 la {1}", n, kq);
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
