using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	public enum GioiTinh
	{
		Nam, Nu
	}

	class KhachHang
	{
		public string CMND;
		public string hoTen;
		public string diaChi;
		public DateTime ngaySinh;
		public GioiTinh gioiTinh;

		public KhachHang()
		{

		}

		public KhachHang(string CMND, string hoTen, string diaChi, GioiTinh gt, string ngaySinh)
		{
			this.CMND = CMND;
			this.hoTen = hoTen;
			this.diaChi = diaChi;
			this.gioiTinh = gt;
			this.ngaySinh = DateTime.Parse(ngaySinh);

		}

		public override string ToString()
		{
			string s = "{0}\t{1}\t{2}\t{3}\t{4}";
			return string.Format(s, CMND, hoTen, diaChi, gioiTinh, ngaySinh);
		}
	}
}
