using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBi
{
	interface ILinhKien
	{
		float Gia { get; set; }
		string Ten { get; set; }
	}

	class CPU : ILinhKien
	{
		float gia;
		string ten;
		public float Gia { get { return gia; } set { gia = value; } }
		public string Ten { get { return ten; } set { ten = value; } }

		public CPU()
		{

		}
		public CPU(float g, string t)
		{
			Gia = g;
			Ten = t;
		}

		public override string ToString()
		{
			return string.Format("CPU {0} gia {1}", Ten, Gia);
		}
	}

	class RAM : ILinhKien
	{
		float gia;
		string ten;
		public float Gia { get { return gia; } set { gia = value; } }
		public string Ten { get { return ten; } set { ten = value; } }
		public RAM()
		{

		}

		public RAM(float g, string t)
		{
			Gia = g;
			Ten = t;
		}

		public override string ToString()
		{
			return string.Format("RAM {0} gia {1}", Ten, Gia);
		}
	}
}
