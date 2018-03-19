using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class QuanLyThueBao
	{
		public DanhSachKhachHang DS_KH = new DanhSachKhachHang();
		public DanhSachThueBao DS_TB = new DanhSachThueBao();

		public void NhapTuFile()
		{
			DS_KH.NhapTuFile();
			DS_TB.NhapTuFile();
		}

		//*************Tìm thành phố có nhiều/ít thuê bao nhất*************

		/// <summary>
		/// Tìm danh sách các thành phố xuất hiện trong danh sách khách hàng
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ThanhPho()
		{
			List<string> kq = new List<string>();
			string thanhPho;
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				thanhPho = t[t.Length - 2];
				if (!kq.Contains(thanhPho))
					kq.Add(thanhPho);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách CMND dựa vào tên thành phố trong danh sách khách hàng
		/// </summary>
		/// <param name="thanhPho">Thành phố cần tìm</param>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_CMND_TheoThanhPho(string thanhPho)
		{
			List<string> kq = new List<string>();
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				if (t[t.Length - 2] == thanhPho)
					kq.Add(item.CMND);
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao mà mỗi người sử dụng
		/// </summary>
		/// <param name="CMND">Chứng minh nhân dân</param>
		/// <returns>Số lượng thuê bao</returns>
		public int TinhTong_ThueBao_TheoCMND(string CMND)
		{
			int kq = 0;
			foreach (var item in DS_TB.DS_TB)
			{
				if (item.CMND == CMND)
					kq++;
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao có trong thành phố
		/// </summary>
		/// <param name="thanhPho">Thành phố cần tìm</param>
		/// <returns>Số lượng thuê bao</returns>
		public int TinhTong_ThueBao_TheoThanhPho(string thanhPho)
		{
			int kq = 0;
			List<string> DS_CMND = Tim_DS_CMND_TheoThanhPho(thanhPho);
			foreach (var item in DS_CMND)
			{
				kq += TinhTong_ThueBao_TheoCMND(item);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách các thành phố có nhiều thuê bao nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ThanhPho_NhieuThueBao()
		{
			List<string> kq = new List<string>();
			List<string> DS_TP = Tim_DS_ThanhPho();
			int max = int.MinValue;
			foreach (var item in DS_TP)
			{
				if (TinhTong_ThueBao_TheoThanhPho(item) > max)
					max = TinhTong_ThueBao_TheoThanhPho(item);
			}
			foreach (var item in DS_TP)
			{
				if (TinhTong_ThueBao_TheoThanhPho(item) == max)
					kq.Add(item);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách các thành phố có ít thuê bao nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ThanhPho_ItThueBao()
		{
			List<string> kq = new List<string>();
			List<string> DS_TP = Tim_DS_ThanhPho();
			int min = int.MaxValue;
			foreach (var item in DS_TP)
			{
				if (TinhTong_ThueBao_TheoThanhPho(item) < min)
					min = TinhTong_ThueBao_TheoThanhPho(item);
			}
			foreach (var item in DS_TP)
			{
				if (TinhTong_ThueBao_TheoThanhPho(item) == min)
					kq.Add(item);
			}
			return kq;
		}

		//*************Tìm thuê bao sở hữu ít số điện thoại nhất*************

		/// <summary>
		/// Tìm người mà dùng ít số điện thoại nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<KhachHang> Tim_TB_ItDienThoai()
		{
			List<KhachHang> kq = new List<KhachHang>();
			int min = int.MaxValue;
			foreach (var item in DS_KH.DS_KH)
			{
				if (TinhTong_ThueBao_TheoCMND(item.CMND) < min)
					min = TinhTong_ThueBao_TheoCMND(item.CMND);
			}
			foreach (var item in DS_KH.DS_KH)
			{
				if (TinhTong_ThueBao_TheoCMND(item.CMND) == min)
					kq.Add(item);
			}
			return kq;
		}

		//*************Tìm con đường có nhiều/ít thuê bao nhất*************

		/// <summary>
		/// Tìm tên những con đường dựa vào danh sách khách hàng
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ConDuong()
		{
			List<string> kq = new List<string>();
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				if (!kq.Contains(t[1]))
					kq.Add(t[1]);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách người sử dụng ở một con đường chỉ định
		/// </summary>
		/// <param name="tenDuong">Tên đường cần tìm</param>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_CMND_TheoConDuong(string tenDuong)
		{
			List<string> kq = new List<string>();
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				if (t[1] == tenDuong)
					kq.Add(item.CMND);
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao có ở con đường đó
		/// </summary>
		/// <param name="tenDuong">Tên đường cần tìm</param>
		/// <returns>Số lượng thuê bao</returns>
		public int TinhTong_ThueBao_TheoConDuong(string tenDuong)
		{
			int kq = 0;
			List<string> DS_CMND = Tim_DS_CMND_TheoConDuong(tenDuong);
			foreach (var item in DS_CMND)
			{
				kq += TinhTong_ThueBao_TheoCMND(item);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách con đường có nhiều thuê bao nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ConDuong_NhieuThueBao()
		{
			List<string> kq = new List<string>();
			List<string> DS_CD = Tim_DS_ConDuong();
			int max = int.MinValue;
			foreach (var item in DS_CD)
			{
				if (TinhTong_ThueBao_TheoConDuong(item) > max)
					max = TinhTong_ThueBao_TheoConDuong(item);
			}
			foreach (var item in DS_CD)
			{
				if (TinhTong_ThueBao_TheoConDuong(item) == max)
					kq.Add(item);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách con đường có ít thuê bao nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ConDuong_ItThueBao()
		{
			List<string> kq = new List<string>();
			List<string> DS_CD = Tim_DS_ConDuong();
			int min = int.MaxValue;
			foreach (var item in DS_CD)
			{
				if (TinhTong_ThueBao_TheoConDuong(item) < min)
					min = TinhTong_ThueBao_TheoConDuong(item);
			}
			foreach (var item in DS_CD)
			{
				if (TinhTong_ThueBao_TheoConDuong(item) == min)
					kq.Add(item);
			}
			return kq;
		}

		//*************Sắp xếp danh sách theo chiều tăng/giảm họ tên, số lượng thuê bao*************

		/// <summary>
		/// Hoán đổi giá trị 2 phần tử của list
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của list</typeparam>
		/// <param name="list">Danh sách cần hoán vị</param>
		/// <param name="indexA">Chỉ số cần hoán vị</param>
		/// <param name="indexB">Chỉ số cần hoán vị</param>
		public static void Swap<T>(IList<T> list, int indexA, int indexB)
		{
			T tmp = list[indexA];
			list[indexA] = list[indexB];
			list[indexB] = tmp;
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều tăng của tên
		/// </summary>
		public void SapXep_Tang_Ten()
		{
			KhachHang[] myArray = DS_KH.DS_KH.ToArray();
			string ten1, ten2;
			string[] t1, t2;
			for (int i = 0; i < myArray.Length - 1; i++)
			{
				for (int j = i + 1; j < myArray.Length; j++)
				{
					t1 = myArray[i].hoTen.Split(' ');
					t2 = myArray[j].hoTen.Split(' ');
					ten1 = t1[t1.Length - 1];
					ten2 = t2[t2.Length - 1];
					if (ten2.CompareTo(ten1) < 0)
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều giảm của tên
		/// </summary>
		public void SapXep_Giam_HoTen()
		{
			KhachHang[] myArray = DS_KH.DS_KH.ToArray();
			string ten1, ten2;
			string[] t1, t2;
			for (int i = 0; i < myArray.Length - 1; i++)
			{
				for (int j = i + 1; j < myArray.Length; j++)
				{
					t1 = myArray[i].hoTen.Split(' ');
					t2 = myArray[j].hoTen.Split(' ');
					ten1 = t1[t1.Length - 1];
					ten2 = t2[t2.Length - 1];
					if (ten2.CompareTo(ten1) > 0)
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều tăng của số thuê bao
		/// </summary>
		public void SapXep_Tang_SoThueBao()
		{
			KhachHang[] myArray = DS_KH.DS_KH.ToArray();
			for (int i = 0; i < myArray.Length - 1; i++)
			{
				for (int j = i + 1; j < myArray.Length; j++)
				{
					if (TinhTong_ThueBao_TheoCMND(myArray[j].CMND) < TinhTong_ThueBao_TheoCMND(myArray[i].CMND))
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều giảm của số thuê bao
		/// </summary>
		public void SapXep_Giam_SoThueBao()
		{
			KhachHang[] myArray = DS_KH.DS_KH.ToArray();
			for (int i = 0; i < myArray.Length - 1; i++)
			{
				for (int j = i + 1; j < myArray.Length; j++)
				{
					if (TinhTong_ThueBao_TheoCMND(myArray[j].CMND) > TinhTong_ThueBao_TheoCMND(myArray[i].CMND))
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách thành phố theo chiều tăng của số thuê bao
		/// </summary>
		/// <returns>Mảng sau khi sắp xếp</returns>
		public string[] SapXep_TP_Tang_SoThueBao()
		{
			string[] DS_TP = Tim_DS_ThanhPho().ToArray();
			for (int i = 0; i < DS_TP.Length - 1; i++)
			{
				for (int j = i + 1; j < DS_TP.Length; j++)
				{
					if (TinhTong_ThueBao_TheoThanhPho(DS_TP[j]) < TinhTong_ThueBao_TheoThanhPho(DS_TP[i]))
						Swap(DS_TP, i, j);
				}
			}
			return DS_TP;
		}

		/// <summary>
		/// Sắp xếp danh sách thành phố theo chiều giảm của số thuê bao
		/// </summary>
		/// <returns>Mảng sau khi sắp xếp</returns>
		public string[] SapXep_TP_Giam_SoThueBao()
		{
			string[] DS_TP = Tim_DS_ThanhPho().ToArray();
			for (int i = 0; i < DS_TP.Length - 1; i++)
			{
				for (int j = i + 1; j < DS_TP.Length; j++)
				{
					if (TinhTong_ThueBao_TheoThanhPho(DS_TP[j]) > TinhTong_ThueBao_TheoThanhPho(DS_TP[i]))
						Swap(DS_TP, i, j);
				}
			}
			return DS_TP;
		}

		//*************Tìm tháng không có thuê bao nào đăng ký*************

		public List<int> Tim_Thang_KhongCoTB()
		{
			List<int> kq = new List<int>();
			List<int> thang = new List<int>();
			foreach (var item in DS_TB.DS_TB)
			{
				if (!thang.Contains(item.ngayDK.Month))
					thang.Add(item.ngayDK.Month);
			}
			for (int i = 1; i <= 12; i++)
				if (!thang.Contains(i))
					kq.Add(i);
			return kq;
		}

		//*************Tìm tất cả khách hàng theo giới tính*************

		public List<KhachHang> Tim_DS_KhachHang_GT(GioiTinh gt)
		{
			List<KhachHang> kq = new List<KhachHang>();
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.gioiTinh == gt)
					kq.Add(item);
			}
			return kq;
		}

		//*************Xóa tất cả khách hàng thuộc một tỉnh nào đó*************

		public void Xoa_KH_Tinh(string tenTinh)
		{
			string tinh;
			string[] t;
			List<KhachHang> khachHang = new List<KhachHang>();
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				tinh = t[t.Length - 1];
				if (tinh == tenTinh)
				{
					khachHang.Add(item);
				}
			}
			foreach (var item in khachHang)
			{
				DS_KH.DS_KH.Remove(item);
			}
		}

		//Xu ly xoa thue bao tai day

		//*************Tất cả khách hàng nào sinh tháng 1 thì được tặng thêm một số điện thoại mới có số là CMND*************

		public void Them_SoDienThoai_NeuSinhThang1()
		{
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.ngaySinh.Month == 1)
					DS_TB.DS_TB.Add(new ThueBao(item.CMND, item.CMND, "18/3/2018"));
			}
		}

		//*************Tìm ngày có nhiều khách hàng đăng ký nhất, ít người đăng ký nhất*************

		public List<int> Tim_NgayDK_Nhieu()
		{
			List<int> ngayDK = new List<int>();
			List<int> kq = new List<int>();
			for (int i = 0; i < 31; i++)
				ngayDK.Add(0);
			foreach (var item in DS_TB.DS_TB)
			{
				ngayDK[item.ngayDK.Day - 1]++;
			}
			int max = ngayDK.Max();
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == max)
					kq.Add(i + 1);
			return kq;
		}

		public List<int> Tim_NgayDK_It()
		{
			List<int> ngayDK = new List<int>();
			List<int> kq = new List<int>();
			List<int> temp = new List<int>();
			for (int i = 0; i < 31; i++)
				ngayDK.Add(0);
			foreach (var item in DS_TB.DS_TB)
			{
				ngayDK[item.ngayDK.Day - 1]++;
			}
			temp = ngayDK;
			temp.RemoveAll(val => val == 0);
			int min = temp.Min();
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == min)
					kq.Add(i + 1);
			return kq;
		}
	}
}
