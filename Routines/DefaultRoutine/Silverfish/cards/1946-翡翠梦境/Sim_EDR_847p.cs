using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//英雄技能 德鲁伊 费用：2
	//Blessing of the Golem
	//魔像的祝福
	//Summon a <b>@</b>/<b>@</b> Plant_Golem.
	//召唤一个<b>@</b>/<b>@</b>的植物魔像。
	class Sim_EDR_847p : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			Minion callKid;
			if (ownplay)
			{
				callKid = p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EDR_847pt2),
					p.ownMinions.Count, true);
			}
			else
			{
				callKid = p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EDR_847pt2),
					p.enemyMinions.Count, false);
			}

			if (callKid != null)
			{
				callKid.Angr = p.ownHeroAblility.SCRIPT_DATA_NUM_1;
				callKid.Hp = p.ownHeroAblility.SCRIPT_DATA_NUM_1;
			}
		}
	}
}
