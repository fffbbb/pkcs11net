
using System;
using System.Collections;
using System.Collections.Generic;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11
{
	/// <summary>
    /// Wrapper around Pkcs11 (high-level).
	/// </summary>
	public class Module
	{
		protected Pkcs11.Wrapper.Pkcs11Module p11Module;

        public Pkcs11Module P11Module
        {
			get { return p11Module; }
		}
		protected Module(Pkcs11Module p11Module)
		{
			this.p11Module=p11Module;
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
			uint[] csis= p11Module.GetSlotList(onlyTokenPresent);
			
			for(int i=0;i<csis.Length;i++){
				l.Add( new Slot(this, csis[i]) );
			}
			return l.ToArray();
		}
		
		
	}
}
