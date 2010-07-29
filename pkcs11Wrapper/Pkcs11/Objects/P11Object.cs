
using System;
using Net.Sf.Pkcs11.Wrapper;
using Net.Sf.Pkcs11;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of PKCS11Object.
	/// </summary>
	public class P11Object
	{
		uint hObj;
		
		internal uint HObj {
			get { return hObj; }
			set { hObj = value; }
		}
		

		internal P11Object(Session session, uint hObj)
		{
			this.hObj= hObj;
			
			ReadAttributes(session);
			
		}
		internal P11Object()
		{
			this.hObj= 0;
		}

		public static P11Object GetInstance(Session session, uint hObj)
		{
			if (session == null)
				throw new Exception("Argument \"session\" must not be null.");

			ObjectClassAttribute classAtr =(ObjectClassAttribute)
				AssignAttributeFromObj(session , hObj, new ObjectClassAttribute());
			
			switch(classAtr.ObjectType){
				case CKO.CERTIFICATE:
					return Certificate.GetInstance(session,hObj);
					
				case CKO.DATA:
					break;
					
				case CKO.DOMAIN_PARAMETERS:
					break;
					
				case CKO.HW_FEATURE:
					break;
					
				case CKO.MECHANISM:
					break;
					
				case CKO.PRIVATE_KEY:
					return PrivateKey.GetInstance(session,hObj);
					
				case CKO.PUBLIC_KEY:
					return PublicKey.GetInstance(session,hObj);
					
				case CKO.SECRET_KEY:
					break;
					
					
				case CKO.VENDOR_DEFINED :
					break;
					
				default:
					break;
			}
			
			return null;
		}
		
		
		protected static P11Attribute AssignAttributeFromObj(Session session , uint hObj, P11Attribute attr)
		{
			uint hSession=session.HSession;
			Wrapper.Pkcs11Module pm= session.Module.P11Module;
			try{
				return attr.Load( pm.GetAttributeValue(hSession, hObj, new CK_ATTRIBUTE[]{attr.CK_ATTRIBUTE})[0]);
			}catch{//TODO:sadece attribute not found handle et
				return null;
			}
		}
		
		public static BooleanAttribute ReadAttribute(Session session, uint hObj, BooleanAttribute attr){
			
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new BooleanAttribute(ck.Value);
		}
		
		
		
		public static ByteArrayAttribute ReadAttribute(Session session, uint hObj, ByteArrayAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new ByteArrayAttribute(ck.Value);
		}
		
		
		
		public static CertificateTypeAttribute ReadAttribute(Session session, uint hObj, CertificateTypeAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new CertificateTypeAttribute(ck.Value);
		}
		
		
		
		public static CharArrayAttribute ReadAttribute(Session session, uint hObj, CharArrayAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new CharArrayAttribute(ck.Value);
		}
		
		
		
		public static DateAttribute ReadAttribute(Session session, uint hObj, DateAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new DateAttribute(ck.Value);
		}
		
		
		
		public static KeyTypeAttribute ReadAttribute(Session session, uint hObj, KeyTypeAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new KeyTypeAttribute(ck.Value);
		}
		
		
		
		public static MechanismTypeAttribute ReadAttribute(Session session, uint hObj, MechanismTypeAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new MechanismTypeAttribute(ck.Value);
		}
		
		
		
		public static ObjectClassAttribute ReadAttribute(Session session, uint hObj, ObjectClassAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new ObjectClassAttribute(ck.Value);
		}
		
		
		
		public static UIntAttribute ReadAttribute(Session session, uint hObj, UIntAttribute attr){
			CK_ATTRIBUTE? ck;
			if( null == (ck = GetCkAttribute(session,hObj,attr))  )
				return  null;
			else
				return new UIntAttribute(ck.Value);
		}
		
		
		public virtual void ReadAttributes(Session session)
		{
			if (session == null)
				throw new NullReferenceException("Argument \"session\" must not be null.");
		}

		public static CK_ATTRIBUTE? GetCkAttribute(Session session , uint hObj, P11Attribute attr)
		{
			try{
				uint hSession=session.HSession;
				Wrapper.Pkcs11Module pm= session.Module.P11Module;
				
				CK_ATTRIBUTE tmp = pm.GetAttributeValue(hSession, hObj, new CK_ATTRIBUTE[]{attr.CK_ATTRIBUTE})[0];
				
				if(tmp.ulValueLen==0)
					return null;
				
				return tmp;
				
			}catch(TokenException tex) {
				if(tex.ErrorCode== CKR.ATTRIBUTE_TYPE_INVALID
				   || tex.ErrorCode== CKR.ATTRIBUTE_VALUE_INVALID
				   || tex.ErrorCode== CKR.ATTRIBUTE_SENSITIVE
				  )
					
					return null;
				else throw tex;
			}
		}
	}
}
