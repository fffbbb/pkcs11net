using System;
using net.sf.pkcs11net.objects;
using System.Collections.Generic;
using net.sf.pkcs11net.generalDataTypes;
using System.Runtime.InteropServices;
namespace net.sf.pkcs11net
{
	/// <summary>
	/// Description of ObjectManager.
	/// </summary>
	public class ObjectManager
	{
		static readonly uint MAX_COUNT=1000;
		
		Pkcs11Module pm;
		uint sessionID;
		public ObjectManager(Pkcs11Module pm, uint sessionID){
			this.pm=pm;
			this.sessionID=sessionID;
		}
		
		public void update(){
			
		}
		
		public void save(){}
		
		public void saveAsNew(){
			
		}
		
		public void delete(){
			
		}
		
		
		#region find object methods
		public List<StorageObject> findObjects(CKO objectClass){
			return findObjects(new CK_ATTRIBUTE[]{AttributeUtil.CreateClassAttribute(objectClass)});
		}
		
		public List<StorageObject> findObjects(CK_ATTRIBUTE[] attrs){
			
			/*find object handlers**/
			pm.FindObjectsInit(sessionID,attrs);
			uint[] objects = pm.FindObjects(sessionID,MAX_COUNT);
			pm.FindObjectsFinal(sessionID);
						
			List<StorageObject> sobjs=new List<StorageObject>();
			
			foreach(uint hObj in objects){
				
				CKO cko= (CKO) getInt32(hObj,AttributeTypes.CLASS);
				
				switch(cko){
					case CKO.CERTIFICATE:
						Certificate c= getAsCertificate(hObj);
						sobjs.Add(c);
						break;
					case CKO.PRIVATE_KEY:
						PrivateKey pk= getAsPrivateKey(hObj);
						sobjs.Add(pk);
						break;
					default:
						StorageObject so=getAsStorageObject(hObj);
						sobjs.Add(so);
						break;
				}
			}
			return sobjs;
		}
		
		
		public List<StorageObject> findObjects(){
			return findObjects(null);
		}
		
		#endregion
		
		#region load object properties methods
		StorageObject getAsStorageObject(uint hObj){
			StorageObject so=new StorageObject();
			loadProperties(so, hObj);
			
			return so;
		}
		
		private void loadProperties(StorageObject so, uint hObj){
			
			so.IsTokenObject=getBool(hObj, AttributeTypes.TOKEN);
			so.IsPrivate=getBool(hObj, AttributeTypes.PRIVATE);
			so.IsModifiable=getBool(hObj, AttributeTypes.MODIFIABLE);
			so.Label=getString(hObj, AttributeTypes.LABEL);
			
		}
		
		PrivateKey getAsPrivateKey(uint hObj){
			PrivateKey cer= new PrivateKey();
			loadProperties(cer, hObj);
			cer.Subject=getBinary(hObj, AttributeTypes.SUBJECT);
			cer.SupportsDecryption=getBool(hObj,AttributeTypes.DECRYPT);
			
			return cer;
		}
		
		Certificate getAsCertificate(uint hObj){
			Certificate cer= new Certificate();
			loadProperties(cer, hObj);
			
			CK_ATTRIBUTE[] r= pm.GetAttributeValue(sessionID,hObj,new CK_ATTRIBUTE[]{
			                                       	AttributeUtil.createAttribute(AttributeTypes.VALUE,0)
			                                       });
			
			r= pm.GetAttributeValue(sessionID,hObj,new CK_ATTRIBUTE[]{
			                        	AttributeUtil.createAttribute(AttributeTypes.VALUE,(int)r[0].ulValueLen)
			                        });
			
			cer.Value=getAsBinary(r[0].pValue, (int)r[0].ulValueLen);
			
			return cer;
		}
		
		#endregion


		#region get attribute help methods

		byte[] getBinary(uint hObj,AttributeTypes attr)
		{
			CK_ATTRIBUTE[] r = pm.GetAttributeValue(sessionID, hObj, new CK_ATTRIBUTE[] { AttributeUtil.createAttribute(attr, 0) });
			r = pm.GetAttributeValue(sessionID, hObj, new CK_ATTRIBUTE[] { AttributeUtil.createAttribute(attr, (int)r[0].ulValueLen) });
			if(r[0].ulValueLen<1)return new byte[0];
			return getAsBinary(r[0].pValue, (int)r[0].ulValueLen);
		}
		
		bool getBool(uint hObj,AttributeTypes attr)
		{
			CK_ATTRIBUTE[] r = pm.GetAttributeValue(sessionID, hObj, new CK_ATTRIBUTE[] { AttributeUtil.createAttribute(attr, 1) });
			return getAsBinary(r[0].pValue, (int)r[0].ulValueLen)[0]==1;
		}
		
		int getInt32(uint hObj,AttributeTypes attr)
		{
			CK_ATTRIBUTE[] r = pm.GetAttributeValue(sessionID, hObj, new CK_ATTRIBUTE[] { AttributeUtil.createAttribute(attr, 4) });
			return BitConverter.ToInt32(getAsBinary(r[0].pValue, (int)r[0].ulValueLen),0);
		}
		
		
		String getString(uint hObj,AttributeTypes attr)
		{
			CK_ATTRIBUTE[] r = pm.GetAttributeValue(sessionID, hObj, new CK_ATTRIBUTE[] { AttributeUtil.createAttribute(attr, 1) });
			return System.Text.Encoding.UTF8.GetString(getAsBinary(r[0].pValue, (int)r[0].ulValueLen));
		}
		
		private byte[] getAsBinary(IntPtr ptr, int size){
			byte[] val=new byte[size];
			Marshal.Copy(ptr,val,0,size);
			return val;
		}
		
		#endregion
	}
	
}
