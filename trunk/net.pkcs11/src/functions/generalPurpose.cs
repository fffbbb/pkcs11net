using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	internal delegate ReturnValues C_Initialize(
		IntPtr pInitArgs
	);
	
	internal delegate ReturnValues C_Finalize(
		IntPtr pReserved
	);
	
	internal delegate ReturnValues C_GetInfo(
		ref CK_INFO pInfo
	);
	
	internal delegate ReturnValues C_GetFunctionList(
		IntPtr ppFunctionList 
	);
}
