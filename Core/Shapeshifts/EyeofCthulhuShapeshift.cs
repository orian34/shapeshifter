﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Shapeshifter.Core.Shapeshifts
{
	public class EyeofCthulhuShapeshift : Shapeshift
	{
		public override string BossName => "Eye of Cthulhu";
		public override string ShapeshiftName => "Eye of Cthulhu Shapeshift";
		public override string ShapeDesc => "Increases your combat ability the more you are damaged. Dashing heals you when enraged. Your vision is influenced by your health.";

		public bool eocRage;

		public override void Activate()
		{
			eocRage = false;
		}

		public override void Deactivate()
		{
			eocRage = false;
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[2] = true;
			player.npcTypeNoAggro[5] = true;
			player.npcTypeNoAggro[133] = true;
			player.npcTypeNoAggro[190] = true;
			player.npcTypeNoAggro[192] = true;
			player.npcTypeNoAggro[191] = true;
			player.npcTypeNoAggro[193] = true;
			player.npcTypeNoAggro[194] = true;
			player.npcTypeNoAggro[251] = true;

			if ((double)player.statLife <= (double)player.statLifeMax2 * 0.8)
			{
				player.moveSpeed += 0.1f;
				player.meleeSpeed += 0.1f;
				player.meleeDamage += 0.1f;
				player.thrownDamage += 0.08f;
				if ((double)player.statLife <= (double)player.statLifeMax2 * 0.6)
				{
					player.moveSpeed += 0.15f;
					player.meleeSpeed += 0.15f;
					player.meleeDamage += 0.15f;
					player.thrownDamage += 0.1f;
					if ((double)player.statLife <= (double)player.statLifeMax2 * 0.4)
					{
						player.moveSpeed += 0.15f;
						player.meleeSpeed += 0.15f;
						player.meleeDamage += 0.15f;
						player.thrownDamage += 0.15f;
						player.blind = true;
						eocRage = true;
						if ((double)player.statLife <= (double)player.statLifeMax2 * 0.2)
						{
							player.moveSpeed += 0.5f;
							player.meleeSpeed += 0.5f;
							player.meleeDamage += 0.5f;
							player.thrownDamage += 0.3f;
							player.endurance -= 2f;
							player.detectCreature = true;
						}
					}
					else
					{
						eocRage = false;
					}
				}
			}
		}

		public override void PostUpdateBuffs()
		{
			if (player.eocDash > 8 && player.eocHit > 0 && eocRage)
			{
				double x = 6f*player.meleeDamage;
				int b = (int)x;
				Main.PlaySound(15 , player.position, 0);
				player.statLife += b;
				player.HealEffect(b);
				if (player.statLife > player.statLifeMax2)
				{
					player.statLife = player.statLifeMax2;
				}
			}
			if(!eocRage)
			{
				player.scope = true;
				player.nightVision = true;
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
		}
	}
}
