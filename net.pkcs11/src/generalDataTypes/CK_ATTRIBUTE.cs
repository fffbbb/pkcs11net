
using System;
using System.Runtime.InteropServices;
namespace net.pkcs11.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_ATTRIBUTE{
		
		public uint type;

		public IntPtr pValue;

		public uint ulValueLen;
	}
}
