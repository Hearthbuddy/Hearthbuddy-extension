using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 战士 费用：1
	//Concussive Shells
	//震荡弹
	//Deal $2 damage and gain 2 Armor.Your next <b>Starship</b>launch costs (2) less.
	//造成$2点伤害并获得2点护甲值。你的下一次<b>星舰</b>发射的法力值消耗减少（2）点。
	class Sim_SC_411 : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetDamageOrHeal(target, 2);
			p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 2);
			if (ownplay) p.ownStarShipsCostMore -= 2;
		}
		
		public override PlayReq[] GetPlayReqs()
		{
			return new PlayReq[] {
				new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
				new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET)
			};
		}
	}
}
