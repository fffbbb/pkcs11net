
using System;

namespace net.sf.pkcs11net
{

	public enum UserTypes:uint
	{
		SO = ManifestConstants.CKU_SO,
		USER = ManifestConstants.CKU_USER,
		CONTEXT_SPECIFIC =ManifestConstants.CKU_CONTEXT_SPECIFIC
	}
}
