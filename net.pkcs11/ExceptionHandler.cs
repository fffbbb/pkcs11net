
using System;
using net.sf.pkcs11net.exceptions;
namespace net.sf.pkcs11net
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
