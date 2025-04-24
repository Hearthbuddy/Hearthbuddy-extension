using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 圣骑士 费用：4
	//Crusader Aura
	//十字军光环
	//Whenever a friendly minion attacks, give it +2/+1. Lasts @ turns.
	//每当一个友方随从攻击时，使其获得+2/+1。持续@回合。
	class Sim_TTN_908 : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (ownplay) p.ownSecretsIDList.Add(CardDB.cardIDEnum.TTN_908);
		}
		
	}
}
