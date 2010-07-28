
using System;

namespace net.sf.pkcs11net.objects
{
	/// <summary>
	/// Description of StorageObject.
	/// </summary>
	public class StorageObject
	{
		bool isTokenObject;
		bool isPrivate;
		bool isModifiable;
		string label;

		public bool IsTokenObject{
			get{				
				return isTokenObject ;				
			}
			set{
				isTokenObject = value;
			}
		}
		
		public bool IsPrivate{
			get{	
				return isPrivate;				
			}
			set{
				isPrivate = value;
			}
		}
		
		public bool IsModifiable{
			get{				
				return isModifiable ;				
			}
			set{
				isModifiable= value;
			}
		}
		
		public string Label{
			get{				
				return  label;				
			}
			set{
				label= value;
			}
		}
		
	}
}
