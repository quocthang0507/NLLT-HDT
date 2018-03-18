using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa
{
	class ThueBao
	{
		public string CMND;
		public string soDT;
		public DateTime ngayDK;
		public ThueBao()
		{

		}

		public ThueBao(string CMND, string soDT, string ngayDK)
		{
			this.CMND = CMND;
			this.soDT = soDT;
			this.ngayDK = DateTime.Parse(ngayDK);
		}

		public override string ToString()
		{
			string s = "{0}\t{1}\t{2}";
			return string.Format(s, CMND, soDT, ngayDK);
		}
	}
}
