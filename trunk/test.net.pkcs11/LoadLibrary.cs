/*
 * SharpDevelop Tarafından Oluşturulmuşdur.
 * Kullanıcı: Administrator
 * Tarih: 13.09.2009
 * Zaman: 11:14
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

using net.pkcs11.generalDataTypes;
namespace net.pkcs11
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
			List<uint> slots= pm.GetSlotList();
			
			CK_SLOT_INFO csInfo=pm.GetSlotInfo(slots[0]);

				
			
		}
		

		
	}
}
