using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4._1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Nhập kích thước và khởi tạo mảng 1 chiều
			int n;
			do
			{
				Console.Write("Nhap vao kich thuoc mang: ");
				n = int.Parse(Console.ReadLine());
			} while (n < 0);
			int[] a = new int[n];
			//Nhập các phần tử vào mảng
			for (int i = 0; i < n; i++)
			{
				Console.Write("Phan tu a[{0}]= ", i);
				a[i] = int.Parse(Console.ReadLine());
			}
			//Tính tổng
			int tong = 0;
			for (int i = 0; i < a.Length; i++)
				tong += a[i];
			//Xuất các phần tử trong mảng
			Console.WriteLine("Danh sach cac phan tu ");
			for (int i = 0; i < n; i++)
			{
				Console.Write(" {0} ", a[i]);
			}
			//Xuất tổng
			Console.WriteLine(" Tong cac phan tu = {0}", tong);
			Console.Read();
		}
	}
}
