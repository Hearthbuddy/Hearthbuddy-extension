using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 中立 费用：1
	//Amulet of Mobility
	//灵动护符
	//Draw 3 cards.
	//抽三张牌。
	class Sim_VAC_959t09t : SimTemplate
	{
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 抽三张牌
            for (int i = 0; i < 3; i++)
            {
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            }
        }


    }
}
