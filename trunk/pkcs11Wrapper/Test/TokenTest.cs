

using System;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Wrapper;
using NUnit.Framework;

namespace Net.Sf.Test
{
	[TestFixture]
	class TokenTest
	{
		[Test]
		public void TestMethod()
		{
			Module m=Module.GetInstance("siecap11.dll");
			m.Initialize();
			
			Slot slot= m.GetSlotList(true)[0];
			
			TokenInfo ti=slot.Token.TokenInfo;
			
			Console.WriteLine(ti);
			
			
			m.Finalize_();
		}
		
		[Test]
		public void GetCkmList()
		{
			Module m=Module.GetInstance("gclib.dll");
			m.Initialize();
			
			Slot slot= m.GetSlotList(true)[0];
			
			CKM[] ckms=slot.Token.MechanismList;
			
			foreach(CKM ckm in ckms ) Console.WriteLine(ckm);
			
			
			m.Finalize_();
		}
	}
}
