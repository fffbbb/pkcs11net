

using System;
using NUnit.Framework;
using Net.Sf.Pkcs11;

namespace Net.Sf.Test
{
	[TestFixture]
	public class SlotTest
	{
		[Test]
		public void getSlotInfoTest()
		{
			Module m=Module.GetInstance("gclib.dll");
			m.Initialize();
			
			Slot slot= m.GetSlotList(true)[0];
			
			Console.WriteLine (slot.SlotId);
			
			SlotInfo si= slot.SlotInfo;
			
			Console.WriteLine(si.FirmwareVersion);
			Console.WriteLine(si.HardwareVersion);
			Console.WriteLine(si.ManufacturerID);
			Console.WriteLine(si.SlotDescription);
						
			m.Finalize_();
		}
	}
}
