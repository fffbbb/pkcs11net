/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 17:48
 * 
 */
using System;
using System.Runtime.InteropServices;

namespace net.pkcs11
{
	/// <summary>
	/// Description of DelegateUtil.
	/// </summary>
	internal static class DelegateUtil
	{
		public static Delegate getDelegate(IntPtr hLib, Type delegateType){
			
			IntPtr p = KernelUtil.GetProcAddress(hLib, delegateType.Name);
			if (p == IntPtr.Zero) { throw new Exception(delegateType.Name + " could not be found"); }
            
			return Marshal.GetDelegateForFunctionPointer(p, delegateType);
		}
	}
}
