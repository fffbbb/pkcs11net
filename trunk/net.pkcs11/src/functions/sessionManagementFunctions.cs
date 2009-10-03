using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	internal delegate CK_RV C_OpenSession(
		uint slotID,
		uint flags,
		ref uint pApplication,
		IntPtr Notify,
		ref uint phSession
	);

	internal delegate CK_RV C_CloseSession(
		uint hSession
	);

	internal delegate CK_RV C_CloseAllSessions(
		uint slotID
	);

	internal delegate CK_RV C_GetSessionInfo(
		uint hSession,
		ref SessionInfo pInfo
	);

	internal delegate CK_RV C_GetOperationState(
		uint hSession,
		byte[] pOperationState,
		uint pulOperationStateLen
	);

	internal delegate CK_RV C_SetOperationState(
		uint hSession,
		byte[] pOperationState,
		uint ulOperationStateLen,
		uint hEncryptionKey,
		uint hAuthenticationKey
	);

	internal delegate CK_RV C_Login(
		uint hSession;
		uint userType,
		byte[] pPin,
		uint ulPinLen;
	);

	internal delegate CK_RV C_Logout(
		uint hSession
	);

}

