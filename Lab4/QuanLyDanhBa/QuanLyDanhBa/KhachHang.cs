using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class KhachHang
	{
		public string CMND;
		public string hoTen;
		public string diaChi;

		public enum gioiTinh
		{
			Nam, Nu
		}

		public KhachHang()
		{

		}

		public KhachHang(string CMND, string hoTen, string diaChi)
		{
			this.CMND = CMND;
			this.hoTen = hoTen;
			this.diaChi = diaChi;
		}

		public override string ToString()
		{
			return CMND + "\t" + hoTen + "\t" + diaChi;
		}
	}
}
