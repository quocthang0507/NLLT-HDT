using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2._2
{
	class Program
	{
		static void Main(string[] args)
		{
			string sa, sb;
			Console.Write("Nhap vao chuoi dau tien: ");
			sa = Console.ReadLine();
			Console.Write("Nhap vao chuoi thu hai: ");
			sb = Console.ReadLine();
			Console.WriteLine("Chuoi vua nhap:" + (sa + sb));
			Console.ReadLine();
		}
	}
}
