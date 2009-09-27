/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 15:51
 * 
 */
using System;
using System.Runtime.InteropServices;
namespace net.pkcs11
{
	/// <summary>
	/// Description of LibraryManager.
	/// </summary>
	internal static class KernelUtil 
	{

		#region KernelCalls
		[DllImport("kernel32")]
		internal extern static IntPtr LoadLibrary(string lpLibFileName);
		
		[DllImport("kernel32")]
		internal extern static bool FreeLibrary(IntPtr hLibModule);
		
		[DllImport("kernel32", CharSet = CharSet.Ansi)]
		internal extern static IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
		#endregion
		
	}
}
