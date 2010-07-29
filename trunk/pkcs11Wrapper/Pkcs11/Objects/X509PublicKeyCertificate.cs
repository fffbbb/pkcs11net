﻿
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
		
		public ByteArrayAttribute Subject {
			get { return subject_; }
		}
		protected ByteArrayAttribute id_;
		
		public ByteArrayAttribute Id {
			get { return id_; }
		}
		protected ByteArrayAttribute issuer_;
		
		public ByteArrayAttribute Issuer {
			get { return issuer_; }
		}
		protected ByteArrayAttribute serialNumber_;
		
		public ByteArrayAttribute SerialNumber {
			get { return serialNumber_; }
		}
		protected ByteArrayAttribute value_;
		
		public ByteArrayAttribute Value {
			get { return value_; }
		}
		
		
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
		
		public override void ReadAttributes(Session session)
		{
			base.ReadAttributes(session);
			
			subject_= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.SUBJECT));

			id_= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.ID));
			
			issuer_= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.ISSUER));
			
			serialNumber_= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.SERIAL_NUMBER));
			
			value_= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.VALUE));
		}
		
	}
}
