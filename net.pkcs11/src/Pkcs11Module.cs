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
		
		
	}
}