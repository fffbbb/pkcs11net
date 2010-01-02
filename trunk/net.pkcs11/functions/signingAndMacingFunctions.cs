using System;
using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net.functions
{
	internal delegate ReturnValues C_SignRecoverInit(
		uint hSession,
		ref CK_MECHANISM pMechanism,
		uint hKey
	);
	
	internal delegate ReturnValues C_SignFinal(
		uint hSession,
		byte[] pSignature,
		ref uint pulSignatureLen
	);
	
	
	internal delegate ReturnValues C_SignUpdate(
		uint hSession,
		byte[] pPart,
		uint ulPartLen
	);

	internal delegate ReturnValues C_Sign(
		uint hSession,
		byte[] pData,
		uint ulDataLen,
		byte[] pSignature,
		ref uint pulSignatureLen
	);
	
	internal delegate ReturnValues C_SignInit(
		uint hSession,
		ref CK_MECHANISM pMechanism,
		uint hKey
	);
}
