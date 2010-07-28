
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of RSAPublicKey.
	/// </summary>
	public class RSAPublicKey:PublicKey
	{
		
		protected ByteArrayAttribute modulus_;
		protected ByteArrayAttribute publicExponent_;
		protected UIntAttribute modulusBits_;
		
		public RSAPublicKey()
		{
		}
		
		public RSAPublicKey(Session session, uint hObj):base(session,hObj)
		{
			
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return new RSAPublicKey(session,hObj) ;
		}
		
		public override void readAttributes(Session session)
		{
			base.readAttributes(session);
			
			modulus_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.MODULUS))
			);

			publicExponent_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.PUBLIC_EXPONENT))
			);
			
			modulusBits_=new UIntAttribute(
				getAttribute(session,HObj,new UIntAttribute((uint)CKA.MODULUS_BITS))
			);
		}
	}
}
