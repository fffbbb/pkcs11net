﻿
namespace Net.Sf.Pkcs11.Wrapper
{
	public enum CKO:uint{
		DATA = PKCS11Constants.CKO_DATA ,
        CERTIFICATE = PKCS11Constants.CKO_CERTIFICATE,
        PUBLIC_KEY = PKCS11Constants.CKO_PUBLIC_KEY,
        PRIVATE_KEY = PKCS11Constants.CKO_PRIVATE_KEY,
		SECRET_KEY = PKCS11Constants.CKO_SECRET_KEY ,
        HW_FEATURE = PKCS11Constants.CKO_HW_FEATURE,
        DOMAIN_PARAMETERS = PKCS11Constants.CKO_DOMAIN_PARAMETERS,
        MECHANISM = PKCS11Constants.CKO_MECHANISM,
        VENDOR_DEFINED = PKCS11Constants.CKO_VENDOR_DEFINED
	}

}
