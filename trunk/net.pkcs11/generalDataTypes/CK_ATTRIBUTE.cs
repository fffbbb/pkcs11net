
using System;
using System.Runtime.InteropServices;
namespace net.sf.pkcs11net.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_ATTRIBUTE{
		
		public uint type;

		public IntPtr pValue;

		public uint ulValueLen;
	}
}
