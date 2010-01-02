using System;
using NUnit.Framework;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

using net.sf.pkcs11net.generalDataTypes;
namespace net.sf.pkcs11net
{
	[TestFixture]
	public class LoadLibrary
	{
		

		[Test]
		public void TestMethod()
		{

			Pkcs11Module pm=Pkcs11Module.GetInstance("test");
			bool hasToken=true;
			CK_INFO cInfo=pm.GetInfo();
			List<uint> slots= pm.GetSlotList(hasToken);
			
			CK_SLOT_INFO csInfo=pm.GetSlotInfo(slots[0]);

				
			
		}
		

		
	}
}
