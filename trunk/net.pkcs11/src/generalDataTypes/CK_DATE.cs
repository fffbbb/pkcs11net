
using System;
using System.Runtime.InteropServices;

namespace net.pkcs11.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_DATE
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] year;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] month;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] day;
		
		public DateTime Value{
			get{
				int _year=year[0]*1000+year[1]*100+year[2]*10+year[3];
				int _month=month[0]*10+month[1];
				int _day=day[0]*10+day[1];
				return new DateTime(_year,_month,_day);
			}
		}
	}
}
