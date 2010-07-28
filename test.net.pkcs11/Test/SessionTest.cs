

using System;
using NUnit.Framework;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Params;

namespace Net.Sf.Test
{
	[TestFixture]
	public class SessionTest
	{
		
		
		[Test]
		public void Digest()
		{
			// fEqNCco3Yq9h5ZUglD3CZJT4lBs=
			
			session.DigestInit( new Mechanism(CKM.SHA_1));
			byte[] s= session.Digest( System.Text.Encoding.UTF8.GetBytes( "123456" ) );
			
			String digest= System.Convert.ToBase64String(s);
			
			Assert.AreEqual(digest,"fEqNCco3Yq9h5ZUglD3CZJT4lBs=");
		}
		
		[Test]
		public void FindObject()
		{

			session.FindObjectsInit( null/*new P11Attribute[]{new ObjectClassAttribute(CKO.CERTIFICATE),
			                        		new ObjectClassAttribute(CKO.PUBLIC_KEY)
			                        }*/);
			
			P11Object[] objs= session.FindObjects(10);
			
			session.FindObjectsFinal();
			
			Console.WriteLine(objs);
		}
		
		[Test]
		public void SignTest(){
			
			byte[] data = System.Text.Encoding.UTF8.GetBytes( "123456" );
			
			Mechanism m= new Mechanism(CKM.SHA1_RSA_PKCS);
			
			//get private key			
			session.FindObjectsInit( new P11Attribute[]{ 
			                        	new ObjectClassAttribute(CKO.PRIVATE_KEY),
			                        	new KeyTypeAttribute(CKK.RSA)
			                        });
			
			RSAPrivateKey pk= session.FindObjects(1)[0] as RSAPrivateKey;
			
			session.SignInit (new Mechanism(CKM.SHA1_RSA_PKCS), pk);
			
			byte[] signature= session.Sign(data);
			
			Console.WriteLine(signature.Length);
			
			Console.WriteLine( BitConverter.ToString(signature) );
			
		}
		
		
		
		#region session olusturulup kapatılıyor.
		
		Session session;
		
		
		[TestFixtureSetUp]
		public void Init()
		{
			Module m=Module.GetInstance("gclib.dll");
			m.Initialize();
			
			session= m.GetSlotList(true)[0].Token.OpenSession(false);
			
			session.Login(UserType.USER,"123456".ToCharArray());
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
