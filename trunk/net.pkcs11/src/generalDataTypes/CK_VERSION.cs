/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 14:58
 * 
 */
using System.Runtime.InteropServices;

namespace net.pkcs11.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_VERSION
	{		
        public byte major;
        public byte minor;		
	}
}
