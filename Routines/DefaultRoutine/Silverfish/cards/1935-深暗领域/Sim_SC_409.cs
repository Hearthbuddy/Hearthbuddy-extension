using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 萨满祭司 费用：2 攻击力：1 生命值：3
	//Missile Pod
	//飞弹舱
	//[x]<b>Starship Piece</b><b>Battlecry:</b> Deal 1 damageto all enemies. Alsotriggers on launch.
	//<b>星舰组件</b><b>战吼：</b>对所有敌人造成1点伤害。发射时也会触发。
	class Sim_SC_409 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			onLaunchStarShip(p, own);
		}

		public override void onLaunchStarShip(Playfield p, Minion starShip)
		{
			p.allCharsOfASideGetDamage(!starShip.own, 1);
		}
	}
}
