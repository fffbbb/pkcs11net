
using System;
using System.Runtime.InteropServices;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of DateAttribute.
	/// </summary>
	public class DateAttribute:P11Attribute
	{
		
		DateTime val;
		
		public DateTime Value {
			get { return val; }
			set { val = value;
				IsPresent=true;
			}
		}
		
		public DateAttribute()
		{
		}
		
		internal DateAttribute(CK_ATTRIBUTE attr):base(attr)
		{
		}
		
		public DateAttribute(uint type):base(type)
		{
		}
		
		public override byte[] encode(){
			throw new NotSupportedException();
		}
		
		public override void decode(byte[] val){
			throw new NotSupportedException();
		}
		
		protected override void decodeAttr(){
			CK_DATE d=(CK_DATE)Marshal.PtrToStructure(attr.pValue, typeof(CK_DATE));
			
			Value= P11Util.toDateTime(d);
		}
		
		internal override CK_ATTRIBUTE toCK()
		{
			if(IsPresent){
				
				CK_DATE d=P11Util.toCK_DATE(val);
				attr.pValue = Marshal.AllocHGlobal(Marshal.SizeOf(d));
				Marshal.StructureToPtr(d, attr.pValue, false);
				attr.ulValueLen=(uint)Marshal.SizeOf(d);
				
			}else{
				assignNullValue();
			}
			return attr;
		}
		
		static string intToString(int val, int strSize){
			String str= new String('0',strSize)+val.ToString();
			return str.Substring(str.Length-strSize, strSize);
		}
	}
}
