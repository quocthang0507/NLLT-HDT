using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc_KeThua
{
	class DanhSachHinhHoc
	{
		public List<HinhHoc> DS_HH = new List<HinhHoc>();

		public HinhHoc this[int index]
		{
			get { return this[index]; }
		}

		public void Them(HinhHoc a)
		{
			DS_HH.Add(a);
		}

		public void Xoa(HinhHoc a)
		{
			DS_HH.Remove(a);
		}

		public override string ToString()
		{
			string s = "\n";
			foreach (var item in DS_HH)
				s += item + "\n";
			return s;
		}

		public void Xuat_DS()
		{
			Console.WriteLine(this);
		}

		public void DocTuFile()
		{
			string path = @"data.txt";
			StreamReader sr = new StreamReader(path);
			string s = "";
			while ((s = sr.ReadLine()) != null)
			{
				string[] t = s.Split(' ');
				if (t[0] == "HT")
					Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					Them(new HinhVuong(float.Parse(t[1])));
				else
					Them(new HinhCN(float.Parse(t[1]), float.Parse(t[2])));
			}
		}

		public void NhapBangTay()
		{
			string s = "";
			do
			{
				Console.Write("Nhap theo dinh dang, moi lan nhap la mot hinh (HT 4, HCN 4 5, HV 5.5): ");
				s = Console.ReadLine();
				string[] t = s.Split(' ');
				if (t[0] == "HT")
					Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					Them(new HinhVuong(float.Parse(t[1])));
				else if (t[0] == "HCN")
					Them(new HinhCN(float.Parse(t[1]), float.Parse(t[2])));
				else return;
			} while (s == "");
		}

		public float TimMax_DT()
		{
			float max = float.MinValue;
			foreach (var item in DS_HH)
				if (max < item.Tinh_DienTich())
					max = item.Tinh_DienTich();
			return max;
		}

		public float TimMin_DT()
		{
			float min = float.MaxValue;
			foreach (var item in DS_HH)
				if (min > item.Tinh_DienTich())
					min = item.Tinh_DienTich();
			return min;
		}

		public float TimMax_CV()
		{
			float max = float.MinValue;
			foreach (var item in DS_HH)
				if (max < item.Tinh_ChuVi())
					max = item.Tinh_ChuVi();
			return max;
		}

		public float TimMin_CV()
		{
			float min = float.MaxValue;
			foreach (var item in DS_HH)
				if (min > item.Tinh_ChuVi())
					min = item.Tinh_ChuVi();
			return min;
		}

		public float TimMax_BK()
		{
			float max = float.MinValue;
			foreach (var item in DS_HH)
				if (item is HinhTron)
				{
					HinhTron t = (HinhTron)item;
					if (max < t.bk)
						max = t.bk;
				}
			return max;
		}
	}
}
