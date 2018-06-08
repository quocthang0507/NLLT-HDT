using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1610207_LaQuocThang
{
	interface ILinhKien
	{
		float Gia { get; set; }
		string Ten { get; set; }
		int SoLuong { get; set; }
	}

	class CPU : ILinhKien
	{
		float gia;
		string ten;
		int soLuong = 0;
		public float Gia { get { return gia; } set { gia = value; } }
		public string Ten { get { return ten; } set { ten = value; } }
		public int SoLuong { get { return soLuong; } set { soLuong = value; } }

		public CPU()
		{

		}
		public CPU(float g, string t)
		{
			Gia = g;
			Ten = t;
			SoLuong++;
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
		int soLuong = 0;
		public float Gia { get { return gia; } set { gia = value; } }
		public string Ten { get { return ten; } set { ten = value; } }
		public int SoLuong { get { return soLuong; } set { soLuong = value; } }

		public RAM()
		{

		}

		public RAM(float g, string t)
		{
			Gia = g;
			Ten = t;
			SoLuong++;
		}

		public override string ToString()
		{
			return string.Format("RAM {0} gia {1}", Ten, Gia);
		}
	}
}
