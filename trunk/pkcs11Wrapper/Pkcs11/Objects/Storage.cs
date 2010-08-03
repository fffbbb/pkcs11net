﻿
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of Storage.
	/// </summary>
	public class Storage:P11Object
	{
		protected BooleanAttribute token_;
		
		public BooleanAttribute Token {
			get { return token_; }
		}
		protected BooleanAttribute private_;
		
		public BooleanAttribute Private {
			get { return private_; }
		}
		protected BooleanAttribute modifiable_;
		
		public BooleanAttribute Modifiable {
			get { return modifiable_; }
		}
		protected CharArrayAttribute label_;
		
		public CharArrayAttribute Label {
			get { return label_; }
		}
		
		public Storage(Session session, uint hObj):base(session,hObj)
		{
		}
		
		public Storage():base(){
			
		}
		
		public override void ReadAttributes(Session session)
		{
			base.ReadAttributes(session);
			
			token_ = ReadAttribute(session , HObj, new BooleanAttribute(CKA.TOKEN));
			
			private_= ReadAttribute(session , HObj, new BooleanAttribute(CKA.PRIVATE));
			
			modifiable_= ReadAttribute(session , HObj, new BooleanAttribute(CKA.MODIFIABLE));
			
			label_=  ReadAttribute(session,HObj,new CharArrayAttribute(CKA.LABEL));
		}
	}
}