/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 15:02
 * 
 */
using System.Runtime.InteropServices;

namespace net.pkcs11.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_SESSION_INFO{ 
		
		public uint slotID;
		
		public uint state;
		
		public uint flags;
		
		public uint ulDeviceError;
	}
}
