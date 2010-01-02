using System;
using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net.functions
{
	internal delegate ReturnValues C_DecryptFinal(
		uint hSession,
		byte[] pLastPart,
		ref uint pulLastPartLen
	);

	internal delegate ReturnValues C_DecryptUpdate(
		uint hSession,
		byte[] pEncryptedPart,
		uint ulEncryptedPartLen,
		byte[] pPart,
		ref uint pulPartLen
	);

	internal delegate ReturnValues C_Decrypt(
		uint hSession,
		byte[] pEncryptedData,
		uint ulEncryptedDataLen,
		byte[] pData,
		ref uint pulDataLen
	);

	internal delegate ReturnValues C_DecryptInit(
		uint hSession,
		ref CK_MECHANISM pMechanism,
		uint hKey
	);
}
