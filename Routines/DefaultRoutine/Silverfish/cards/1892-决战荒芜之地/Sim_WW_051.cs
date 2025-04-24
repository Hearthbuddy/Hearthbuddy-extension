using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 圣骑士 费用：2
	//Showdown!
	//决战！
	//Both players summon three 3/3 Outlaws.Give yours <b>Rush</b>.
	//双方玩家各召唤三个3/3的歹徒，使你召唤的获得<b>突袭</b>。
	class Sim_WW_051 : SimTemplate
	{
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.WW_051t);//歹徒
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			int pos1 = (ownplay) ? p.enemyMinions.Count : p.ownMinions.Count;

			p.callKid(kid, pos, ownplay, false);
			p.callKid(kid, pos, ownplay);
			p.callKid(kid, pos, ownplay);

			p.callKid(kid, pos1, !ownplay);
			p.callKid(kid, pos1, !ownplay);
			p.callKid(kid, pos1, !ownplay);
		}

		public override PlayReq[] GetPlayReqs()
		{
			return new PlayReq[] {
				new PlayReq(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS, 3),
			};
		}
	}
}
