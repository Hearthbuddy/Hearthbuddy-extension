using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 潜行者 费用：4 攻击力：4 生命值：4
	//Glowstone Gyreworm
	//亮石旋岩虫
	//[x]<b><b>Lifesteal</b>Quickdraw:</b> Deal 5 damage.<b>Forge:</b> Change <b>Quickdraw</b>to <b>Battlecry</b>.
	//<b><b>吸血</b>。快枪：</b>造成5点伤害。<b>锻造：</b>将<b>快枪</b>变为<b>战吼</b>。
	class Sim_DEEP_024 : SimTemplate
	{

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice, Handmanager.Handcard hc)
        {
            if (hc.card.Quickdraw && target != null)
            {
                ApplyEffects(p, ownplay, target);
            }
        }

        private void ApplyEffects(Playfield p, bool ownplay, Minion target)
        {
            // 固定5点伤害
            int damage = 5;
            p.minionGetDamageOrHeal(target, damage);

            // 吸血效果
            Minion healTarget = ownplay ? p.ownHero : p.enemyHero;
            p.minionGetDamageOrHeal(healTarget, -damage);
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[]
            {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE), // 条件1：有可用目标时必须选择
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET), // 条件2：目标必须是敌方角色
                new PlayReq(CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO) // 条件3：目标类型限制（随从或敌方英雄）
            };
        }
    }
}
