using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class DanhSachHinhVuong
	{
		public List<HinhVuong> DS_HV = new List<HinhVuong>();

		public HinhVuong this[int index]
		{
			get { return DS_HV[index]; }
		}

		public int Dem
		{
			get { return DS_HV.Count; }
		}
		public void Them(HinhVuong a)
		{
			DS_HV.Add(a);
		}

		public override string ToString()
		{
			string s = "";
			foreach (var item in DS_HV)
				s += item + "\n";
			return s;
		}

		public void Xuat()
		{
			Console.WriteLine(this);
		}

		public void Xoa(HinhVuong a)
		{
			DS_HV.Remove(a);
		}
	}
}
