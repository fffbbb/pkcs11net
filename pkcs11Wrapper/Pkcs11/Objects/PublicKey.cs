
using System;
using  Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of PublicKey.
	/// </summary>
	public class PublicKey:Key
	{
		public PublicKey()
		{
		}
		public PublicKey(Session session, uint hObj):base(session,hObj)
		{
			
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			
			KeyTypeAttribute keyType = ReadAttribute(session , hObj, new KeyTypeAttribute());
			
			switch (keyType.KeyType){
				case CKK.RSA:
					return RSAPublicKey.GetInstance(session,hObj);
				default:
					return null;
			}
			
		}
	}
}
