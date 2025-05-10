using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 中立 费用：2 攻击力：0 生命值：7
	//Doomsayer
	//末日预言者
	//At the start of your turn, destroy ALL minions.
	//在你的回合开始时，消灭所有随从。
	class Sim_CORE_NEW1_021 : SimTemplate
	{
		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
		{
			if (turnStartOfOwner == triggerEffectMinion.own)
			{
				foreach (Minion m in p.ownMinions)
				{
					if (m.entitiyID == triggerEffectMinion.entitiyID) continue;
					if (m.playedThisTurn || m.playedPrevTurn)
					{
						if (PenalityManager.Instance.ownSummonFromDeathrattle.ContainsKey(m.name)) continue;
						p.evaluatePenality += (m.Hp * 2 + m.Angr * 2) * 2;
					}
				}

				p.allMinionsGetDestroyed();
			}
		}
	}
}
