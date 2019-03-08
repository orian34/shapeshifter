using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EaterofWorldShapeplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Worlds Shapeplate");
			Tooltip.SetDefault("Reduces damage taken by 18% \n[c/003300:2/3 Eater of Worlds Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 27;
			item.value = 12800*5;
			item.rare = 2;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.18f;
		}
		public override void AddRecipes()
		{
			ModRecipe eaterofworldshapeplate = new ModRecipe(mod);
			eaterofworldshapeplate.AddIngredient(ItemID.RottenChunk, 15);
			eaterofworldshapeplate.AddIngredient(ItemID.ShadowScale, 27);
			eaterofworldshapeplate.AddIngredient(3224);
			eaterofworldshapeplate.AddTile(TileID.DemonAltar);
			eaterofworldshapeplate.SetResult(this);
			eaterofworldshapeplate.AddRecipe();
		}
	}
}
