
using System;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of Key.
	/// </summary>
	public class Key:Storage
	{
		public Key()
		{
		}
		
		public Key(Session session, uint hObj):base(session,hObj)
		{
			
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return null;
		}
	}
}
