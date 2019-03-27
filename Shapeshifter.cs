using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shapeshifter.Core;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace Shapeshifter
{
	public class Shapeshifter : Mod
	{
		/// <summary>
		/// All existing Shapeshifts
		/// </summary>
		internal static IList<Type> Shapeshifts;

		public static string GithubUserName { get { return "orian34"; } }
		public static string GithubProjectName { get { return "shapeshifter"; } }
		public Shapeshifter()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public override void Load()
		{
			// Fill shapeshifts arrays
			Shapeshifts = Assembly.GetAssembly(GetType())
				.GetTypes()
				.OrderBy(x => x.FullName, StringComparer.InvariantCulture)
				.Where(t => t.IsClass && !t.IsAbstract && (t.IsSubclassOf(typeof(Shapeshift)) || t == typeof(Shapeshift)))
				.ToList();

			AddEquipTexture(null, EquipType.Legs, "LunaticCultistShaperobe_Legs", "Shapeshifter/Items/Armor/LunaticCultistShaperobe_Legs");
			AddEquipTexture(new Items.Armor.SkeletronShapemaskCursed(), null, EquipType.Head, "SkeletronShapemaskCursed", "Shapeshifter/Items/Armor/SkeletronShapemaskCursed_Head");
			AddEquipTexture(new Items.Armor.PlanteraShapemaskAwakened(), null, EquipType.Head, "PlanteraShapemaskAwakened", "Shapeshifter/Items/Armor/PlanteraShapemaskAwakened_Head");
			AddEquipTexture(new Items.Armor.GolemShapemaskDanger(), null, EquipType.Head, "GolemShapemaskDanger", "Shapeshifter/Items/Armor/GolemShapemaskDanger_Head");
			AddEquipTexture(new Items.Armor.GolemShapeplateDanger(), null, EquipType.Body, "GolemShapeplateDanger", "Shapeshifter/Items/Armor/GolemShapeplateDanger_Body", "Shapeshifter/Items/Armor/GolemShapeplateDanger_Arms");
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Evil Ore", new int[]
			{
			ItemID.CrimtaneOre,
			ItemID.DemoniteOre
			}
			);
			RecipeGroup.RegisterGroup("anyEvilOre", group);
			
			RecipeGroup seeds = new RecipeGroup(() => Lang.misc[37] + " Evil Seed", new int[]
			{
			ItemID.CorruptSeeds,
			ItemID.CrimsonSeeds
			}
			);
			RecipeGroup.RegisterGroup("anyEvilSeed", seeds);
			
			RecipeGroup elight = new RecipeGroup(() => Lang.misc[37] + " Evil Light", new int[]
			{
			ItemID.ShadowOrb,
			ItemID.CrimsonHeart
			}
			);
			RecipeGroup.RegisterGroup("anyEvilLight", elight);
			
			RecipeGroup tier = new RecipeGroup(() => Lang.misc[37] + " Tier 1 Metal Bar", new int[]
			{
			ItemID.CobaltBar,
			ItemID.PalladiumBar
			}
			);
			RecipeGroup.RegisterGroup("anyTier1Bar", tier);
			
			RecipeGroup crowns = new RecipeGroup(() => Lang.misc[37] + " Crown", new int[]
			{
			ItemID.GoldCrown,
			ItemID.PlatinumCrown
			}
			);
			RecipeGroup.RegisterGroup("anyCrown", crowns);
			
			RecipeGroup mirror = new RecipeGroup(() => Lang.misc[37] + " Mirror", new int[]
			{
			ItemID.MagicMirror,
			ItemID.IceMirror
			}
			);
			RecipeGroup.RegisterGroup("anyMirror", mirror);
		}

		public override void AddRecipes()
		{
			RecipeHelper.AddExpertRecipes(this);
		}
	}

	public class Shapeplayer : ModPlayer
	{

		public override void ResetEffects()
		{
		}
		
		public void UpdateLifeRegen2()
		{
			for(int i = 0; i < 200; i++)
			{
			   NPC target = Main.npc[i];
			   if(target.active && target.GetGlobalNPC<ShapeGlobalNPC>(mod).overgenerous)
			   {
				   float lookToX = target.position.X + (float)target.width * 0.5f - player.position.X;
				   float lookToY = target.position.Y - player.position.Y;
				   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
				   if(distance < 222f)
				   {
					   player.statLife += 1;
					   if (player.statLife > player.statLifeMax2)
						{
							player.statLife = player.statLifeMax2;
						}
				   }
			   }
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.type == mod.ProjectileType("PrimordialEnergyBolt"))
			{
				int leng = 333;
				target.AddBuff(mod.BuffType("Overgenerous"), leng, false);
			}
		}
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if(player.ownedProjectileCounts[mod.ProjectileType("PrimordialShield")] > 0)
			{
				if(Main.rand.Next(4) == 0)
				{
					Main.PlaySound(2 , player.position, 48);
				}
				return false;
			}
			else
			{
				return true;
			}
		}

		public override void FrameEffects()
		{
		}
		
	}   
}
