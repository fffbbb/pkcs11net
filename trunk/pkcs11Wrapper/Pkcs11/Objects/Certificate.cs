
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of Certificate.
	/// </summary>
	public class Certificate:Storage
	{
		protected CertificateTypeAttribute certificateType_;
		
		public CertificateTypeAttribute CertificateType {
			get { return certificateType_; }
		}
//		protected BooleanAttribute trusted_;
//		
//		public BooleanAttribute Trusted {
//			get { return trusted_; }
//		}
		
		public Certificate()
		{
		}
		
		public Certificate(Session session, uint hObj):base(session,hObj)
		{
		}
		
		public override void readAttributes(Session session)
		{
			base.readAttributes(session);
			
//			trusted_=new BooleanAttribute(
//				getAttribute(session , HObj, new BooleanAttribute(CKA.TRUSTED))
//			);
			
			certificateType_= new CertificateTypeAttribute(
				getAttribute(session,HObj,new CertificateTypeAttribute())
			);
			
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			if (session == null)
				throw new NullReferenceException("Argument \"session\" must not be null.");
			
			CertificateTypeAttribute classAtr =new CertificateTypeAttribute(
				getAttribute(session , hObj, new CertificateTypeAttribute())
			);
			
			switch(classAtr.CertificateType){
				case CKC.WTLS:
				case CKC.X_509:
					return X509PublicKeyCertificate.GetInstance(session,hObj);
				case CKC.X_509_ATTR_CERT:
				case CKC.VENDOR_DEFINED:
				default:
					break;
					
			}
			
			return null;
		}
	}
}
