﻿using System;
using net.sf.pkcs11net.generalDataTypes;
using System.Runtime.InteropServices;
namespace net.sf.pkcs11net
{
	public class AttributeUtil
	{
		public static CK_ATTRIBUTE CreateClassAttribute(){
			return createAttribute((uint)AttributeTypes.CLASS,new byte[0]);
			
		}
		
		public static CK_ATTRIBUTE CreateClassAttribute(CKO objectClass){

			return createAttribute((uint)AttributeTypes.CLASS,BitConverter.GetBytes((uint)objectClass));
		}
		
		public static CK_ATTRIBUTE createAttribute(uint type, byte[]val ){
			
			CK_ATTRIBUTE attr= new CK_ATTRIBUTE();
			attr.type=type;
			if(val!=null && val.Length>0){
				attr.ulValueLen=(uint)val.Length;
				attr.pValue=Marshal.AllocHGlobal(val.Length);
				Marshal.Copy(val,0,attr.pValue,val.Length);
			}else{
				attr.ulValueLen=(uint)val.Length;
				attr.pValue=IntPtr.Zero;
				
			}
			return attr;
		}
		
		public static CK_ATTRIBUTE createAttribute(uint type, int size ){
			return createAttribute(type,new byte[size]);
		}
		
		public static CK_ATTRIBUTE createAttribute(AttributeTypes type, int size ){
			return createAttribute((uint)type,new byte[size]);
		}
		
	}
}
