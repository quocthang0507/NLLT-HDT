using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class Program
	{
		enum Menu
		{
			Thoat,
			Nhap
		}
		static void Main(string[] args)
		{
			Console.WriteLine(" ".PadRight(30) + "HE THONG CHUC NANG");
			//Menu ở đây
			Console.Write("Nhap so thu tu chuc nang: ");
			Menu menu = (Menu)int.Parse(Console.ReadLine());
			Console.ReadKey();
		}
	}
}
