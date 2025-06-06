using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 萨满祭司 费用：2
	//Ancestral Knowledge
	//先祖知识
	//Draw 2 cards. <b>Overload:</b> (1)
	//抽两张牌。<b>过载：</b>（1）
	class Sim_CORE_AT_053 : SimTemplate
	{
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            if (ownplay) p.ueberladung += 2;
        }

    }
}
