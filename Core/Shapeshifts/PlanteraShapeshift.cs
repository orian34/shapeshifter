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
	public class PlanteraShapeshift : Shapeshift
	{
		public override string BossName => "Plantera";
		public override string ShapeshiftName => "Plantera Shapeshift";
		public override string ShapeDesc => "You alternate between sleeping and awakened state. When sleeping, you are incredibly tough but deal very little damage, and when you are awakened, you get increased offensive abilities including melee and ranged damage. Weaknesses of a plant.";

		public float bloomingTimer;
		public float witherTimer;
		public bool awakened;
		public bool awakening;
		public bool sleeping;

		public override void Activate()
		{
			awakened = false;
			sleeping = false;
			awakening = false;
			bloomingTimer = 0f;
			witherTimer = 0f;
		}

		public override void Deactivate()
		{
			awakened = false;
			sleeping = false;
			awakening = false;
			bloomingTimer = 0f;
			witherTimer = 0f;
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[175] = true;
			player.npcTypeNoAggro[56] = true;
			player.npcTypeNoAggro[43] = true;
			player.npcTypeNoAggro[263] = true;
			player.npcTypeNoAggro[264] = true;
			player.npcTypeNoAggro[265] = true;
			player.fishingSkill += 25;
		}

		public override void PostUpdateBuffs()
		{
			if (player.FindBuffIndex(BuffID.Poisoned) != -1 || player.FindBuffIndex(BuffID.Burning) != -1 || player.FindBuffIndex(BuffID.Frostburn) != -1 || player.FindBuffIndex(BuffID.Frozen) != -1 || player.FindBuffIndex(BuffID.CursedInferno) != -1 || player.FindBuffIndex(BuffID.OnFire) != -1)	
			{
				if(Main.rand.Next(11) == 0)
				{
					player.statLife -= 1;
				}
				if (player.statLife <= 0)
				{
					player.statLife = 0;
				}
				player.endurance -= 0.4f;
			}
			int x = (int)player.position.X/16;
            int y = (int)player.position.Y/16;
			if(bloomingTimer > 0)
			{
				sleeping = true;
				bloomingTimer -= 2f;
				player.statDefense += 12;
				player.lifeRegen += 6;
				player.moveSpeed -= 0.2f;
				player.meleeSpeed -= 0.7f;
				player.meleeDamage -= 0.75f;
				player.thrownDamage -= 0.75f;
				player.rangedDamage -= 0.75f;
				player.minionDamage -= 0.75f;
				player.magicDamage -= 0.75f;
				player.maxMinions -= 6; 
				if(bloomingTimer > 0 && (player.ZoneOverworldHeight && Main.tile[x,y].wall == 0 && Main.dayTime || player.ZoneJungle))
				{
					bloomingTimer -= 2f;
					player.lifeRegen += 8;
					player.statDefense += 12;
					player.dryadWard = true;
					player.endurance += 0.2f;
				}
				if(bloomingTimer < 1)
				{
					float t = Main.rand.Next(7200,12601);
					witherTimer += t;
					sleeping = false;
					Main.PlaySound(15 , player.position, 0);
					awakening = true;
				}
				
			}
			if(witherTimer > 0)
			{
				awakened = true;
				witherTimer -= 2f;
				player.moveSpeed += 0.1f;
				player.meleeSpeed += 0.15f;
				player.meleeDamage += 0.1f;
				player.rangedDamage += 0.08f;
				if(witherTimer > 0 && (!player.ZoneOverworldHeight || Main.tile[x,y].wall > 0 || !Main.dayTime)&& !player.ZoneJungle)
				{
					witherTimer -= 2f;
				}
				else
				{
					player.moveSpeed += 0.2f;
					player.meleeSpeed += 0.2f;
					player.meleeDamage += 0.2f;
					player.rangedDamage += 0.12f;
					player.dryadWard = true;
					if (player.thorns < 1f)
					{
						player.thorns += 0.35f;
					}
				}
			}
			if(bloomingTimer < 1 && witherTimer < 1)
			{
				float t = Main.rand.Next(14400,25201);
				bloomingTimer += t;
				awakened = false;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(awakened && (proj.ranged || proj.melee))
			{
				if(Main.rand.Next(9) == 0)
				{
					target.AddBuff(BuffID.Poisoned, 666, true);
				}
			}
		}
		
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			if(awakened && item.melee)
			{
				if(Main.rand.Next(9) == 0)
				{
					target.AddBuff(BuffID.Venom, 789, true);
				}
				else
				{
					target.AddBuff(BuffID.Poisoned, 987, true);
				}
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
			if(sleeping)
			{
				for (int i = 0; i < 5; i++)
				{
					int r = (int)Main.rand.Next(567,572);
					int dmg = (int)Main.rand.Next(70,101);
					Projectile.NewProjectile(player.position.X+Main.rand.Next(-16,17), player.position.Y+Main.rand.Next(-32,33), 0f, 0f, r, dmg, 0, Main.myPlayer);
				}
			}
		}
		
		public override void FrameEffects()
		{
			if(awakening)
			{
				for (int i = 0; i < 30; i++)
				{
					int newDust = Dust.NewDust(player.position, player.width + 4, player.height + 4, 3, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
				awakening = false;
			}
			if(awakened)
			{
				if(player.armor[10].headSlot < 0) {player.head = mod.GetEquipSlot("PlanteraShapemaskAwakened", EquipType.Head);}
			}
		}
	}
}
