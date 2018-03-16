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

		public ThueBao(string CMND, string soDT, DateTime ngayDK)
		{
			this.CMND = CMND;
			this.soDT = soDT;
			this.ngayDK = ngayDK;
		}

		public override string ToString()
		{
			return CMND + "\t" + soDT + "\t" + ngayDK;
		}
	}
}
