
using System;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of SecretKey.
	/// </summary>
	public class SecretKey:Key
	{
		public SecretKey()
		{
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return null;
		}
	}
}
