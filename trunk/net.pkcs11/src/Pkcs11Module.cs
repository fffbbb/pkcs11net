using System;
using net.pkcs11.functions;
using net.pkcs11.generalDataTypes;
using System.Collections.Generic;
namespace net.pkcs11
{
	/// <summary>
	/// Description of Cryptoki.
	/// </summary>
	public class Pkcs11Module
	{
		private IntPtr hLib;
		
		internal IntPtr HLib {
			get{
				return hLib;
			}
		}
		
		private Pkcs11Module(IntPtr hLib){
			this.hLib=	hLib;
		}
		
		public static Pkcs11Module GetInstance(string moduleName){
			IntPtr hLib;
			if ((hLib = KernelUtil.LoadLibrary(moduleName)) == IntPtr.Zero)
				throw new Exception("Could not load module. Module name:" + moduleName);
			return new Pkcs11Module(hLib);
		}
		
		public void Initialize(){
			C_Initialize proc=(C_Initialize)DelegateUtil.getDelegate(this.HLib,typeof(C_Initialize));
			Validator.ValidateCK_RV( proc(IntPtr.Zero));
		}
		
		public void Finalize_(){
			C_Finalize proc=(C_Finalize)DelegateUtil.getDelegate(this.HLib,typeof(C_Finalize));
			Validator.ValidateCK_RV( proc(IntPtr.Zero));
		}
		
		public CK_INFO GetInfo()
		{
			C_GetInfo proc=(C_GetInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetInfo));
			
			CK_INFO ckInfo=new CK_INFO();
			Validator.ValidateCK_RV( proc(ref ckInfo));
			
			return ckInfo;
		}
		
		public List<uint> GetSlotList(bool tokenPresent){
			
			C_GetSlotList proc=(C_GetSlotList)DelegateUtil.getDelegate(this.HLib,typeof(C_GetSlotList));
			
			uint pullVal=0;
			Validator.ValidateCK_RV( proc(tokenPresent,null,ref pullVal));
			
			uint[] slots = new uint[pullVal];
			Validator.ValidateCK_RV( proc(tokenPresent,slots,ref pullVal));
			
			return new List<uint>(slots);
		}
		
		public CK_SLOT_INFO GetSlotInfo(uint slotID){
			
			C_GetSlotInfo proc=(C_GetSlotInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetSlotInfo));
			
			CK_SLOT_INFO slotInfo=new CK_SLOT_INFO();
			Validator.ValidateCK_RV( proc(slotID, ref slotInfo));
			
			return slotInfo;
		}
		
		public CK_TOKEN_INFO GetTokenInfo(uint slotID){
			
			C_GetTokenInfo proc=(C_GetTokenInfo)DelegateUtil.getDelegate(this.HLib,typeof(C_GetTokenInfo));
			
			CK_TOKEN_INFO tokenInfo=new CK_TOKEN_INFO();
			Validator.ValidateCK_RV( proc(slotID, ref tokenInfo));
			
			return tokenInfo;
		}
		
		
		public uint WaitForSlotEvent(params WaitForSlotEventOptions[] options){
			
			C_WaitForSlotEvent proc=(C_WaitForSlotEvent)DelegateUtil.getDelegate(this.HLib,typeof(C_WaitForSlotEvent));
			
			uint slotId=0, flags=0;
			
			foreach(WaitForSlotEventOptions opt in options) flags |= (uint) opt;
			
			Validator.ValidateCK_RV(proc(flags, ref slotId, IntPtr.Zero));
			
			return slotId;
		}

		public List<MechanismTypes> GetMechanismList(uint slotId){
			
			C_GetMechanismList proc=(C_GetMechanismList)DelegateUtil.getDelegate(this.HLib,typeof(C_GetMechanismList));
			
			uint pulCount=0;
			Validator.ValidateCK_RV( proc(slotId,null,ref pulCount));
			
			MechanismTypes[] mechanismList = new MechanismTypes[pulCount];
			
			Validator.ValidateCK_RV( proc(slotId, mechanismList,ref pulCount));
			
			return  new List<MechanismTypes>(mechanismList);
		}
		
		public CK_MECHANISM_INFO GetMechanismInfo(uint slotId, MechanismTypes mechanism){
			
			C_GetMechanismInfo proc=(C_GetMechanismInfo)DelegateUtil.getDelegate(this.hLib,typeof(C_GetMechanismInfo));
			
			CK_MECHANISM_INFO mecInfo=new CK_MECHANISM_INFO();
			
			Validator.ValidateCK_RV(proc(slotId,mechanism,ref mecInfo) );
			
			return mecInfo;
		}
		
		public void InitToken(uint slotId, string pin, string label){
			
			C_InitToken proc=(C_InitToken)DelegateUtil.getDelegate(this.hLib,typeof(C_InitToken));

			byte[] pinBytes=System.Text.Encoding.UTF8.GetBytes(pin);
			
			byte[] labelBytes=new byte[32];
			new List<byte>(System.Text.Encoding.UTF8.GetBytes(label+new String(' ',32 ))).CopyTo(0,labelBytes,0,32);
			
			Validator.ValidateCK_RV(proc(slotId,pinBytes,(uint)pinBytes.Length,labelBytes));
		}
		
		public void InitPIN(uint hSession , string pin){
			
			C_InitPIN proc = (C_InitPIN)DelegateUtil.getDelegate(this.hLib,typeof(C_InitPIN));
			
			byte[] pinBytes=System.Text.Encoding.UTF8.GetBytes(pin);
			
			Validator.ValidateCK_RV(proc(hSession,pinBytes,(uint)pinBytes.Length));
		}
		
		public void SetPIN (uint hSession, string oldPin, string newPin){
			
			C_SetPIN proc = (C_SetPIN)DelegateUtil.getDelegate(this.hLib,typeof(C_SetPIN));
			
			byte[] oldPinBytes=System.Text.Encoding.UTF8.GetBytes(oldPin);
			byte[] newPinBytes=System.Text.Encoding.UTF8.GetBytes(newPin);
			
			Validator.ValidateCK_RV(
				proc(hSession,oldPinBytes,(uint)oldPinBytes.Length,newPinBytes,(uint)newPinBytes.Length));
		}
		
	}
}