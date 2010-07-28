
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11.Params
{
	/// <summary>
	/// Description of Parameters.
	/// </summary>
	public class Parameters
	{
		
		public void setParams(CK_MECHANISM ckMechanism){
			ckMechanism.pParameter=IntPtr.Zero;
			ckMechanism.ulParameterLen=0;
		}
	}
}
