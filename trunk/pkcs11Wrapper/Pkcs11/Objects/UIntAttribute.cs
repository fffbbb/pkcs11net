using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	public class UIntAttribute:P11Attribute
	{
		uint val_;
		
		public uint Value {
			get { return val_; }
			set { val_ = value; 
			IsPresent=true;
			}
		}
		
		public override byte[] encode(){
			return BitConverter.GetBytes(Value);
		}

		public override void decode(byte[] val){
			Value=BitConverter.ToUInt32(val,0);
		}
		internal UIntAttribute(CK_ATTRIBUTE attr):base(attr){
			
		}
		
		internal UIntAttribute(uint type):base(type){

		}
		
		public override string ToString()
		{
			return Value.ToString();
		}
		
	}
}
