
using System;
using net.pkcs11.exceptions;
namespace net.pkcs11
{
	/// <summary>
	/// Description of ExceptionHandler.
	/// </summary>
	internal static class ExceptionHandler
	{
		public static UnexpectedRetValException throwException(ReturnValues ckRvl){
			return new UnexpectedRetValException();;
		}
	}
}
