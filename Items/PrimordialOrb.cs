using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;
using Shapeshifter.Projectiles;

namespace Shapeshifter.Items
{
	public class PrimordialOrb : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The catalyst to the primordial magic.");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.magic = true;
			item.mana = 333;
			item.width = 20;
			item.height = 20;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 1000000*5;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("PrimordialMissile");
			item.shootSpeed = 16f;
		}
		public override bool Shoot (Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(player.FindBuffIndex(BuffID.ManaSickness) != -1)
			{
				string str = "Your head is throbbing!";
				Main.NewText( str, 234, 0, 102, false );
				return false;
			}
			if(player.GetModPlayer<ShapeshifterPlayer>().Shapeshift is LunaticCultistShapeshift)
			{
				LunaticCultistShapeshift sp = (LunaticCultistShapeshift)player.GetModPlayer<ShapeshifterPlayer>().Shapeshift;
				if(sp.primeFire)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PrimordialEnergyBolt"), 1, knockBack, player.whoAmI);
					return false;
				}
				else if(sp.primeEarth)
				{
					int d = (int)(player.magicDamage*Main.rand.Next(3000,3999));
					Projectile.NewProjectile(position.X, position.Y, speedX/10f, speedY/10f, mod.ProjectileType("PrimordialGravity"), d, 0f, player.whoAmI);
					return false;
				}
				else if(sp.primeWater)
				{
					if(player.ownedProjectileCounts[mod.ProjectileType("PrimordialShield")] < 1)
					{
						int d = (int)(player.magicDamage*Main.rand.Next(200,299));
						Projectile.NewProjectile(player.position.X-23, player.position.Y-15, 0f, 0f, mod.ProjectileType("PrimordialShield"), d, knockBack, player.whoAmI);
					}
					return false;
				}
				else if(sp.primeWind)
				{
					for(int i = 0; i < 200; i++)
					{
					   NPC target = Main.npc[i];
					   if(!target.friendly && target.active && !target.immortal && (!target.dontTakeDamage || target.type == NPCID.LunarTowerStardust || target.type == NPCID.LunarTowerSolar || target.type == NPCID.LunarTowerNebula || target.type == NPCID.LunarTowerVortex) && !target.dontTakeDamageFromHostiles && target.timeLeft > 0)
					   {
						   float lookToX = target.position.X + (float)target.width * 0.5f - Main.MouseWorld.X;
						   float lookToY = target.position.Y - Main.MouseWorld.Y;
						   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
						   if(distance < 555f)
						   {
							   int d = (int)(player.magicDamage*Main.rand.Next(2000,3501));
							   player.ApplyDamageToNPC(target, d, knockBack, 0, false);
						   }
					   }
					}
					for(int i = 0; i < 1001; i++)
					{
					   Projectile proj = Main.projectile[i];
					   float goToX = proj.position.X + (float)proj.width * 0.5f - Main.MouseWorld.X;
					   float goToY = proj.position.Y - Main.MouseWorld.Y;
					   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
					   if(distance < 555)
					   {
						   goToX *= (1f/distance)*5f;
							goToY *= (1f/distance)*5f;
						   proj.velocity.X = goToX;
							proj.velocity.Y = goToY;
					   }
					}
					Main.PlaySound(4 , player.position, 43);
					Projectile dummy = new Projectile();
					dummy.SetDefaults(ModContent.ProjectileType<Shockwave>());
					Projectile.NewProjectile(Main.MouseWorld.X - dummy.width / 4, Main.MouseWorld.Y - dummy.height / 4, 0f, 0f, mod.ProjectileType("Shockwave"), 0, 0, player.whoAmI);
					return false;
				}
				else {return true;}
			}
			else
			{
				string str = "You lack the knowledge required to use the catalyst!";
				Main.NewText( str, 234, 0, 102, false );
				return false;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalBall);
			recipe.AddIngredient(ItemID.DirtRod);
			recipe.AddIngredient(ItemID.RainbowRod);
			recipe.AddIngredient(ItemID.IceRod);
			recipe.AddIngredient(ItemID.RodofDiscord);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}