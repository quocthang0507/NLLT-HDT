using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
	public class MaTran
	{
		public double[,] mt;
		public int hang;
		public int cot;

		#region Phuong thuc tao lap

		public MaTran()
		{

		}

		/// <summary>
		/// Tạo một ma trận mới với kích thước h x c
		/// </summary>
		/// <param name="h">Hàng</param>
		/// <param name="c">Cột</param>
		public MaTran(int h, int c)
		{
			this.hang = h;
			this.cot = h;
			mt = new double[h, c];
		}

		/// <summary>
		/// Tạo một ma trận mới dựa trên ma trận có sẵn
		/// </summary>
		/// <param name="a">Ma trận tham chiếu</param>
		public MaTran(MaTran a)
		{
			//mt = new double[a.hang, a.cot];
			//this.hang = a.hang;
			//this.cot = a.cot;
			//for (int i = 0; i < a.hang; i++)
			//{
			//	for (int j = 0; j < a.cot; j++)
			//	{
			//		this.mt[i, j] = a.mt[i, j];
			//	}
			//}
			mt = a.mt;
		}

		/// <summary>
		/// Tạo một ma trận mới dựa trên ma trận cũ với kích thước h x c
		/// </summary>
		/// <param name="a">Ma trận tham chiếu</param>
		/// <param name="h">Hàng</param>
		/// <param name="c">Cột</param>
		public MaTran(MaTran a, int h, int c)
		{
			mt = new double[h, c];
			this.hang = h;
			this.cot = c;
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < c; j++)
				{
					this.mt[i, j] = a.mt[i, j];
				}
			}
		}

		#endregion

		/// <summary>
		/// Nhập tự động ma trận (là tổng của hàng + cột tại vị trí đó)
		/// </summary>
		public void Nhap()
		{
			Console.WriteLine("Nhap mot ma tran cap {0}x{1}", this.hang, this.cot);
			for (int i = 0; i < this.hang; i++)
			{
				for (int j = 0; j < this.cot; j++)
				{
					this.mt[i, j] = i + j;
				}
			}
		}

		/// <summary>
		/// Nhập giá trị cho ma trận từ bàn phím có kích thước h x c
		/// </summary>
		/// <param name="h">Hàng</param>
		/// <param name="c">Cột</param>
		public void Nhap(int h, int c)
		{
			mt = new double[h, c];
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < c; j++)
				{
					Console.Write("Nhap phan tu thu [{0},{1}] = ", i, j);
					this.mt[i, j] = double.Parse(Console.ReadLine());
				}
			}
		}

		/// <summary>
		/// Ghi đè phương thức có sẵn ToString
		/// </summary>
		/// <returns>Xuất ma trận đó</returns>
		public override string ToString()
		{
			string kq = "";
			for (int i = 0; i < this.hang; i++)
			{
				kq += "\n";
				for (int j = 0; j < this.cot; j++)
				{
					kq += "\t" + this.mt[i, j].ToString();
				}
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng 2 ma trận
		/// </summary>
		/// <param name="a">Ma trận đầu tiên</param>
		/// <param name="b">Ma trận thứ hai</param>
		/// <returns>Ma trận tổng</returns>
		public static MaTran Tong(MaTran a, MaTran b)
		{
			MaTran kq = new MaTran(a.hang, a.cot);
			for (int i = 0; i < b.hang; i++)
			{
				for (int j = 0; j < b.cot; j++)
				{
					kq.mt[i, j] = a.mt[i, j] + b.mt[i, j];
				}
			}
			return kq;
		}

		/// <summary>
		/// Cộng ma trận vào ma trận sẵn có
		/// </summary>
		/// <param name="b">Ma trận mới</param>
		public void Tong(MaTran b)
		{
			for (int i = 0; i < b.hang; i++)
			{
				for (int j = 0; j < b.cot; j++)
				{
					this.mt[i, j] = this.mt[i, j] + b.mt[i, j];
				}
			}
		}
	}
}