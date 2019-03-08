using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EyeofCthulhuShapeplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Cthulhu Shapeplate");
			Tooltip.SetDefault("Hunger draws you to your enemies \n[c/FF3333:2/3 Eye of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 27;
			item.value = 195000;
			item.rare = 1;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.dash = 2;
		}
		public override void AddRecipes()
		{
			ModRecipe eyeofcthulhushapeplate = new ModRecipe(mod);
			eyeofcthulhushapeplate.AddIngredient(ItemID.EoCShield);
			eyeofcthulhushapeplate.AddRecipeGroup("anyEvilOre", 30);
			eyeofcthulhushapeplate.AddTile(TileID.Anvils);
			eyeofcthulhushapeplate.SetResult(this);
			eyeofcthulhushapeplate.AddRecipe();
		}
	}
}
