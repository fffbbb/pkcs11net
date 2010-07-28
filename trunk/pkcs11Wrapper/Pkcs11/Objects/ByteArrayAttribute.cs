
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of ByteArrayAttribute.
	/// </summary>
	public class ByteArrayAttribute:P11Attribute
	{
		byte[] val;
		
		public byte[] Value {
			get { return val; }
			set { val = value; }
		}
		
		public ByteArrayAttribute(uint type):base(type)
		{
		}
		
		public ByteArrayAttribute(CKA type):base((uint)type)
		{
		}
		
		public ByteArrayAttribute(CK_ATTRIBUTE ckAttr):base(ckAttr)
		{
		}
		
		public override byte[] encode(){
			return Value;
		}
		public override void decode(byte[] val){
			Value= val;
		}
		
		public override string ToString()
		{
			return BitConverter.ToString(Value).Replace('-',' ');
		}
	}
}
