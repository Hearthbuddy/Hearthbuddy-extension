using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 圣骑士 费用：3
	//Seal of Blood
	//鲜血圣印
	//Give a minion +3/+3 and <b>Divine Shield</b>. Deal $3 damage to your hero.
	//使一个随从获得+3/+3和<b>圣盾</b>。对你的英雄造成$3点伤害。
	class Sim_RLK_922 : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, 3);
			p.minionGetBuffed(target, 3, 3);
			target.divineshild = true;
		}


		public override PlayReq[] GetPlayReqs()
		{
			return new PlayReq[] {
				new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
				new PlayReq(CardDB.ErrorType2.REQ_FRIENDLY_TARGET),
				new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
			};
		}
	}
}
