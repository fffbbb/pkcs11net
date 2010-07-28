using System;
using Net.Sf.Pkcs11.Wrapper;
using System.Runtime.InteropServices;

namespace Net.Sf.Pkcs11.Objects
{
	public abstract class P11Attribute
	{
		bool isPresent;

		protected CK_ATTRIBUTE attr=new CK_ATTRIBUTE();
		
		internal uint Type {
			 get { return attr.type; }
			 private set {attr.type=value;}
		}
		
		public bool IsPresent {
			get { return isPresent; }
			protected set { isPresent = value; }
		}
		
		protected void assignValue( byte[] val ){
			attr.ulValueLen=(uint)val.Length;
			attr.pValue=Marshal.AllocHGlobal(val.Length);
			Marshal.Copy(val,0,attr.pValue,val.Length);
		}
		
		protected void assignNullValue(){
			attr.pValue=IntPtr.Zero;
			attr.ulValueLen=0;
		}
		
		internal virtual CK_ATTRIBUTE toCK(){
			
			if(IsPresent)
				assignValue(encode());
			else assignNullValue();

			return attr;
			
		}
		
		public abstract byte[] encode();
		
		public abstract void decode(byte[] val);
		
		
		internal P11Attribute(CK_ATTRIBUTE attr){
			this.attr=attr;
			
			this.decodeAttr();
		}
		
		internal P11Attribute(){
			this.attr=new CK_ATTRIBUTE();
		}
		
		internal P11Attribute(uint type):base(){
			this.Type=type;
		}
		
		private byte[] getAsBinary(IntPtr ptr, int size){
			byte[] val=new byte[size];
			Marshal.Copy(ptr,val,0,size);
			return val;
		}
		
		protected virtual void decodeAttr(){
			decode( getAsBinary(attr.pValue,(int)attr.ulValueLen) );
		}
	}
}
