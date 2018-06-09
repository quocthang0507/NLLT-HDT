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
			foreach (var item in DS_KH.DS_KH)
				if (!kq.Contains(item.thanhPho))
					kq.Add(item.thanhPho);
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
			foreach (var item in DS_KH.DS_KH)
				if (item.thanhPho == thanhPho)
					kq.Add(item.CMND);
			return kq;
		}

		/// <summary>
		/// Tìm danh sách thuê bao mà mỗi người sử dụng
		/// </summary>
		/// <param name="CMND">Chứng minh nhân dân</param>
		/// <returns>Một danh sách</returns>
		public List<ThueBao> Tim_DS_ThueBao_TheoCMND(string CMND)
		{
			List<ThueBao> kq = new List<ThueBao>();
			foreach (var item in DS_TB.DS_TB)
				if (item.CMND == CMND)
					kq.Add(item);
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao có trong thành phố
		/// </summary>
		/// <param name="thanhPho">Thành phố cần tìm</param>
		/// <returns>Số lượng thuê bao</returns>
		public int Tinh_Tong_ThueBao_TheoThanhPho(string thanhPho)
		{
			int kq = 0;
			List<string> DS_CMND = Tim_DS_CMND_TheoThanhPho(thanhPho);
			foreach (var item in DS_CMND)
				kq += Tim_DS_ThueBao_TheoCMND(item).Count;
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
			int temp;
			foreach (var item in DS_TP)
			{
				temp = Tinh_Tong_ThueBao_TheoThanhPho(item);
				if (temp > max)
					max = temp;
			}
			foreach (var item in DS_TP)
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) == max)
					kq.Add(item);
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
			int temp;
			foreach (var item in DS_TP)
			{
				temp = Tinh_Tong_ThueBao_TheoThanhPho(item);
				if (temp < min)
					min = temp;
			}
			foreach (var item in DS_TP)
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) == min)
					kq.Add(item);
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
			int temp;
			foreach (var item in DS_KH.DS_KH)
			{
				temp = Tim_DS_ThueBao_TheoCMND(item.CMND).Count;
				if (temp < min)
					min = temp;
			}
			foreach (var item in DS_KH.DS_KH)
				if (Tim_DS_ThueBao_TheoCMND(item.CMND).Count == min)
					kq.Add(item);
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
			foreach (var item in DS_KH.DS_KH)
				if (!kq.Contains(item.tenDuong))
					kq.Add(item.tenDuong);
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
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.tenDuong == tenDuong)
					kq.Add(item.tenDuong);
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao có ở con đường đó
		/// </summary>
		/// <param name="tenDuong">Tên đường cần tìm</param>
		/// <returns>Số lượng thuê bao</returns>
		public int Tinh_Tong_ThueBao_TheoConDuong(string tenDuong)
		{
			int kq = 0;
			List<string> DS_CMND = Tim_DS_CMND_TheoConDuong(tenDuong);
			foreach (var item in DS_CMND)
				kq += Tim_DS_ThueBao_TheoCMND(item).Count;
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
			int temp;
			foreach (var item in DS_CD)
			{
				temp = Tinh_Tong_ThueBao_TheoConDuong(item);
				if (max > temp)
					temp = max;
			}
			foreach (var item in DS_CD)
				if (Tinh_Tong_ThueBao_TheoConDuong(item) == max)
					kq.Add(item);
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
			int temp;
			foreach (var item in DS_CD)
			{
				temp = Tinh_Tong_ThueBao_TheoConDuong(item);
				if (min > temp)
					min = temp;
			}
			foreach (var item in DS_CD)
				if (Tinh_Tong_ThueBao_TheoConDuong(item) == min)
					kq.Add(item);
			return kq;
		}

		//*************Sắp xếp danh sách theo chiều tăng/giảm họ tên, số lượng thuê bao*************

		/// <summary>
		/// Hoán đổi giá trị 2 phần tử của list
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của list</typeparam>
		/// <param name="list">Danh sách cần hoán vị</param>
		/// <param name="indexA">Chỉ số cần hoán vị A</param>
		/// <param name="indexB">Chỉ số cần hoán vị B</param>
		public void Swap<T>(IList<T> list, int indexA, int indexB)
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
			for (int i = 0; i < DS_KH.Dem - 1; i++)
				for (int j = i + 1; j < DS_KH.Dem; j++)
					if (string.Compare(DS_KH[j].ten, DS_KH[i].ten) < 0)
						Swap(DS_KH.DS_KH, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều giảm của tên
		/// </summary>
		public void SapXep_Giam_HoTen()
		{
			for (int i = 0; i < DS_KH.Dem - 1; i++)
				for (int j = i + 1; j < DS_KH.Dem; j++)
					if (string.Compare(DS_KH[j].ten, DS_KH[i].ten) > 0)
						Swap(DS_KH.DS_KH, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều tăng của số lượng thuê bao
		/// </summary>
		public void SapXep_Tang_SoThueBao()
		{
			for (int i = 0; i < DS_KH.Dem - 1; i++)
				for (int j = i + 1; j < DS_KH.Dem; j++)
					if (Tim_DS_ThueBao_TheoCMND(DS_KH[j].CMND).Count < Tim_DS_ThueBao_TheoCMND(DS_KH[i].CMND).Count)
						Swap(DS_KH.DS_KH, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều giảm của số lượng thuê bao
		/// </summary>
		public void SapXep_Giam_SoThueBao()
		{
			for (int i = 0; i < DS_KH.Dem - 1; i++)
				for (int j = i + 1; j < DS_KH.Dem; j++)
					if (Tim_DS_ThueBao_TheoCMND(DS_KH[j].CMND).Count > Tim_DS_ThueBao_TheoCMND(DS_KH[i].CMND).Count)
						Swap(DS_KH.DS_KH, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách thành phố theo chiều tăng của số thuê bao
		/// </summary>
		/// <returns>Mảng sau khi sắp xếp</returns>
		public string[] SapXep_TP_Tang_SoThueBao()
		{
			string[] DS_TP = Tim_DS_ThanhPho().ToArray();
			for (int i = 0; i < DS_TP.Length - 1; i++)
				for (int j = i + 1; j < DS_TP.Length; j++)
					if (Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[j]) < Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[i]))
						Swap(DS_TP, i, j);
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
				for (int j = i + 1; j < DS_TP.Length; j++)
					if (Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[j]) > Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[i]))
						Swap(DS_TP, i, j);
			return DS_TP;
		}

		//*************Tìm tháng không có thuê bao nào đăng ký*************

		/// <summary>
		/// Tìm tháng không có thuê bao nào đăng ký
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<int> Tim_Thang_KhongCoTB()
		{
			List<int> kq = new List<int>();
			List<int> thang = new List<int>();
			foreach (var item in DS_TB.DS_TB)
				if (!thang.Contains(item.ngayDK.Month))
					thang.Add(item.ngayDK.Month);
			for (int i = 1; i <= 12; i++)
				if (!thang.Contains(i))
					kq.Add(i);
			return kq;
		}

		//*************Tìm tất cả khách hàng theo giới tính*************

		/// <summary>
		/// Tìm danh sách khách hàng theo giới tính
		/// </summary>
		/// <param name="gt">Giới tính nam/ nữ</param>
		/// <returns>Một danh sách</returns>
		public List<KhachHang> Tim_DS_KhachHang_GT(GioiTinh gt)
		{
			List<KhachHang> kq = new List<KhachHang>();
			foreach (var item in DS_KH.DS_KH)
				if (item.gioiTinh == gt)
					kq.Add(item);
			return kq;
		}

		//*************Xóa tất cả khách hàng thuộc một tỉnh nào đó*************

		/// <summary>
		/// Xóa khách hàng ở một tỉnh nào đó
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần xóa</param>
		public void Xoa_KH_Tinh(string tenTinh)
		{
			List<KhachHang> khachHang = new List<KhachHang>();
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.tenTinh == tenTinh)
					khachHang.Add(item);
			}
			foreach (var item in khachHang)
				DS_KH.DS_KH.Remove(item);
		}

		/// <summary>
		/// Xóa thuê bao ở một tỉnh nào đó
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần xóa</param>
		public void Xoa_TB_Tinh(string tenTinh)
		{
			List<string> DS_TP = Tim_DS_ThanhPho_ThuocTinh(tenTinh);
			List<string> DS_CMND = new List<string>();
			foreach (var item in DS_TP)
			{
				DS_CMND = Tim_DS_CMND_TheoThanhPho(item);
				foreach (var item1 in DS_TB.DS_TB)
					foreach (var item2 in DS_CMND)
						if (item1.CMND == item2)
							DS_TB.DS_TB.Remove(item1);
			}
		}

		//*************Tất cả khách hàng nào sinh tháng 1 thì được tặng thêm một số điện thoại mới có số là CMND*************

		/// <summary>
		/// Thêm một số điện thoại là số CMND nếu khách hàng sinh vào tháng một
		/// </summary>
		public void Them_SoDienThoai_NeuSinhThang1()
		{
			foreach (var item in DS_KH.DS_KH)
				if (item.ngaySinh.Month == 1)
					DS_TB.DS_TB.Add(new ThueBao(item.CMND, item.CMND, "1/1/2018"));
		}

		//*************Tìm ngày có nhiều khách hàng đăng ký nhất, ít người đăng ký nhất*************

		/// <summary>
		/// Tìm ngày mà có nhiều người đăng ký nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<int> Tim_NgayDK_Nhieu()
		{
			List<int> ngayDK = new List<int>();
			List<int> kq = new List<int>();
			for (int i = 0; i < 31; i++)
				ngayDK.Add(0);
			foreach (var item in DS_TB.DS_TB)
				ngayDK[item.ngayDK.Day - 1]++;
			int max = ngayDK.Max();
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == max)
					kq.Add(i + 1);
			return kq;
		}

		/// <summary>
		/// Tìm ngày mà có nhiều ít đăng ký nhất (ít đăng ký chứ không phải là không đăng ký)
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<int> Tim_NgayDK_It()
		{
			List<int> ngayDK = new List<int>();
			List<int> kq = new List<int>();
			int min = int.MaxValue;
			for (int i = 0; i < 31; i++)
				ngayDK.Add(0);
			foreach (var item in DS_TB.DS_TB)
				ngayDK[item.ngayDK.Day - 1]++;
			foreach (var item in ngayDK)
				if (item != 0 && item < min)
					min = item;
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == min)
					kq.Add(i + 1);
			return kq;
		}

		//********************Thống kê và hiển thị dữ liệu theo từng tỉnh và mỗi tỉnh hiển thị theo thành phố theo mẫu********************

		/// <summary>
		/// Tìm danh sách các tỉnh xuất hiện trong danh sách khách hàng
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_Tinh()
		{
			List<string> kq = new List<string>();
			foreach (var item in DS_KH.DS_KH)
			{
				if (!kq.Contains(item.tenTinh))
					kq.Add(item.tenTinh);
			}
			return kq;
		}

		/// <summary>
		/// Tìm danh sách thành phố thuộc một tỉnh nào đó
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần tìm</param>
		/// <returns>Một danh sách</returns>
		public List<string> Tim_DS_ThanhPho_ThuocTinh(string tenTinh)
		{
			List<string> kq = new List<string>();
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.tenTinh == tenTinh)
					if (!kq.Contains(item.thanhPho))
						kq.Add(item.thanhPho);
			}
			return kq;
		}

		/// <summary>
		/// Tính tổng số thuê bao ở một tỉnh nào đó
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần tìm</param>
		/// <returns>Số lượng thuê bao</returns>
		public int Tinh_Tong_ThueBao_TheoTinh(string tenTinh)
		{
			List<string> DS_TP = Tim_DS_ThanhPho_ThuocTinh(tenTinh);
			int kq = 0;
			foreach (var item in DS_TP)
				kq += Tinh_Tong_ThueBao_TheoThanhPho(item);
			return kq;
		}

		/// <summary>
		/// Xuất chuỗi danh sách khách hàng và thuê bao theo CMND
		/// </summary>
		/// <param name="CMND">CMND cần tìm</param>
		/// <param name="stt">Số thứ tự</param>
		/// <returns></returns>
		public string Xuat_DS_KH_TB_TheoCMND(string CMND, int stt)
		{
			string kq = "\t\t";
			foreach (var kh in DS_KH.DS_KH)
				if (kh.CMND == CMND)
				{
					kq += stt + ". " + kh + ". So dien thoai: ";
					foreach (var tb in DS_TB.DS_TB)
						if (tb.CMND == CMND)
							kq += tb.soDT + "; ";
					kq += "\n";
				}
			return kq;
		}

		/// <summary>
		/// Xuất chuỗi danh sách thống kê theo tỉnh
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần tìm</param>
		/// <returns>Chuỗi kết quả</returns>
		public string Xuat_DS_ThongKe_TheoTinh(string tenTinh)
		{
			string kq = "\n";
			int stt = 1;
			List<string> DS_TP = Tim_DS_ThanhPho_ThuocTinh(tenTinh);
			List<string> DS_CMND = new List<string>();
			kq += "Tinh: " + tenTinh + " . Tong so thue bao: " + Tinh_Tong_ThueBao_TheoTinh(tenTinh) + "\n";
			foreach (var tp in DS_TP)
			{
				kq += "\t" + "Thanh pho: " + tp + " .Tong so thue bao: " + Tinh_Tong_ThueBao_TheoThanhPho(tp) + "\n";
				DS_CMND = Tim_DS_CMND_TheoThanhPho(tp);
				foreach (var cmnd in DS_CMND)
				{
					kq += Xuat_DS_KH_TB_TheoCMND(cmnd, stt);
					stt++;
				}
			}
			return kq;
		}
	}
}