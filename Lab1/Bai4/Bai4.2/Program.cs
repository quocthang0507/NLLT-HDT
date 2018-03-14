using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4._2
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			Console.Write("Nhap vao kich thuoc mang: ");
			n = int.Parse(Console.ReadLine());
			double [] a = new double[n];
			Console.WriteLine("Nhap vao cac so thuc:");
			for (int i = 0; i < n; i++)
			{
				Console.Write("Phan tu a[{0}]= ", i);
				a[i] = double.Parse(Console.ReadLine());
			}
			Console.WriteLine("Danh sach cac phan tu ");
			for (int i = 0; i < n; i++)
			{
				Console.Write(" {0} ", a[i]);
			}
			Console.Read();
		}
	}
}
