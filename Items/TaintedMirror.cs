using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items
{
	public class TaintedMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shows your inner abilities.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 4;
			item.value = 15000*5;
			item.rare = 2;
			item.UseSound = SoundID.Item43;
		}
		public override bool UseItem(Player player)
		{
			if(player.GetModPlayer<ShapeshifterPlayer>().Shapeshift is Shapeshift)
			{
				string shape = player.GetModPlayer<ShapeshifterPlayer>().Shapeshift.ShapeshiftName;
				string str = player.GetModPlayer<ShapeshifterPlayer>().Shapeshift.ShapeDesc;
				Main.NewText( shape, 190, 120, 50, false );
				Main.NewText( str, 180, 50, 50, false );
			}
			else
			{
				string str = "There is no movement on the surface of the mirror.";
				Main.NewText( str, 60, 60, 120, false );
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("anyMirror");
			recipe.AddIngredient(ItemID.SuspiciousLookingEye);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}