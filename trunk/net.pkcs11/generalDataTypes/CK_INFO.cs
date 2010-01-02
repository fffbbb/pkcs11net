using System.Runtime.InteropServices;
namespace net.sf.pkcs11net.generalDataTypes
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CK_INFO
	{
        public CK_VERSION cryptokiVersion;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] manufacturerID;

        public uint flags;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] libraryDescription;

        public CK_VERSION libraryVersion;
	}
}
