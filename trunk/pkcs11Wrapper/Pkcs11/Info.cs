
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11
{
	/// <summary>
	/// Description of Info.
	/// </summary>
	public class Info
	{
		protected Version cryptokiVersion_;
		
		public Version CryptokiVersion {
			get { return cryptokiVersion_; }
		}
		protected String manufacturerID_;
		
		public string ManufacturerID {
			get { return manufacturerID_; }
		}
		protected String libraryDescription_;
		
		public string LibraryDescription {
			get { return libraryDescription_; }
		}
		protected Version libraryVersion_;
		
		public Version LibraryVersion {
			get { return libraryVersion_; }
		}
		
		internal Info(CK_INFO ckInfo)
		{
			this.cryptokiVersion_ = new Version(ckInfo.cryptokiVersion);
			this.manufacturerID_ = P11Util.toUtf8String(ckInfo.manufacturerID);
			this.libraryDescription_ = P11Util.toUtf8String(ckInfo.libraryDescription);
			this.libraryVersion_ = new Version(ckInfo.libraryVersion);
		}
	}
}
