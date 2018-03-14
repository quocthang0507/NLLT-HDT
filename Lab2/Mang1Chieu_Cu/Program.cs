using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang1Chieu
{
	class Program
	{
		static void Main(string[] args)
		{
			int soMenu = 20, menu;
			int[] array = new int[100];
			int length;
			Console.Write("Nhap kich thuoc mang : ");
			length = int.Parse(Console.ReadLine());
			Nhap_TD(array, length);
			do
			{
				menu = ChonMenu(soMenu);
				XuLyMenu(menu, array, ref length);
			} while (menu > 0);
		}

		static void XuatMenu()
		{
			Console.WriteLine("================= HE THONG CHUC NANG =================");
			Console.WriteLine("0.Thoat khoi chuong trinh");
			Console.WriteLine("1.Tim so am lon nhat");
			Console.WriteLine("2.Tim so am nho nhat");
			Console.WriteLine("3.Tim so duong lon nhat");
			Console.WriteLine("4.Tim so duong nho nhat");
			Console.WriteLine("5.Tim tat ca cac so am trong mang");
			Console.WriteLine("6.Tim tat ca cac so duong trong mang");
			Console.WriteLine("7.Tong tat ca cac so am trong mang");
			Console.WriteLine("8.Tong cac so duong trong mang");
			Console.WriteLine("9.Xoa mot so tai vi tri vt trong mang");
			Console.WriteLine("10.Xoa phan tu dau tien trong mang");
			Console.WriteLine("11.Xoa phan tu cuoi cung trong mang");
			Console.WriteLine("12.Xoa phan tu x trong mang");
			Console.WriteLine("13.Them mot so tai vi tri vt trong mang");
			Console.WriteLine("14.Them phan tu dau tien trong mang");
			Console.WriteLine("15.Them phan tu cuoi cung trong mang");
			Console.WriteLine("16.Xoa tat ca so am trong mang");
			Console.WriteLine("17.Xoa tat ca so duong trong mang");
			Console.WriteLine("18.Dem so phan tu am trong mang");
			Console.WriteLine("19.Dem so phan tu duong trong mang");
			Console.WriteLine("20.Tim cac phan tu co gia tri la x trong mang.");
			Console.WriteLine("===================================================");
		}
		static int ChonMenu(int soMenu)
		{
			int stt;
			while (true)
			{
				Console.Clear();
				XuatMenu();
				Console.Write("Chon chuc nang tu [0,..,20]: ");
				stt = int.Parse(Console.ReadLine());
				if (0 <= stt && stt <= soMenu)
					break;
			}
			return stt;
		}

		static void XuLyMenu(int menu, int[] a, ref int length)
		{
			Console.Clear();
			int vt;
			int x;
			bool kq;
			int max, min;
			int[] mkq;
			int nkq = 0;
			switch (menu)
			{
				case 0:
					Console.WriteLine("0.Thoat khoi chuong trinh");
					break;
				case 1:
					Console.WriteLine("1.Tim so am lon nhat");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					max = TimMaxAm(a, length);
					if (max == 0)
					{
						Console.WriteLine("Khong co gia tri am!");
					}
					else Console.WriteLine("Gia tri am lon nhat " + max);
					break;
				case 2:
					Console.WriteLine("2.Tim so am nho nhat");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					min = TimMinAm(a, length);
					if (min == 0)
					{
						Console.WriteLine("Khong co gia tri am!");
					}
					else Console.WriteLine("Gia tri am nho nhat " + min);
					break;
				case 3:
					Console.WriteLine("3.Tim so duong lon nhat");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					max = TimMaxDuong(a, length);
					if (max == 0)
					{
						Console.WriteLine("Khong co gia tri duong!");
					}
					else Console.WriteLine("Gia tri duong lon nhat " + max);
					break;
				case 4:
					Console.WriteLine("4.Tim so duong nho nhat");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					min = TimMinDuong(a, length);
					if (min == 0)
					{
						Console.WriteLine("Khong co gia tri duong!");
					}
					else Console.WriteLine("Gia tri duong nho nhat " + min);
					break;
				case 5:
					Console.WriteLine("5.Tim tat ca cac so am trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					mkq = TimTatCaSoAm(a, length, ref nkq);
					if (nkq == 0)
					{
						Console.WriteLine("Khong co gia tri am!");
					}
					else
					{
						Console.WriteLine("Ket qua:");
						Xuat(mkq, nkq);
					}
					break;
				case 6:
					Console.WriteLine("6.Tim tat ca cac so duong trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					mkq = TimTatCaSoDuong(a, length, ref nkq);
					if (nkq == 0)
					{
						Console.WriteLine("Khong co gia tri duong!");
					}
					else
					{
						Console.WriteLine("Ket qua:");
						Xuat(mkq, nkq);
					}
					break;
				case 7:
					Console.WriteLine("7.Tong tat ca cac so am trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					mkq = TimTatCaSoAm(a, length, ref nkq);
					if (nkq == 0)
					{
						Console.WriteLine("Khong co gia tri am!");
					}
					else
					{
						Console.WriteLine("Danh sach cac so am trong mang");
						Xuat(mkq, nkq);
						Console.WriteLine("Ket qua: {0}", Tong(mkq, nkq));
					}
					break;
				case 8:
					Console.WriteLine("8.Tong cac so duong trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					mkq = TimTatCaSoDuong(a, length, ref nkq);
					if (nkq == 0)
					{
						Console.WriteLine("Khong co gia tri duong!");
					}
					else
					{
						Console.WriteLine("Danh sach cac so duong trong mang");
						Xuat(mkq, nkq);
						Console.WriteLine("Ket qua: {0}", Tong(mkq, nkq));
					}
					break;
				case 9:
					Console.WriteLine("9.Xoa mot so tai vi tri vt trong mang");
					Xuat(a, length);
					Console.Write("\nNhap vi tri can xoa: ");
					vt = int.Parse(Console.ReadLine());
					kq = Xoa_TaiVT(a, ref length, vt);
					if (kq)
					{
						Console.WriteLine("Mang sau khi xoa : ");
						Xuat(a, length);
					}
					else Console.WriteLine("Ban nhap vi tri khong dung!");
					break;
				case 10:
					Console.WriteLine("10.Xoa phan tu dau tien trong mang");
					Xuat(a, length);
					Console.WriteLine("Mang sau khi xoa : ");
					Xoa_Dau(a, ref length);
					Xuat(a, length);
					break;
				case 11:
					Console.WriteLine("11.Xoa phan tu cuoi cung trong mang");
					Xuat(a, length);
					Console.WriteLine("Mang sau khi xoa : ");
					Xoa_Cuoi(a, ref length);
					Xuat(a, length);
					break;
				case 12:
					Console.WriteLine("12.Xoa phan tu x trong mang");
					Xuat(a, length);
					Console.Write("Nhap phan tu x can xoa: ");
					x = int.Parse(Console.ReadLine());
					if (Tim_X(a, x) == -1)
						Console.WriteLine("Phan tu x khong co trong mang");
					else
					{
						Xoa_X(a, ref length, x);
						Console.WriteLine("Mang sau khi xoa : ");
						Xuat(a, length);
					}
					break;
				case 13:
					Console.WriteLine("13.Them mot so tai vi tri vt trong mang");
					Xuat(a, length);
					Console.Write("\nNhap vi tri can chen: ");
					vt = int.Parse(Console.ReadLine());
					Console.Write("Nhap gia tri can chen: ");
					x = int.Parse(Console.ReadLine());
					kq = Chen_TaiVT(a, ref length, x, vt);
					if (kq == true)
					{
						Xuat(a, length);
					}
					else Console.WriteLine("Ban nhap vi tri khong dung!");
					break;
				case 14:
					Console.WriteLine("14.Them phan tu dau tien trong mang");
					Console.Write("Nhap gia tri can chen: ");
					x = int.Parse(Console.ReadLine());
					Console.WriteLine("Mang ban dau : ");
					Xuat(a, length);
					Console.WriteLine("Mang sau khi chen : ");
					ChenDau(a, ref length, x);
					Xuat(a, length);
					break;
				case 15:
					Console.WriteLine("15.Them phan tu cuoi cung trong mang");
					Console.Write("Nhap gia tri can chen: ");
					x = int.Parse(Console.ReadLine());
					Console.WriteLine("Mang ban dau : ");
					Xuat(a, length);
					ChenCuoi(a, ref length, x);
					Console.WriteLine("Mang sau khi chen : ");
					Xuat(a, length);
					break;
				case 16:
					Console.WriteLine("16.Xoa tat ca so am trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					Xoa_SoAm(a, ref length);
					Console.WriteLine("Mang sau khi xoa: ");
					Xuat(a, length);
					break;
				case 17:
					Console.WriteLine("17.Xoa tat ca so duong trong mang");
					Console.WriteLine("Mang ban dau: ");
					Xuat(a, length);
					Xoa_SoDuong(a, ref length);
					Console.WriteLine("Mang sau khi xoa: ");
					Xuat(a, length);
					break;
				case 18:
					Console.WriteLine("18.Dem so phan tu am trong mang");
					Console.WriteLine("Xem lai mang: ");
					Xuat(a, length);
					Console.WriteLine("Mang tren co {0} so am", Dem_SoAm(a, length));
					break;
				case 19:
					Console.WriteLine("19.Dem so phan tu duong trong mang");
					Console.WriteLine("Xem lai mang: ");
					Xuat(a, length);
					Console.WriteLine("Mang tren co {0} so duong", Dem_SoDuong(a, length));
					break;
				case 20:
					Console.WriteLine("20.Tim cac phan tu co gia tri la x trong mang.");
					Console.WriteLine("Xem lai mang: ");
					Xuat(a, length);
					Console.Write("Nhap phan tu X = ");
					x = int.Parse(Console.ReadLine());
					Console.WriteLine("Co {0} so bang X", Dem_X(a, length, x));
					break;
				default:
					break;
			}
			Console.ReadLine();
		}

		//////////////////////////MỘT SỐ HÀM PHỤC VỤ CÁC CHỨC NĂNG////////////////////////////////////

		/// <summary>
		/// Nhập tự động cho mảng với phạm vi [-20;20]
		/// </summary>
		/// <param name="a">Mảng cần nhập</param>
		/// <param name="length">Chiều dài</param>
		static void Nhap_TD(int[] a, int length)
		{
			//Khai báo một số ngẫu nhiên
			Random so = new Random();
			//Duyệt hết mảng để nhập giá trị
			for (int i = 0; i < length; i++)
			{
				//Sử dụng phương thức Next trong lớp Random với 2 tham số tương ứng là min và max
				a[i] = so.Next(-20, 20);
			}
		}

		/// <summary>
		/// Xuất mảng ra màn hình
		/// </summary>
		/// <param name="a">Mảng cần xuất</param>
		/// <param name="length">Chiều dài của mảng</param>
		static void Xuat(int[] a, int length)
		{
			Console.WriteLine();
			//Duyệt tuần tự mảng
			for (int i = 0; i < length; i++)
			{
				//Xuất giá trị của mảng tại vị trí i
				Console.Write("{0}\t", a[i]);
			}
			Console.WriteLine();
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
			{
				a[i] = a[i + 1];
			}
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
			{
				//Nếu phần tử đó âm
				if (a[i] < 0)
				{
					//Gọi hàm xóa tại vị trí i
					Xoa_TaiVT(a, ref length, i);
					//Giảm i một đơn vị để xét lại vị trí vừa mới xóa
					i--;
				}
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
			{
				//Nếu phần tử đó dương
				if (a[i] > 0)
				{
					//Gọi hàm xóa tại vị trí i
					Xoa_TaiVT(a, ref length, i);
					//Giảm i một đơn vị để xét lại vị trí vừa mới xóa
					i--;
				}
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
			{
				//Nếu phần tử đó là số âm thì tăng biến dem lên một đơn vị
				if (a[i] < 0)
					dem++;
			}
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
			{
				//Nếu phần tử đó là số dương thì tăng biến dem lên một đơn vị
				if (a[i] > 0)
					dem++;
			}
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
			{
				//Nếu phần tử đó bằng x thì tăng biến dem lên một đơn vị
				if (a[i] == x)
					dem++;
			}
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
			{
				//Nếu la so am thì chèn vào kết quả
				if (a[i] < 0)
					//Chèn số âm vào kết quả
					ChenDau(kq, ref nkq, a[i]);
			}
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
			{
				//Nếu la so dương thì chèn vào kết quả
				if (a[i] > 0)
					ChenDau(kq, ref nkq, a[i]);
			}
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
			{
				tong += a[i];
			}
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
	}
}