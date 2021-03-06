using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SkeletronShapeplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron Shapeplate");
			Tooltip.SetDefault("33% chance to not consume throwing item \n[c/C0AE90:2/3 Skeletron Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 27;
			item.height = 17;
			item.value = 50000*5;
			item.rare = 3;
			item.defense = 6;
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownCost33 = true;
		}
		public override void AddRecipes()
		{
			ModRecipe skeletronshapeplate = new ModRecipe(mod);
			skeletronshapeplate.AddIngredient(ItemID.BoneGlove);
			skeletronshapeplate.AddIngredient(ItemID.Bone, 46);
			skeletronshapeplate.AddTile(TileID.BoneWelder);
			skeletronshapeplate.SetResult(this);
			skeletronshapeplate.AddRecipe();
		}
	}
}
