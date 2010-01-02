using System;
using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net.functions
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
