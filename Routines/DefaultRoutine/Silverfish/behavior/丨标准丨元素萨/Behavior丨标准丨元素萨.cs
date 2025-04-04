using System.Collections.Generic;
using System;
using Logger = Triton.Common.LogUtilities.Logger;
using log4net;
using System.Linq;

namespace HREngine.Bots
{
    public partial class Behavior丨标准丨元素萨 : Behavior
    {
        private int bonus_enemy = 4;
        private int bonus_mine = 4;

        public override string BehaviorName() { return "丨标准丨元素萨"; }
        PenalityManager penman = PenalityManager.Instance;

        //文本输出
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();



        /// <summary>
        /// 标准元素萨的留牌策略
        /// </summary>
        /// <param name="cards">起手卡牌列表</param>
        public override void specialMulligan(List<Mulligan.CardIDEntity> cards)
        {
            int 冰川裂片 = 0;
            int 火羽精灵 = 0;
            int 雷电跳蛙 = 0;
            int 空气元素 = 0;
            int 凶恶的雨云 = 0;
            int 可靠陪伴 = 0;
            int 即兴演奏 = 0;
            int 摇滚巨石 = 0;
            int 烈焰亡魂 = 0;
            int 页岩蛛 = 0;
            int 消融元素 = 0;
            int 湍流元素特布勒斯 = 0;

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);
                if (cardCN.nameCN == CardDB.cardNameCN.冰川裂片)
                {
                    冰川裂片 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.火羽精灵)
                {
                    火羽精灵 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.雷电跳蛙)
                {
                    雷电跳蛙 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.空气元素)
                {
                    空气元素 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.凶恶的雨云)
                {
                    凶恶的雨云 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.可靠陪伴)
                {
                    可靠陪伴 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.即兴演奏)
                {
                    即兴演奏 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.摇滚巨石)
                {
                    摇滚巨石 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.烈焰亡魂)
                {
                    烈焰亡魂 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.页岩蛛)
                {
                    页岩蛛 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.消融元素)
                {
                    消融元素 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.湍流元素特布勒斯)
                {
                    湍流元素特布勒斯 += 1;
                }
            }

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);

                if (cardCN.nameCN == CardDB.cardNameCN.冰川裂片)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张冰川裂片";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡冰川裂片";
                            }
                        }
                    }

                    if (cards.Count >= 3 && 火羽精灵 + 雷电跳蛙 + 空气元素 >= 1)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按特殊规则丢弃冰川裂片，因为有更优质的一费随从";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.火羽精灵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张火羽精灵";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡火羽精灵";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.雷电跳蛙)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张雷电跳蛙";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡雷电跳蛙";
                            }
                        }
                    }

                    if (cards.Count >= 3 && 火羽精灵 >= 1)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按特殊规则丢弃雷电跳蛙，因为有更优质的一费随从";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.空气元素)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张空气元素";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡空气元素";
                            }
                        }
                    }

                    if (cards.Count >= 3 && 火羽精灵 + 雷电跳蛙  >= 1)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按特殊规则丢弃空气元素，因为有更优质的一费随从";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.凶恶的雨云)
                {
                    if (cards.Count >= 3 && 冰川裂片 + 火羽精灵 + 雷电跳蛙 + 空气元素 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手有能用的1费元素留1张凶恶的雨云";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡凶恶的雨云";
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }                  
                }



                if (cardCN.nameCN == CardDB.cardNameCN.摇滚巨石)
                {
                    if (cards.Count >= 3 && 冰川裂片 + 火羽精灵 + 雷电跳蛙 + 空气元素 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手有能用的1费元素留1张摇滚巨石";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡摇滚巨石";
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }                  
                }



                if (cardCN.nameCN == CardDB.cardNameCN.烈焰亡魂)
                {
                    if (cards.Count >= 3 && 冰川裂片 + 火羽精灵 + 雷电跳蛙 + 空气元素 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手有能用的1费元素留1张烈焰亡魂";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡烈焰亡魂";
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }                  
                }
                


                if (cardCN.nameCN == CardDB.cardNameCN.页岩蛛)
                {
                    if (cards.Count >= 3 && 冰川裂片 + 火羽精灵 + 雷电跳蛙 + 空气元素 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手有能用的1费元素留1张页岩蛛";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张卡页岩蛛";
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.湍流元素特布勒斯)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "不留湍流元素特布勒斯怎么赢？";
                    }
                }



                if (cardCN.nameCN == CardDB.cardNameCN.可靠陪伴)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留可靠陪伴";
                    }
                }


                if (cardCN.nameCN == CardDB.cardNameCN.即兴演奏)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留即兴演奏";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.消融元素)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留消融元素";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.矿车巡逻兵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留矿车巡逻兵";
                    }
                }
                //剩下大于等于4费的卡hb是默认不留的
            }       
        }



        public override int getComboPenality(CardDB.Card card, Minion target, Playfield p, Handmanager.Handcard nowHandcard)
        {
            // 无法选中(值越大越不会打出)
            if (target != null && target.untouchable)
            {
                return 100000;
            }
            // 初始惩罚值（负为优先打出该牌，正为低优先打出该牌）
            int pen = 0;
            //一费检查手牌有没有烈焰亡魂、幸运币、元素随从，此处为没有元素随从，返回值1000不打出此combo。
            if (Hrtprozis.Instance.gTurn <= 2 && card.race == CardDB.Race.ELEMENTAL && p.enemyMinions.Count == 0)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.nameCN == CardDB.cardNameCN.烈焰亡魂)
                    {
                        foreach (Handmanager.Handcard hhc in p.owncards)
                        {
                            if (hhc.card.nameCN == CardDB.cardNameCN.幸运币 || hhc.getManaCost(p) == 1 && hhc.card.race != CardDB.Race.ELEMENTAL && hhc.card.type == CardDB.cardtype.MOB)
                            {
                                return 1000;
                            }
                        }
                    }
                }
            }
            //如果是元素随从并且随从有烈焰亡魂， 增加基础推荐出牌。
            if(card.race == CardDB.Race.ELEMENTAL)	
			{
				foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.烈焰亡魂)
					{
						pen -= 100;
					}
				}
			}





            //此处为单卡描述
            switch (card.nameCN)		
            {
                case CardDB.cardNameCN.冰川裂片:
                break;
                case CardDB.cardNameCN.火羽精灵:
                break;
                case CardDB.cardNameCN.雷电跳蛙:
                break;
                case CardDB.cardNameCN.空气元素:
                break;
                case CardDB.cardNameCN.凶恶的雨云:
                if (p.ownMaxMana == 2) pen = -20;
                foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ( hc.card.nameCN == CardDB.cardNameCN.页岩蛛 && p.ownMaxMana == 1)
                            {
                            pen -= 30;
                            }

                            if ( hc.card.nameCN == CardDB.cardNameCN.页岩蛛 && p.ownMaxMana == 2)
                            {
                            pen -= 30;
                            }
                        }
                break;
                case CardDB.cardNameCN.可靠陪伴:
                foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ( hc.card.nameCN == CardDB.cardNameCN.凶恶的雨云 && p.ownMaxMana == 2)
                            {
                            pen += 10000;
                            }

                            if ( hc.card.nameCN == CardDB.cardNameCN.页岩蛛 && p.ownMaxMana == 2)
                            {
                            pen += 10000;
                            }

                            if ( hc.card.nameCN == CardDB.cardNameCN.烈焰亡魂 && p.ownMaxMana == 2)
                            {
                            pen += 10000;
                            }
                        }//可能影响元素链
                if(target != null && target.handcard.card.race == CardDB.Race.ELEMENTAL)//别加在奇奇怪怪的东西上，比如突袭牛牛！
                    pen -= 5;
                break;

                case CardDB.cardNameCN.烈焰亡魂:
                if (p.ownMaxMana == 2) pen = -20;
                if (p.ownMaxMana <= 2 && p.enemyMinions.Count >= 1) pen += 100;
                if (p.ownMaxMana >= 2 && p.enemyMinions.Count == 0) pen = -20;
                break;

                case CardDB.cardNameCN.页岩蛛:
                if (p.ownMaxMana == 2) pen = -20;
                if (p.owncards.Count <= 3) pen -= 10; //手牌低于3时尽快打出
                break;

                case CardDB.cardNameCN.消融元素:
                if (p.ownMaxMana == 3 ) pen = -20;
                if ( p.enemyMinions.Count >= 2) pen = -20;
                break;

                case CardDB.cardNameCN.湍流元素特布勒斯://打出巨大优势
                pen = -700;
                if (p.ownMinions.Count >= 5 && p.enemyHero.Hp + p.enemyHero.armor - 2 <= p.ownMinions.Count) pen -= 900;
                break;               

                case CardDB.cardNameCN.矿车巡逻兵:
                if (p.ownMaxMana == 3 ) pen = -20;
                if (p.ownMinions.Count >= 1) pen = -50;
                if (p.getCorpseCount() > 0) // 如果墓地里的尸体大于0 建议出牌。 
                    {
                        pen = -50;
                    }               
                break;

                case CardDB.cardNameCN.燃灯元素:
                if (p.enemyHero.immune)
                pen += 100000; // 对面免疫时不打。
                if ( p.ownMaxMana <= 10) pen += 1000; 
                if (p.enemyHero.Hp + p.enemyHero.armor <= p.ownMaxMana) pen -= 1000;
                if (p.owncards.FindAll(x => x.card.nameCN == CardDB.cardNameCN.燃灯元素).Count >= 2 && p.enemyHero.Hp + p.enemyHero.armor <= 2 * p.ownMaxMana) pen -= 1000;
                if (p.owncards.Count <= 1) pen -= 1000;//殊死一搏                   
                if (target.isHero && !target.own) // 检查目标是否为敌方英雄
                pen -= 100;
                else
                pen += 100;
                break;

                case CardDB.cardNameCN.乐坛灾星玛加萨:
                if (p.ownMaxMana <= 5 ) pen = + 1000;
                if (p.owncards.Count <= 3) pen -= 50;
                foreach (Handmanager.Handcard hc in p.owncards)
                        {
                            if ( (hc.card.nameCN == CardDB.cardNameCN.冰川裂片 || hc.card.nameCN == CardDB.cardNameCN.雷电跳蛙 || hc.card.nameCN == CardDB.cardNameCN.烈焰元素 || hc.card.nameCN == CardDB.cardNameCN.火羽精灵|| hc.card.nameCN == CardDB.cardNameCN.空气元素|| hc.card.nameCN == CardDB.cardNameCN.影石潜伏者|| hc.card.nameCN == CardDB.cardNameCN.奥术工匠|| hc.card.nameCN == CardDB.cardNameCN.焦油泥浆怪|| hc.card.nameCN == CardDB.cardNameCN.进化融合怪)&& p.ownMaxMana >= 6)                         
                            pen -= 550;                                    
                        }
                if (p.owncards.Count >= 5) pen += 1000;
                break;

                case CardDB.cardNameCN.活体原野岩:
                if (p.ownMaxMana == 5 ) pen = - 20;
                if (p.ownMinions.Count >= 5) pen = +50;
                if (p.enemyMinions.Count >= 2) pen = -25;
                break;

                case CardDB.cardNameCN.灾变飓风斯卡尔:
                if (p.enemyHero.immune)
                pen += 100000; // 对面免疫时不打。
                if (p.ownMaxMana >= 7 && p.enemyMinions.Count >= 1) pen -= 800;
                if (p.enemyHero.Hp + p.enemyHero.armor - p.calTotalAngr() <= p.ownMaxMana) pen -= 1000;
                break;

                case CardDB.cardNameCN.伊辛迪奥斯:              
                pen -= 500;
                break;

                case CardDB.cardNameCN.荒蛮之主卡利莫斯://事实上这是张好卡，但未实现选择。
                pen += 2000;
                break;

                case CardDB.cardNameCN.艾泽里特巨人:
                if (nowHandcard.getManaCost(p) <= 4) pen -= 10;
                if (nowHandcard.getManaCost(p) >= 4) pen += 10;
                break;
                
                case CardDB.cardNameCN.图腾召唤:
                pen += 1;
                break;



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //下面是随机获得牌的判定
                //过载牌

                case CardDB.cardNameCN.电击学徒:
                if (p.ownMaxMana <= 5) pen += 100;
                break;

                case CardDB.cardNameCN.闪电箭:
                if (p.ownMaxMana <= 4) pen += 100;
                break;

                case CardDB.cardNameCN.先祖知识:
                if ( p.ownMaxMana <= 2) pen += 1000; 
                if (p.owncards.Count <= 2) pen -= 50;
                break;

                case CardDB.cardNameCN.即兴演奏:
               // 目标不为空或目标或是我方随从
               if (target == null || !target.own)
                    return 100000;
               // 统计敌方场上生命值小于等于1的随从数量，同时减去这些随从攻击力的平方值。
               int kill_num = 0;
               if (p.enemyMinions.Count > 0)
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Hp <= 1)                   
                        {
                        kill_num++;
                        pen -= mi.Angr * mi.Angr;
                        }
                    }
                // 如果满足特定条件，调整 kill_num 的值以影响对即将被消灭的敌方随从的评分。
                if (kill_num < 3 && p.enemyHeroName == HeroEnum.thief && p.enemyMaxMana < 3) 
                // 遇到贼开局留了即兴演奏3费之前应该再等他至少铺场2个怪才使用。
                    kill_num -= 3;
                // 统计我方场上生命值小于等于1的随从数量，同时增加这些随从攻击力的平方值。
                if (p.ownMinions.Count > 0)
                    foreach (Minion mi in p.ownMinions)
                    {
                        if (mi.Hp <= 1)                    
                        {
                        kill_num--;
                        pen += mi.Angr * mi.Angr; 
                        }
                    }
                // 根据 kill_num 的值调整 pen 的分数，并乘以一个固定的数值（5）。
                pen -= kill_num * 5;
                break;

                case CardDB.cardNameCN.野性狼魂:
                if (p.ownMaxMana <= 5) pen += 100;
                break;

                case CardDB.cardNameCN.闪电风暴:
                if (p.ownMaxMana <= 5) pen += 100;
                break;

                case CardDB.cardNameCN.火箭跳蛙:
                if (p.ownMaxMana <= 7) pen += 100;
                break;

                case CardDB.cardNameCN.跳吧虫子:
                if (p.ownMaxMana <= 7) pen += 100;
                if (p.enemyHero.Hp + p.enemyHero.armor - p.calTotalAngr() <= 8 ) pen -= 1000;
                break;

                case CardDB.cardNameCN.聚集观众:
                if (p.ownMaxMana <= 8) pen += 100;
                if (p.ownMaxMana >= 9) pen -= 550;
                break;

                case CardDB.cardNameCN.步移山丘:
                break;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////               

                //元素牌
                case CardDB.cardNameCN.黑曜亡魂:
                break;
                case CardDB.cardNameCN.影石潜伏者:
                break;

                case CardDB.cardNameCN.晶石雕像://断节奏
                pen += 20;
                break;
                
                case CardDB.cardNameCN.萨隆铁矿蹒跚者:
                break;

                case CardDB.cardNameCN.暗石守卫:
                pen += 2000;
                break;

                case CardDB.cardNameCN.抱石伙伴:
                break;
                case CardDB.cardNameCN.地幔塑型者:
                break;
                case CardDB.cardNameCN.奥术工匠:
                break;

                case CardDB.cardNameCN.流水档案管理员:
                if ( p.ownMaxMana >= 2) pen -= 1000;
                break;

                case CardDB.cardNameCN.水彩美术家:
                break;

                case CardDB.cardNameCN.三芯诡烛:
                if (p.enemyHero.Hp + p.enemyHero.armor <=6 && p.enemyMinions.Count == 0) pen = -1000;
                break;

                case CardDB.cardNameCN.溢流熔岩:
                if (p.ownMinions.Count >= 5) pen = +50;
                foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.烈焰亡魂)
					{
						pen -= 100;
					}
				}               
                break;

                case CardDB.cardNameCN.破链角斗士:
                if (p.owncards.Count <= 3) pen -= 10;
                if (p.owncards.Count >= 7) pen += 100;
                break;

                case CardDB.cardNameCN.滑冰元素:
                break;

                case CardDB.cardNameCN.碎裂巨岩迈沙顿:
                if (p.owncards.Count <= 3 || p.enemyMinions.Count <= 1) pen -= 50;
                break;

                case CardDB.cardNameCN.腐化残渣:
                if (p.enemyHero.Hp + p.enemyHero.armor <=7 && p.enemyMinions.Count == 0) pen = -1000;
                break;

                case CardDB.cardNameCN.圣沙泽尔:
                break;

                case CardDB.cardNameCN.活体天光:
                if (nowHandcard.getManaCost(p) <= 4) pen -= 10;
                if (nowHandcard.getManaCost(p) >= 4) pen += 10;
                break;

                case CardDB.cardNameCN.法力晶簇:
                break;
                case CardDB.cardNameCN.隐藏宝石:
                break;
                case CardDB.cardNameCN.亮石旋岩虫://会锻造出吗？不知道，不写先。
                break;
                case CardDB.cardNameCN.布景光耀之子:
                break;
                case CardDB.cardNameCN.沙画元素:
                break;
                case CardDB.cardNameCN.铜管元素:
                break;
                case CardDB.cardNameCN.风暴勇士:
                break;
                case CardDB.cardNameCN.火元素:
                break;

                

                case CardDB.cardNameCN.闪岩哨兵:
                break;
                case CardDB.cardNameCN.风领主奥拉基尔:
                break;

                case CardDB.cardNameCN.源质晶簇:
                if (p.owncards.Count <= 3) pen -= 50;
                if (p.owncards.Count >= 7) pen += 1000;
                break;

                case CardDB.cardNameCN.蒸汽守卫:
                break;

                case CardDB.cardNameCN.偃息的焰喉:
                pen += 20;
                break;

                case CardDB.cardNameCN.芝士怪物:
                break;
                case CardDB.cardNameCN.焦油泥浆怪:
                break;
                case CardDB.cardNameCN.进化融合怪:
                break;
                case CardDB.cardNameCN.侵蚀沉积岩:
                break;
                case CardDB.cardNameCN.岩熔冶锻师:
                break;

                case CardDB.cardNameCN.梦想策划师杰弗里斯://事实上这是张好卡，但未实现选择。
                pen += 1000;
                break;

                case CardDB.cardNameCN.炫彩旋岩虫:
                break;
                case CardDB.cardNameCN.焦油爬行者:
                break;

                case CardDB.cardNameCN.甜蜜雪灵://事实上这是张好卡，但未实现选择。会投降？
                pen += 1000;
                break;

                case CardDB.cardNameCN.静滞波形:
                break;

                case CardDB.cardNameCN.波池造浪者:
                pen += 100;
                break;

                case CardDB.cardNameCN.炸裂元素:
                if ( p.enemyMinions.Count >= 2) pen = -10;
                break;

                case CardDB.cardNameCN.岩石幼龙:
                break;

                case CardDB.cardNameCN.塞拉赞恩:
                pen -= 500;
                break;

                case CardDB.cardNameCN.希亚玛特:
                break;

                case CardDB.cardNameCN.玛鲁特缚石:
                break;

                case CardDB.cardNameCN.融合独奏团:
                break;

                case CardDB.cardNameCN.迦顿男爵:
                // 统计敌方场上生命值小于等于2的随从数量，同时减去这些随从攻击力的平方值。
               int kill2_num = 0;
               if (p.enemyMinions.Count > 0)
                    foreach (Minion mi in p.enemyMinions)
                    {
                        if (mi.Hp <= 2)                   
                        {
                        kill2_num++;
                        pen -= mi.Angr * mi.Angr;
                        }
                    }
                // 统计我方场上生命值小于等于2的随从数量，同时增加这些随从攻击力的平方值。
                if (p.ownMinions.Count > 0)
                    foreach (Minion mi in p.ownMinions)
                    {
                        if (mi.Hp <= 2)                    
                        {
                        kill2_num--;
                        pen += mi.Angr * mi.Angr; 
                        }
                    }
                // 根据 kill2_num 的值调整 pen 的分数，并乘以一个固定的数值（5）。
                pen -= kill2_num * 5;
                break;

                case CardDB.cardNameCN.奔雷骏马:
                break;
                case CardDB.cardNameCN.炎魔之王拉格纳罗斯:
                break;

                case CardDB.cardNameCN.美术家可丽菲罗:  //没有办法的办法
                if (p.owncards.Count >= 2) pen += 10000;
                if (p.enemyHero.Hp + p.enemyHero.armor - p.calTotalAngr() <= 0 ) pen += 10000;
                break;

                case CardDB.cardNameCN.山岭巨人:
                case CardDB.cardNameCN.熔核巨人:
                if (nowHandcard.getManaCost(p) <= 4) pen -= 10;
                if (nowHandcard.getManaCost(p) >= 4) pen += 10;
                break;
        
            }
            return pen;
        }

        // 核心，场面值
        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value > -200000) return p.value;
            float retval = 0;
            retval += getGeneralVal(p);
            retval += p.owncarddraw * 5;
            // 危险血线
            int hpboarder = 3;
            // 不考虑法强了
            if (p.enemyHeroName == HeroEnum.mage) retval += 2 * p.enemyspellpower;
            // 抢脸血线
            int aggroboarder = 20;
            retval += getHpValue(p, hpboarder, aggroboarder);
            // 出牌序列数量
            int count = p.playactions.Count;
            int ownActCount = 0;
            bool useAb = false;

            bool canBe_flameward = false;

            if (p.anzOldWoman > 0)
            {
                foreach (SecretItem si in p.enemySecretList)  //Todo: 是否要判断己方回合还是敌方回合？？？
                {
                    if (si.canBe_flameward) { canBe_flameward = true; break; }
                }
            }
            bool attacted = false;
            // 排序问题！！！！
            for (int i = 0; i < count; i++)
            {
                Action a = p.playactions[i];
                ownActCount++;
                switch (a.actionType)
                {
                    
                    // 英雄攻击
                    case actionEnum.attackWithMinion:
                    case actionEnum.attackWithHero:
                        if (a.target != null && a.target.isHero)
                        {
                            attacted = true;
                        }
                        continue;
                    case actionEnum.useHeroPower:
                        useAb = true;
                        break;
                    case actionEnum.playcard:
                        break;
                    default:
                        continue;
                }
        
                //// 出牌排序优先
                switch (a.card.card.nameCN)
                {
                    
                    
                    case CardDB.cardNameCN.可靠陪伴:
                        retval -= i * 6;
                    break;
                    
                    case CardDB.cardNameCN.烈焰亡魂:
                        retval -= i * 5;
                    break;
                    case CardDB.cardNameCN.湍流元素特布勒斯:
                        retval -= i * 4;
                    break;

                    case CardDB.cardNameCN.矿车巡逻兵:
                    case CardDB.cardNameCN.凶恶的雨云:
                    case CardDB.cardNameCN.页岩蛛:
                    case CardDB.cardNameCN.活体原野岩:
                    case CardDB.cardNameCN.消融元素:
                        retval -= i * 3;
                    break;

                    case CardDB.cardNameCN.冰川裂片:
                    case CardDB.cardNameCN.火羽精灵:
                    case CardDB.cardNameCN.雷电跳蛙:
                    case CardDB.cardNameCN.空气元素:
                    case CardDB.cardNameCN.烈焰元素:
                    case CardDB.cardNameCN.影石潜伏者:
                    case CardDB.cardNameCN.奥术工匠:
                    case CardDB.cardNameCN.焦油泥浆怪:
                    case CardDB.cardNameCN.进化融合怪:
                        retval -= i * 2;
                    break;

                    case CardDB.cardNameCN.摇滚巨石:
                        retval -= i ;
                    break;
                    case CardDB.cardNameCN.燃灯元素:
                    case CardDB.cardNameCN.乐坛灾星玛加萨:
                    case CardDB.cardNameCN.灾变飓风斯卡尔:
                    case CardDB.cardNameCN.艾泽里特巨人:
                    break;
                }
            }
            // 对手基本随从交换模拟
            retval -= p.lostDamage;
            //retval += getSecretPenality(p); // 奥秘的影响
            retval -= p.enemyWeapon.Angr * 3 + p.enemyWeapon.Durability * 3;

            // 留着技能下回合出的情况
            if (p.ownMaxMana < 2 && p.ownHeroPowerCostLessOnce <= -99)
            {
                if (!useAb && p.enemyMinions.Count == 0)
                    retval += 20;
            }

            // 特殊：优势防亵渎
            if (retval > 50 && p.enemyHeroStartClass == TAG_CLASS.WARLOCK && p.enemyMinions.Count == 0 && p.ownMinions.Count > 2)
            {
                bool found = false;
                // 从 2 开始防，术士自带一堆 1
                for (int i = 1; i <= 10; i++)
                {
                    found = false;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.Hp == i)
                        {
                            retval -= 2 * (i - 1);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        if (i == 1) retval += 10;
                        if (i == 2) retval += 10;
                        break;
                    }
                }
            }
            
             // 如果不攻击就能击杀还有额外奖励哦
            if (!attacted && p.enemyHero.Hp <= 0) retval += 10000;
            //p.value = retval;
            return retval;
        }


        
        // 敌方随从价值 主要等于（HP + Angr） * 4
        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            bool dieNextTurn = false;
            foreach (Minion mm in p.enemyMinions)
            {
                if (mm.handcard.card.nameCN == CardDB.cardNameCN.末日预言者)
                {
                    dieNextTurn = true;
                    break;
                }
            }
            if (m.destroyOnEnemyTurnEnd || m.destroyOnEnemyTurnStart || m.destroyOnOwnTurnEnd || m.destroyOnOwnTurnStart) dieNextTurn = true;
            if (dieNextTurn)
            {
                return -1;
            }
            if (m.Hp <= 0) return 0;
            int retval = 0;
            if (m.Angr > 0 || m.taunt || m.handcard.card.race == CardDB.Race.TOTEM || p.enemyHeroStartClass == TAG_CLASS.PALADIN || p.enemyHeroStartClass == TAG_CLASS.PRIEST)
                retval += m.Hp * 4;
            retval += m.spellpower * 2;
            retval += m.Hp * m.Angr / 2;
            if (!m.frozen && (!m.cantAttack || m.handcard.card.nameCN == CardDB.cardNameCN.邪刃豹))
            {
                retval += m.Angr * 4;
                if (m.Angr > 5) retval += 10;
                if (m.windfury) retval += m.Angr * 2;
            }
            if (m.silenced) return retval;

            if (m.taunt) retval += 2;
            if (m.divineshild) retval += m.Angr * 2;
            if (m.divineshild && m.taunt) retval += 5;
            if (m.stealth) retval += 2;

            // 鱼人
            if (m.handcard.card.race == CardDB.Race.MURLOC) retval += bonus_enemy * 4;

            // 剧毒价值两点属性
            if (m.poisonous)
            {
                retval += 8;
            }
            if (m.lifesteal) retval += m.Angr * bonus_enemy * 4;

            int bonus = 4;
            switch (m.handcard.card.nameCN)
            {
                case CardDB.cardNameCN.巫师学徒:
                case CardDB.cardNameCN.肢体商贩:
                case CardDB.cardNameCN.巨型图腾埃索尔:
                case CardDB.cardNameCN.驻锚图腾:
                case CardDB.cardNameCN.刺豚拳手:
                case CardDB.cardNameCN.空中飞爪:
                case CardDB.cardNameCN.金翼巨龙:
                case CardDB.cardNameCN.安保自动机:
                case CardDB.cardNameCN.机械跃迁者:
                case CardDB.cardNameCN.火焰术士弗洛格尔:
                case CardDB.cardNameCN.对空奥术法师:
                case CardDB.cardNameCN.前沿哨所:
                case CardDB.cardNameCN.战场军官:
                case CardDB.cardNameCN.伯尔纳锤喙:
                case CardDB.cardNameCN.甜水鱼人斥候:
                case CardDB.cardNameCN.塔姆辛罗姆:
                case CardDB.cardNameCN.暗影珠宝师汉纳尔:
                case CardDB.cardNameCN.伦萨克大王:
                case CardDB.cardNameCN.布莱恩铜须:
                case CardDB.cardNameCN.观星者露娜:
                case CardDB.cardNameCN.大法师瓦格斯:
                case CardDB.cardNameCN.火妖:
                case CardDB.cardNameCN.下水道渔人:
                case CardDB.cardNameCN.空中炮艇:
                case CardDB.cardNameCN.船载火炮:
                case CardDB.cardNameCN.火舌图腾:
                case CardDB.cardNameCN.末日预言者:
                case CardDB.cardNameCN.莫尔杉哨所:
                case CardDB.cardNameCN.鱼人领军:
                case CardDB.cardNameCN.南海船长:
                case CardDB.cardNameCN.灭龙弩炮:
                case CardDB.cardNameCN.战马训练师:
                case CardDB.cardNameCN.加基森拍卖师:
                case CardDB.cardNameCN.健谈的调酒师:
                case CardDB.cardNameCN.豪宅管家俄里翁:
                case CardDB.cardNameCN.小鬼骑士:
                case CardDB.cardNameCN.针岩图腾:
                case CardDB.cardNameCN.伴唱机:
                case CardDB.cardNameCN.空气之怒图腾:
                case CardDB.cardNameCN.战场通灵师:
                case CardDB.cardNameCN.纸艺天使:
                case CardDB.cardNameCN.纳亚克海克森:
                case CardDB.cardNameCN.烈焰亡魂:
                case CardDB.cardNameCN.饥饿食客哈姆:
                case CardDB.cardNameCN.箭矢工匠:
                case CardDB.cardNameCN.傀儡大师多里安:
                case CardDB.cardNameCN.脆骨海盗:
                case CardDB.cardNameCN.暗影升腾者:
                case CardDB.cardNameCN.赤红教士:
                case CardDB.cardNameCN.受伤的搬运工:
                case CardDB.cardNameCN.阿米图斯的信徒:
                case CardDB.cardNameCN.隐藏宝石:
                case CardDB.cardNameCN.落难的大法师:
                case CardDB.cardNameCN.虚空协奏者:
                case CardDB.cardNameCN.神话观测者:
                    retval += 150;
                    break;
              
                // 不解巨大劣势
                case CardDB.cardNameCN.安娜科德拉:
                case CardDB.cardNameCN.农夫:
                case CardDB.cardNameCN.旗标骷髅:
                case CardDB.cardNameCN.尼鲁巴蛛网领主:
                case CardDB.cardNameCN.凯瑞尔罗姆:
                case CardDB.cardNameCN.暗鳞先知:
                case CardDB.cardNameCN.鲨鳍后援:
                case CardDB.cardNameCN.相位追猎者:
                case CardDB.cardNameCN.鱼人宝宝车队:
                case CardDB.cardNameCN.饥饿的秃鹫:
                case CardDB.cardNameCN.锈水海盗:
                case CardDB.cardNameCN.盛装歌手:
                case CardDB.cardNameCN.玛克扎尔的小鬼:
                case CardDB.cardNameCN.发明机器人:
                case CardDB.cardNameCN.宝藏经销商:
                case CardDB.cardNameCN.随船外科医师:
                case CardDB.cardNameCN.玩具船:
                case CardDB.cardNameCN.淘金客:
                case CardDB.cardNameCN.雏龙牧人:
                    retval += 50;
                    break;

                // 算有点用
                case CardDB.cardNameCN.贪婪的书虫:
                case CardDB.cardNameCN.治疗图腾:
                case CardDB.cardNameCN.力量图腾:
                case CardDB.cardNameCN.神秘女猎手:
                case CardDB.cardNameCN.矮人神射手:
                case CardDB.cardNameCN.低阶侍从:
                case CardDB.cardNameCN.战斗邪犬:
                case CardDB.cardNameCN.法力浮龙:
                case CardDB.cardNameCN.飞刀杂耍者:
                    retval += 15;
                    break;

                case CardDB.cardNameCN.白银之手新兵:
                case CardDB.cardNameCN.脆弱的食尸鬼:
                case CardDB.cardNameCN.伊丽扎刺刃:
                case CardDB.cardNameCN.石心之王:
                case CardDB.cardNameCN.神秘的蛋:
                    retval -= 150;
                    break;
                
                case CardDB.cardNameCN.侏儒飞行员诺莉亚:
                if (p.anzEnemyTaunt == 0 && p.calTotalAngr()  >= p.enemyHero.Hp + p.enemyHero.armor)
                    retval -= 150;
                    break;
               
                   
                

                
                
            }
            return retval;
        }

        // 我方随从价值，大致等于主要等于 （HP + Angr） * 4 
        public override int getMyMinionValue(Minion m, Playfield p)
        {
            bool dieNextTurn = false;
            foreach (Minion mm in p.enemyMinions)
            {
                if (mm.handcard.card.nameCN == CardDB.cardNameCN.末日预言者)
                {
                    dieNextTurn = true;
                    break;
                }
            }
            if (m.destroyOnEnemyTurnEnd || m.destroyOnEnemyTurnStart || m.destroyOnOwnTurnEnd || m.destroyOnOwnTurnStart) dieNextTurn = true;
            if (dieNextTurn)
            {
                return -1;
            }
            if (m.Hp <= 0) return 0;
            int retval = 5;
            if (m.Hp <= 0) return 0;
            retval += m.Hp * 4;
            retval += m.Angr * 4;
            retval += m.Hp * m.Angr / 2;
            // 高攻低血是垃圾
            if (m.Angr > m.Hp + 4) retval -= (m.Angr - m.Hp) * 3;

            // 风怒价值
            if ((!m.playedThisTurn || m.rush == 1 || m.charge == 1) && m.windfury) retval += m.Angr;
            // 圣盾价值
            if (m.divineshild) retval += m.Angr * 3;
            // 潜行价值
            if (m.stealth) retval += m.Angr / 2 + 1;
            // 吸血
            if (m.lifesteal) retval += m.Angr / 2 + 1;
            // 圣盾嘲讽
            if (m.divineshild && m.taunt) retval += 4;

            int bonus = 4;
            switch (m.handcard.card.nameCN)
            {
                case CardDB.cardNameCN.烈焰亡魂:
                    retval += 2 * bonus_mine;
                    break;

            }
            return retval;
        }

        public override int getSirFinleyPriority(List<Handmanager.Handcard> discoverCards)
        {

            return -1; //comment out or remove this to set manual priority
            int sirFinleyChoice = -1;
            int tmp = int.MinValue;
            for (int i = 0; i < discoverCards.Count; i++)
            {
                CardDB.cardNameEN name = discoverCards[i].card.nameEN;
                if (SirFinleyPriorityList.ContainsKey(name) && SirFinleyPriorityList[name] > tmp)
                {
                    tmp = SirFinleyPriorityList[name];
                    sirFinleyChoice = i;
                }
            }
            return sirFinleyChoice;
        }
        public override int getSirFinleyPriority(CardDB.Card card)
        {
            return SirFinleyPriorityList[card.nameEN];
        }

        private Dictionary<CardDB.cardNameEN, int> SirFinleyPriorityList = new Dictionary<CardDB.cardNameEN, int>
        {
            //{HeroPowerName, Priority}, where 0-9 = manual priority
            { CardDB.cardNameEN.lesserheal, 0 },
            { CardDB.cardNameEN.shapeshift, 6 },
            { CardDB.cardNameEN.fireblast, 7 },
            { CardDB.cardNameEN.totemiccall, 1 },
            { CardDB.cardNameEN.lifetap, 9 },
            { CardDB.cardNameEN.daggermastery, 5 },
            { CardDB.cardNameEN.reinforce, 4 },
            { CardDB.cardNameEN.armorup, 2 },
            { CardDB.cardNameEN.steadyshot, 8 }
        };


        public override int getHpValue(Playfield p, int hpboarder, int aggroboarder)
        {
            int offset_enemy = 0;
            int offset_mine = p.calEnemyTotalAngr() + Hrtprozis.Instance.enemyDirectDmg;

            int retval = 0;
            // 血线安全
            if (p.ownHero.Hp + p.ownHero.armor - offset_mine > hpboarder)
            {
                retval += (5 + p.ownHero.Hp + p.ownHero.armor - offset_mine - hpboarder) * 3 / 2;
            }
            // 快死了
            else if (p.ownHero.Hp + p.ownHero.armor - offset_mine > 0)
            {
                //if (p.nextTurnWin()) retval -= (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor);
                retval -= 4 * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor + offset_mine) * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor + offset_mine);
            }
            else
            {
                retval -= 3 * (hpboarder + 1) * (hpboarder + 1) + 100;
            }
            if (p.ownHero.Hp + p.ownHero.armor - offset_mine < 6 && p.ownHero.Hp + p.ownHero.armor - offset_mine > 0)
            {
                retval -= 80 / (p.ownHero.Hp + p.ownHero.armor - offset_mine);
            }
            // 对手血线安全
            if (p.enemyHero.Hp + p.enemyHero.armor + offset_enemy >= aggroboarder)
            {
                retval += 3 * (aggroboarder - p.enemyHero.Hp - p.enemyHero.armor - offset_enemy);
            }
            // 开始打脸
            else
            {
                retval += 4 * (aggroboarder + 1 - p.enemyHero.Hp - p.enemyHero.armor - offset_enemy);
            }
            // 进入斩杀线
            // if (p.enemyHero.Hp + p.enemyHero.armor + offset_enemy <= 5 && p.enemyHero.Hp + p.enemyHero.armor + offset_enemy > 0)
            // {
            //     retval += 300 / (p.enemyHero.Hp + p.enemyHero.armor - offset_enemy);
            // }
            // 场攻+直伤大于对方生命，预计完成斩杀
            if (p.anzEnemyTaunt == 0 && p.calTotalAngr() + p.calDirectDmg(p.mana, false) >= p.enemyHero.Hp + p.enemyHero.armor)
            {
                retval += 2000;
            }
            // 下回合斩杀本回合打脸
            if (p.calDirectDmg(p.ownMaxMana + 1, false, true) >= p.enemyHero.Hp + p.enemyHero.armor)
            {
                retval += 100;
            }
            return retval;
        }


        /// <summary>
        /// 攻击触发的奥秘惩罚
        /// </summary>
        /// <param name="si"></param>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public override int getSecretPen_CharIsAttacked(Playfield p, SecretItem si, Minion attacker, Minion defender)
        {
            if (attacker.isHero) return 0;
            int pen = 0;
            // 攻击的基本惩罚
            if (si.canBe_explosive && !defender.isHero)
            {
                pen -= 20;
                //pen += (attacker.Hp + attacker.Angr);
                foreach (SecretItem sii in p.enemySecretList)
                {
                    sii.canBe_explosive = false;
                }
            }
            return pen;
        }




    }
}