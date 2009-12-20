using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{
	internal delegate ReturnValues C_EncryptFinal(
		uint hSession,
		byte[] pLastEncryptedPart,
		ref uint pulLastEncryptedPartLen
	);

	internal delegate ReturnValues C_EncryptUpdate(
		uint hSession,
		byte[] pPart,
		uint ulPartLen,
		byte[] pEncryptedPart,
		ref uint pulEncryptedPartLen
	);

	internal delegate ReturnValues C_Encrypt(
		uint hSession,
		byte[] pData,
		uint ulDataLen,
		byte[] pEncryptedData,
		ref uint pulEncryptedDataLen
	);

	internal delegate ReturnValues C_EncryptInit(
		uint hSession,
		ref CK_MECHANISM pMechanism,
		uint hKey
	);
}

