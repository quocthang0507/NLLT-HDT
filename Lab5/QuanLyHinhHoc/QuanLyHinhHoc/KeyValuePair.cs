using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHinhHoc
{
	class KeyValuePair
	{
		public float value;
		public object key;

		public KeyValuePair()
		{

		}

		public KeyValuePair(object k, float v)
		{
			key = k;
			value = v;
		}

		public override string ToString()
		{
			return key.ToString();
		}
	}
	class MyList
	{
		public List<KeyValuePair> List = new List<KeyValuePair>();

		public void Them(KeyValuePair a)
		{
			List.Add(a);
		}

		public float Tim_Min()
		{
			float min = float.MaxValue;
			foreach (var item in List)
				if (item.value < min)
					min = item.value;
			return min;
		}

		public float Tim_Max()
		{
			float max = float.MinValue;
			foreach (var item in List)
				if (item.value > max)
					max = item.value;
			return max;
		}

		public override string ToString()
		{
			string s = "";
			foreach (var item in List)
				s += item;
			return s;
		}

		public int Dem
		{
			get { return List.Count; }
		}

		public KeyValuePair this[int index]
		{
			get { return List[index]; }
		}
	}
}
