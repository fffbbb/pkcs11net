
using System;
using Net.Sf.Pkcs11.Wrapper;
namespace Net.Sf.Pkcs11.Objects
{
	/// <summary>
	/// Description of Key.
	/// </summary>
	public class Key:Storage
	{
		KeyTypeAttribute keyType;
		
		public KeyTypeAttribute KeyType {
			get { return keyType; }
		}
		
		ByteArrayAttribute id;
		
		public ByteArrayAttribute Id {
			get { return id; }
		}
		
		DateAttribute startDate;
		
		public DateAttribute StartDate {
			get { return startDate; }
		}
		
		DateAttribute endDate;
		
		public DateAttribute EndDate {
			get { return endDate; }
		}
		
		BooleanAttribute derive;
		
		public BooleanAttribute Derive {
			get { return derive; }
		}
		
		BooleanAttribute local;
		
		public BooleanAttribute Local {
			get { return local; }
		}
		
		MechanismTypeAttribute keyGenMechanism;
		
		public MechanismTypeAttribute KeyGenMechanism {
			get { return keyGenMechanism; }
		}
		
		
		//TODO: CKA_ALLOWED_MECHANISMS 
		
		
		public Key()
		{
		}
		
		public Key(Session session, uint hObj):base(session,hObj)
		{
			
		}
		
		public static new P11Object GetInstance(Session session, uint hObj)
		{
			return null;
		}
		
		public override void ReadAttributes(Session session)
		{
			base.ReadAttributes(session);
			
			keyType= ReadAttribute(session,HObj,new KeyTypeAttribute());

			id= ReadAttribute(session,HObj,new ByteArrayAttribute(CKA.ID));
			
			startDate= ReadAttribute(session,HObj,new DateAttribute((uint)CKA.START_DATE));

			endDate= ReadAttribute(session,HObj,new DateAttribute((uint)CKA.END_DATE));
			
			derive= ReadAttribute(session,HObj,new BooleanAttribute(CKA.DERIVE));
			
			local = ReadAttribute(session,HObj,new BooleanAttribute(CKA.LOCAL));
			
			keyGenMechanism = ReadAttribute(session,HObj,new MechanismTypeAttribute(CKA.KEY_GEN_MECHANISM));
		}
	}
}
