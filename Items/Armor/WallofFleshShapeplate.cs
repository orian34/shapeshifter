using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class WallofFleshShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh Shapeplate");
			Tooltip.SetDefault("8% increased melee speed \n[c/9E0202:2/3 Wall of Flesh Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 42800*5;
			item.rare = 4;
			item.defense = 8;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.08f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemonHeart);
			recipe.AddIngredient(null, "EyeofCthulhuShapeplate");
			recipe.AddRecipeGroup("anyTier1Bar", 20);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
