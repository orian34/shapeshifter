using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class WallofFleshShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh Shapelegs");
			Tooltip.SetDefault("8% increased movement speed \n[c/9E0202:3/3 Wall of Flesh Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 30000*5;
			item.rare = 4;
			item.defense = 7;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofCthulhuShapelegs");
			recipe.AddRecipeGroup("anyTier1Bar", 15);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
