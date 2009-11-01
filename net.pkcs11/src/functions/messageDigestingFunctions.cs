using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{
	internal delegate ReturnValues C_DigestInit(
		uint hSession,
		ref CK_MECHANISM pMechanism
	);

	internal delegate ReturnValues C_Digest(
		uint hSession,
		byte[] pData,
		uint ulDataLen,
		byte[] pDigest,
		ref uint pulDigestLen
	);

	internal delegate ReturnValues C_DigestUpdate(
		uint hSession,
		byte[] pPart,
		uint ulPartLen
	);

	internal delegate ReturnValues C_DigestKey(
		uint hSession,
		uint hKey
	);

	internal delegate ReturnValues C_DigestFinal(
		uint hSession,
		byte[] pDigest,
		ref uint pulDigestLen
	);
}
