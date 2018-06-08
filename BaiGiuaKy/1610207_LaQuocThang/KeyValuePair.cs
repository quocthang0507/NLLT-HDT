using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1610207_LaQuocThang
{
	class KeyValuePair
	{
		public ILinhKien linhKien;
		int soLan = 0;

		public int SoLan { get { return soLan; } set { soLan = value; } }

		public KeyValuePair()
		{

		}

		public KeyValuePair(ILinhKien t)
		{
			linhKien = t;
		}

		public override string ToString()
		{
			return linhKien.ToString() + ", Su dung: " + soLan + " lan";
		}
	}

	class DanhSachTanSuat
	{
		public List<KeyValuePair> listPair = new List<KeyValuePair>();

		public void Them(KeyValuePair x)
		{
			listPair.Add(x);
		}

		public void CapNhat(string ten)
		{
			foreach (var item in listPair)
				if (item.linhKien.Ten == ten)
					item.SoLan++;
		}

		public void KhoiTao(DanhSachLinhKien a)
		{
			foreach (var item in a.DS)
				Them(new KeyValuePair(item));
		}

		public void CapNhat_ToanBo(DanhSachThietBi a)
		{
			foreach (var item in a.DS)
			{
				CapNhat(item.TenCPU);
				CapNhat(item.TenRAM);
			}
		}

		public int Tim_Max_CPU()
		{
			int max = 0;
			foreach (var item in listPair)
				if (item.linhKien is CPU && item.SoLan > max)
					max = item.SoLan;
			return max;
		}
	}
}
