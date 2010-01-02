using System;
using System.Runtime.InteropServices;

namespace net.sf.pkcs11net.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_MECHANISM
	{
		public uint mechanism;
		
		public IntPtr pParameter;
		
		public uint ulParameterLen;
	}
}
