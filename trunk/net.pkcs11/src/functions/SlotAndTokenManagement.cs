using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{
	//CK_DEFINE_FUNCTION(CK_RV, C_GetSlotList)(
	//CK_BBOOL tokenPresent,
	//CK_SLOT_ID_PTR pSlotList,
	//CK_ULONG_PTR pulCount
	//);
	internal delegate CK_RV C_GetSlotList(bool tokenPresent, uint[] pSlotList, ref uint pulCount);

	//CK_DEFINE_FUNCTION(CK_RV, C_GetSlotInfo)(
	//CK_SLOT_ID slotID,
	//CK_SLOT_INFO_PTR pInfo
	//);
	internal delegate CK_RV C_GetSlotInfo(uint slotID, ref CK_SLOT_INFO pInfo);
	
	//CK_DEFINE_FUNCTION(CK_RV, C_GetTokenInfo)(
	//CK_SLOT_ID slotID,
	//CK_TOKEN_INFO_PTR pInfo
	//);
	internal delegate CK_RV C_GetTokenInfo(uint slotID, ref CK_TOKEN_INFO pInfo);
}
