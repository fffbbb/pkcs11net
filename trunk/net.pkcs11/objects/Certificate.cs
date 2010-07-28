
using System;

namespace net.sf.pkcs11net.objects
{
	/// <summary>
	/// Description of Certificate.
	/// </summary>
	public class Certificate:StorageObject
	{
		byte[] value;
		
		public byte[] Value {
			get { return value; }
			set { this.value=value; }
		}		
	}
}
