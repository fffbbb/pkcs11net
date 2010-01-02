using System;
using System.Runtime.InteropServices;

namespace net.sf.pkcs11net
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
