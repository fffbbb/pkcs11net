using System.Runtime.InteropServices;

namespace net.sf.pkcs11net.generalDataTypes
{

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_MECHANISM_INFO
	{
		public uint ulMinKeySize;
		
		public uint ulMaxKeySize;
		
		public uint flags;
		
	}
}
