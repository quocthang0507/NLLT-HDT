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
			//Nhập và khởi tạo mảng một chiều kích thước n
			int n;
			Console.Write("Nhap vao kich thuoc mang: ");
			n = int.Parse(Console.ReadLine());
			double [] a = new double[n];
			//Nhập các phần tử
			Console.WriteLine("Nhap vao cac so thuc:");
			for (int i = 0; i < n; i++)
			{
				Console.Write("Phan tu a[{0}]= ", i);
				a[i] = double.Parse(Console.ReadLine());
			}
			//Xuất mảng
			Console.WriteLine("Danh sach cac phan tu ");
			for (int i = 0; i < n; i++)
			{
				Console.Write(" {0} ", a[i]);
			}
			Console.Read();
		}
	}
}
