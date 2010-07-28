
using System;
using  Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of CharArrayAttribute.
	/// </summary>
	public class CharArrayAttribute : P11Attribute
	{
		char[] val;
		
		public char[] Value {
			get { return val; }
			set { 
				val = value;
				IsPresent=true; 
			}
		}
		
		public CharArrayAttribute()
		{
		}
		
		public CharArrayAttribute(uint type):base(type)
		{
		}
		public CharArrayAttribute(CKA type):base((uint)type)
		{
		}
		public CharArrayAttribute(CK_ATTRIBUTE ckAttr):base(ckAttr)
		{
		}
		
		public override byte[] encode(){
			return System.Text.Encoding.UTF8.GetBytes(new String(Value));
		}
		public override void decode(byte[] val){
			Value= System.Text.Encoding.UTF8.GetString(val).ToCharArray();
		}
		
		public override string ToString()
		{
			return new String(Value);
		}
	}
}
