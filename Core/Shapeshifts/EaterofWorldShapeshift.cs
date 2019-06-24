using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace Shapeshifter.Core.Shapeshifts
{
	public class EaterofWorldShapeshift : Shapeshift
	{
		public override string BossName => "Eater of Worlds";
		public override string ShapeshiftName => "Eater of Worlds Shapeshift";
		public override string ShapeDesc => "You get a stat boost in melee and summoning, as well as the power to summon small eaters when fighting, but you can't summon as much normal minions. Weakness to repeated hits.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[6] = true;
			player.npcTypeNoAggro[94] = true;
			player.npcTypeNoAggro[7] = true;
			player.npcTypeNoAggro[8] = true;
			player.npcTypeNoAggro[9] = true;
			player.npcTypeNoAggro[98] = true;
			player.npcTypeNoAggro[99] = true;
			player.npcTypeNoAggro[100] = true;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.12f;
			player.minionDamage += 0.4f;
			player.maxMinions -= 3; 
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[20] = true;
			player.buffImmune[24] = true;
		}

		public override void OnHitAnything(float x, float y, Entity victim)
		{
			int dmg = (int)(14f*player.minionDamage);
			if(Main.rand.Next(8) == 0)
			{
				int newProj = Projectile.NewProjectile(x, y, 0.1f, 0.1f, ProjectileID.EatersBite, dmg, 0, Main.myPlayer);
				Main.projectile[newProj].timeLeft = 2;
			}
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			playSound = false;
			return true;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			double x = 0.14f*player.statLifeMax2;
			int b = (int)x;
			player.statLife -= b;
			Main.PlaySound(4 , player.position, 1);
			int dmg = (int)(20f*player.meleeDamage);
			for (int i = 0; i < 7; i++)
			{
				float speedX = (float)Main.rand.Next(-150, 151) * 0.01f;
				float speedY = (float)Main.rand.Next(-150, 151) * 0.01f;
				Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, ProjectileID.TinyEater, dmg, 0, Main.myPlayer);
			}
		}
		
		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("EaterofWorldShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("EaterofWorldShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("EaterofWorldShapelegs", EquipType.Legs);
		}
	}
}
