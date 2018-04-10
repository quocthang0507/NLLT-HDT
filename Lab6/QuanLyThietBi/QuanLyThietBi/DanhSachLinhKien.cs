using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	class DanhSachLinhKien
	{
		List<ILinhKien> DS = new List<ILinhKien>();

		public void Them(ILinhKien x)
		{
			DS.Add(x);
		}

		public void Xoa(ILinhKien x)
		{
			DS.Remove(x);
		}

		public override string ToString()
		{
			string s = "";
			foreach (var item in DS)
				s += item + "\n";
			return s;
		}

		public void Xuat()
		{
			Console.WriteLine(this);
		}

		public void NhapTuFile()
		{
			string p = @"LinhKien.txt";
			StreamReader sr = new StreamReader(p);
			string s;
			while ((s = sr.ReadLine()) != null)
			{
				string[] t = s.Split(',');
				if (t[0] == "RAM")
				{
					string[] x = t[1].Split(' ');
					Them(new RAM(float.Parse(x[1]), x[0]));
				}
				else
				{
					string[] x = t[1].Split(' ');
					Them(new CPU(float.Parse(x[1]), x[0]));
				}
			}
		}
	}
}
