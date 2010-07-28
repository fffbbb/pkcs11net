
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of CertificateTypeAttribute.
	/// </summary>
	public class CertificateTypeAttribute:UIntAttribute
	{
		public CertificateTypeAttribute():base((uint)CKA.CERTIFICATE_TYPE)
		{
		}
		
		public CertificateTypeAttribute(CK_ATTRIBUTE ckAttr):base(ckAttr)
		{
		}		
		
		public CKC CertificateType {
			get { return (CKC)base.Value; }
			set { base.Value= (uint)value;
			IsPresent=true;
			}
		}
		
		public override string ToString()
		{
			return CertificateType.ToString();
		}
	}
}
