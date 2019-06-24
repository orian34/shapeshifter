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
	public class BrainofCthulhuShapeshift : Shapeshift
	{
		public override string BossName => "Brain of Cthulhu";
		public override string ShapeshiftName => "Brain of Cthulhu Shapeshift";
		public override string ShapeDesc => "Greatly increases magic damage but nullifies mana regen, magic crit and increases mana cost. Mana gets refilled by tapping in weak minds or when you hit enemies with magic. You get random beneficial buffs by hurting enemies with magic.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.magicDamage += 1.15f;
			player.manaCost += 4.55f;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			if (player.FindBuffIndex(BuffID.Poisoned) != -1 || player.FindBuffIndex(BuffID.Bleeding) != -1)	
			{
				if(Main.rand.Next(7) == 0)
				{
					player.statLife -= 1;
				}
				if (player.statLife <= 0)
				{
					player.statLife = 0;
				}
			}
			if(player.magicCrit < 0 || player.magicCrit > 0)
			{
				player.magicCrit = 0;
			}
			double x = player.statManaMax2*0.667f;
			int b = (int)x;
			player.statManaMax2 += b;
			player.manaRegen -= 9999;
			player.manaRegenBonus -= 9999;
			for(int i = 0; i < 200; i++)
			{
			   NPC target = Main.npc[i];
			   if(target.active && target.FindBuffIndex(BuffID.Confused) != -1)
			   {
				   float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
					float lookToY = target.position.Y - player.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
				   if(distance < 555f)
				   {
					   if(Main.rand.Next(3) == 0) player.statMana += 1;
						if (player.statMana > player.statManaMax2)
						{
							player.statMana = player.statManaMax2;
						}
						if (player.statMana < 0)
						{
							player.statMana = 0;
						}
						int newDust = Dust.NewDust(target.position, target.width, target.height, 27, 0f, 0f, 0, default(Color));
						Main.dust[newDust].noGravity = true;
						distance = 20f / distance;
						lookToX *= distance*-1f;
						lookToY *= distance*-1f;
						Main.dust[newDust].velocity.X = lookToX;
						Main.dust[newDust].velocity.Y = lookToY;
				   }
			   }
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.magic && target.CanBeChasedBy())
			{
				double x = 0.36f*damage;
				int b = (int)x;
				player.statMana += b;
				player.ManaEffect(b);
				if (player.statMana > player.statManaMax2)
				{
					player.statMana = player.statManaMax2;
				}
				if (player.statMana < 0)
				{
					player.statMana = 0;
				}
				if(Main.rand.Next(4) == 0)
				{
					for(int i = 0; i < 28; i++)
					{
						int newDust = Dust.NewDust(target.position, target.width, target.height, 21, 0f, -1f, 0, default(Color));
						Main.dust[newDust].noGravity = true;
					}
					target.AddBuff(BuffID.Confused, 600, true);
				}
				if(Main.rand.Next(16) == 0) player.AddBuff(BuffID.Heartreach, 370, true);
				if(Main.rand.Next(27) == 0) player.AddBuff(BuffID.Regeneration, 1020, true);
				if(Main.rand.Next(16) == 0) player.AddBuff(BuffID.Swiftness, 840, true);
				if(Main.rand.Next(39) == 0) player.AddBuff(BuffID.SoulDrain, 1330, true);
				if(Main.rand.Next(23) == 0) player.AddBuff(BuffID.Panic, 300, true);
				if(Main.rand.Next(18) == 0) player.AddBuff(BuffID.NightOwl, 410, true);
				if(Main.rand.Next(31) == 0) player.AddBuff(BuffID.MagicPower, 730, true);
				if(Main.rand.Next(25) == 0) player.AddBuff(BuffID.Hunter, 640, true);
				if(Main.rand.Next(19) == 0) player.AddBuff(BuffID.Dangersense, 530, true);
				if(Main.rand.Next(45) == 0) player.AddBuff(BuffID.RapidHealing, 390, true);
				if(Main.rand.Next(21) == 0) player.AddBuff(BuffID.Clairvoyance, 830, true);
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
			Main.PlaySound(3 , player.position, 1);
		}
		
		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("BrainofCthulhuShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("BrainofCthulhuShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("BrainofCthulhuShapelegs", EquipType.Legs);
		}
	}
}
