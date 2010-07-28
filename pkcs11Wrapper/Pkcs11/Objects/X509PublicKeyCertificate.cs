
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of X509PublicKeyCertificate.
	/// </summary>
	public class X509PublicKeyCertificate:Certificate
	{
		protected ByteArrayAttribute subject_;
		protected ByteArrayAttribute id_;
		protected ByteArrayAttribute issuer_;
		protected ByteArrayAttribute serialNumber_;
		protected ByteArrayAttribute value_;
		
		
		public X509PublicKeyCertificate()
		{
		}
		
		public X509PublicKeyCertificate(Session session, uint hObj):base(session,hObj)
		{
			
		}
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return new X509PublicKeyCertificate(session,hObj) ;
		}
		
		public override void readAttributes(Session session)
		{
			base.readAttributes(session);
			
			subject_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.SUBJECT))
			);

			id_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.ID))
			);
			
			issuer_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.ISSUER))
			);
			
			serialNumber_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.SERIAL_NUMBER))
			);
			
			value_=new ByteArrayAttribute(
				getAttribute(session,HObj,new ByteArrayAttribute(CKA.VALUE))
			);			
		}
		
	}
}
