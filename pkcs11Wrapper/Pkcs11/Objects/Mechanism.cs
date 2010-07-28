
using System;
using Net.Sf.Pkcs11.Wrapper;
using Net.Sf.Pkcs11.Params;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of Mechanism.
	/// </summary>
	public class Mechanism
	{
		public Mechanism(CKM ckm)
		{
			this.ckm=ckm;
		}
		
		public Mechanism(CK_MECHANISM ckMechanism){
			this.ckm= (CKM)ckMechanism.mechanism;
			this.parameters=MechanismUtil.GetParameters(ckMechanism);
		}
		
		CKM ckm;
		Parameters parameters;
		
		public Parameters Parameters {
			get { return parameters; }
			set { parameters = value; }
		}

		public CK_MECHANISM CK_MECHANISM{
			get{
				CK_MECHANISM mech= new CK_MECHANISM();
				mech.mechanism=(uint) ckm;
				
				if(parameters==null)parameters=new Parameters();
				parameters.setParams(mech);
				
				return mech;}
		}
	}
}
