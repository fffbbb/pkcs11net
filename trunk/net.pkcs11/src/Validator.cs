/*
 * 
 * Kullanıcı: ferhat
 * Tarih: 27.09.2009
 * Zaman: 18:09
 * 
 */
using System;

namespace net.pkcs11
{
	/// <summary>
	/// Description of Validator.
	/// </summary>
	internal static class Validator
	{
		internal static void ValidateCK_RV(CK_RV retVal){
			if(retVal!= CK_RV.OK)
				throw new Exception(retVal.ToString());
		}
	}
}
