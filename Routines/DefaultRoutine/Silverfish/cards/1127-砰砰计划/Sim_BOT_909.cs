using System;
using System.Collections.Generic;
using System.Text;


namespace HREngine.Bots
{
	class Sim_BOT_909 : SimTemplate //* 水晶学 Crystology
	{
		//[x]Draw two 1-Attackminions from your deck.
		//从你的牌库中抽两张攻击力为1的随从牌。
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (ownplay)
			{
				// 1. 创建临时列表保存符合条件的卡牌ID
				List<CardDB.cardIDEnum> validMinions = new List<CardDB.cardIDEnum>();

				// 2. 第一阶段：仅收集符合条件的卡牌
				foreach (KeyValuePair<CardDB.cardIDEnum, int> cid in p.prozis.turnDeck)
				{
					CardDB.Card c = CardDB.Instance.getCardDataFromID(cid.Key);
					if (c.type == CardDB.cardtype.MOB && c.Attack == 1)
					{
						validMinions.Add(cid.Key);
					}
				}

				// 3. 第二阶段：抽取最多两张卡牌
				int countToDraw = Math.Min(2, validMinions.Count);
				for (int i = 0; i < countToDraw; i++)
				{
					p.drawACard(validMinions[i], ownplay);
				}
			}
		}

	}
}