using System.Runtime.InteropServices;

namespace net.sf.pkcs11net.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_VERSION
	{
		public byte major;
		
		public byte minor;
	}
}
