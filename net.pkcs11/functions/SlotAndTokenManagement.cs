using System;
using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net.functions
{

	internal delegate ReturnValues C_GetSlotList(
		bool tokenPresent, 
		uint[] pSlotList, 
		ref uint pulCount
	);

	internal delegate ReturnValues C_GetSlotInfo(
		uint slotID, 
		ref CK_SLOT_INFO pInfo
	);
	
	internal delegate ReturnValues C_GetTokenInfo(
		uint slotID, 
		ref CK_TOKEN_INFO pInfo
	);
	
	internal delegate ReturnValues C_WaitForSlotEvent(
		uint flags,
		ref uint pSlot,
		IntPtr pReserved 
	);
		
	internal delegate ReturnValues C_GetMechanismList(
		uint slotID, 
		MechanismTypes[] pMechanismList,
		ref uint pulCount
	);

	internal delegate ReturnValues C_GetMechanismInfo(
		uint slotID, 
		MechanismTypes type, 
		ref CK_MECHANISM_INFO pInfo
	);

	internal delegate ReturnValues C_InitToken(
		uint slotID, 
		byte[] pPin, 
		uint ulPinLen, 
		byte[] pLabel
	);

	internal delegate ReturnValues C_InitPIN(
		uint hSession, 
		byte[] pPin, 
		uint ulPinLen
	);

	internal delegate ReturnValues C_SetPIN(
		uint hSession, 
		byte[] pOldPin, 
		uint ulOldLen,
		byte[] pNewPin, 
		uint ulNewLen
	);

}
