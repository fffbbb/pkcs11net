﻿using System;
using net.sf.pkcs11net.functions;
using net.sf.pkcs11net.generalDataTypes;
using System.Collections.Generic;
namespace net.sf.pkcs11net
{
	/// <summary>
	/// Description of Cryptoki.
	/// </summary>
	public class Pkcs11Module
	{
		/// <summary>
		/// 
		/// </summary>
		private IntPtr hLib;
		
		/// <summary>
		/// 
		/// </summary>
		internal IntPtr HLib {
			get{
				return hLib;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hLib"></param>
		private Pkcs11Module(IntPtr hLib){
			this.hLib=	hLib;
		}
		
		/// <summary>
		/// Creates an instance of Pkcs11Module
		/// </summary>
		/// <param name="moduleName">
		/// module to be loaded. it is the path of pkcs11 driver
		/// <example>
		/// <code>
		/// Pkcs11Module pm=Pkcs11Module.GetInstance("gclib.dll");
		/// </code>
		/// </example>
		/// </param>
		/// <returns></returns>
		public static Pkcs11Module GetInstance(string moduleName){
			IntPtr hLib;
			if ((hLib = KernelUtil.LoadLibrary(moduleName)) == IntPtr.Zero)
				throw new Exception("Could not load module. Module name:" + moduleName);
			return new Pkcs11Module(hLib);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void Initialize(){
			C_Initialize proc=(C_Initialize)DelegateUtil.getDelegate(this.HLib,typeof(C_Initialize));
			Validator.ValidateCK_RV( proc(IntPtr.Zero));
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void Finalize_(){
			C_Finalize proc=(C_Finalize)DelegateUtil.getDelegate(this.HLib,typeof(C_Finalize));
			Validator.ValidateCK_RV( proc(IntPtr.Zero));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public CK_INFO GetInfo()
		{
			C_GetInfo proc=(C_GetInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetInfo));
			
			CK_INFO ckInfo=new CK_INFO();
			Validator.ValidateCK_RV( proc(ref ckInfo));
			
			return ckInfo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="tokenPresent"></param>
		/// <returns></returns>
		public List<uint> GetSlotList(bool tokenPresent){
			
			C_GetSlotList proc=(C_GetSlotList)DelegateUtil.getDelegate(this.HLib,typeof(C_GetSlotList));
			
			uint pullVal=0;
			Validator.ValidateCK_RV( proc(tokenPresent,null,ref pullVal));
			
			uint[] slots = new uint[pullVal];
			Validator.ValidateCK_RV( proc(tokenPresent,slots,ref pullVal));
			
			return new List<uint>(slots);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotID"></param>
		/// <returns></returns>
		public CK_SLOT_INFO GetSlotInfo(uint slotID){
			
			C_GetSlotInfo proc=(C_GetSlotInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetSlotInfo));
			
			CK_SLOT_INFO slotInfo=new CK_SLOT_INFO();
			Validator.ValidateCK_RV( proc(slotID, ref slotInfo));
			
			return slotInfo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotID"></param>
		/// <returns></returns>
		public CK_TOKEN_INFO GetTokenInfo(uint slotID){
			
			C_GetTokenInfo proc=(C_GetTokenInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetTokenInfo));
			
			CK_TOKEN_INFO tokenInfo=new CK_TOKEN_INFO();
			Validator.ValidateCK_RV( proc(slotID, ref tokenInfo));
			
			return tokenInfo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		public uint WaitForSlotEvent(params WaitForSlotEventOptions[] options){
			
			C_WaitForSlotEvent proc=(C_WaitForSlotEvent)DelegateUtil.getDelegate(this.HLib,typeof(C_WaitForSlotEvent));
			
			uint slotId=0, flags=0;
			
			foreach(WaitForSlotEventOptions opt in options) flags |= (uint) opt;
			
			Validator.ValidateCK_RV(proc(flags, ref slotId, IntPtr.Zero));
			
			return slotId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotId"></param>
		/// <returns></returns>
		public List<MechanismTypes> GetMechanismList(uint slotId){
			
			C_GetMechanismList proc=(C_GetMechanismList)DelegateUtil.getDelegate(this.HLib,typeof(C_GetMechanismList));
			
			uint pulCount=0;
			Validator.ValidateCK_RV( proc(slotId,null,ref pulCount));
			
			MechanismTypes[] mechanismList = new MechanismTypes[pulCount];
			
			Validator.ValidateCK_RV( proc(slotId, mechanismList,ref pulCount));
			
			return  new List<MechanismTypes>(mechanismList);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotId"></param>
		/// <param name="mechanism"></param>
		/// <returns></returns>
		public CK_MECHANISM_INFO GetMechanismInfo(uint slotId, MechanismTypes mechanism){
			
			C_GetMechanismInfo proc=(C_GetMechanismInfo)DelegateUtil.getDelegate(this.hLib,typeof(C_GetMechanismInfo));
			
			CK_MECHANISM_INFO mecInfo=new CK_MECHANISM_INFO();
			
			Validator.ValidateCK_RV(proc(slotId,mechanism,ref mecInfo) );
			
			return mecInfo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotId"></param>
		/// <param name="pin"></param>
		/// <param name="label"></param>
		public void InitToken(uint slotId, string pin, string label){
			
			C_InitToken proc=(C_InitToken)DelegateUtil.getDelegate(this.hLib,typeof(C_InitToken));

			byte[] pinBytes=System.Text.Encoding.UTF8.GetBytes(pin);
			
			byte[] labelBytes=new byte[32];
			new List<byte>(System.Text.Encoding.UTF8.GetBytes(label+new String(' ',32 ))).CopyTo(0,labelBytes,0,32);
			
			Validator.ValidateCK_RV(proc(slotId,pinBytes,(uint)pinBytes.Length,labelBytes));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pin"></param>
		public void InitPIN(uint hSession , string pin){
			
			C_InitPIN proc = (C_InitPIN)DelegateUtil.getDelegate(this.hLib,typeof(C_InitPIN));
			
			byte[] pinBytes=System.Text.Encoding.UTF8.GetBytes(pin);
			
			Validator.ValidateCK_RV(proc(hSession,pinBytes,(uint)pinBytes.Length));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="oldPin"></param>
		/// <param name="newPin"></param>
		public void SetPIN (uint hSession, string oldPin, string newPin){
			
			C_SetPIN proc = (C_SetPIN)DelegateUtil.getDelegate(this.hLib,typeof(C_SetPIN));
			
			byte[] oldPinBytes=System.Text.Encoding.UTF8.GetBytes(oldPin);
			byte[] newPinBytes=System.Text.Encoding.UTF8.GetBytes(newPin);
			
			Validator.ValidateCK_RV(
				proc(hSession,oldPinBytes,(uint)oldPinBytes.Length,newPinBytes,(uint)newPinBytes.Length));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotId"></param>
		/// <param name="applicationId"></param>
		/// <param name="readOnly"></param>
		/// <returns></returns>
		public uint OpenSession(uint slotId, uint applicationId, bool readOnly){
			
			C_OpenSession proc= (C_OpenSession)DelegateUtil.getDelegate(this.hLib,typeof(C_OpenSession));
			
			uint flags=SessionInformationFlags.CKF_SERIAL_SESSION| (readOnly? 0: SessionInformationFlags.CKF_RW_SESSION);
			
			uint hSession=0;
			
			Validator.ValidateCK_RV( proc(slotId,flags, ref applicationId, IntPtr.Zero, ref hSession) );
			
			return hSession;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		public void CloseSession(uint hSession){
			
			C_CloseSession proc= (C_CloseSession)DelegateUtil.getDelegate(this.hLib,typeof(C_CloseSession));
			
			Validator.ValidateCK_RV(proc(hSession));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="slotId"></param>
		public void CloseAllSessions(uint slotId){
			
			C_CloseAllSessions proc= (C_CloseAllSessions)DelegateUtil.getDelegate(this.hLib,typeof(C_CloseAllSessions));
			
			Validator.ValidateCK_RV(proc(slotId));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <returns></returns>
		public CK_SESSION_INFO GetSessionInfo(uint hSession){
			
			C_GetSessionInfo proc= (C_GetSessionInfo)DelegateUtil.getDelegate(this.hLib,typeof(C_GetSessionInfo));

			CK_SESSION_INFO sessionInfo=new CK_SESSION_INFO();
			
			Validator.ValidateCK_RV(proc(hSession, ref sessionInfo));
			
			return sessionInfo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <returns></returns>
		public byte[] GetOperationState(uint hSession){
			
			C_GetOperationState proc= (C_GetOperationState)DelegateUtil.getDelegate(this.hLib,typeof(C_GetOperationState));
			
			uint pLen=0;
			
			Validator.ValidateCK_RV(proc(hSession, null, ref pLen));
			
			byte[] opState=new byte[pLen];
			
			Validator.ValidateCK_RV(proc(hSession, opState, ref pLen));
			
			return opState;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="opState"></param>
		/// <param name="hEncryptionKey"></param>
		/// <param name="hAuthenticationKey"></param>
		public void SetOperationState(uint hSession, byte[] opState, uint hEncryptionKey, uint hAuthenticationKey){
			
			C_SetOperationState proc= (C_SetOperationState)DelegateUtil.getDelegate(this.hLib,typeof(C_SetOperationState));
			
			Validator.ValidateCK_RV ( proc(hSession, opState, (uint)opState.Length, hEncryptionKey, hAuthenticationKey ) );
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="userType"></param>
		/// <param name="pin"></param>
		public void Login(uint hSession, UserTypes userType, string pin){
			
			C_Login proc = (C_Login)DelegateUtil.getDelegate(this.hLib,typeof(C_Login));
			
			byte[] pinBytes=System.Text.Encoding.UTF8.GetBytes(pin);
			
			Validator.ValidateCK_RV(proc(hSession, userType, pinBytes, (uint)pinBytes.Length ));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		public void Logout(uint hSession){
			
			C_Logout proc= (C_Logout)DelegateUtil.getDelegate(this.hLib,typeof(C_Logout));
			
			Validator.ValidateCK_RV(proc(hSession));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="template"></param>
		/// <returns></returns>
		public uint CreateObject(uint hSession, CK_ATTRIBUTE[] template){
			
			C_CreateObject proc= (C_CreateObject)DelegateUtil.getDelegate(this.hLib,typeof(C_CreateObject));
			
			uint hObj=0;
			
			Validator.ValidateCK_RV(proc(hSession,template, (uint)template.Length,ref hObj));
			
			return hObj;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="hObj"></param>
		public void DestroyObject(uint hSession, uint hObj){
			
			C_DestroyObject proc= (C_DestroyObject)DelegateUtil.getDelegate(this.hLib,typeof(C_DestroyObject));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,hObj));
		}
		
		//TODO: implement C_CopyObject
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="hObj"></param>
		/// <returns></returns>
		public uint GetObjectSize(uint hSession, uint hObj){
			
			C_GetObjectSize proc= (C_GetObjectSize)DelegateUtil.getDelegate(this.hLib,typeof(C_GetObjectSize));
			
			uint pulSize=0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,hObj, ref pulSize));
			
			return pulSize;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="hObj"></param>
		/// <param name="template"></param>
		/// <returns></returns>
		public CK_ATTRIBUTE[] GetAttributeValue(uint hSession, uint hObj, CK_ATTRIBUTE[] template ){
			
			C_GetAttributeValue proc= (C_GetAttributeValue)DelegateUtil.getDelegate(this.hLib,typeof(C_GetAttributeValue));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,hObj, template, (uint)template.Length));
			
			return template;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="hObj"></param>
		/// <param name="pTemplate"></param>
		public void SetAttributeValue(uint hSession, uint hObj, CK_ATTRIBUTE[] pTemplate){
			
			C_SetAttributeValue proc= (C_SetAttributeValue)DelegateUtil.getDelegate(this.hLib,typeof(C_SetAttributeValue));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,hObj, pTemplate, (uint)pTemplate.Length));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pTemplate"></param>
		public void FindObjectsInit(uint hSession, CK_ATTRIBUTE[] pTemplate){
			
			C_FindObjectsInit proc= (C_FindObjectsInit)DelegateUtil.getDelegate(this.hLib,typeof(C_FindObjectsInit));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pTemplate, (uint)pTemplate.Length));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="maxCount"></param>
		/// <returns></returns>
		public uint[] FindObjects(uint hSession, uint maxCount){
			
			C_FindObjects proc= (C_FindObjects)DelegateUtil.getDelegate(this.hLib,typeof(C_FindObjects));
			
			uint[] maxObjs=new uint[maxCount];
			
			uint pulCount=0;
			
			/* get the objects */
			Validator.ValidateCK_RV(proc.Invoke(hSession, maxObjs,maxCount, ref pulCount));
			
			if(pulCount==maxCount){
				
				return maxObjs;
				
			}else{/*if the count of the objects is less then maxcount then handle it */
				
				uint[] pulObjs=new uint[pulCount];
				
				Array.Copy(maxObjs,pulObjs,pulObjs.Length);
				
				return pulObjs;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		public void FindObjectsFinal(uint hSession){
			
			C_FindObjectsFinal proc= (C_FindObjectsFinal)DelegateUtil.getDelegate(this.hLib,typeof(C_FindObjectsFinal));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pMechanism"></param>
		/// <param name="hKey"></param>
		public void EncryptInit(uint hSession, CK_MECHANISM pMechanism, uint hKey){
			
			C_EncryptInit proc=(C_EncryptInit)DelegateUtil.getDelegate(this.hLib,typeof(C_EncryptInit));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,ref pMechanism,hKey));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pData"></param>
		/// <returns></returns>
		public byte[] Encrypt(uint hSession, byte[] pData){
			
			C_Encrypt proc=(C_Encrypt)DelegateUtil.getDelegate(this.hLib,typeof(C_Encrypt));
			
			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pData,(uint)pData.Length, null, ref size));
			
			byte[] pEncryptedData=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pData,(uint)pData.Length, pEncryptedData, ref size));
			
			return pEncryptedData;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pPart"></param>
		/// <returns></returns>
		public byte[] EncryptUpdate(uint hSession, byte[] pPart){
			C_EncryptUpdate proc=(C_EncryptUpdate)DelegateUtil.getDelegate(this.hLib,typeof(C_EncryptUpdate));
			
			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pPart,(uint)pPart.Length, null, ref size));
			
			byte[] pEncryptedData=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pPart,(uint)pPart.Length, pEncryptedData, ref size));
			
			return pEncryptedData;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <returns></returns>
		public byte[] EncryptFinal(uint hSession){
			
			C_EncryptFinal proc=(C_EncryptFinal)DelegateUtil.getDelegate(this.hLib,typeof(C_EncryptFinal));
			
			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, null, ref size));
			
			byte[] pEncryptedData=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pEncryptedData, ref size));
			
			return pEncryptedData;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pMechanism"></param>
		/// <param name="hKey"></param>
		public void DecryptInit (uint hSession, CK_MECHANISM pMechanism, uint hKey){
			
			C_DecryptInit proc=(C_DecryptInit)DelegateUtil.getDelegate(this.hLib,typeof(C_DecryptInit));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,ref pMechanism,hKey));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pEncryptedData"></param>
		/// <returns></returns>
		public byte[] Decrypt(uint hSession, byte[] pEncryptedData){
			
			C_Decrypt proc=(C_Decrypt)DelegateUtil.getDelegate(this.hLib,typeof(C_Decrypt));

			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pEncryptedData,(uint)pEncryptedData.Length, null, ref size));
			
			byte[] pData=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pEncryptedData,(uint)pEncryptedData.Length, pData, ref size));
			
			return pData;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pEncryptedPart"></param>
		/// <returns></returns>
		public byte[] DecryptUpdate(uint hSession, byte[] pEncryptedPart){
			
			C_DecryptUpdate proc=(C_DecryptUpdate)DelegateUtil.getDelegate(this.hLib,typeof(C_DecryptUpdate));

			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pEncryptedPart,(uint)pEncryptedPart.Length, null, ref size));
			
			byte[] pPart=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pEncryptedPart,(uint)pEncryptedPart.Length, pPart, ref size));
			
			return pPart;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <returns></returns>
		public byte[] DecryptFinal(uint hSession){
			
			C_DecryptFinal proc=(C_DecryptFinal)DelegateUtil.getDelegate(this.hLib,typeof(C_DecryptFinal));
			
			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, null, ref size));
			
			byte[] pLastPart=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pLastPart, ref size));
			
			return pLastPart;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pMechanism"></param>
		/// <param name="hKey"></param>
		public void DigestInit (uint hSession, CK_MECHANISM pMechanism){
			
			C_DigestInit proc=(C_DigestInit)DelegateUtil.getDelegate(this.hLib,typeof(C_DigestInit));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession,ref pMechanism));
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="pData"></param>
		/// <returns></returns>
		public byte[] Digest(uint hSession, byte[] pData){
			
			C_Digest proc=(C_Digest)DelegateUtil.getDelegate(this.hLib,typeof(C_Digest));

			uint size = 0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pData,(uint)pData.Length, null, ref size));
			
			byte[] pDigest=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pData,(uint)pData.Length, pDigest, ref size));
			
			return pDigest;
		}

		public void DigestUpdate(uint hSession, byte[] pPart){
			
			C_DigestUpdate proc=(C_DigestUpdate)DelegateUtil.getDelegate(this.hLib,typeof(C_DigestUpdate));

			Validator.ValidateCK_RV(proc.Invoke(hSession, pPart,(uint)pPart.Length));
			
			return ;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <param name="hKey"></param>
		public void DigestKey(uint hSession, uint hKey){
			
			C_DigestKey proc=(C_DigestKey)DelegateUtil.getDelegate(this.hLib,typeof(C_DigestKey));
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, hKey));
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hSession"></param>
		/// <returns></returns>
		public byte[] DigestFinal(uint hSession){
			
			C_DigestFinal proc=(C_DigestFinal)DelegateUtil.getDelegate(this.hLib,typeof(C_DigestFinal));
			
			uint size=0;
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, null,ref size));
			
			byte[] pDigest=new byte[size];
			
			Validator.ValidateCK_RV(proc.Invoke(hSession, pDigest,ref size));
			
			return pDigest;
		}
		
		
		
	}
}