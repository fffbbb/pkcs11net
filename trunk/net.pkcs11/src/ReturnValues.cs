﻿using System;

namespace net.pkcs11
{
	/// <summary>
	/// Return messages of function calls
	/// </summary>
	public enum ReturnValues:uint{
		OK = ManifestConstants.CKR_OK,
		CANCEL = ManifestConstants.CKR_CANCEL,
		HOST_MEMORY = ManifestConstants.CKR_HOST_MEMORY,
		SLOT_ID_INVALID = ManifestConstants.CKR_SLOT_ID_INVALID,
		GENERAL_ERROR = ManifestConstants.CKR_GENERAL_ERROR,
		FUNCTION_FAILED = ManifestConstants.CKR_FUNCTION_FAILED,
		ARGUMENTS_BAD = ManifestConstants.CKR_ARGUMENTS_BAD,
		NO_EVENT = ManifestConstants.CKR_NO_EVENT,
		NEED_TO_CREATE_THREADS = ManifestConstants.CKR_NEED_TO_CREATE_THREADS,
		CANT_LOCK = ManifestConstants.CKR_CANT_LOCK,
		ATTRIBUTE_READ_ONLY = ManifestConstants.CKR_ATTRIBUTE_READ_ONLY,
		ATTRIBUTE_SENSITIVE = ManifestConstants.CKR_ATTRIBUTE_SENSITIVE,
		ATTRIBUTE_TYPE_INVALID = ManifestConstants.CKR_ATTRIBUTE_TYPE_INVALID,
		ATTRIBUTE_VALUE_INVALID = ManifestConstants.CKR_ATTRIBUTE_VALUE_INVALID,
		DATA_INVALID = ManifestConstants.CKR_DATA_INVALID,
		DATA_LEN_RANGE = ManifestConstants.CKR_DATA_LEN_RANGE,
		DEVICE_ERROR = ManifestConstants.CKR_DEVICE_ERROR,
		DEVICE_MEMORY = ManifestConstants.CKR_DEVICE_MEMORY,
		DEVICE_REMOVED = ManifestConstants.CKR_DEVICE_REMOVED,
		ENCRYPTED_DATA_INVALID = ManifestConstants.CKR_ENCRYPTED_DATA_INVALID,
		ENCRYPTED_DATA_LEN_RANGE = ManifestConstants.CKR_ENCRYPTED_DATA_LEN_RANGE,
		FUNCTION_CANCELED = ManifestConstants.CKR_FUNCTION_CANCELED,
		FUNCTION_NOT_PARALLEL = ManifestConstants.CKR_FUNCTION_NOT_PARALLEL,
		FUNCTION_NOT_SUPPORTED = ManifestConstants.CKR_FUNCTION_NOT_SUPPORTED,
		KEY_HANDLE_INVALID = ManifestConstants.CKR_KEY_HANDLE_INVALID,
		KEY_SIZE_RANGE = ManifestConstants.CKR_KEY_SIZE_RANGE,
		KEY_TYPE_INCONSISTENT = ManifestConstants.CKR_KEY_TYPE_INCONSISTENT,
		KEY_NOT_NEEDED = ManifestConstants.CKR_KEY_NOT_NEEDED,
		KEY_CHANGED = ManifestConstants.CKR_KEY_CHANGED,
		KEY_NEEDED = ManifestConstants.CKR_KEY_NEEDED,
		KEY_INDIGESTIBLE = ManifestConstants.CKR_KEY_INDIGESTIBLE,
		KEY_FUNCTION_NOT_PERMITTED = ManifestConstants.CKR_KEY_FUNCTION_NOT_PERMITTED,
		KEY_NOT_WRAPPABLE = ManifestConstants.CKR_KEY_NOT_WRAPPABLE,
		KEY_UNEXTRACTABLE = ManifestConstants.CKR_KEY_UNEXTRACTABLE,
		MECHANISM_INVALID = ManifestConstants.CKR_MECHANISM_INVALID,
		MECHANISM_PARAM_INVALID = ManifestConstants.CKR_MECHANISM_PARAM_INVALID,
		OBJECT_HANDLE_INVALID = ManifestConstants.CKR_OBJECT_HANDLE_INVALID,
		OPERATION_ACTIVE = ManifestConstants.CKR_OPERATION_ACTIVE,
		OPERATION_NOT_INITIALIZED = ManifestConstants.CKR_OPERATION_NOT_INITIALIZED,
		PIN_INCORRECT = ManifestConstants.CKR_PIN_INCORRECT,
		PIN_INVALID = ManifestConstants.CKR_PIN_INVALID,
		PIN_LEN_RANGE = ManifestConstants.CKR_PIN_LEN_RANGE,
		PIN_EXPIRED = ManifestConstants.CKR_PIN_EXPIRED,
		PIN_LOCKED = ManifestConstants.CKR_PIN_LOCKED,
		SESSION_CLOSED = ManifestConstants.CKR_SESSION_CLOSED,
		SESSION_COUNT = ManifestConstants.CKR_SESSION_COUNT,
		SESSION_HANDLE_INVALID = ManifestConstants.CKR_SESSION_HANDLE_INVALID,
		SESSION_PARALLEL_NOT_SUPPORTED = ManifestConstants.CKR_SESSION_PARALLEL_NOT_SUPPORTED,
		SESSION_READ_ONLY = ManifestConstants.CKR_SESSION_READ_ONLY,
		SESSION_EXISTS = ManifestConstants.CKR_SESSION_EXISTS,
		SESSION_READ_ONLY_EXISTS = ManifestConstants.CKR_SESSION_READ_ONLY_EXISTS,
		SESSION_READ_WRITE_SO_EXISTS = ManifestConstants.CKR_SESSION_READ_WRITE_SO_EXISTS,
		SIGNATURE_INVALID = ManifestConstants.CKR_SIGNATURE_INVALID,
		SIGNATURE_LEN_RANGE = ManifestConstants.CKR_SIGNATURE_LEN_RANGE,
		TEMPLATE_INCOMPLETE = ManifestConstants.CKR_TEMPLATE_INCOMPLETE,
		TEMPLATE_INCONSISTENT = ManifestConstants.CKR_TEMPLATE_INCONSISTENT,
		TOKEN_NOT_PRESENT = ManifestConstants.CKR_TOKEN_NOT_PRESENT,
		TOKEN_NOT_RECOGNIZED = ManifestConstants.CKR_TOKEN_NOT_RECOGNIZED,
		TOKEN_WRITE_PROTECTED = ManifestConstants.CKR_TOKEN_WRITE_PROTECTED,
		UNWRAPPING_KEY_HANDLE_INVALID = ManifestConstants.CKR_UNWRAPPING_KEY_HANDLE_INVALID,
		UNWRAPPING_KEY_SIZE_RANGE = ManifestConstants.CKR_UNWRAPPING_KEY_SIZE_RANGE,
		UNWRAPPING_KEY_TYPE_INCONSISTENT = ManifestConstants.CKR_UNWRAPPING_KEY_TYPE_INCONSISTENT,
		USER_ALREADY_LOGGED_IN = ManifestConstants.CKR_USER_ALREADY_LOGGED_IN,
		USER_NOT_LOGGED_IN = ManifestConstants.CKR_USER_NOT_LOGGED_IN,
		USER_PIN_NOT_INITIALIZED = ManifestConstants.CKR_USER_PIN_NOT_INITIALIZED,
		USER_TYPE_INVALID = ManifestConstants.CKR_USER_TYPE_INVALID,
		USER_ANOTHER_ALREADY_LOGGED_IN = ManifestConstants.CKR_USER_ANOTHER_ALREADY_LOGGED_IN,
		USER_TOO_MANY_TYPES = ManifestConstants.CKR_USER_TOO_MANY_TYPES,
		WRAPPED_KEY_INVALID = ManifestConstants.CKR_WRAPPED_KEY_INVALID,
		WRAPPED_KEY_LEN_RANGE = ManifestConstants.CKR_WRAPPED_KEY_LEN_RANGE,
		WRAPPING_KEY_HANDLE_INVALID = ManifestConstants.CKR_WRAPPING_KEY_HANDLE_INVALID,
		WRAPPING_KEY_SIZE_RANGE = ManifestConstants.CKR_WRAPPING_KEY_SIZE_RANGE,
		WRAPPING_KEY_TYPE_INCONSISTENT = ManifestConstants.CKR_WRAPPING_KEY_TYPE_INCONSISTENT,
		RANDOM_SEED_NOT_SUPPORTED = ManifestConstants.CKR_RANDOM_SEED_NOT_SUPPORTED,
		RANDOM_NO_RNG = ManifestConstants.CKR_RANDOM_NO_RNG,
		DOMAIN_PARAMS_INVALID = ManifestConstants.CKR_DOMAIN_PARAMS_INVALID,
		BUFFER_TOO_SMALL = ManifestConstants.CKR_BUFFER_TOO_SMALL,
		SAVED_STATE_INVALID = ManifestConstants.CKR_SAVED_STATE_INVALID,
		INFORMATION_SENSITIVE = ManifestConstants.CKR_INFORMATION_SENSITIVE,
		STATE_UNSAVEABLE = ManifestConstants.CKR_STATE_UNSAVEABLE,
		CRYPTOKI_NOT_INITIALIZED = ManifestConstants.CKR_CRYPTOKI_NOT_INITIALIZED,
		CRYPTOKI_ALREADY_INITIALIZED = ManifestConstants.CKR_CRYPTOKI_ALREADY_INITIALIZED,
		MUTEX_BAD = ManifestConstants.CKR_MUTEX_BAD,
		MUTEX_NOT_LOCKED = ManifestConstants.CKR_MUTEX_NOT_LOCKED,
		FUNCTION_REJECTED = ManifestConstants.CKR_FUNCTION_REJECTED,
		VENDOR_DEFINED = ManifestConstants.CKR_VENDOR_DEFINED
	}
}
