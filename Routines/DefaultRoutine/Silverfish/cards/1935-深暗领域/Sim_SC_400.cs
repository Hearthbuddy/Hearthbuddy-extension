using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//英雄 无效的 费用：8
	//Jim Raynor
	//吉姆·雷诺
	//[x]<b>Battlecry:</b> Relaunchevery <b>Starship</b> that youlaunched this game.
	//<b>战吼：</b>再次发射你在本局对战中发射过的每艘<b>星舰</b>。
	class Sim_SC_400 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			var pStarShipLaunchedList = p.StarShipLaunchedList;
			if (pStarShipLaunchedList == null || pStarShipLaunchedList.Count == 0)
			{
				return;
			}

			foreach (var launcheds in pStarShipLaunchedList)
			{
				if (launcheds == null || launcheds.Count == 0)
				{
					continue;
				}

				var starShipCardDataFromHeroId = CardDB.Instance.getStarShipCardDataFromHeroID(p.ownHeroName);
				var callKid = p.callKid(starShipCardDataFromHeroId, p.ownMinions.Count, own.own);
				foreach (var launched in launcheds)
				{
					if (callKid != null)
					{
						callKid.Hp += launched.Health;
						callKid.Angr += launched.Attack;
						//特殊效果
						if (launched.Shield) callKid.divineshild = true;
						if (launched.lifesteal) callKid.lifesteal = true;
						if (launched.poisonous) callKid.poisonous = true;
						if (launched.reborn) callKid.reborn = true;
						if (launched.Rush)
						{
							callKid.rush = 1;
							callKid.cantAttack = true;
							callKid.Ready = true;
						}

						if (launched.Elusive) callKid.elusive = true;
						if (launched.tank) callKid.taunt = true;
						if (launched.windfury) callKid.windfury = true;
					}
					else
					{
						// 一般是格子不够召唤不成功，但是星舰组件效果要触发，这里使用一个unknown的随从
						callKid = new Minion();
						callKid.own = own.own;
					}

					launched.sim_card.onLaunchStarShip(p, callKid);
				}
			}
		}
	}
}
