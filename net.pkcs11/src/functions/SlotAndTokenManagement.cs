using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	internal delegate CK_RV C_GetSlotList(
		bool tokenPresent, 
		uint[] pSlotList, 
		ref uint pulCount
	);

	internal delegate CK_RV C_GetSlotInfo(
		uint slotID, 
		ref CK_SLOT_INFO pInfo
	);
	
	internal delegate CK_RV C_GetTokenInfo(
		uint slotID, 
		ref CK_TOKEN_INFO pInfo
	);

	internal delegate CK_RV C_GetMechanismList(
		uint slotID, 
		uint[] pMechanismList,
		ref uint pulCount
	);

	internal delegate CK_RV C_GetMechanismInfo(
		uint slotID, 
		uint type, 
		ref CK_MECHANISM_INFO pInfo
	);

	internal delegate CK_RV C_InitToken(
		uint slotID, 
		byte[] pPin, 
		uint ulPinLen, 
		byte[] pLabel
	);

	internal delegate CK_RV C_InitPIN(
		uint hSession, 
		byte[] pPin, 
		uint ulPinLen
	);

	internal delegate CK_RV C_SetPIN(
		uint hSession, 
		byte[] pOldPin, 
		uint ulOldLen,
		byte[] pNewPin, 
		uint ulNewLen
	);

}
