
using System;
using Net.Sf.Pkcs11.Wrapper;

namespace Net.Sf.Pkcs11
{
	/// <summary>
	/// Description of SlotInfo.
	/// </summary>
	public class SlotInfo
	{
		String slotDescription;
		
		public string SlotDescription {
			get { return slotDescription; }
		}
		String manufacturerID;
		
		public string ManufacturerID {
			get { return manufacturerID; }
		}
		Version firmwareVersion;
		
		public Version FirmwareVersion {
			get { return firmwareVersion; }
		}
		Version hardwareVersion;
		
		public Version HardwareVersion {
			get { return hardwareVersion; }
		}
		
		protected bool tokenPresent_;
		
		public bool IsTokenPresent {
			get { return tokenPresent_; }
		}
		protected bool removableDevice_;
		
		public bool IsRemovableDevice {
			get { return removableDevice_; }
		}
		protected bool hwSlot_;
		
		public bool IsHwSlot {
			get { return hwSlot_; }
		}
		
		
		internal SlotInfo(CK_SLOT_INFO ckSlotInfo)
		{
			this.firmwareVersion = new Version( ckSlotInfo.firmwareVersion);
			this.slotDescription = P11Util.ConvertToUtf8String(ckSlotInfo.slotDescription);
			this.manufacturerID = P11Util.ConvertToUtf8String(ckSlotInfo.manufacturerID);
			this.hardwareVersion = new Version(ckSlotInfo.hardwareVersion);
			
			this.tokenPresent_ = ((ckSlotInfo.flags & 1L) != 0L);
			this.removableDevice_ = ((ckSlotInfo.flags & 0x2) != 0L);
			this.hwSlot_ = ((ckSlotInfo.flags & 0x4) != 0L);
		}
	}
}
