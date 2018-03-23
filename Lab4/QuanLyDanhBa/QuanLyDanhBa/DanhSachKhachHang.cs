using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class DanhSachKhachHang
	{
		public List<KhachHang> DS_KH = new List<KhachHang>();

		public KhachHang this[int index]
		{
			get { return DS_KH[index]; }
		}

		public DanhSachKhachHang()
		{

		}

		public int Dem
		{
			get { return DS_KH.Count; }
		}

		public void Them_KH(KhachHang x)
		{
			DS_KH.Add(x);
		}

		public override string ToString()
		{
			string kq = "";
			foreach (var item in DS_KH)
			{
				kq += item + "\n";
			}
			return kq;
		}

		public void NhapTuFile()
		{
			string vt = "khachhang.txt";
			StreamReader t = new StreamReader(vt);
			string line = "";
			while ((line = t.ReadLine()) != null)
			{
				string[] dt = line.Split(';');
				Them_KH(new KhachHang(dt[0], dt[1], dt[2], dt[3] == "Nam" ? GioiTinh.Nam : GioiTinh.Nu, dt[4]));
			}
		}
	}
}
