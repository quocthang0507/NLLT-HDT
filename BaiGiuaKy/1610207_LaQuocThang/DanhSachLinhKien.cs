using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1610207_LaQuocThang
{
	class DanhSachLinhKien
	{
		public List<ILinhKien> DS = new List<ILinhKien>();

		public void Them(ILinhKien x)
		{
			if (!DS.Contains(x))
				DS.Add(x);
		}

		public void Xoa_RAM(float gia)
		{
			DS.RemoveAll(t => t is RAM && t.Gia == gia);
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

		public int Dem()
		{
			return DS.Count();
		}
	}
}
