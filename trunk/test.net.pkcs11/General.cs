

using System;
using NUnit.Framework;

namespace net.sf.pkcs11net
{
	[TestFixture]
	public class General
	{
		[Test]
		public void TestMethod()
		{
			int i=45;
			
			Console.WriteLine(i.ToString());
			
			Console.WriteLine( System.Text.Encoding.ASCII.GetBytes(i.ToString()).Length );
		}
		
		[Test]
		public void byteArrayToHexTest(){
			Byte[] Bytes = {0xFF, 0xD0, 0xFF, 0xD1}; // "FF-D0-FF-D1"

			String s=BitConverter.ToString(Bytes).Replace('-',' ');
			Console.WriteLine(s);
		}
	}
}
