using System.Collections.Generic;
using System;
using Logger = Triton.Common.LogUtilities.Logger;
using log4net;
using System.Linq;

namespace HREngine.Bots
{
    public partial class Behavior丨狂野丨号角骑 : Behavior
    {
        private int bonus_enemy = 4;
        private int bonus_mine = 4;

        public override string BehaviorName() { return "丨狂野丨号角骑"; }

        PenalityManager penman = PenalityManager.Instance;

        //文本输出
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        /// <summary>
        /// 号角骑的留牌策略
        /// </summary>
        /// <param name="cards">起手卡牌列表</param>
        public override void specialMulligan(List<Mulligan.CardIDEntity> cards, HeroEnum enemyHeroClass)
        {
            int 战斗号角 = 0;
            int 棱彩光束 = 0;
            int 法庭秩序 = 0;

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);
                if (cardCN.nameCN == CardDB.cardNameCN.战斗号角)
                {
                    战斗号角 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.棱彩光束)
                {
                    棱彩光束 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.法庭秩序)
                {
                    法庭秩序 += 1;
                }
            }

            foreach (Mulligan.CardIDEntity card in cards)
            {

                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);

                if (cardCN.nameCN == CardDB.cardNameCN.古神在上)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.神圣佳酿)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.倔强的蜗牛)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.迅疾救兵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.责难)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.陷坑蜘蛛)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.复仇)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.救赎)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.永不屈服)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.疯狂的科学家)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.正义保护者)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.水晶学)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.智慧祝福)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.决战)
                {
                    if (cards.Count >= 3 && (棱彩光束 >= 1 || (法庭秩序 >= 1 && 棱彩光束 == 0)) && (enemyHeroClass == HeroEnum.priest || enemyHeroClass == HeroEnum.demonhunter || enemyHeroClass == HeroEnum.thief))
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是快攻拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.棱彩光束)
                {
                    if (enemyHeroClass == HeroEnum.priest || enemyHeroClass == HeroEnum.demonhunter || enemyHeroClass == HeroEnum.thief)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是快攻拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.前沿哨所)
                {
                    if (enemyHeroClass == HeroEnum.mage || enemyHeroClass == HeroEnum.hunter || enemyHeroClass == HeroEnum.shaman || enemyHeroClass == HeroEnum.druid || enemyHeroClass == HeroEnum.warrior || enemyHeroClass == HeroEnum.pala || enemyHeroClass == HeroEnum.warlock)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是慢速拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.受伤的托维尔人)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.法庭秩序)
                {
                    if (cards.Count > 3 && 战斗号角 == 0)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "没号角拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    if (棱彩光束 == 0 && (enemyHeroClass == HeroEnum.priest || enemyHeroClass == HeroEnum.demonhunter || enemyHeroClass == HeroEnum.thief))
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是快攻没棱彩拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.淘金客)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.威猛银翼巨龙)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.尼鲁巴蛛网领主)
                {
                    if (enemyHeroClass == HeroEnum.shaman || enemyHeroClass == HeroEnum.pala || enemyHeroClass == HeroEnum.thief)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是慢速拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.螃蟹骑士)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.血骑士领袖莉亚德琳)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.逝者之剑)
                {
                    if (enemyHeroClass == HeroEnum.mage || enemyHeroClass == HeroEnum.hunter || enemyHeroClass == HeroEnum.shaman || enemyHeroClass == HeroEnum.druid || enemyHeroClass == HeroEnum.warrior || enemyHeroClass == HeroEnum.pala || enemyHeroClass == HeroEnum.warlock)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对面是慢速拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.鲜血圣印)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.十字军光环)
                {
                    if (cards.Count >= 3 && 战斗号角 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "有号角拿了";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不拿，赌启动";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.战斗号角)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                            }
                        }
                    }
                }
            }
        }

        public override int getComboPenality(CardDB.Card card, Minion target, Playfield p, Handmanager.Handcard nowHandcard)
        {
            // 无法选中
            if (target != null && target.untouchable)
            {
                return 100000;
            }
            // 初始惩罚值
            int 惩罚值 = 0;
            int 手牌有2费牌 = 0;

            int 牌库 = p.ownDeckSize; // 牌库剩余量
            int 最大法力值 = p.ownMaxMana;
            int 当前法力值 = p.mana;
            int 我方随从数 = p.ownMinions.Count;
            int 敌方随从数 = 0;
            int 敌方地标数 = 0;
            int 打过号角数 = 0;
            int 打过法庭数 = 0;
            int 打过棱彩数 = 0;
            bool 手牌有战斗号角 = false;
            bool 手牌有棱彩光束 = false;
            bool 手牌有决战 = false;
            bool 手牌有十字军 = false;
            bool 我方有螃蟹 = false;
            bool 我方有大莉亚德琳 = false;
            bool 敌方有随船外科医师 = false;
            int buff = 0;
            foreach (CardDB.cardIDEnum s in p.ownSecretsIDList)
            {
                if (s == CardDB.cardIDEnum.TTN_908)
                {
                    buff++;
                }
            }
         
            // 遍历我方坟场
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownGraveyard)
            {
                // 死亡随从
                CardDB.Card rebornMob = CardDB.Instance.getCardDataFromID(e.Key);
                switch (rebornMob.nameCN)
                {
                    case CardDB.cardNameCN.战斗号角: 打过号角数++; break;
                    case CardDB.cardNameCN.法庭秩序: 打过法庭数++; break;
                    case CardDB.cardNameCN.棱彩光束: 打过棱彩数++; break;
                }
            }
            // 遍历我方随从
            foreach (Minion m in p.ownMinions)
            {
                if (m.handcard.card.nameCN == CardDB.cardNameCN.螃蟹骑士)
                {
                    我方有螃蟹 = true;
                }
                if (m.handcard.card.nameCN == CardDB.cardNameCN.血骑士领袖莉亚德琳 && m.Angr > 3)
                {
                    我方有大莉亚德琳 = true;
                }
            }
            //遍历手牌
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.manacost == 2) 手牌有2费牌++;
                switch (hc.card.nameCN)
                {
                    case CardDB.cardNameCN.战斗号角: 手牌有战斗号角 = true; break;
                    case CardDB.cardNameCN.棱彩光束: 手牌有棱彩光束 = true; break;
                    case CardDB.cardNameCN.决战: 手牌有决战 = true; break;
                    case CardDB.cardNameCN.十字军光环: 手牌有十字军 = true; break;
                }
            }
            //遍历敌方随从
            foreach (Minion m in p.enemyMinions)
            {
                if (m.handcard.card.nameCN == CardDB.cardNameCN.随船外科医师)
                {
                    敌方有随船外科医师 = true;
                }
                if (m.handcard.card.type == CardDB.cardtype.MOB && !m.untouchable)
                {
                    敌方随从数++;
                }
                if (m.handcard.card.type == CardDB.cardtype.LOCATION)
                {
                    敌方地标数++;
                }
            }
            switch (card.nameCN)
            {
                //-----------------------------法术-----------------------------------

                case CardDB.cardNameCN.战斗号角:
                    if (我方随从数 >= 3 && 手牌有十字军 && 我方有螃蟹 || (我方随从数 >= 6)) 惩罚值 += 60;
                    else
                        惩罚值 -= 28;
                    break;

                case CardDB.cardNameCN.十字军光环:
                    int 可以攻击随从数 = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.Ready && !m.frozen) 可以攻击随从数++;
                    }
                    if (可以攻击随从数 == 0 && !手牌有决战) 惩罚值 += bonus_mine * 20;
                    else
                        惩罚值 -= 可以攻击随从数 * 16;
                    if (可以攻击随从数 >= 2 && 我方有螃蟹) 惩罚值 -= 46;
                    break;

                case CardDB.cardNameCN.法庭秩序:
                    if (打过法庭数 < 1 && 最大法力值 >= 1 && 敌方随从数 >= 2 && !手牌有棱彩光束 && 打过号角数 < 1 && (p.enemyHeroStartClass == TAG_CLASS.DEMONHUNTER || p.enemyHeroStartClass == TAG_CLASS.PRIEST)) 惩罚值 -= 90;
                    if (最大法力值 >= 2 && !手牌有战斗号角 && 打过号角数 < 1) 惩罚值 -= 70;
                    if (我方随从数 >= 3 && !手牌有十字军 && 我方有螃蟹) 惩罚值 -= 53;
                    惩罚值 -= 16;
                    break;

                case CardDB.cardNameCN.棱彩光束:
                    if (nowHandcard.getManaCost(p) <= 2) 惩罚值 -= 180;
                    if (nowHandcard.getManaCost(p) <= 3) 惩罚值 -= 150;
                    int 三血怪 = 0;
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (m.Hp <= 3)
                        {
                            三血怪++;
                        }
                    }

                    if (p.enemyHeroStartClass == TAG_CLASS.DEMONHUNTER || p.enemyHeroStartClass == TAG_CLASS.PRIEST) 惩罚值 -= 三血怪 * 70;
                    else
                        惩罚值 -= 三血怪 * 60;
                    break;

                case CardDB.cardNameCN.决战:
                    if (当前法力值 - 2 >= 4 - 敌方随从数 + 敌方地标数 && 手牌有棱彩光束) 惩罚值 -= 55;
                    else
                    if (buff > 0 || 我方有大莉亚德琳) 惩罚值 -= 45;
                    else
                    if (敌方随从数 >= 6) 惩罚值 -= 13;
                    else
                    if (敌方有随船外科医师 && buff < 0) 惩罚值 += 55;
                    else
                        惩罚值 += 999;
                    break;

                case CardDB.cardNameCN.鲜血圣印:
                    if (!target.frozen && target.own && (target.nameCN == CardDB.cardNameCN.螃蟹骑士))
                    {
                        惩罚值 -= 22;
                    }
                    else
                    if (!target.frozen && target.own && (target.nameCN == CardDB.cardNameCN.尼鲁巴蛛网领主))
                    {
                        惩罚值 -= 15;
                    }
                    else
                    if (!target.frozen && target.own && (target.Angr == 0))
                    {
                        惩罚值 -= 6;
                    }
                    else
                    if (target.divineshild)
                    {
                        惩罚值 += 8;
                    }
                    else
                    {
                        惩罚值 += 15;
                    }
                    if (!target.silenced && target.nameCN == CardDB.cardNameCN.前沿哨所)
                        惩罚值 += 1000;
                    break;

                case CardDB.cardNameCN.智慧祝福:
                    if (!target.silenced && target.nameCN == CardDB.cardNameCN.前沿哨所)
                        惩罚值 += 1000;
                    else
                    if (!target.Ready || 牌库 < 3 || !target.own)
                    {
                        惩罚值 += 17;
                    }
                    else
                        惩罚值 -= 28;
                    break;

                case CardDB.cardNameCN.幸运币:
                    if (nowHandcard.getManaCost(p) > 0) 惩罚值 += 580;
                    if (最大法力值 == 1 && 手牌有2费牌 < 2) 惩罚值 += 580;
                    if (最大法力值 <= 2 && 手牌有战斗号角) 惩罚值 += 580;
                    break;

                case CardDB.cardNameCN.水晶学:
                    惩罚值 -= 4;
                    break;

                //-----------------------------随从-----------------------------------
                case CardDB.cardNameCN.尼鲁巴蛛网领主:
                    if (p.enemyHeroStartClass != TAG_CLASS.PRIEST)
                        惩罚值 -= 6;
                    break;

                case CardDB.cardNameCN.逝者之剑:
                    if (我方随从数 >= 2 && 我方有螃蟹) 惩罚值 -= 19;
                    else 惩罚值 -= 10;
                    break;

                case CardDB.cardNameCN.血骑士领袖莉亚德琳:
                    if (最大法力值 <= 2 && 敌方随从数 >= 1) 惩罚值 += 25;
                    if (最大法力值 >= 4 && 当前法力值 < 4) 惩罚值 += 45;
                    break;

                case CardDB.cardNameCN.前沿哨所:
                    if (最大法力值 <= 2) 惩罚值 -= 45;
                    //if (最大法力值 <= 3) 惩罚值 -= 14;
                    else 惩罚值 -= 4;
                    break;

                case CardDB.cardNameCN.坚韧的托雷斯:
                    if (最大法力值 >= 5 && 我方随从数 < 3 && !我方有螃蟹 && (!手牌有十字军 || !手牌有战斗号角)) 惩罚值 -= 45;
                    else 惩罚值 -= 16;
                    break;

                case CardDB.cardNameCN.螃蟹骑士:
                    if (最大法力值 == 1) 惩罚值 += 14;
                    if (buff < 0) 惩罚值 += 18;
                    else
                        惩罚值 += 8;
                    break;

                case CardDB.cardNameCN.淘金客:
                    if (最大法力值 == 1) 惩罚值 -= 11;
                    惩罚值 -= 6;
                    break;

                case CardDB.cardNameCN.疯狂的科学家:
                    惩罚值 -= 7;
                    break;

                case CardDB.cardNameCN.受伤的托维尔人:
                    惩罚值 += 2;
                    break;

                //-----------------------------奥秘-----------------------------------
                case CardDB.cardNameCN.救赎:
                    惩罚值 -= 8;
                    break;

                case CardDB.cardNameCN.迅疾救兵:
                    惩罚值 -= 7;
                    break;

                case CardDB.cardNameCN.复仇:
                    惩罚值 -= 7;
                    break;
                case CardDB.cardNameCN.永不屈服:
                case CardDB.cardNameCN.古神在上:
                    if (最大法力值 <= 2 || 我方随从数 < 2) 惩罚值 += 1;
                    else
                    if (我方随从数 > 2 && 我方有螃蟹) 惩罚值 -= 18;
                    else
                        惩罚值 -= 16;
                    break;

                case CardDB.cardNameCN.责难:
                    if (我方随从数 < 2) 惩罚值 += 35;
                    if (我方随从数 > 2 && 当前法力值 <= 2) 惩罚值 -= 16;
                    else
                        惩罚值 += 37;
                    break;
            }
            if (card.type == CardDB.cardtype.SPELL)
            {
                惩罚值 -= 2;
            }
            if (card.type == CardDB.cardtype.HEROPWR)
            {
                if (p.ownSecretsIDList.Contains(CardDB.cardIDEnum.EX1_136) || (手牌有2费牌 >= 1 && !手牌有决战)) 惩罚值 += 35;
                else
                    惩罚值 += 8;
            }
            return 惩罚值;
        }

        /// <summary>
        /// 核心，场面值
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override float getPlayfieldValue(Playfield p)
        {
            // 如果场上的评分值大于-200000，则返回该值
            if (p.value > -200000) return p.value;

            float retval = 0; // 初始化返回值

            // 加上一般的场面价值
            retval += getGeneralVal(p);

            // 自己的抽牌数量，每张牌价值5分
            retval += p.owncarddraw * 5;

            // 危险血量线
            int hpboarder = 3;

            // 不考虑法术伤害加成
            if (p.enemyHeroName == HeroEnum.mage) retval += 2 * p.enemyspellpower;

            // 攻击血量线
            int aggroboarder = 20;

            // 加上血量值
            retval += getHpValue(p, hpboarder, aggroboarder);

            // 出牌的动作数量
            int count = p.playactions.Count;
            int ownActCount = 0; // 自己的动作计数
            bool useAb = false; // 是否使用了英雄技能
            bool attacted = false; // 是否已进行攻击

            // 遍历所有的动作
            for (int i = 0; i < count; i++)
            {
                Action a = p.playactions[i]; // 当前动作
                ownActCount++; // 计数自己的动作数量

                // 根据不同动作类型调整评分
                switch (a.actionType)
                {
                    // 英雄或随从攻击
                    case actionEnum.attackWithMinion:
                    case actionEnum.attackWithHero:
                        if (a.target != null && a.target.isHero)
                        {
                            attacted = true; // 如果攻击了英雄，标记为已攻击
                        }
                        if (a.actionType == actionEnum.attackWithMinion)
                        {
                            int atk = a.own.Angr > 0 ? a.own.Angr + p.anzOldWoman : a.own.Angr;
                            retval += atk * 10;
                        }
                        continue;

                    // 使用英雄技能
                    case actionEnum.useHeroPower:
                        retval += i * 11;
                        useAb = true; // 使用了英雄技能
                        break;


                    //在这里加出牌顺序
                    case actionEnum.playcard:

                        // 判断具体的卡牌，并根据出牌顺序调整评分  减分早下  加分晚下 分数别太极端 会出毛病
                        switch (a.card.card.nameCN)
                        {
                            case CardDB.cardNameCN.幸运币:
                                retval -= i * 10;
                                break;
                            // 排序优先
                            case CardDB.cardNameCN.智慧祝福:
                            case CardDB.cardNameCN.血骑士领袖莉亚德琳:
                                retval -= i * 5;
                                break;
                            case CardDB.cardNameCN.法庭秩序:
                                retval -= i * 3;
                                break;
                            case CardDB.cardNameCN.战斗号角:
                            case CardDB.cardNameCN.十字军光环:
                                retval -= i;
                                break;
                        }
                        break;
                    default:
                        continue;
                }
            }
            // 对手基本随从交换模拟
            //retval -= p.lostDamage;
            retval += getSecretPenality(p); // 奥秘的影响
            retval -= p.enemyWeapon.Angr * 3 + p.enemyWeapon.Durability * 3; // 对方武器影响
            // 返回计算后的场面价值
            return retval;
        }

        /// <summary>
        /// 敌方随从价值 主要等于（HP + Angr） * 4
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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
                case CardDB.cardNameCN.粗暴的猢狲:
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
            }
            return retval;
        }

        /// <summary>
        /// 我方随从价值，大致等于主要等于 （HP + Angr） * 4 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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
            if (m.handcard.card.nameCN == CardDB.cardNameCN.螃蟹骑士 && m.Hp >= 3) retval += 33;
            if (m.handcard.card.nameCN == CardDB.cardNameCN.尼鲁巴蛛网领主 && m.Hp >= 3) retval += 31;
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

            switch (m.handcard.card.nameCN)
            {
                case CardDB.cardNameCN.血骑士领袖莉亚德琳:
                    retval += bonus_mine * 2;
                    break;
                case CardDB.cardNameCN.淘金客:
                    retval += bonus_mine * 2;
                    break;
                case CardDB.cardNameCN.螃蟹骑士:
                    retval += bonus_mine * 3;
                    break;
                case CardDB.cardNameCN.尼鲁巴蛛网领主:
                    retval += bonus_mine * 3;
                    break;
            }
            return retval;
        }

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
                foreach (SecretItem sii in p.enemySecretList)
                {
                    sii.canBe_explosive = false;
                }
            }
            return pen;
        }

    }
}