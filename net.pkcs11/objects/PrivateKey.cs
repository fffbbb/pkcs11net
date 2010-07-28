
using System;

namespace net.sf.pkcs11net.objects
{
	/// <summary>
	/// Description of PrivateKey.
	/// </summary>
	public class PrivateKey:StorageObject
	{
		
		byte[] subject;
		
		public byte[] Subject {
			get { return subject; }
			set { subject = value; }
		}
		
		bool isSensitive;
		
		public bool IsSensitive {
			get { return isSensitive; }
			set { isSensitive = value; }
		}
		
		bool supportsDecryption;
		
		public bool SupportsDecryption {
			get { return supportsDecryption; }
			set { supportsDecryption = value; }
		}
		
		bool supportsSigning;
		
		public bool SupportsSigning {
			get { return supportsSigning; }
			set { supportsSigning = value; }
		}
		
	}
}
