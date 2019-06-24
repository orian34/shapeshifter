using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class MoonLordEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord Emblem");
			Tooltip.SetDefault("'This emblem shows your eldritch god mastery.' \nImproved vision \nIncreases your max number of minions by 3 \n10% increased ranged crit chance \n20% increased melee speed \n[c/99FFCC:Moon Lord Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 2320000*5;
			item.rare = 10;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.sonarPotion = true;
			player.maxMinions += 3;
			player.meleeSpeed += 0.2f;
			player.rangedCrit += 10;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(MoonLordShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MoonLordShapemask");
			recipe.AddIngredient(null, "MoonLordShapeplate");
			recipe.AddIngredient(null, "MoonLordShapelegs");
			recipe.AddIngredient(ItemID.MoonLordTrophy);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
