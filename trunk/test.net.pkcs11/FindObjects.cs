
using System;
using NUnit.Framework;
using net.sf.pkcs11net.generalDataTypes;
using System.Runtime.InteropServices;
namespace net.sf.pkcs11net
{
	[TestFixture]
	public class FindObjects
	{
		Pkcs11Module pm;
		uint sessionId;
		
			
		[Test]
		public void findAllObjects()
		{
			ObjectManager om= new ObjectManager(pm,sessionId);
			
			om.findObjects();
			//om.findObjects(CKO.CERTIFICATE);
			//om.findObjects(CKO.PUBLIC_KEY);	
			//om.findObjects(CKO.PRIVATE_KEY);
		}
		
				
		[Test]
		public void getCertificates()
		{
			pm.FindObjectsInit(sessionId,new CK_ATTRIBUTE[]{AttributeUtil.CreateClassAttribute(CKO.CERTIFICATE)});
			uint[] objects = pm.FindObjects(sessionId,10);
			
			CK_ATTRIBUTE ck=new CK_ATTRIBUTE();
			ck.type=(uint)AttributeTypes.CLASS;
			
			CK_ATTRIBUTE[] attr=new CK_ATTRIBUTE[]{AttributeUtil.CreateClassAttribute(CKO.VENDOR_DEFINED)};
			
			foreach(uint i in objects){
				CK_ATTRIBUTE[] r= pm.GetAttributeValue(sessionId,i,attr);
				
				CKO cko=(CKO)Marshal.ReadInt32(r[0].pValue);
				
				Console.WriteLine(cko);
				
			}
				
			
			pm.FindObjectsFinal(sessionId);
		}
		
		
		[TestFixtureSetUp]
		public void Init()
		{
			pm=Pkcs11Module.GetInstance("gclib.dll");
			pm.Initialize();
			sessionId= pm.OpenSession(pm.GetSlotList(true)[0],0,true);
			pm.Login(sessionId, UserTypes.USER,"123456");
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			pm.Finalize_();
		}
	}
}
