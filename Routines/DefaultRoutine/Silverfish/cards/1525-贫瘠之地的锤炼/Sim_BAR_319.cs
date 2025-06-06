using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BAR_319 : SimTemplate //* 邪恶挥刺（等级1） Wicked Stab (Rank 1)
	{
		//Deal $2 damage. <i>(Upgrades when you have 5 Mana.)</i>
		//造成$2点伤害。<i>（当你有5点法力值时升级。）</i>


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
            };
        }
    }
}

	

