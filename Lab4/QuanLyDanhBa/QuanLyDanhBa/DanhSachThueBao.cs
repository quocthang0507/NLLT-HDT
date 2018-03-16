using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class DanhSachThueBao
	{
		public List<ThueBao> DS_TB = new List<ThueBao>();

		public void Them_TB(ThueBao x)
		{
			DS_TB.Add(x);
		}

		public override string ToString()
		{
			string kq = "";
			foreach (var item in DS_TB)
			{
				kq += item + "\n";
			}
			return kq;
		}

		public void NhapTuFile()
		{
			string vt = "thuebao.txt";
			StreamReader t = new StreamReader(vt);
			string line = "";
			while ((line = t.ReadLine()) != null)
			{
				string[] dt = line.Split(';');
				Them_TB(new ThueBao(dt[0], dt[1], DateTime.Parse(dt[2])));
			}

		}
	}
}
