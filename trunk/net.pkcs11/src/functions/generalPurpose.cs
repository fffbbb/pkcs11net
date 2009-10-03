using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	internal delegate CK_RV C_Initialize(
		IntPtr pInitArgs
	);
	
	internal delegate CK_RV C_Finalize(
		IntPtr pReserved
	);
	
	internal delegate CK_RV C_GetInfo(
		ref CK_INFO pInfo
	);
	
	internal delegate CK_RV C_GetFunctionList(
		IntPtr ppFunctionList 
	);
}
