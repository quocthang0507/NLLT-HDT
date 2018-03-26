using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class DanhSachHinhTron
	{
		public List<HinhTron> DS_HT = new List<HinhTron>();

		public HinhTron this[int index]
		{
			get { return DS_HT[index]; }
		}

		public int Dem
		{
			get { return DS_HT.Count; }
		}

		public void Them(HinhTron a)
		{
			DS_HT.Add(a);
		}

		public override string ToString()
		{
			string s = "";
			foreach (var item in DS_HT)
				s += item + "\n";
			return s;
		}

		public void Xuat()
		{
			Console.WriteLine(this);
		}

		public void Xoa(HinhTron a)
		{
			DS_HT.Remove(a);
		}
	}
}
