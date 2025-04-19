
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_528 : SimTemplate // 避免报错
    {
	    public override void onAuraStarts(Playfield p, Minion own)
	    {
		    if (own.own) p.ownHeroPowerTimes = 1;
		    else p.enemyHeroPowerTimes = 1;
	    }

	    public override void onAuraEnds(Playfield p, Minion own)
	    {
		    if (own.own) p.ownHeroPowerTimes = 0;
		    else p.enemyHeroPowerTimes = 0;
	    }
	}
}
