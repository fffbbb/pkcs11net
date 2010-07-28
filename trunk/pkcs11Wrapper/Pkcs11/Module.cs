
using System;
using System.Collections;
using System.Collections.Generic;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11
{
	/// <summary>
	/// Description of Module.
	/// </summary>
	public class Module
	{
		Pkcs11.Wrapper.Pkcs11Module p11Module;
		
		internal Pkcs11Module P11Module {
			get { return p11Module; }
		}
		protected Module(Pkcs11Module p11Module)
		{
			this.p11Module=p11Module;
		}
				
		public static Module GetInstance(String moduleName)
		{
			if(moduleName == null)
			{
				throw new Exception("Argument \"pkcs11ModuleName\" must not be null.");
			} else
			{
				Pkcs11.Wrapper.Pkcs11Module pm=Pkcs11.Wrapper.Pkcs11Module.GetInstance(moduleName);
				
				return new Module(pm);
			}
		}
		
		public void Finalize_(){
			p11Module.Finalize_();
		}
		
		public Info GetInfo()
		{
			CK_INFO localCK_INFO = this.p11Module.GetInfo();

			return new Info(localCK_INFO);
		}
		
		public void Initialize(){
			p11Module.Initialize();
		}
		
		public Slot[] GetSlotList(bool onlyTokenPresent){
			List<Slot> l= new List<Slot>();
			List<uint> csis= p11Module.GetSlotList(onlyTokenPresent);
			
			for(int i=0;i<csis.Count;i++){
				l.Add( new Slot(this, csis[i]) );
			}
			return l.ToArray();
		}
		
		
	}
}
