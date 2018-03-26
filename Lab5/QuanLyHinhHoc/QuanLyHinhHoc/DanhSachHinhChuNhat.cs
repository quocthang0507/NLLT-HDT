using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class DanhSachHinhChuNhat
	{
		public List<HinhChuNhat> DS_HCN = new List<HinhChuNhat>();

		public HinhChuNhat this[int index]
		{
			get { return DS_HCN[index]; }
		}

		public int Dem
		{
			get { return DS_HCN.Count; }
		}

		public void Them(HinhChuNhat a)
		{
			DS_HCN.Add(a);
		}

		public override string ToString()
		{
			string s = "";
			foreach (var item in DS_HCN)
				s += item + "\n";
			return s;
		}

		public void Xuat()
		{
			Console.WriteLine(this);
		}

		public void Xoa(HinhChuNhat a)
		{
			DS_HCN.Remove(a);
		}
	}
}
