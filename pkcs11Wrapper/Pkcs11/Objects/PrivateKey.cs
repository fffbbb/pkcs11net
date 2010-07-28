
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of PrivateKey.
	/// </summary>
	public class PrivateKey:Key
	{
		public PrivateKey()
		{
		}
		
		public PrivateKey(Session session, uint hObj):base(session,hObj){
			
		}		
			
			
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			
			KeyTypeAttribute keyAttr =new KeyTypeAttribute(
				getAttribute(session , hObj, new KeyTypeAttribute())
			);
			
			switch(keyAttr.KeyType){
				case CKK.RSA:
					return RSAPrivateKey.GetInstance(session,hObj);
				default: 
					return null;
			}
			
			
		}
	}
}
