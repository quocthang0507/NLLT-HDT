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
		/// Tìm danh sách thuê bao mà mỗi người sử dụng
		/// </summary>
		/// <param name="CMND">Chứng minh nhân dân</param>
		/// <returns>Số lượng thuê bao</returns>
		public List<ThueBao> Tim_DS_ThueBao_TheoCMND(string CMND)
		{
			List<ThueBao> kq = new List<ThueBao>();
			foreach (var item in DS_TB.DS_TB)
			{
				if (item.CMND == CMND)
					kq.Add(item);
			}
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
			{
				kq += Tim_DS_ThueBao_TheoCMND(item).Count;
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
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) > max)
					max = Tinh_Tong_ThueBao_TheoThanhPho(item);
			}
			foreach (var item in DS_TP)
			{
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) == max)
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
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) < min)
					min = Tinh_Tong_ThueBao_TheoThanhPho(item);
			}
			foreach (var item in DS_TP)
			{
				if (Tinh_Tong_ThueBao_TheoThanhPho(item) == min)
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
				if (Tim_DS_ThueBao_TheoCMND(item.CMND).Count < min)
					min = Tim_DS_ThueBao_TheoCMND(item.CMND).Count;
			}
			foreach (var item in DS_KH.DS_KH)
			{
				if (Tim_DS_ThueBao_TheoCMND(item.CMND).Count == min)
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
		public int Tinh_Tong_ThueBao_TheoConDuong(string tenDuong)
		{
			int kq = 0;
			List<string> DS_CMND = Tim_DS_CMND_TheoConDuong(tenDuong);
			foreach (var item in DS_CMND)
			{
				kq += Tim_DS_ThueBao_TheoCMND(item).Count;
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
				if (Tinh_Tong_ThueBao_TheoConDuong(item) > max)
					max = Tinh_Tong_ThueBao_TheoConDuong(item);
			}
			foreach (var item in DS_CD)
			{
				if (Tinh_Tong_ThueBao_TheoConDuong(item) == max)
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
				if (Tinh_Tong_ThueBao_TheoConDuong(item) < min)
					min = Tinh_Tong_ThueBao_TheoConDuong(item);
			}
			foreach (var item in DS_CD)
			{
				if (Tinh_Tong_ThueBao_TheoConDuong(item) == min)
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
		/// <param name="indexA">Chỉ số cần hoán vị A</param>
		/// <param name="indexB">Chỉ số cần hoán vị B</param>
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
			string ten1, ten2;
			string[] t1, t2;
			for (int i = 0; i < DS_KH.DS_KH.Count - 1; i++)
			{
				for (int j = i + 1; j < DS_KH.DS_KH.Count; j++)
				{
					t1 = DS_KH.DS_KH[i].hoTen.Split(' ');
					t2 = DS_KH.DS_KH[j].hoTen.Split(' ');
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
			string ten1, ten2;
			string[] t1, t2;
			for (int i = 0; i < DS_KH.DS_KH.Count - 1; i++)
			{
				for (int j = i + 1; j < DS_KH.DS_KH.Count; j++)
				{
					t1 = DS_KH.DS_KH[i].hoTen.Split(' ');
					t2 = DS_KH.DS_KH[j].hoTen.Split(' ');
					ten1 = t1[t1.Length - 1];
					ten2 = t2[t2.Length - 1];
					if (ten2.CompareTo(ten1) > 0)
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều tăng của số lượng thuê bao
		/// </summary>
		public void SapXep_Tang_SoThueBao()
		{
			for (int i = 0; i < DS_KH.DS_KH.Count - 1; i++)
			{
				for (int j = i + 1; j < DS_KH.DS_KH.Count; j++)
				{
					if (Tim_DS_ThueBao_TheoCMND(DS_KH.DS_KH[j].CMND).Count < Tim_DS_ThueBao_TheoCMND(DS_KH.DS_KH[i].CMND).Count)
						Swap<KhachHang>(DS_KH.DS_KH, i, j);
				}
			}
		}

		/// <summary>
		/// Sắp xếp danh sách khách hàng theo chiều giảm của số lượng thuê bao
		/// </summary>
		public void SapXep_Giam_SoThueBao()
		{
			for (int i = 0; i < DS_KH.DS_KH.Count - 1; i++)
			{
				for (int j = i + 1; j < DS_KH.DS_KH.Count; j++)
				{
					if (Tim_DS_ThueBao_TheoCMND(DS_KH.DS_KH[j].CMND).Count > Tim_DS_ThueBao_TheoCMND(DS_KH.DS_KH[i].CMND).Count)
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
					if (Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[j]) < Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[i]))
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
					if (Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[j]) > Tinh_Tong_ThueBao_TheoThanhPho(DS_TP[i]))
						Swap(DS_TP, i, j);
				}
			}
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

		/// <summary>
		/// Tìm danh sách khách hàng theo giới tính
		/// </summary>
		/// <param name="gt">Giới tính nam/ nữ</param>
		/// <returns>Một danh sách</returns>
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

		/// <summary>
		/// Xóa khách hàng ở một tỉnh nào đó
		/// </summary>
		/// <param name="tenTinh">Tên tỉnh cần xóa</param>
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
				{
					foreach (var item2 in DS_CMND)
					{
						if (item1.CMND == item2)
							DS_TB.DS_TB.Remove(item1);
					}
				}
			}
		}

		//*************Tất cả khách hàng nào sinh tháng 1 thì được tặng thêm một số điện thoại mới có số là CMND*************

		/// <summary>
		/// Thêm một số điện thoại là số CMND nếu khách hàng sinh vào tháng một
		/// </summary>
		public void Them_SoDienThoai_NeuSinhThang1()
		{
			foreach (var item in DS_KH.DS_KH)
			{
				if (item.ngaySinh.Month == 1)
					DS_TB.DS_TB.Add(new ThueBao(item.CMND, item.CMND, "18/3/2018"));
			}
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
			{
				ngayDK[item.ngayDK.Day - 1]++;
			}
			int max = ngayDK.Max();
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == max)
					kq.Add(i + 1);
			return kq;
		}

		/// <summary>
		/// Tìm ngày mà có nhiều ít đăng ký nhất
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
			{
				ngayDK[item.ngayDK.Day - 1]++;
			}
			foreach (var item in ngayDK)
			{
				if (item != 0 && item < min)
					min = item;
			}
			for (int i = 0; i < 31; i++)
				if (ngayDK[i] == 1)
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
			string tinh;
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				tinh = t[t.Length - 1];
				if (!kq.Contains(tinh))
					kq.Add(tinh);
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
			string[] t;
			foreach (var item in DS_KH.DS_KH)
			{
				t = item.diaChi.Split(',');
				if (t[t.Length - 1] == tenTinh)
					if (!kq.Contains(t[t.Length - 2]))
						kq.Add(t[t.Length - 2]);
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
			{
				kq += Tinh_Tong_ThueBao_TheoThanhPho(item);
			}
			return kq;
		}

		/// <summary>
		/// Xuất danh sách khách hàng và thuê bao theo CMND
		/// </summary>
		/// <param name="CMND">CMND cần tìm</param>
		/// <param name="stt">Số thứ tự</param>
		/// <returns></returns>
		public string Xuat_DS_KH_TB_TheoCMND(string CMND, int stt)
		{
			string kq = "\t\t";
			foreach (var kh in DS_KH.DS_KH)
			{
				if (kh.CMND == CMND)
				{
					kq += stt + ". " + kh + ". So dien thoai: ";
					foreach (var tb in DS_TB.DS_TB)
					{
						if (tb.CMND == CMND)
							kq += tb.soDT + "; ";
					}
					kq += "\n";
				}
			}
			return kq;
		}

		/// <summary>
		/// Xuất danh sách thống kê theo tỉnh
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
