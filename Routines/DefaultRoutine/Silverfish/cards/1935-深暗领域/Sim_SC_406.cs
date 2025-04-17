using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 战士 费用：4 攻击力：3 生命值：3
	//Yamato Cannon
	//大和炮
	//[x]<b>Starship Piece</b><b>Battlecry:</b> Destroy a randomenemy minion. Also triggerson launch.
	//<b>星舰组件</b><b>战吼：</b>随机消灭一个敌方随从。发射时也会触发。
	class Sim_SC_406 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			onLaunchStarShip(p, own);
		}

		public override void onLaunchStarShip(Playfield p, Minion starShip)
		{
			Minion m = p.searchRandomMinion(starShip.own ? p.enemyMinions : p.ownMinions, searchmode.searchLowestHP);
			if (m != null) p.minionGetDestroyed(m);
		}
	}
}
