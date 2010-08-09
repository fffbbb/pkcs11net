using System;
using NUnit.Framework;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;	

namespace Net.Sf.Test
{
	[TestFixture]
	public class Test1
	{
		[Test]
		public void InitCard()
		{
			Pkcs11Module m= Pkcs11Module.GetInstance("siecap11.dll");
			m.Initialize();
			uint h=m.GetSlotList(true)[0];
			m.InitToken(h,"1234","my-test-card");
			uint hSession = m.OpenSession(h,0,false);
			m.Login(hSession, CKU.SO,"1234");
			m.InitPIN( hSession, "1234");
		}
		
	}
}
