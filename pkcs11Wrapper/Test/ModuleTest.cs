

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
			Console.WriteLine("field of info");
			Console.WriteLine(info.CryptokiVersion);
			Console.WriteLine(info.LibraryDescription);
			Console.WriteLine(info.LibraryVersion);
			Console.WriteLine(info.ManufacturerID);
			
			m.Finalize_();
			
		}
	}
}
