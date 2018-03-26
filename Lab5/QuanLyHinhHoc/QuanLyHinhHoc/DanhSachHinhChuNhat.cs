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
			string s = "Danh sach hinh chu nhat:\n";
			foreach (var item in DS_HCN)
			{
				s += "\t" + item + "\n";
			}
			return s;
		}

		public void Xuat()
		{
			Console.WriteLine("Danh sach hinh chu nhat:");
			foreach (var item in DS_HCN)
			{
				Console.WriteLine("\t" + item);
			}
		}

	}
}
