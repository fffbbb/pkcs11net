
using System;

namespace net.pkcs11
{

	public enum UserTypes:uint
	{
		SO = ManifestConstants.CKU_SO,
		USER = ManifestConstants.CKU_USER,
		CONTEXT_SPECIFIC =ManifestConstants.CKU_CONTEXT_SPECIFIC
	}
}
