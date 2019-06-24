using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class DukeFishronEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron Emblem");
			Tooltip.SetDefault("'This emblem shows your mutant fish mastery.' \nGrants you improved mobility in water \n6% increased throwing and summoning damage \n[c/00FFFF:Duke Fishron Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 164000*5;
			item.rare = 9;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			if(player.wet && !player.lavaWet && !player.honeyWet)
			{
				player.gravity = 0.2f;
				player.maxFallSpeed = 20f;
				player.releaseJump = true;
				player.wings = 0;
				player.accFlipper = true;
				player.merman = true;
				player.hideMerman = true;
				player.ignoreWater = true;
				player.maxRunSpeed = 3f;
				player.runAcceleration = 3f;
				player.pickSpeed -= 3.5f;
			}
			player.thrownDamage += 0.06f;
			player.minionDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(DukeFishronShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DukeFishronShapemask");
			recipe.AddIngredient(null, "DukeFishronShapeplate");
			recipe.AddIngredient(null, "DukeFishronShapelegs");
			recipe.AddIngredient(ItemID.DukeFishronTrophy);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
