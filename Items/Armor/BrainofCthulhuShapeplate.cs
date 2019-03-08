using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BrainofCthulhuShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu Shapeplate");
			Tooltip.SetDefault("Confusion rules among your foes. \n[c/99004C:2/3 Brain of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 12800*5;
			item.rare = 2;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.brainOfConfusion = true;
		}
		public override void AddRecipes()
		{
			ModRecipe brainofcthulhushapeplate = new ModRecipe(mod);
			brainofcthulhushapeplate.AddIngredient(ItemID.BrainOfConfusion);
			brainofcthulhushapeplate.AddIngredient(ItemID.Vertebrae, 13);
			brainofcthulhushapeplate.AddIngredient(ItemID.TissueSample, 27);
			brainofcthulhushapeplate.AddTile(TileID.DemonAltar);
			brainofcthulhushapeplate.SetResult(this);
			brainofcthulhushapeplate.AddRecipe();
		}
	}
}
