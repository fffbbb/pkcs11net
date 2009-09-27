/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 16:16
 * 
 */
using System;
using net.pkcs11.generalDataTypes;
namespace net.pkcs11.functions
{

	//CK_DEFINE_FUNCTION(CK_RV, C_Initialize)(
	//CK_VOID_PTR pInitArgs
	//);
	internal delegate CK_RV C_Initialize(IntPtr pInitArgs);
	
	//CK_DEFINE_FUNCTION(CK_RV, C_Finalize)(
	//CK_VOID_PTR pReserved
	//);
	internal delegate CK_RV C_Finalize(IntPtr pReserved);
	
	//CK_DEFINE_FUNCTION(CK_RV, C_GetInfo)(
	//CK_INFO_PTR pInfo
	//);
	internal delegate CK_RV C_GetInfo(ref CK_INFO pInfo);
	
	//CK_DEFINE_FUNCTION(CK_RV, C_GetFunctionList)(
	//CK_FUNCTION_LIST_PTR_PTR ppFunctionList
	//);
	internal delegate CK_RV C_GetFunctionList(IntPtr ppFunctionList );
}
