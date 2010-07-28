
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11
{
	/// <summary>
	/// Description of TokenInfo.
	/// </summary>
	public class TokenInfo
	{
		internal TokenInfo(CK_TOKEN_INFO paramCK_TOKEN_INFO)
		{
			this.label = P11Util.ConvertToUtf8String(paramCK_TOKEN_INFO.label);
			this.manufacturerID = P11Util.ConvertToUtf8String(paramCK_TOKEN_INFO.manufacturerID);
			this.model = P11Util.ConvertToUtf8String(paramCK_TOKEN_INFO.model);
			this.serialNumber = P11Util.ConvertToUtf8String(paramCK_TOKEN_INFO.serialNumber);
			this.maxSessionCount = paramCK_TOKEN_INFO.ulMaxSessionCount;
			this.sessionCount = paramCK_TOKEN_INFO.ulSessionCount;
			this.maxRwSessionCount = paramCK_TOKEN_INFO.ulMaxRwSessionCount;
			this.rwSessionCount = paramCK_TOKEN_INFO.ulRwSessionCount;
			this.maxPinLen = paramCK_TOKEN_INFO.ulMaxPinLen;
			this.minPinLen = paramCK_TOKEN_INFO.ulMinPinLen;
			this.totalPublicMemory = paramCK_TOKEN_INFO.ulTotalPublicMemory;
			this.freePublicMemory = paramCK_TOKEN_INFO.ulFreePublicMemory;
			this.totalPrivateMemory = paramCK_TOKEN_INFO.ulTotalPrivateMemory;
			this.freePrivateMemory = paramCK_TOKEN_INFO.ulFreePrivateMemory;
			this.hardwareVersion = new Version(paramCK_TOKEN_INFO.hardwareVersion);
			this.firmwareVersion = new Version(paramCK_TOKEN_INFO.firmwareVersion);
			this.time =P11Util.ConvertToDateTimeYYYYMMDDhhmmssxx( P11Util.ConvertToASCIIString(paramCK_TOKEN_INFO.utcTime));
			
			this.rng = ((paramCK_TOKEN_INFO.flags & 1L) != 0L);
			this.writeProtected = ((paramCK_TOKEN_INFO.flags & 0x2) != 0L);
			this.loginRequired = ((paramCK_TOKEN_INFO.flags & 0x4) != 0L);
			this.userPinInitialized = ((paramCK_TOKEN_INFO.flags & 0x8) != 0L);
			this.restoreKeyNotNeeded = ((paramCK_TOKEN_INFO.flags & 0x20) != 0L);
			this.clockOnToken = ((paramCK_TOKEN_INFO.flags & 0x40) != 0L);
			this.protectedAuthenticationPath = ((paramCK_TOKEN_INFO.flags & 0x100) != 0L);
			this.dualCryptoOperations = ((paramCK_TOKEN_INFO.flags & 0x200) != 0L);
			this.tokenInitialized = ((paramCK_TOKEN_INFO.flags &  0x400) != 0L);
			this.secondaryAuthentication = ((paramCK_TOKEN_INFO.flags & 0x800) != 0L);
			this.userPinCountLow = ((paramCK_TOKEN_INFO.flags & 0x10000) != 0L);
			this.userPinFinalTry = ((paramCK_TOKEN_INFO.flags & 0x20000) != 0L);
			this.userPinLocked = ((paramCK_TOKEN_INFO.flags & 0x40000) != 0L);
			this.userPinToBeChanged = ((paramCK_TOKEN_INFO.flags & 0x80000) != 0L);
			this.soPinCountLow = ((paramCK_TOKEN_INFO.flags & 0x100000) != 0L);
			this.soPinFinalTry = ((paramCK_TOKEN_INFO.flags & 0x200000) != 0L);
			this.soPinLocked = ((paramCK_TOKEN_INFO.flags & 0x400000) != 0L);
			this.soPinToBeChanged = ((paramCK_TOKEN_INFO.flags & 0x800000) != 0L);
		}
		
		protected String label;
		
		public string Label {
			get { return label; }
		}
		protected string manufacturerID;
		
		public string ManufacturerID {
			get { return manufacturerID; }
		}
		protected string model;
		
		public string Model {
			get { return model; }
		}
		protected string serialNumber;
		
		public string SerialNumber {
			get { return serialNumber; }
		}
		protected long maxSessionCount;
		
		public long MaxSessionCount {
			get { return maxSessionCount; }
		}
		protected long sessionCount;
		
		public long SessionCount {
			get { return sessionCount; }
		}
		protected long maxRwSessionCount;
		
		public long MaxRwSessionCount {
			get { return maxRwSessionCount; }
		}
		protected long rwSessionCount;
		
		public long RwSessionCount {
			get { return rwSessionCount; }
		}
		protected long maxPinLen;
		
		public long MaxPinLen {
			get { return maxPinLen; }
		}
		protected long minPinLen;
		
		public long MinPinLen {
			get { return minPinLen; }
		}
		protected long totalPublicMemory;
		
		public long TotalPublicMemory {
			get { return totalPublicMemory; }
		}
		protected long freePublicMemory;
		
		public long FreePublicMemory {
			get { return freePublicMemory; }
		}
		protected long totalPrivateMemory;
		
		public long TotalPrivateMemory {
			get { return totalPrivateMemory; }
		}
		protected long freePrivateMemory;
		
		public long FreePrivateMemory {
			get { return freePrivateMemory; }
		}
		protected Version hardwareVersion;
		
		public Version HardwareVersion {
			get { return hardwareVersion; }
		}
		protected Version firmwareVersion;
		
		public Version FirmwareVersion {
			get { return firmwareVersion; }
		}
		protected DateTime time;
		
		public DateTime Time {
			get { return time; }
		}
		protected bool rng;
		
		public bool Rng {
			get { return rng; }
		}
		protected bool writeProtected;
		
		public bool WriteProtected {
			get { return writeProtected; }
		}
		protected bool loginRequired;
		
		public bool LoginRequired {
			get { return loginRequired; }
		}
		protected bool userPinInitialized;
		
		public bool UserPinInitialized {
			get { return userPinInitialized; }
		}
		protected bool restoreKeyNotNeeded;
		
		public bool RestoreKeyNotNeeded {
			get { return restoreKeyNotNeeded; }
		}
		protected bool clockOnToken;
		
		public bool ClockOnToken {
			get { return clockOnToken; }
		}
		protected bool protectedAuthenticationPath;
		
		public bool ProtectedAuthenticationPath {
			get { return protectedAuthenticationPath; }
		}
		protected bool dualCryptoOperations;
		
		public bool DualCryptoOperations {
			get { return dualCryptoOperations; }
		}
		protected bool tokenInitialized;
		
		public bool TokenInitialized {
			get { return tokenInitialized; }
		}
		protected bool secondaryAuthentication;
		
		public bool SecondaryAuthentication {
			get { return secondaryAuthentication; }
		}
		protected bool userPinCountLow;
		
		public bool UserPinCountLow {
			get { return userPinCountLow; }
		}
		protected bool userPinFinalTry;
		
		public bool UserPinFinalTry {
			get { return userPinFinalTry; }
		}
		protected bool userPinLocked;
		
		public bool UserPinLocked {
			get { return userPinLocked; }
		}
		protected bool userPinToBeChanged;
		
		public bool UserPinToBeChanged {
			get { return userPinToBeChanged; }
		}
		protected bool soPinCountLow;
		
		public bool SoPinCountLow {
			get { return soPinCountLow; }
		}
		protected bool soPinFinalTry;
		
		public bool SoPinFinalTry {
			get { return soPinFinalTry; }
		}
		protected bool soPinLocked;
		
		public bool SoPinLocked {
			get { return soPinLocked; }
		}
		protected bool soPinToBeChanged;
		
		public bool SoPinToBeChanged {
			get { return soPinToBeChanged; }
		}

	}
}
