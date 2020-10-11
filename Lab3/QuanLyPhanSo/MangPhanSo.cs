using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace QuanLyPhanSo
{
    class MangPhanSo
    {
        public PhanSo[] a = new PhanSo[100];
        public int length = 0;

        /// <summary>
        /// Nhập vào mảng phân số thủ công
        /// </summary>
        public void Nhap()
        {
            Console.WriteLine("Nhap vao chieu dai mang: ");
            length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                a[i] = new PhanSo();
                a[i].Nhap_PhanSo();
            }
        }

        /// <summary>
        /// Hàm chèn phân số x vào cuối mảng
        /// </summary>
        /// <param name="x">Phân số cần chèn</param>
        public void Chen_Cuoi(PhanSo x)
        {
            a[length] = x;
            length++;
        }

        /// <summary>
        /// Hàm nhập phân số vào mảng từ file cho sẵn
        /// </summary>
        public void NhapTuFile()
        {
            string path = @"data.txt";
            StreamReader sr = new StreamReader(path);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] t = s.Split('/');
                int tu = int.Parse(t[0]);
                int mau = int.Parse(t[1]);
                Chen_Cuoi(new PhanSo(tu, mau));
            }
        }

        /// <summary>
        /// Hàm xuất các phần tử trong mảng
        /// </summary>
        public void Xuat()
        {
            RutGon();
            for (int i = 0; i < length; i++)
                Console.Write(a[i].ToString() + "\t");
            Console.WriteLine();
        }

        /// <summary>
        /// Hàm rút gọn tất cả các phân số trong mảng
        /// </summary>
        public void RutGon()
        {
            for (int i = 0; i < length; i++)
                a[i].RutGon();
        }

        /// <summary>
        /// Hàm tìm giá trị lớn nhất có trong mảng
        /// </summary>
        /// <returns>Giá trị lớn nhất</returns>
        public PhanSo Tim_Max()
        {
            PhanSo max = a[0];
            for (int i = 1; i < length; i++)
                //if (SoSanh_2PS(max, a[i]) < 0)
                if (max < a[i])
                    max = a[i];
			//RutGon();
            return max;
        }

        /// <summary>
        /// Hàm tìm giá trị nhỏ nhất có trong mảng
        /// </summary>
        /// <returns>Giá trị nhỏ nhất</returns>
        public PhanSo Tim_Min()
        {
            PhanSo min = a[0];
            for (int i = 1; i < length; i++)
                //if (SoSanh_2PS(min, a[i]) > 0)
                if (min > a[i])
                    min = a[i];
			//RutGon();
            return min;
        }

        /// <summary>
        /// Hàm tính tổng các phân số trong mảng
        /// </summary>
        /// <returns>Tổng</returns>
        public PhanSo Tong()
        {
            PhanSo tong = new PhanSo(0, 1);
            for (int i = 0; i < length; i++)
                tong = tong + a[i];
            return tong;
        }

        /// <summary>
        /// Tìm các phân số âm có trong mảng
        /// </summary>
        /// <returns>Mảng phân số</returns>
        public MangPhanSo MangAm()
        {
            MangPhanSo kq = new MangPhanSo();
            for (int i = 0; i < length; i++)
                if ((float)a[i].tuSo / a[i].mauSo < 0)
                    kq.Chen_Cuoi(a[i]);
            return kq;
        }

        /// <summary>
        /// Tìm các phân số dương có trong mảng
        /// </summary>
        /// <returns>Mảng phân số</returns>
        public MangPhanSo MangDuong()
        {
            MangPhanSo kq = new MangPhanSo();
            for (int i = 0; i < length; i++)
                if ((float)a[i].tuSo / a[i].mauSo > 0)
                    kq.Chen_Cuoi(a[i]);
            return kq;
        }

        /// <summary>
        /// Tìm tất cả các phân số có tử là x
        /// </summary>
        /// <param name="tuSo">Tử số cần tìm</param>
        /// <returns>Mảng phân số</returns>
        public MangPhanSo Tim_TuX(int tuSo)
        {
            MangPhanSo kq = new MangPhanSo();
            for (int i = 0; i < length; i++)
                if (a[i].tuSo == tuSo)
                    kq.Chen_Cuoi(a[i]);
            return kq;
        }

        /// <summary>
        /// Tìm tất cả các phân số có mẫu là x
        /// </summary>
        /// <param name="mauSo">Mẫu số cần tìm</param>
        /// <returns>Mảng phân số</returns>
        public MangPhanSo Tim_MauX(int mauSo)
        {
            MangPhanSo kq = new MangPhanSo();
            for (int i = 0; i < length; i++)
                if (a[i].mauSo == mauSo)
                    kq.Chen_Cuoi(a[i]);
            return kq;
        }

        /// <summary>
        /// Hàm tìm vị trí của phân số x trong mảng
        /// </summary>
        /// <param name="x">Phân số cần tìm</param>
        /// <returns>Mảng vị trí của x</returns>
        public int[] Tim_VTx(PhanSo x)
        {
            List<int> kq = new List<int>();
            for (int i = 0; i < length; i++)
                //if(a[i].tuSo == x.tuSo && a[i].mauSo == x.mauSo)
                if (a[i] == x)
                    kq.Add(i);
            return kq.ToArray();
        }

        /// <summary>
        /// Hàm tìm vị trí của các phân số dương có trong mảng
        /// </summary>
        /// <returns>Mảng vị trí</returns>
        public int[] Tim_VT_Duong()
        {
            List<int> kq = new List<int>();
            for (int i = 0; i < length; i++)
                if ((float)a[i].tuSo / a[i].mauSo > 0)
                    kq.Add(i);
            return kq.ToArray();
        }

        /// <summary>
        /// Hàm tìm vị trí của các phân số âm có trong mảng
        /// </summary>
        /// <returns>Mảng vị trí</returns>
        public int[] Tim_VT_Am()
        {
            List<int> kq = new List<int>();
            for (int i = 0; i < length; i++)
                if (a[i].tuSo < 0 || (float)a[i].tuSo / a[i].mauSo < 0)
                    kq.Add(i);
            return kq.ToArray();
        }

        /// <summary>
        /// Hàm xóa phân số tại vị trí chỉ định
        /// </summary>
        /// <param name="vt">Vị trí cần xóa</param>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_VT(int vt)
        {
            if (vt < 0 || vt > length)
                return false;
            List<PhanSo> kq = a.ToList();
            kq.RemoveAt(vt);
            a = kq.ToArray();
            length--;
            return true;
        }

        /// <summary>
        /// Hàm xóa tất cả các phân số x có trong mảng
        /// </summary>
        /// <param name="x">Phân số cần xóa</param>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_x(PhanSo x)
        {
            int[] kq = Tim_VTx(x);
            if (kq.Length != 0)
            {
                for (int i = kq.Length - 1; i >= 0; i--)
                    Xoa_VT(kq[i]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hàm xóa tất cả các phân số có tử số cho trước
        /// </summary>
        /// <param name="tuSo">Tử số cần xóa</param>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_tuX(int tuSo)
        {
            MangPhanSo kq = Tim_TuX(tuSo);
            if (kq.length == 0)
                return false;
            else
            {
                for (int i = 0; i < kq.length; i++)
                    Xoa_x(kq.a[i]);
                return true;
            }
        }

        /// <summary>
        /// Hàm xóa tất cả các phân số có mẫu số cho trước
        /// </summary>
        /// <param name="mauSo">Mẫu số cần xóa</param>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_mauX(int mauSo)
        {
            MangPhanSo kq = Tim_MauX(mauSo);
            if (kq.length == 0)
                return false;
            else
            {
                for (int i = 0; i < kq.length; i++)
                    Xoa_x(kq.a[i]);
                return true;
            }
        }

        /// <summary>
        /// Hàm xóa các phân số bằng với phân số đầu mảng
        /// </summary>
        public void Xoa_GiongDau()
        {
            int[] kq = Tim_VTx(a[0]);
            for (int i = kq.Length - 1; i >= 0; i--)
                Xoa_VT(kq[i]);
        }

        /// <summary>
        /// Hàm xóa các phân số bằng với phân số cuối mảng
        /// </summary>
        public void Xoa_GiongCuoi()
        {
            int[] kq = Tim_VTx(a[length - 1]);
            for (int i = kq.Length - 1; i >= 0; i--)
                Xoa_VT(kq[i]);
        }

        /// <summary>
        /// Hàm xóa các phân số âm trong mảng
        /// </summary>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_Am()
        {
            MangPhanSo kq = MangAm();
            if (kq.length != 0)
            {
                for (int i = 0; i < kq.length; i++)
                    Xoa_x(kq.a[i]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hàm xóa các phân số dương trong mảng
        /// </summary>
        /// <returns>Thực hiện thành công hay không</returns>
        public bool Xoa_Duong()
        {
            MangPhanSo kq = MangDuong();
            if (kq.length != 0)
            {
                for (int i = 0; i < kq.length; i++)
                    Xoa_x(kq.a[i]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hàm xóa các phân số trong mảng với vị trí cho trước
        /// </summary>
        /// <param name="vt">Mảng vị trí cần xóa</param>
        /// <param name="len">Chiều dài của mảng vt trên</param>
        public void Xoa_MangVT(int[] vt, int len)
        {
            Array.Sort(vt, 0, len);
            for (int i = len - 1; i >= 0; i--)
            {
                if (vt[i] < 0 || vt[i] > length)
                    Console.WriteLine("Khong ton tai vi tri {0} trong mang", vt[i]);
                else
                    Xoa_VT(vt[i]);
            }
        }

        /// <summary>
        /// Hàm chèn phân số tại vị trí cho trước vào mảng
        /// </summary>
        /// <param name="x">Phân số cần chèn</param>
        /// <param name="vt">Vị trí cần chèn</param>
        /// <returns></returns>
        public bool Chen_VT(PhanSo x, int vt)
        {
            if (vt < 0 || vt > length)
                return false;
            List<PhanSo> kq = a.ToList();
            kq.Insert(vt, x);
            a = kq.ToArray();
            length++;
            return true;
        }

        /// <summary>
        /// Hàm so sánh giá trị 2 phân số
        /// </summary>
        /// <param name="a">Phân số đầu tiên</param>
        /// <param name="b">Phân số thứ hai</param>
        /// <returns>Trả về 1 nếu a lớn hơn b, trả về 0 nếu a bằng b, trả về -1 nếu a nhỏ hơn b</returns>
        public int SoSanh_2PS(PhanSo a, PhanSo b)
        {
            float x = (float)a.tuSo / a.mauSo;
            float y = (float)b.tuSo / b.mauSo;
            return x.CompareTo(y);
        }

	/// <summary>
	/// Trả về giá trị của phân số	
	/// </summary>
	/// <param name="a">Phân số</param>
	/// <returns></returns>
	public static float Tinh_GT(PhanSo a)
	{
		return (float)a.tuSo / a.mauSo;
	}

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều tăng
        /// </summary>
        public void SapXep_Tang()
        {
			for (int i = 0; i < length - 1; i++)
				for (int j = i + 1; j < length; j++)
					//if (SoSanh_2PS(a[i], a[j]) > 0)
					if (a[i] > a[j])
					{
						PhanSo t = a[j];
						a[j] = a[i];
						a[i] = t;
					}
			RutGon();
        }

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều tăng mẫu số
        /// </summary>
        public void SapXep_TangMau()
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    if (a[i].mauSo > a[j].mauSo)
                    {
                        PhanSo t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
        }

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều tăng tử số
        /// </summary>
        public void SapXep_TangTu()
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    if (a[i].tuSo > a[j].tuSo)
                    {
                        PhanSo t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
        }

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều giảm
        /// </summary>
        public void SapXep_Giam()
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    //if (SoSanh_2PS(a[i], a[j]) < 0)
                    if (a[i] < a[j])
                    {
                        PhanSo t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
            RutGon();
        }

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều giảm mẫu số
        /// </summary>
        public void SapXep_GiamMau()
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    if (a[i].mauSo < a[j].mauSo)
                    {
                        PhanSo t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
        }

        /// <summary>
        /// Hàm sắp xếp mảng theo chiều giảm tử
        /// </summary>
        public void SapXep_GiamTu()
        {
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    if (a[i].tuSo < a[j].tuSo)
                    {
                        PhanSo t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
        }
    }
}
