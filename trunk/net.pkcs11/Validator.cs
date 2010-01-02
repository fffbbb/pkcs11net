using System;

namespace net.sf.pkcs11net
{
	/// <summary>
	/// Description of Validator.
	/// </summary>
	internal static class Validator
	{
		internal static void ValidateCK_RV(ReturnValues retVal){
			if(retVal!= ReturnValues.OK)
				ExceptionHandler.throwException(retVal);
		}
	}
}
