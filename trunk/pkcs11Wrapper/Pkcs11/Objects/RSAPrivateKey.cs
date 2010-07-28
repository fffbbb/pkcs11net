
using System;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of RSAPrivateKey.
	/// </summary>
	public class RSAPrivateKey:PrivateKey
	{
		public RSAPrivateKey()
		{
		}
		
		public RSAPrivateKey(Session session, uint hObj):base(session,hObj)
		{
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return new RSAPrivateKey(session,hObj) ;
		}
	}
}
