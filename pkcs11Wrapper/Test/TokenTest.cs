

using System;
using NUnit.Framework;
using Net.Sf.Pkcs11;

namespace Net.Sf.Test
{
	[TestFixture]
	class TokenTest
	{
		[Test]
		public void TestMethod()
		{
			Module m=Module.GetInstance("gclib.dll");
			m.Initialize();
			
			Slot slot= m.GetSlotList(true)[0];
			
			TokenInfo ti=slot.Token.TokenInfo;
			
			Console.WriteLine(ti);
			
			
			m.Finalize_();
		}
	}
}
