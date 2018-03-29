using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class QuanLyHinhHoc
	{
		//Khởi tạo 3 danh sách lưu 3 loại hình
		public DanhSachHinhChuNhat DS_HCN = new DanhSachHinhChuNhat();
		public DanhSachHinhTron DS_HT = new DanhSachHinhTron();
		public DanhSachHinhVuong DS_HV = new DanhSachHinhVuong();
		//Khởi tạo 1 danh sách lưu 3 loại hình
		public MyList DS_Hinh_DT = new MyList();
		public MyList DS_Hinh_CV = new MyList();

		/// <summary>
		/// Đọc dữ liệu từ tập tin
		/// </summary>
		public void DocTuFile()
		{
			string path = @"data.txt";
			StreamReader sr = new StreamReader(path);
			string s = "";
			while ((s = sr.ReadLine()) != null)
			{
				string[] t = s.Split(' ');
				if (t[0] == "HT")
					DS_HT.Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					DS_HV.Them(new HinhVuong(float.Parse(t[1])));
				else
					DS_HCN.Them(new HinhChuNhat(float.Parse(t[1]), float.Parse(t[2])));
			}
		}

		/// <summary>
		/// Xuất cả 3 hình
		/// </summary>
		public void Xuat()
		{
			Console.WriteLine("Danh sach hinh chu nhat:");
			Console.WriteLine(DS_HCN);
			Console.WriteLine("Danh sach hinh vuong:");
			Console.WriteLine(DS_HV);
			Console.WriteLine("Danh sach hinh tron:");
			Console.WriteLine(DS_HT);
		}

		/// <summary>
		/// Nhập bằng tay
		/// </summary>
		public void NhapBangTay()
		{
			string s = "";
			do
			{
				Console.Write("Nhap theo dinh dang, moi lan nhap la mot hinh (HT 4, HCN 4 5, HV 5.5): ");
				s = Console.ReadLine();
				string[] t = s.Split(' ');
				if (t[0] == "HT")
					DS_HT.Them(new HinhTron(float.Parse(t[1])));
				else if (t[0] == "HV")
					DS_HV.Them(new HinhVuong(float.Parse(t[1])));
				else if (t[0] == "HCN")
					DS_HCN.Them(new HinhChuNhat(float.Parse(t[1]), float.Parse(t[2])));
				else return;
			} while (s == "");
		}

		/// <summary>
		/// Tìm hình vuông có diện tích lớn nhất
		/// </summary>
		/// <returns>Danh sách hình vuông</returns>
		public List<HinhVuong> Tim_HV_S_Max()
		{
			List<HinhVuong> kq = new List<HinhVuong>();
			MyList List = new MyList();
			foreach (var item in DS_HV.DS_HV)
				List.Them(new KeyValuePair(item, item.dTich));
			float max = List.Tim_Max();
			foreach (var item in DS_HV.DS_HV)
				if (item.dTich == max)
					kq.Add(item);
			return kq;
		}

		/// <summary>
		/// Tìm hình chữ nhật có diện tích nhỏ nhất
		/// </summary>
		/// <returns>Danh sách hình chữ nhật</returns>
		public List<HinhChuNhat> Tim_HCN_S_Min()
		{
			List<HinhChuNhat> kq = new List<HinhChuNhat>();
			MyList List = new MyList();
			foreach (var item in DS_HCN.DS_HCN)
				List.Them(new KeyValuePair(item, item.dTich));
			float min = List.Tim_Min();
			foreach (var item in DS_HCN.DS_HCN)
				if (item.dTich == min)
					kq.Add(item);
			return kq;
		}

		/// <summary>
		/// Tìm hình tròn có bán kính lớn nhất
		/// </summary>
		/// <returns>Danh sách hình tròn</returns>
		public List<HinhTron> Tim_HT_R_Max()
		{
			List<HinhTron> kq = new List<HinhTron>();
			MyList List = new MyList();
			foreach (var item in DS_HT.DS_HT)
				List.Them(new KeyValuePair(item, item.bKinh));
			float max = List.Tim_Max();
			foreach (var item in DS_HT.DS_HT)
				if (item.bKinh == max)
					kq.Add(item);
			return kq;
		}

		/// <summary>
		/// Hoán vị 2 phần tử trong danh sách
		/// </summary>
		/// <typeparam name="T">Kiểu danh sách</typeparam>
		/// <param name="list">Tên danh sách</param>
		/// <param name="i">Chỉ số i</param>
		/// <param name="j">Chỉ số j</param>
		public void Swap<T>(IList<T> list, int i, int j)
		{
			T tmp = list[i];
			list[i] = list[j];
			list[j] = tmp;
		}

		/// <summary>
		/// Sắp xếp danh sách hình vuông theo chiều tăng chu vi
		/// </summary>
		public void SapXep_DSHV_Tang_CV()
		{
			for (int i = 0; i < DS_HV.Dem - 1; i++)
				for (int j = i + 1; j < DS_HV.Dem; j++)
					if (DS_HV[j].cVi < DS_HV[i].cVi)
						Swap<HinhVuong>(DS_HV.DS_HV, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách hình vuông theo chiều giảm chu vi
		/// </summary>
		public void SapXep_DSHV_Giam_CV()
		{
			for (int i = 0; i < DS_HV.Dem - 1; i++)
				for (int j = i + 1; j < DS_HV.Dem; j++)
					if (DS_HV[j].cVi > DS_HV[i].cVi)
						Swap<HinhVuong>(DS_HV.DS_HV, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách hình tròn theo chiều tăng chu vi
		/// </summary>
		public void SapXep_DSHT_Tang_CV()
		{
			for (int i = 0; i < DS_HT.Dem - 1; i++)
				for (int j = i + 1; j < DS_HT.Dem; j++)
					if (DS_HT[j].cVi < DS_HT[i].cVi)
						Swap<HinhTron>(DS_HT.DS_HT, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách hình tròn theo chiều giảm chu vi
		/// </summary>
		public void SapXep_DSHT_Giam_CV()
		{
			for (int i = 0; i < DS_HT.Dem - 1; i++)
				for (int j = i + 1; j < DS_HT.Dem; j++)
					if (DS_HT[j].cVi > DS_HT[i].cVi)
						Swap<HinhTron>(DS_HT.DS_HT, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách hình chữ nhật theo chiều tăng chu vi
		/// </summary>
		public void SapXep_DSHCN_Tang_CV()
		{
			for (int i = 0; i < DS_HCN.Dem - 1; i++)
				for (int j = i + 1; j < DS_HCN.Dem; j++)
					if (DS_HCN[j].cVi < DS_HCN[i].cVi)
						Swap<HinhChuNhat>(DS_HCN.DS_HCN, i, j);
		}

		/// <summary>
		/// Sắp xếp danh sách hình chữ nhật theo chiều giảm chu vi
		/// </summary>
		public void SapXep_DSHCN_Giam_CV()
		{
			for (int i = 0; i < DS_HCN.Dem - 1; i++)
				for (int j = i + 1; j < DS_HCN.Dem; j++)
					if (DS_HCN[j].cVi > DS_HCN[i].cVi)
						Swap<HinhChuNhat>(DS_HCN.DS_HCN, i, j);
		}

		/// <summary>
		/// Gộp 3 danh sách thành 1 danh sách với value là diện tích
		/// </summary>
		public void Gop_3_DS_DienTich()
		{
			foreach (var item in DS_HV.DS_HV)
				DS_Hinh_DT.Them(new KeyValuePair(item, item.dTich));
			foreach (var item in DS_HT.DS_HT)
				DS_Hinh_DT.Them(new KeyValuePair(item, item.dTich));
			foreach (var item in DS_HCN.DS_HCN)
				DS_Hinh_DT.Them(new KeyValuePair(item, item.dTich));
		}

		/// <summary>
		/// Gộp 3 danh sách thành 1 danh sách với value là chu vi
		/// </summary>
		public void Gop_3_DS_ChuVi()
		{
			foreach (var item in DS_HV.DS_HV)
				DS_Hinh_CV.Them(new KeyValuePair(item, item.cVi));
			foreach (var item in DS_HT.DS_HT)
				DS_Hinh_CV.Them(new KeyValuePair(item, item.cVi));
			foreach (var item in DS_HCN.DS_HCN)
				DS_Hinh_CV.Them(new KeyValuePair(item, item.cVi));
		}

		/// <summary>
		/// Tìm hình có diện tích lớn nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<object> Tim_Hinh_S_Max()
		{
			List<object> kq = new List<object>();
			if (DS_Hinh_DT.Dem == 0)
				Gop_3_DS_DienTich();
			float max = DS_Hinh_DT.Tim_Max();
			foreach (var item in DS_Hinh_DT.List)
				if (item.value == max)
					kq.Add(item.key);
			return kq;
		}

		/// <summary>
		/// Tìm hình có diện tích nhỏ nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<object> Tim_Hinh_S_Min()
		{
			List<object> kq = new List<object>();
			if (DS_Hinh_DT.Dem == 0)
				Gop_3_DS_DienTich();
			float min = DS_Hinh_DT.Tim_Min();
			foreach (var item in DS_Hinh_DT.List)
				if (item.value == min)
					kq.Add(item.key);
			return kq;
		}

		/// <summary>
		/// Tìm hình có chu vi lớn nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<object> Tim_Hinh_C_Max()
		{
			List<object> kq = new List<object>();
			if (DS_Hinh_CV.Dem == 0)
				Gop_3_DS_ChuVi();
			float max = DS_Hinh_CV.Tim_Max();
			foreach (var item in DS_Hinh_CV.List)
				if (item.value == max)
					kq.Add(item.key);
			return kq;
		}


		/// <summary>
		/// Tìm hình có chu vi nhỏ nhất
		/// </summary>
		/// <returns>Một danh sách</returns>
		public List<object> Tim_Hinh_C_Min()
		{
			List<object> kq = new List<object>();
			if (DS_Hinh_CV.Dem == 0)
				Gop_3_DS_ChuVi();
			float min = DS_Hinh_CV.Tim_Min();
			foreach (var item in DS_Hinh_CV.List)
				if (item.value == min)
					kq.Add(item.key);
			return kq;
		}

		/// <summary>
		/// Hiển thị danh sách hình theo chiều tăng diện tích
		/// </summary>
		public void HienThi_Hinh_S_Tang()
		{
			if (DS_Hinh_DT.Dem == 0)
				Gop_3_DS_DienTich();
			for (int i = 0; i < DS_Hinh_DT.Dem - 1; i++)
				for (int j = i + 1; j < DS_Hinh_DT.Dem; j++)
					if (DS_Hinh_DT[j].value < DS_Hinh_DT[i].value)
						Swap<KeyValuePair>(DS_Hinh_DT.List, i, j);
			foreach (var item in DS_Hinh_DT.List)
				Console.WriteLine(item);
		}

		/// <summary>
		/// Hiển thị danh sách hình theo chiều giảm diện tích
		/// </summary>
		public void HienThi_Hinh_S_Giam()
		{
			if (DS_Hinh_DT.Dem == 0)
				Gop_3_DS_DienTich();
			for (int i = 0; i < DS_Hinh_DT.Dem - 1; i++)
				for (int j = i + 1; j < DS_Hinh_DT.Dem; j++)
					if (DS_Hinh_DT[j].value > DS_Hinh_DT[i].value)
						Swap<KeyValuePair>(DS_Hinh_DT.List, i, j);
			foreach (var item in DS_Hinh_DT.List)
				Console.WriteLine(item);
		}

		/// <summary>
		/// Hiển thị danh sách hình theo chiều tăng chu vi
		/// </summary>
		public void HienThi_Hinh_C_Tang()
		{
			if (DS_Hinh_CV.Dem == 0)
				Gop_3_DS_ChuVi();
			for (int i = 0; i < DS_Hinh_CV.Dem - 1; i++)
				for (int j = i + 1; j < DS_Hinh_CV.Dem; j++)
					if (DS_Hinh_CV[j].value < DS_Hinh_CV[i].value)
						Swap<KeyValuePair>(DS_Hinh_CV.List, i, j);
			foreach (var item in DS_Hinh_CV.List)
				Console.WriteLine(item);
		}

		/// <summary>
		/// Hiển thị danh sách hình theo chiều giảm chu vi
		/// </summary>
		public void HienThi_Hinh_C_Giam()
		{
			if (DS_Hinh_CV.Dem == 0)
				Gop_3_DS_ChuVi();
			for (int i = 0; i < DS_Hinh_CV.Dem - 1; i++)
				for (int j = i + 1; j < DS_Hinh_CV.Dem; j++)
					if (DS_Hinh_CV[j].value > DS_Hinh_CV[i].value)
						Swap<KeyValuePair>(DS_Hinh_CV.List, i, j);
			foreach (var item in DS_Hinh_CV.List)
				Console.WriteLine(item);
		}

		/// <summary>
		/// Xóa một phần tử a ra khỏi 1 trong ba danh sách
		/// </summary>
		/// <param name="a">Phần tử cần xóa</param>
		public void Xoa(object a)
		{
			Type t = a.GetType();
			if (t.Equals(typeof(HinhVuong)))
				DS_HV.Xoa((HinhVuong)a);
			else if (t.Equals(typeof(HinhTron)))
				DS_HT.Xoa((HinhTron)a);
			else DS_HCN.Xoa((HinhChuNhat)a);
		}

		/// <summary>
		/// Xóa hình có diện tích lớn nhất
		/// </summary>
		public void Xoa_Hinh_S_Max()
		{
			List<object> DS = Tim_Hinh_S_Max();
			foreach (var item in DS)
				Xoa(item);
		}

		/// <summary>
		/// Xóa hình có diện tích nhỏ nhất
		/// </summary>
		public void Xoa_Hinh_S_Min()
		{
			List<object> DS = Tim_Hinh_S_Min();
			foreach (var item in DS)
				Xoa(item);
		}

		/// <summary>
		/// Xóa hình có chu vi lớn nhất
		/// </summary>
		public void Xoa_Hinh_C_Max()
		{
			List<object> DS = Tim_Hinh_C_Max();
			foreach (var item in DS)
				Xoa(item);
		}

		/// <summary>
		/// Xóa hình có chu vi nhỏ nhất
		/// </summary>
		public void Xoa_Hinh_C_Min()
		{
			List<object> DS = Tim_Hinh_C_Min();
			foreach (var item in DS)
				Xoa(item);
		}
	}
}
