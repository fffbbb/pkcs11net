﻿
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Delegates
{
	internal delegate CKR C_EncryptFinal(
		uint hSession,
		byte[] pLastEncryptedPart,
		ref uint pulLastEncryptedPartLen
	);
}
