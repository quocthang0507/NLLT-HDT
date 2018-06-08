using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.IO;
using System.Threading.Tasks;

namespace MangMotChieu
{
	class Program
	{
		/// <summary>
		/// Định nghĩa kiểu liệt kê Thực đơn, dùng để chứa các từ khóa của tất cả các chức năng
		/// </summary>
		enum ThucDon
		{
			Thoat, NhapThuCong, NhapTuDong,
			TimAm_Max, TimAm_Min, TimDuong_Max, TimDuong_Min, TimAm, TimDuong, TongAm, TongDuong,
			XoaTai_VT, Xoa_Dau, Xoa_Cuoi, Xoa_x, ThemTai_VT, Them_Dau, Them_Cuoi, Xoa_Am, Xoa_Duong, Dem_Am, Dem_Duong, Tim_x
		};
		static void Main(string[] args)
		{
			int[] a = new int[100];
			int length = 0;
			int vt;
			int x;
			bool kq;
			int max, min;
			int[] mkq = new int[100];
			int nkq = 0;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("\n".PadRight(30, '*') + "HE THONG CHUC NANG" + "".PadRight(30, '*'));
				Console.WriteLine("    Nhan {0}: Thoat khoi chuong trinh", (int)ThucDon.Thoat);
				Console.WriteLine("    Nhan {0}: Nhap thu cong", (int)ThucDon.NhapThuCong);
				Console.WriteLine("    Nhan {0}: Nhap tu dong", (int)ThucDon.NhapTuDong);
				Console.WriteLine("    Nhan {0}: Tim so am lon nhat", (int)ThucDon.TimAm_Max);
				Console.WriteLine("    Nhan {0}: Tim so am nho nhat", (int)ThucDon.TimAm_Min);
				Console.WriteLine("    Nhan {0}: Tim so duong lon nhat", (int)ThucDon.TimDuong_Max);
				Console.WriteLine("    Nhan {0}: Tim so duong nho nhat", (int)ThucDon.TimDuong_Min);
				Console.WriteLine("    Nhan {0}: Tim tat ca cac so am trong mang", (int)ThucDon.TimAm);
				Console.WriteLine("    Nhan {0}: Tim tat ca cac so duong trong mang", (int)ThucDon.TimDuong);
				Console.WriteLine("    Nhan {0}: Tong tat ca cac so am trong mang", (int)ThucDon.TongAm);
				Console.WriteLine("    Nhan {0}: Tong cac so duong trong mang", (int)ThucDon.TongDuong);
				Console.WriteLine("    Nhan {0}: Xoa mot so tai vi tri vt trong mang", (int)ThucDon.XoaTai_VT);
				Console.WriteLine("    Nhan {0}: Xoa phan tu dau tien trong mang", (int)ThucDon.Xoa_Dau);
				Console.WriteLine("    Nhan {0}: Xoa phan tu cuoi cung trong mang", (int)ThucDon.Xoa_Cuoi);
				Console.WriteLine("    Nhan {0}: Xoa phan tu x trong mang", (int)ThucDon.Xoa_x);
				Console.WriteLine("    Nhan {0}: Them mot so tai vi tri vt trong mang", (int)ThucDon.ThemTai_VT);
				Console.WriteLine("    Nhan {0}: Them phan tu dau tien trong mang", (int)ThucDon.Them_Dau);
				Console.WriteLine("    Nhan {0}: Them phan tu cuoi cung trong mang", (int)ThucDon.Them_Cuoi);
				Console.WriteLine("    Nhan {0}: Xoa tat ca so am trong mang", (int)ThucDon.Xoa_Am);
				Console.WriteLine("    Nhan {0}: Xoa tat ca so duong trong mang", (int)ThucDon.Xoa_Duong);
				Console.WriteLine("    Nhan {0}: Dem so phan tu am trong mang", (int)ThucDon.Dem_Am);
				Console.WriteLine("    Nhan {0}: Dem so phan tu duong trong mang", (int)ThucDon.Dem_Duong);
				Console.WriteLine("    Nhan {0}: Tim cac phan tu co gia tri la x trong mang.", (int)ThucDon.Tim_x);
				Console.WriteLine("".PadRight(78, '*'));
				Console.Write("    Nhap so thu tu chuc nang: ");
				ThucDon td = (ThucDon)int.Parse(Console.ReadLine());
				Console.Clear();
				switch (td)
				{
					case ThucDon.Thoat:
						Console.WriteLine("0.Thoat khoi chuong trinh");
						Console.ReadKey();
						return;
					case ThucDon.NhapThuCong:
						Console.WriteLine("1.Nhap thu cong");
						NhapThuCong(a, ref length);
						SapXepTang(a, length);
						Xuat(a, length);
						break;
					case ThucDon.NhapTuDong:
						Console.WriteLine("2.Nhap tu dong");
						NhapTD(a, ref length);
						SapXepTang(a, length);
						Xuat(a, length);
						break;
					case ThucDon.TimAm_Max:
						Console.WriteLine("3.Tim so am lon nhat");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						max = TimMaxAm(a, length);
						if (max == 0)
							Console.WriteLine("\nKhong co gia tri am!");
						else Console.WriteLine("\nGia tri am lon nhat " + max);
						break;
					case ThucDon.TimAm_Min:
						Console.WriteLine("4.Tim so am nho nhat");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						min = TimMinAm(a, length);
						if (min == 0)
							Console.WriteLine("\nKhong co gia tri am!");
						else Console.WriteLine("\nGia tri am nho nhat " + min);
						break;
					case ThucDon.TimDuong_Max:
						Console.WriteLine("5.Tim so duong lon nhat");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						max = TimMaxDuong(a, length);
						if (max == 0)
							Console.WriteLine("\nKhong co gia tri duong!");
						else Console.WriteLine("\nGia tri duong lon nhat " + max);
						break;
					case ThucDon.TimDuong_Min:
						Console.WriteLine("6.Tim so duong nho nhat");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						min = TimMinDuong(a, length);
						if (min == 0)
							Console.WriteLine("\nKhong co gia tri duong!");
						else Console.WriteLine("\nGia tri duong nho nhat " + min);
						break;
					case ThucDon.TimAm:
						Console.WriteLine("7.Tim tat ca cac so am trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						mkq = TimTatCaSoAm(a, length, ref nkq);
						if (nkq == 0)
							Console.WriteLine("\nKhong co gia tri am!");
						else
						{
							Console.WriteLine("\nKet qua:");
							Xuat(mkq, nkq);
						}
						break;
					case ThucDon.TimDuong:
						Console.WriteLine("8.Tim tat ca cac so duong trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						mkq = TimTatCaSoDuong(a, length, ref nkq);
						if (nkq == 0)
							Console.WriteLine("\nKhong co gia tri duong!");
						else
						{
							Console.WriteLine("\nKet qua:");
							Xuat(mkq, nkq);
						}
						break;
					case ThucDon.TongAm:
						Console.WriteLine("9.Tong tat ca cac so am trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						mkq = TimTatCaSoAm(a, length, ref nkq);
						if (nkq == 0)
							Console.WriteLine("\nKhong co gia tri am!");
						else
						{
							Console.WriteLine("\nDanh sach cac so am trong mang");
							Xuat(mkq, nkq);
							Console.WriteLine("\nKet qua: {0}", Tong(mkq, nkq));
						}
						break;
					case ThucDon.TongDuong:
						Console.WriteLine("10.Tong cac so duong trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						mkq = TimTatCaSoDuong(a, length, ref nkq);
						if (nkq == 0)
							Console.WriteLine("\nKhong co gia tri duong!");
						else
						{
							Console.WriteLine("\nDanh sach cac so duong trong mang");
							Xuat(mkq, nkq);
							Console.WriteLine("\nKet qua: {0}", Tong(mkq, nkq));
						}
						break;
					case ThucDon.XoaTai_VT:
						Console.WriteLine("11.Xoa mot so tai vi tri vt trong mang");
						Xuat(a, length);
						Console.Write("\nNhap vi tri can xoa: ");
						vt = int.Parse(Console.ReadLine());
						kq = Xoa_TaiVT(a, ref length, vt);
						if (kq)
						{
							Console.WriteLine("\nMang sau khi xoa : ");
							Xuat(a, length);
						}
						else Console.WriteLine("\nBan nhap vi tri khong dung!");
						break;
					case ThucDon.Xoa_Dau:
						Console.WriteLine("12.Xoa phan tu dau tien trong mang");
						Xuat(a, length);
						Console.WriteLine("\nMang sau khi xoa : ");
						Xoa_Dau(a, ref length);
						Xuat(a, length);
						break;
					case ThucDon.Xoa_Cuoi:
						Console.WriteLine("13.Xoa phan tu cuoi cung trong mang");
						Xuat(a, length);
						Console.WriteLine("\nMang sau khi xoa : ");
						Xoa_Cuoi(a, ref length);
						Xuat(a, length);
						break;
					case ThucDon.Xoa_x:
						Console.WriteLine("14.Xoa phan tu x trong mang");
						Xuat(a, length);
						Console.Write("\nNhap phan tu x can xoa: ");
						x = int.Parse(Console.ReadLine());
						if (Tim_X(a, x) == -1)
							Console.WriteLine("\nPhan tu x khong co trong mang");
						else
						{
							Xoa_X(a, ref length, x);
							Console.WriteLine("\nMang sau khi xoa : ");
							Xuat(a, length);
						}
						break;
					case ThucDon.ThemTai_VT:
						Console.WriteLine("15.Them mot so tai vi tri vt trong mang");
						Xuat(a, length);
						Console.Write("\nNhap vi tri can chen: ");
						vt = int.Parse(Console.ReadLine());
						Console.Write("\nNhap gia tri can chen: ");
						x = int.Parse(Console.ReadLine());
						kq = Chen_TaiVT(a, ref length, x, vt);
						if (kq == true)
							Xuat(a, length);
						else Console.WriteLine("\nBan nhap vi tri khong dung!");
						break;
					case ThucDon.Them_Dau:
						Console.WriteLine("16.Them phan tu dau tien trong mang");
						Console.Write("\nNhap gia tri can chen: ");
						x = int.Parse(Console.ReadLine());
						Console.WriteLine("\nMang ban dau : ");
						Xuat(a, length);
						Console.WriteLine("\nMang sau khi chen : ");
						ChenDau(a, ref length, x);
						Xuat(a, length);
						break;
					case ThucDon.Them_Cuoi:
						Console.WriteLine("17.Them phan tu cuoi cung trong mang");
						Console.Write("\nNhap gia tri can chen: ");
						x = int.Parse(Console.ReadLine());
						Console.WriteLine("\nMang ban dau : ");
						Xuat(a, length);
						ChenCuoi(a, ref length, x);
						Console.WriteLine("\nMang sau khi chen : ");
						Xuat(a, length);
						break;
					case ThucDon.Xoa_Am:
						Console.WriteLine("18.Xoa tat ca so am trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						Xoa_SoAm(a, ref length);
						Console.WriteLine("\nMang sau khi xoa: ");
						Xuat(a, length);
						break;
					case ThucDon.Xoa_Duong:
						Console.WriteLine("19.Xoa tat ca so duong trong mang");
						Console.WriteLine("\nMang ban dau: ");
						Xuat(a, length);
						Xoa_SoDuong(a, ref length);
						Console.WriteLine("\nMang sau khi xoa: ");
						Xuat(a, length);
						break;
					case ThucDon.Dem_Am:
						Console.WriteLine("20.Dem so phan tu am trong mang");
						Console.WriteLine("\nXem lai mang: ");
						Xuat(a, length);
						Console.WriteLine("\nMang tren co {0} so am", Dem_SoAm(a, length));
						break;
					case ThucDon.Dem_Duong:
						Console.WriteLine("21.Dem so phan tu duong trong mang");
						Console.WriteLine("\nXem lai mang: ");
						Xuat(a, length);
						Console.WriteLine("\nMang tren co {0} so duong", Dem_SoDuong(a, length));
						break;
					case ThucDon.Tim_x:
						Console.WriteLine("22.Tim cac phan tu co gia tri la x trong mang.");
						Console.WriteLine("\nXem lai mang: ");
						Xuat(a, length);
						Console.Write("\nNhap phan tu X = ");
						x = int.Parse(Console.ReadLine());
						Console.WriteLine("\nCo {0} so bang X", Dem_X(a, length, x));
						break;
					default:
						break;
				}
				Console.ReadKey();
				Xoa_Het(mkq, ref nkq);
			}
		}

		/// <summary>
		/// Nhập thủ công mảng một chiều từ bàn phím
		/// </summary>
		/// <param name="a">Mảng cần nhập</param>
		/// <param name="length">Độ dài của mảng</param>
		private static void NhapThuCong(int[] a, ref int length)
		{
			Console.Write("\nNhap kich thuoc mang mot chieu: ");
			length = int.Parse(Console.ReadLine());
			for (int i = 0; i < length; i++)
			{
				Console.Write("Nhap a[{0}] = ", i);
				a[i] = int.Parse(Console.ReadLine());
			}
		}

		/// <summary>
		/// Sắp xếp mảng theo giá trị tăng dần
		/// </summary>
		/// <param name="mang">Mảng cần sắp</param>
		/// <param name="length">Độ dài của mảng</param>
		private static void SapXepTang(int[] mang, int length)
		{
			for (int i = 0; i < length; i++)
				for (int j = i + 1; j < length; j++)
					if (mang[j] < mang[i])
					{
						var temp = mang[i];
						mang[i] = mang[j];
						mang[j] = temp;
					}
		}

		/// <summary>
		/// Xuất các phần tử của mảng
		/// </summary>
		/// <param name="mang">Mảng cần xuất</param>
		/// <param name="length">Độ dài của mảng</param>
		private static void Xuat(int[] mang, int length)
		{
			Console.WriteLine();
			for (int i = 0; i < length; i++)
			{
				Console.Write(mang[i] + "\t");
				if ((i + 1) % 10 == 0)
					Console.WriteLine();
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Nhập tự động vào mảng một chiều với phạm vi (-20;20)
		/// </summary>
		/// <param name="mang">Mảng cần nhập</param>
		/// <param name="length">Độ dài của mảng</param>
		private static void NhapTD(int[] mang, ref int length)
		{
			//string line = "";
			//using (StreamReader sr = new StreamReader(@"File.txt"))
			//{
			//	while ((line = sr.ReadLine()) != null)
			//	{
			//		mang[length++] = int.Parse(line);
			//	}
			//}
			Random so = new Random();
			Console.Write("\nNhap kich thuoc mang mot chieu: ");
			length = int.Parse(Console.ReadLine());
			for (int i = 0; i < length; i++)
				mang[i] = so.Next(-20, 20);
		}

		/// <summary>
		/// Chèn giá trị vào vị trí bất kỳ của mảng
		/// </summary>
		/// <param name="a">Mảng cần chèn</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="x">Giá trị cần chèn</param>
		/// <param name="vt">Vị trí cần chèn</param>
		/// <returns>True nếu vị trí đó tồn tại, False nếu không tồn tại vị trí vt</returns>
		static bool Chen_TaiVT(int[] a, ref int length, int x, int vt)
		{
			//Nếu vị trí không khả vi thì trả về false
			if (vt < 0 || vt > length)
				return false;
			//Ngược lại thì đẩy các phần tử về sau từ vị trí vt
			for (int i = length; i > vt; i--)
				a[i] = a[i - 1];
			//Chèn tại vị trí vt giá trị x
			a[vt] = x;
			//Tăng kích thước mảng lên 1 đơn vị
			length++;
			return true;
		}

		/// <summary>
		/// Chèn giá trị vào đầu mảng
		/// </summary>
		/// <param name="a">Mảng cần chèn</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="x">Giá trị cần chèn</param>
		static void ChenDau(int[] a, ref int length, int x)
		{
			//Sử dụng lại hàm chèn tại vị trí ở trên với vt = 0
			Chen_TaiVT(a, ref length, x, 0);
		}

		/// <summary>
		/// Chèn giá trị vào cuối mảng
		/// </summary>
		/// <param name="a">Mảng cần chèn</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="x">Giá trị cần chèn</param>
		static void ChenCuoi(int[] a, ref int length, int x)
		{
			//Sử dụng lại hàm chèn tại vị trí ở trên với vt = length
			Chen_TaiVT(a, ref length, x, length);
		}

		/// <summary>
		/// Xóa một phần tử tại một vị trí ra khỏi mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="vt">Vị trí cần xóa</param>
		/// <returns>True nếu vị trí đó tồn tại, False nếu không tồn tại vị trí vt</returns>
		static bool Xoa_TaiVT(int[] a, ref int length, int vt)
		{
			//Trả về false nếu vị trí cần xóa không khả vi
			if (vt < 0 || vt > length)
				return false;
			//Dịch các phần tử lên trên từ vị trí vt
			for (int i = vt; i < length; i++)
				a[i] = a[i + 1];
			//Giảm kích thước mảng một đơn vị
			length--;
			return true;
		}

		/// <summary>
		/// Hàm xóa phần tử đầu mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		static void Xoa_Dau(int[] a, ref int length)
		{
			Xoa_TaiVT(a, ref length, 0);
		}

		/// <summary>
		/// Xóa phần tử cuối mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		static void Xoa_Cuoi(int[] a, ref int length)
		{
			Xoa_TaiVT(a, ref length, length - 1);
		}

		/// <summary>
		/// Xóa tất cả các số âm ra khỏi mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		static void Xoa_SoAm(int[] a, ref int length)
		{
			//Duyệt tuần tự từ đầu đến hết mảng
			for (int i = 0; i < length; i++)
				//Nếu phần tử đó âm
				if (a[i] < 0)
				{
					//Gọi hàm xóa tại vị trí i
					Xoa_TaiVT(a, ref length, i);
					//Giảm i một đơn vị để xét lại vị trí vừa mới xóa
					i--;
				}
		}

		/// <summary>
		/// Xóa tất cả các số dương ra khỏi mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		static void Xoa_SoDuong(int[] a, ref int length)
		{
			//Duyệt tuần tự từ đầu đến hết mảng
			for (int i = 0; i < length; i++)
				//Nếu phần tử đó dương
				if (a[i] > 0)
				{
					//Gọi hàm xóa tại vị trí i
					Xoa_TaiVT(a, ref length, i);
					//Giảm i một đơn vị để xét lại vị trí vừa mới xóa
					i--;
				}
		}

		/// <summary>
		/// Đếm tất cả các số âm trong mảng
		/// </summary>
		/// <param name="a">Mảng cần đếm</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <returns>Trả về số lượng các số âm trong mảng</returns>
		static int Dem_SoAm(int[] a, int length)
		{
			int dem = 0;
			//Duyệt tuần tự từ đầu đến hết mảng
			for (int i = 0; i < length; i++)
				//Nếu phần tử đó là số âm thì tăng biến dem lên một đơn vị
				if (a[i] < 0)
					dem++;
			return dem;
		}

		/// <summary>
		/// Đếm tất cả các số dương trong mảng
		/// </summary>
		/// <param name="a">Mảng cần đếm</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <returns>Trả về số lượng các số dương trong mảng</returns>
		static int Dem_SoDuong(int[] a, int length)
		{
			int dem = 0;
			//Duyệt tuần tự từ đầu đến hết mảng
			for (int i = 0; i < length; i++)
				//Nếu phần tử đó là số dương thì tăng biến dem lên một đơn vị
				if (a[i] > 0)
					dem++;
			return dem;
		}

		/// <summary>
		/// Đếm số phần tử có giá trị bằng X trong mảng
		/// </summary>
		/// <param name="a">Mảng cần đếm</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="x">Giá trị cần đếm</param>
		/// <returns>Trả về số lượng các số bằng x trong mảng</returns>
		static int Dem_X(int[] a, int length, int x)
		{
			int dem = 0;
			//Duyệt tuần tự từ đầu đến hết mảng
			for (int i = 0; i < length; i++)
				//Nếu phần tử đó bằng x thì tăng biến dem lên một đơn vị
				if (a[i] == x)
					dem++;
			return dem;
		}

		/// <summary>
		/// Tìm max âm
		/// </summary>
		/// <param name="a">Mảng hiện hành</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <returns>Số âm lớn nhất</returns>
		static int TimMaxAm(int[] a, int length)
		{
			//Lưu số kết quả là âm
			int len = 0;
			//Tạo một mảng lưu kết quả với chiều dài bằng chiều dài length
			int[] kq = TimTatCaSoAm(a, length, ref len);
			//Nếu len = 0 thì nghĩa là không có số âm
			if (len == 0)
				return 0;
			//Khử các phần tử bằng 0 trong mảng kq
			kq = kq.Where(val => val != 0).ToArray();
			//Trả về giá trị lớn nhất của mảng số âm
			return kq.Max();
		}

		/// <summary>
		/// Tim so am nho nhat
		/// </summary>
		/// <param name="a">Mang hien hanh</param>
		/// <param name="length">chieu dai mang</param>
		/// <returns>Số âm nhỏ nhất</returns>
		static int TimMinAm(int[] a, int length)
		{
			//Lưu số kết quả là âm
			int len = 0;
			//Tạo một mảng lưu kết quả với chiều dài bằng chiều dài length
			int[] kq = TimTatCaSoAm(a, length, ref len);
			//Nếu len = 0 thì nghĩa là không có số âm
			if (len == 0)
				return 0;
			//Khử các phần tử bằng 0 trong mảng kq
			kq = kq.Where(val => val != 0).ToArray();
			//Trả về giá trị nhỏ nhất của mảng số âm
			return kq.Min();
		}

		/// <summary>
		/// Tim so duong lon nhat
		/// </summary>
		/// <param name="a">Mang hien hanh</param>
		/// <param name="length">Chieu dai mang</param>
		/// <returns>Số dương lớn nhất</returns>
		static int TimMaxDuong(int[] a, int length)
		{
			//Lưu số kết quả là dương
			int len = 0;
			//Tạo một mảng lưu kết quả với chiều dài bằng chiều dài length
			int[] kq = TimTatCaSoDuong(a, length, ref len);
			//Nếu len = 0 thì nghĩa là không có số dương
			if (len == 0)
				return 0;
			//Khử các phần tử bằng 0 trong mảng kq
			kq = kq.Where(val => val != 0).ToArray();
			//Trả về giá trị lớn nhất của mảng số dương
			return kq.Max();
		}

		/// <summary>
		/// Tim so duong nho nhat
		/// </summary>
		/// <param name="a">Mang hien hanh</param>
		/// <param name="length">Chieu dai mang</param>
		/// <returns>Số dương nhỏ nhất</returns>
		static int TimMinDuong(int[] a, int length)
		{
			//Lưu số kết quả là dương
			int len = 0;
			//Tạo một mảng lưu kết quả với chiều dài bằng chiều dài length
			int[] kq = TimTatCaSoDuong(a, length, ref len);
			//Nếu len = 0 thì nghĩa là không có số dương
			if (len == 0)
				return 0;
			//Khử các phần tử bằng 0 trong mảng kq
			kq = kq.Where(val => val != 0).ToArray();
			//Trả về giá trị lớn nhất của mảng số dương
			return kq.Min();
		}

		/// <summary>
		/// Tìm tất cả các số âm
		/// </summary>
		/// <param name="a">Mảng hiện hành</param>
		/// <param name="length">Chiều dài mảng hiện hành</param>
		/// <param name="nkq">Chiều dài mảng kết quả</param>
		/// <returns>Trả về mảng các số âm</returns>
		static int[] TimTatCaSoAm(int[] a, int length, ref int nkq)
		{
			//Tạo mảng lưu kết quả
			int[] kq = new int[length];
			//Duyệt từ đầu tới cuối mảng
			for (int i = 0; i < length; i++)
				//Nếu la so am thì chèn vào kết quả
				if (a[i] < 0)
					//Chèn số âm vào kết quả
					ChenDau(kq, ref nkq, a[i]);
			return kq;
		}

		/// <summary>
		/// Tìm tất cả các số dương
		/// </summary>
		/// <param name="a">Mảng hiện hành</param>
		/// <param name="length">Chiều dài mảng hiện hành</param>
		/// <param name="nkq">Chiều dài mảng kết quả</param>
		/// <returns>Trả về mảng các số dương</returns>
		static int[] TimTatCaSoDuong(int[] a, int length, ref int nkq)
		{
			//Tạo mảng lưu kết quả
			int[] kq = new int[length];
			//Duyệt từ đầu tới cuối mảng
			for (int i = 0; i < length; i++)
				//Nếu la so dương thì chèn vào kết quả
				if (a[i] > 0)
					ChenDau(kq, ref nkq, a[i]);
			return kq;
		}

		/// <summary>
		/// Tính tổng các phần tử của mảng
		/// </summary>
		/// <param name="a">Mảng cần tính</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <returns>Tổng</returns>
		static int Tong(int[] a, int length)
		{
			//Khởi tạo biến tổng
			int tong = 0;
			//Duyệt hết các phần tử trong mảng và cộng dồn vào biến tổng
			for (int i = 0; i < length; i++)
				tong += a[i];
			return tong;
		}

		/// <summary>
		/// Tìm và trả về vị trí x đầu tiên trong mảng
		/// </summary>
		/// <param name="a">Mảng cần tìm</param>
		/// <param name="length">Chiều dài</param>
		/// <param name="x">Phần tử x cần tìm</param>
		/// <returns>Vị trí đầu tiên</returns>
		static int Tim_X(int[] a, int x)
		{
			return Array.IndexOf(a, x);
		}

		/// <summary>
		/// Xóa tất cả phần tử x trong mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Chiều dài mảng</param>
		/// <param name="x">Phần tử x</param>
		static void Xoa_X(int[] a, ref int length, int x)
		{
			while (Tim_X(a, x) != -1)
			{
				Xoa_TaiVT(a, ref length, Tim_X(a, x));
			}
		}

		/// <summary>
		/// Xóa hết các giá trị của mảng
		/// </summary>
		/// <param name="a">Mảng cần xóa</param>
		/// <param name="length">Độ dài của mảng</param>
		static void Xoa_Het(int[] a, ref int length)
		{
			Array.Clear(a, 0, length);
			length = 0;
		}
	}
}