using System.Runtime.InteropServices;

namespace net.pkcs11.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CK_MECHANISM
	{
		public uint mechanism;
		
		public IntPtr pParameter;
		
		public uint ulParameterLen;
	}
}
