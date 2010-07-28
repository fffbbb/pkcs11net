
using System;

namespace Net.Sf.Pkcs11
{
	/// <summary>
	/// Description of Token.
	/// </summary>
	public class Token
	{
		protected Slot slot_;
		
		public Module Module {
			get { return slot_.Module; }
		}
		public Token(Slot slot)
		{
			this.slot_=slot;
		}
		
		public uint TokenId{
			get { return slot_.SlotId; }
		}
		
		
		
		public TokenInfo TokenInfo{
			get{
				return new TokenInfo(slot_.Module.P11Module.GetTokenInfo(slot_.SlotId));
			}
		}
		
		public Session OpenSession(bool readOnly){
			return new Session(this, this.slot_.Module.P11Module.OpenSession(this.slot_.SlotId,0,readOnly));
		}
	}
}
