

using System;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;
using NUnit.Framework;

namespace Net.Sf.Test
{
	[TestFixture]
	public class SecretKeyTest
	{
		[Test]
		public void GenerateEncryptDecryptDestroyTest()
		{
			
			Mechanism mech= new Mechanism(CKM.DES3_KEY_GEN);
			Des3SecretKey template=new Des3SecretKey();
			template.Token.Value=true;
			template.Sensitive.Value=true;
			template.Label.Value="my-test-des3-key".ToCharArray();
			
			Des3SecretKey sc=(Des3SecretKey )session.GenerateKey(mech,template);

			//session.DestroyObject(sc);
			
			
		}
		
		#region session olusturulup kapatılıyor.
		
		Session session;
		
		
		[TestFixtureSetUp]
		public void Init()
		{
			Module m=Module.GetInstance("siecap11.dll");
			m.Initialize();
			
			session= m.GetSlotList(true)[0].Token.OpenSession(false);
			
			session.Login(UserType.USER,"1234".ToCharArray());
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			session.Logout();
			session.Module.Finalize_();
			
			Console.WriteLine();
		}
		#endregion
	}
}
