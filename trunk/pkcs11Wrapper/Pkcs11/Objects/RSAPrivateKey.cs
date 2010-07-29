
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of RSAPrivateKey.
	/// </summary>
	public class RSAPrivateKey:PrivateKey
	{
		
		ByteArrayAttribute modulus, publicExponent, privateExponent,
		prime1, prime2, exponent1, exponent2, coefficient;
		
		public ByteArrayAttribute Coefficient {
			get { return coefficient; }
		}
		
		public ByteArrayAttribute Exponent2 {
			get { return exponent2; }
		}
		
		public ByteArrayAttribute Exponent1 {
			get { return exponent1; }
		}
		
		public ByteArrayAttribute Prime2 {
			get { return prime2; }
		}
		
		public ByteArrayAttribute Prime1 {
			get { return prime1; }
		}
		
		public ByteArrayAttribute PrivateExponent {
			get { return privateExponent; }
		}
		
		public ByteArrayAttribute PublicExponent {
			get { return publicExponent; }
		}
		
		public ByteArrayAttribute Modulus {
			get { return modulus; }
		}
		
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
		
		public override void ReadAttributes(Session session)
		{
			base.ReadAttributes(session);
			
			modulus= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.MODULUS));
			publicExponent= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.PUBLIC_EXPONENT));
			privateExponent= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.PRIVATE_EXPONENT));
			prime1= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.PRIME_1));
			prime2= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.PRIME_2));
			exponent1= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.EXPONENT_1));
			exponent2= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.EXPONENT_2));
			coefficient= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.COEFFICIENT));
		}
		
	}
}
