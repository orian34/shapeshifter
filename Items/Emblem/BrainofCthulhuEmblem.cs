using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class BrainofCthulhuEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu Emblem");
			Tooltip.SetDefault("'This emblem shows your malicious brain mastery.' \nConfusion rules among your foes. \n10% increased magic damage. \n[c/99004C:Brain of Cthulhu Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 35780*5;
			item.rare = 2;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.brainOfConfusion = true;
			player.magicDamage += 0.1f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(BrainofCthulhuShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrainofCthulhuShapemask");
			recipe.AddIngredient(null, "BrainofCthulhuShapeplate");
			recipe.AddIngredient(null, "BrainofCthulhuShapelegs");
			recipe.AddIngredient(ItemID.BrainofCthulhuTrophy);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
