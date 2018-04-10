using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	class DanhSachThietBi
	{
		public List<IThietBi> DS = new List<IThietBi>();

		public void Them(IThietBi x)
		{
			DS.Add(x);
		}

		public void Xoa(IThietBi x)
		{
			DS.Remove(x);
		}

		public override string ToString()
		{
			string s = "\n";
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
			string p = @"ThietBi.txt";
			StreamReader sr = new StreamReader(p);
			string s;
			string[] tR;
			string[] tC;
			while ((s = sr.ReadLine()) != null)
			{
				string[] t = s.Split(',');
				if (t[0] == "MT")
				{
					tR = t[2].Split(' ');
					tC = t[3].Split(' ');
					Them(new MayTinh(t[1], new RAM(float.Parse(tR[1]), tR[0]), new CPU(float.Parse(tC[1]), tC[0])));
				}
				else
				{
					tR = t[2].Split(' ');
					tC = t[3].Split(' ');
					Them(new MayAnh(t[1], new RAM(float.Parse(tR[1]), tR[0]), new CPU(float.Parse(tC[1]), tC[0])));
				}
			}
		}

		public void NhapBangTay()
		{
			string[] tR, tC;
			while (true)
			{
				Console.Write("Nhap theo dinh dang sau (Vd: MT,Dell,Corsair_4GB 81,Corei9-7940X 1366) : ");
				string s = Console.ReadLine();
				string[] t = s.Split(',');
				if (t[0] == "MT")
				{
					tR = t[2].Split(' ');
					tC = t[3].Split(' ');
					Them(new MayTinh(t[1], new RAM(float.Parse(tR[1]), tR[0]), new CPU(float.Parse(tC[1]), tC[0])));
				}
				else if (t[0] == "MA")
				{
					tR = t[2].Split(' ');
					tC = t[3].Split(' ');
					Them(new MayAnh(t[1], new RAM(float.Parse(tR[1]), tR[0]), new CPU(float.Parse(tC[1]), tC[0])));
				}
				else if (s == "")
					break;
			}
		}

		public int Dem()
		{
			return DS.Count();
		}

		public float Tim_Max()
		{
			float max = float.MinValue;
			foreach (var item in this.DS)
			{
				if (item.TinhGia() > max)
					max = item.TinhGia();
				item
			}
			return max;
		}

		public float Tim_Min()
		{
			float min = float.MaxValue;
			foreach (var item in this.DS)
			{
				if (item.TinhGia() < min)
					min = item.TinhGia();
			}
			return min;
		}
	}
}
