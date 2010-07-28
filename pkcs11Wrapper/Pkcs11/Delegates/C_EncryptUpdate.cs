﻿
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Delegates
{
	internal delegate CKR C_EncryptUpdate(
		uint hSession,
		byte[] pPart,
		uint ulPartLen,
		byte[] pEncryptedPart,
		ref uint pulEncryptedPartLen
	);
}
