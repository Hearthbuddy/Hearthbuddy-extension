using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 潜行者 费用：3 攻击力：3 生命值：3
	//Pip the Potent
	//皮普，强力水霸
	//<b>Battlecry:</b> Copy each1-Cost card in your hand.
	//<b>战吼：</b>复制你手牌中法力值消耗为（1）的牌。
	class Sim_WW_394 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				// 存储需要复制的卡牌临时列表
				List<Handmanager.Handcard> toCopy = new List<Handmanager.Handcard>();

				// 遍历己方手牌检查当前费用
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					// 使用动态费用计算方法
					int currentCost = hc.getManaCost(p);
					if (currentCost == 1)
					{
						toCopy.Add(hc);
					}
				}

				// 执行复制操作
				foreach (Handmanager.Handcard hc in toCopy)
				{
					// 使用 cardID 枚举进行复制
					p.drawACard(hc.card.cardIDenum, own.own, false);
				}
			}
		}
	}
}
