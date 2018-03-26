using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class QuanLyHinhHoc
	{
		public DanhSachHinhChuNhat DS_HCN = new DanhSachHinhChuNhat();
		public DanhSachHinhTron DS_HT = new DanhSachHinhTron();
		public DanhSachHinhVuong DS_HV = new DanhSachHinhVuong();

		public void DocTuFile()
		{
			string path = @"data.txt";
			StreamReader sr = new StreamReader(path);
			string s = "";
			while ((s = sr.ReadLine()) != null)
			{
				string[] t = s.Split(' ');
				if (t[0] == "HT")
					DS_HT.Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					DS_HV.Them(new HinhVuong(float.Parse(t[1])));
				else
					DS_HCN.Them(new HinhChuNhat(float.Parse(t[1]), float.Parse(t[2])));
			}
		}
		public void Xuat()
		{
			Console.WriteLine();
			Console.WriteLine(DS_HCN);
			Console.WriteLine(DS_HV);
			Console.WriteLine(DS_HT);
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
					DS_HT.Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					DS_HV.Them(new HinhVuong(float.Parse(t[1])));
				else if (t[0] == "HCN")
					DS_HCN.Them(new HinhChuNhat(float.Parse(t[1]), float.Parse(t[2])));
				else return;
			} while (s != "");
		}

		//public List<float> Xuat_DS_DienTich()
		//{
		//	List<float> kq = new List<float>();
		//	foreach (var item in DS_HCN.DS_HCN)
		//		kq.Add(item.dTich);
		//	foreach (var item in DS_HT.DS_HT)
		//		kq.Add(item.dTich);
		//	foreach (var item in DS_HV.DS_HV)
		//		kq.Add(item.dTich);
		//	return kq;
		//}

		public List<float> Xuat_DS_S_HV()
		{
			List<float> kq = new List<float>();
			foreach (var item in DS_HV.DS_HV)
				kq.Add(item.dTich);
			return kq;
		}

		public List<HinhVuong> Tim_HV_S_Max()
		{
			List<HinhVuong> kq = new List<HinhVuong>();
			float max = Xuat_DS_S_HV().Max();
			foreach (var item in DS_HV.DS_HV)
			{
				if (item.dTich == max)
					kq.Add(item);
			}
			return kq;
		}

		public List<float> Xuat_DS_S_HCN()
		{
			List<float> kq = new List<float>();
			foreach (var item in DS_HCN.DS_HCN)
				kq.Add(item.dTich);
			return kq;
		}

		public List<HinhChuNhat> Tim_HCN_S_Min()
		{
			List<HinhChuNhat> kq = new List<HinhChuNhat>();
			float min = Xuat_DS_S_HCN().Min();
			foreach (var item in DS_HCN.DS_HCN)
			{
				if (item.dTich == min)
					kq.Add(item);
			}
			return kq;
		}

		public List<float> Xuat_DS_S_HT()
		{
			List<float> kq = new List<float>();
			foreach (var item in DS_HT.DS_HT)
				kq.Add(item.dTich);
			return kq;
		}

		public List<HinhTron> Tim_HT_R_Max()
		{
			List<HinhTron> kq = new List<HinhTron>();
			float max = float.MinValue;
			foreach (var item in DS_HT.DS_HT)
			{
				if (max < item.bKinh)
					max = item.bKinh;
			}
			foreach (var item in DS_HT.DS_HT)
			{
				if (item.bKinh == max)
					kq.Add(item);
			}
			return kq;
		}

		public void Swap<T>(IList<T> list, int i, int j)
		{
			T tmp = list[i];
			list[i] = list[j];
			list[j] = tmp;
		}

		public void SapXep_DSHV_Tang_CV()
		{
			for (int i = 0; i < DS_HV.Dem - 1; i++)
				for (int j = i + 1; j < DS_HV.Dem; j++)
					if (DS_HV[j].cVi < DS_HV[i].cVi)
						Swap<HinhVuong>(DS_HV.DS_HV, i, j);
		}

		public void SapXep_DSHV_Giam_CV()
		{
			for (int i = 0; i < DS_HV.Dem - 1; i++)
				for (int j = i + 1; j < DS_HV.Dem; j++)
					if (DS_HV[j].cVi > DS_HV[i].cVi)
						Swap<HinhVuong>(DS_HV.DS_HV, i, j);
		}
		public void SapXep_DSHT_Tang_CV()
		{
			for (int i = 0; i < DS_HT.Dem - 1; i++)
				for (int j = i + 1; j < DS_HT.Dem; j++)
					if (DS_HT[j].cVi < DS_HT[i].cVi)
						Swap<HinhTron>(DS_HT.DS_HT, i, j);
		}

		public void SapXep_DSHT_Giam_CV()
		{
			for (int i = 0; i < DS_HT.Dem - 1; i++)
				for (int j = i + 1; j < DS_HT.Dem; j++)
					if (DS_HT[j].cVi > DS_HT[i].cVi)
						Swap<HinhTron>(DS_HT.DS_HT, i, j);
		}

		public void SapXep_DSHCN_Tang_CV()
		{
			for (int i = 0; i < DS_HCN.Dem - 1; i++)
				for (int j = i + 1; j < DS_HCN.Dem; j++)
					if (DS_HCN[j].cVi < DS_HCN[i].cVi)
						Swap<HinhChuNhat>(DS_HCN.DS_HCN, i, j);
		}

		public void SapXep_DSHCN_Giam_CV()
		{
			for (int i = 0; i < DS_HCN.Dem - 1; i++)
				for (int j = i + 1; j < DS_HCN.Dem; j++)
					if (DS_HCN[j].cVi > DS_HCN[i].cVi)
						Swap<HinhChuNhat>(DS_HCN.DS_HCN, i, j);
		}

		public void Tim_Hinh_S_Max()
		{
			float max = Xuat_DS_DienTich().Max();
			foreach (var item in DS_HCN.DS_HCN)
				if (item.dTich == max)
					Console.Write(item);
			foreach (var item in DS_HT.DS_HT)
				if (item.dTich == max)
					Console.Write(item);
			foreach (var item in DS_HV.DS_HV)
				if (item.dTich == max)
					Console.Write(item);
		}

		public void Tim_Hinh_S_Min()
		{
			float min = Xuat_DS_DienTich().Min();
			foreach (var item in DS_HCN.DS_HCN)
				if (item.dTich == min)
					Console.Write(item);
			foreach (var item in DS_HT.DS_HT)
				if (item.dTich == min)
					Console.Write(item);
			foreach (var item in DS_HV.DS_HV)
				if (item.dTich == min)
					Console.Write(item);
		}

	}
}
