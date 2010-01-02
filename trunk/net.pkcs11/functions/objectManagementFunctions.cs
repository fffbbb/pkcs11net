using System;
using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net.functions
{

	internal delegate ReturnValues C_FindObjectsFinal(
		uint hSession
	);
	
	internal delegate ReturnValues C_FindObjects(
		uint hSession,
		uint[] phObject,
		uint ulMaxObjectCount,
		ref uint pulObjectCount
	);
	
	internal delegate ReturnValues C_FindObjectsInit(
		uint hSession,
		CK_ATTRIBUTE[] pTemplate,
		uint ulCount
	);
	
	internal delegate ReturnValues C_SetAttributeValue(
		uint hSession,
		uint hObject,
		CK_ATTRIBUTE[] pTemplate,
		uint ulCount
	);
	
	internal delegate ReturnValues C_GetAttributeValue(
		uint hSession,
		uint hObject,
		CK_ATTRIBUTE[] pTemplate,
		uint ulCount
	);
	
	internal delegate ReturnValues C_GetObjectSize(
		uint hSession,
		uint hObject,
		ref uint pulSize
	);

	internal delegate ReturnValues C_DestroyObject(
		uint hSession,
		uint hObject
	);
	
	internal delegate ReturnValues C_CopyObject(
		uint hSession,
		uint hObject,
		CK_ATTRIBUTE[] hTemplate,
		uint ulCount,
		ref uint phNewObject
	);
	
	internal delegate ReturnValues C_CreateObject(
		uint hSession,
		CK_ATTRIBUTE[] pTemplate,
		uint ulCount,
		ref uint phObject
	);
}
