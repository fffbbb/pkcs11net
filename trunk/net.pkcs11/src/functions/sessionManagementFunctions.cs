using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	internal delegate ReturnValues C_OpenSession(
		uint slotID,
		uint flags,
		ref uint pApplication,
		IntPtr Notify,
		ref uint phSession
	);

	internal delegate ReturnValues C_CloseSession(
		uint hSession
	);

	internal delegate ReturnValues C_CloseAllSessions(
		uint slotID
	);

	internal delegate ReturnValues C_GetSessionInfo(
		uint hSession,
		ref CK_SESSION_INFO pInfo
	);

	internal delegate ReturnValues C_GetOperationState(
		uint hSession,
		byte[] pOperationState,
		uint pulOperationStateLen
	);

	internal delegate ReturnValues C_SetOperationState(
		uint hSession,
		byte[] pOperationState,
		uint ulOperationStateLen,
		uint hEncryptionKey,
		uint hAuthenticationKey
	);

	internal delegate ReturnValues C_Login(
		uint hSession,
		uint userType,
		byte[] pPin,
		uint ulPinLen
	);

	internal delegate ReturnValues C_Logout(
		uint hSession
	);

}

