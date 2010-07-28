
using System;

namespace net.sf.pkcs11net.objects
{
	/// <summary>
	/// Description of PublicKey.
	/// </summary>
	public class PublicKey:StorageObject
	{
		byte[] subject;		
		public byte[] Subject {
			get { return subject; }
			set { subject = value; }
		}
		
		bool supportsEncryption;		
		public bool SupportsEncryption {
			get { return supportsEncryption; }
			set { supportsEncryption = value; }
		}
		
		bool supportsVerification;		
		public bool SupportsVerification {
			get { return supportsVerification; }
			set { supportsVerification = value; }
		}
	}
}
