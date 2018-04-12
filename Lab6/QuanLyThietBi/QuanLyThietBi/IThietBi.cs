using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	interface IThietBi
	{
		float TinhGia();
		float GiaCPU { get; set; }
		float GiaRAM { get; set; }
		string TenCPU { get; set; }
		string TenRAM { get; set; }
	}

	class MayAnh : IThietBi
	{
		public List<ILinhKien> DS_LK = new List<ILinhKien>();
		public string tenMA;
		public float giaRAM, giaCPU;
		public string tenCPU, tenRAM;

		public float GiaCPU
		{
			get
			{
				return giaCPU;
			}

			set
			{
				giaCPU = value;
			}
		}

		public float GiaRAM
		{
			get
			{
				return giaRAM;
			}

			set
			{
				giaRAM = value;
			}
		}

		public string TenCPU
		{
			get
			{
				return tenCPU;
			}

			set
			{
				tenCPU = value;
			}
		}

		public string TenRAM
		{
			get
			{
				return tenRAM;
			}

			set
			{
				tenRAM = value;
			}
		}

		public void Them(ILinhKien x)
		{
			if (!DS_LK.Contains(x))
				DS_LK.Add(x);
		}

		public MayAnh()
		{

		}

		public MayAnh(string ten, RAM r, CPU c)
		{
			tenMA = ten;
			Them(r);
			giaRAM = r.Gia;
			tenRAM = r.Ten;
			Them(c);
			giaCPU = c.Gia;
			tenCPU = c.Ten;
		}
		public float TinhGia()
		{
			float tong = 0;
			foreach (var item in DS_LK)
				tong += item.Gia;
			return tong;
		}

		public override string ToString()
		{
			string s = tenMA;
			foreach (var item in DS_LK)
				s += " " + item + ", ";
			s += "Tong gia " + TinhGia();
			return s;
		}
	}

	class MayTinh : IThietBi
	{
		public List<ILinhKien> DS_LK = new List<ILinhKien>();
		public string tenMT;
		public float giaRAM, giaCPU;
		public string tenCPU, tenRAM;

		public float GiaCPU
		{
			get
			{
				return giaCPU;
			}

			set
			{
				giaCPU = value;
			}
		}

		public float GiaRAM
		{
			get
			{
				return giaRAM;
			}

			set
			{
				giaRAM = value;
			}
		}

		public string TenCPU
		{
			get
			{
				return tenCPU;
			}

			set
			{
				tenCPU = value;
			}
		}

		public string TenRAM
		{
			get
			{
				return tenRAM;
			}

			set
			{
				tenRAM = value;
			}
		}

		public void Them(ILinhKien x)
		{
			if (!DS_LK.Contains(x))
				DS_LK.Add(x);
		}

		public MayTinh()
		{

		}

		public MayTinh(string ten, RAM r, CPU c)
		{
			tenMT = ten;
			Them(r);
			giaRAM = r.Gia;
			tenRAM = r.Ten;
			Them(c);
			giaCPU = c.Gia;
			tenCPU = c.Ten;
		}
		public float TinhGia()
		{
			float tong = 0;
			foreach (var item in DS_LK)
				tong += item.Gia;
			return tong;
		}

		public override string ToString()
		{
			string s = tenMT;
			foreach (var item in DS_LK)
				s += " " + item + ", ";
			s += "Tong gia " + TinhGia();
			return s;
		}
	}
}
