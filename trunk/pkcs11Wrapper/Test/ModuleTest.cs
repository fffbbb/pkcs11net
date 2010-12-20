

using System;
using NUnit.Framework;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;
using Net.Sf.Pkcs11;

namespace Net.Sf.Test
{
	[TestFixture]
	class ModuleTest
	{
		[Test]
		public void GetInfoTest()
		{
			Module m=Module.GetInstance("gclib.dll");
			m.Initialize();
			
			Info info=m.GetInfo();
			Console.WriteLine(info);
			m.Finalize_();
			
		}
	}
}
