
using System;
using Net.Sf.Pkcs11.Wrapper;
using Net.Sf.Pkcs11;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of PKCS11Object.
	/// </summary>
	public class P11Object
	{
		uint hObj;
		
		internal uint HObj {
			get { return hObj; }
			set { hObj = value; }
		}
		

		internal P11Object(Session session, uint hObj)
		{
			this.hObj= hObj;
			
			readAttributes(session);
			
		}
		internal P11Object()
		{
			this.hObj= 0;
		}

		public static P11Object GetInstance(Session session, uint hObj)
		{
			if (session == null)
				throw new Exception("Argument \"session\" must not be null.");

			ObjectClassAttribute classAtr =new ObjectClassAttribute(
				getAttribute(session , hObj, new ObjectClassAttribute())
			);
			
			switch(classAtr.ObjectType){
				case CKO.CERTIFICATE:
					return Certificate.GetInstance(session,hObj);
					
				case CKO.DATA:					
					break;
					
				case CKO.DOMAIN_PARAMETERS:					
					break;
					
				case CKO.HW_FEATURE:					
					break;
					
				case CKO.MECHANISM:					
					break;
				
				case CKO.PRIVATE_KEY:
					return PrivateKey.GetInstance(session,hObj);
					
				case CKO.PUBLIC_KEY:
					return PublicKey.GetInstance(session,hObj);
					
				case CKO.SECRET_KEY:					
					break;
					
					
				case CKO.VENDOR_DEFINED :					
					break;
					
				default:
					break;
			}
			
			return null;
		}
		
		protected static CK_ATTRIBUTE getAttribute(Session session , uint hObj, P11Attribute attr)
		{
			uint hSession=session.HSession;
			Wrapper.Pkcs11Module pm= session.Module.P11Module;
			
			return pm.GetAttributeValue(hSession, hObj, new CK_ATTRIBUTE[]{attr.toCK()})[0];
			
		}
		
		public virtual void readAttributes(Session session)
		{
			if (session == null)
				throw new NullReferenceException("Argument \"session\" must not be null.");
		}

	}
}
