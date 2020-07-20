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
using Terraria.Localization;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.ComponentModel;
using Shapeshifter.Projectiles;

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

			if (Main.netMode != NetmodeID.Server)
            {
				Ref<Effect> shockwaveRef = new Ref<Effect>(GetEffect("Effects/ShockwaveEffect"));
				Filters.Scene["ShapeshifterShockwave1"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
				Filters.Scene["ShapeshifterShockwave1"].Load();
				Filters.Scene["ShapeshifterShockwave2"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
				Filters.Scene["ShapeshifterShockwave2"].Load();
				Filters.Scene["ShapeshifterShockwave3"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
				Filters.Scene["ShapeshifterShockwave3"].Load();
				Filters.Scene["ShapeshifterShockwave4"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
				Filters.Scene["ShapeshifterShockwave4"].Load();
				Filters.Scene["ShapeshifterShockwave5"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
				Filters.Scene["ShapeshifterShockwave5"].Load();
			}
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Ore", new int[]
			{
			ItemID.CrimtaneOre,
			ItemID.DemoniteOre
			}
			);
			RecipeGroup.RegisterGroup("anyEvilOre", group);
			
			RecipeGroup seeds = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Seed", new int[]
			{
			ItemID.CorruptSeeds,
			ItemID.CrimsonSeeds
			}
			);
			RecipeGroup.RegisterGroup("anyEvilSeed", seeds);
			
			RecipeGroup elight = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Light", new int[]
			{
			ItemID.ShadowOrb,
			ItemID.CrimsonHeart
			}
			);
			RecipeGroup.RegisterGroup("anyEvilLight", elight);
			
			RecipeGroup tier = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 1 Metal Bar", new int[]
			{
			ItemID.CobaltBar,
			ItemID.PalladiumBar
			}
			);
			RecipeGroup.RegisterGroup("anyTier1Bar", tier);
			
			RecipeGroup crowns = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Crown", new int[]
			{
			ItemID.GoldCrown,
			ItemID.PlatinumCrown
			}
			);
			RecipeGroup.RegisterGroup("anyCrown", crowns);
			
			RecipeGroup mirror = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Mirror", new int[]
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

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if(player.ownedProjectileCounts[ModContent.ProjectileType<PrimordialShield>()] > 0)
			{
				if(Main.rand.Next(14) == 0)
				{
					Main.PlaySound(SoundID.Item , player.position, 48);
				}
				return false;
			}
			else
			{
				return true;
			}
		}
    }   
}
