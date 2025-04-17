using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{
	//随从 中立 费用：7 攻击力：6 生命值：8
	//The Exodar
	//埃索达
	//<b>Battlecry:</b> If you're building a <b>Starship</b>, launch it and choose a Protocol!
	//<b>战吼：</b>如果你正在构筑<b>星舰</b>，将其发射并选择一项指令！
	class Sim_GDB_120 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			var starShip = p.ownMinions.Find(x =>
				x.handcard != null && x.handcard.card != null && x.handcard.card.StarShip && !x.isStarShipLaunched);
			if (starShip == null)
			{
				return;
			}

			// 发射星舰
			starShip.isStarShipLaunched = true;
			p.ownStarShipsCostMore = 0;
			// 理论应该模拟随机发射，但是为了场面计算效率，这里使用顺序发射
			// 即时模拟了随机发射，游戏实际顺序还是会不一致，模拟随机没有意义
			var starShipGraveYard = starShip.starShipGraveyard.ToArray();
			List<CardDB.Card> launchedList = new List<CardDB.Card>();
			foreach (var starShipPiece in starShipGraveYard)
			{
				var card = CardDB.Instance.getCardDataFromID(starShipPiece.Key);
				for (int i = 0; i < starShipPiece.Value; i++)
				{
					card.sim_card.onLaunchStarShip(p, starShip);
					launchedList.Add(card);
				}
			}

			p.StarShipLaunchedList.Add(launchedList);
			if (starShip.rush == 1)
			{
				starShip.cantAttack = true;
				starShip.Ready = true;
			}

			// 指令
			if (choice == 1)
			{
				p.minionGetArmor(starShip.own ? p.ownHero : p.enemyHero, starShip.Hp);
			}
			else if (choice == 2)
			{
				p.allCharsOfASideGetRandomDamage(!starShip.own, starShip.Angr);
			}
			else if (choice == 3)
			{
				foreach (var sgy in starShip.starShipGraveyard)
				{
					for (int i = 0; i < sgy.Value; i++)
					{
						p.drawACard(sgy.Key, !starShip.own);
					}
				}
			}
		}
	}
}
