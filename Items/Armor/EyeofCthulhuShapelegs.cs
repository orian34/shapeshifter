using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class EyeofCthulhuShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Cthulhu Shapelegs");
			Tooltip.SetDefault("8% increased movement speed \n[c/FF3333:3/3 Eye of Cthulhu Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 19000*5;
			item.rare = 1;
			item.defense = 3;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
		}
		public override void AddRecipes()
		{
			ModRecipe eyeofcthulhushapelegs = new ModRecipe(mod);
			eyeofcthulhushapelegs.AddIngredient(ItemID.Gel, 27);
			eyeofcthulhushapelegs.AddRecipeGroup("anyEvilOre", 20);
			eyeofcthulhushapelegs.AddTile(TileID.Anvils);
			eyeofcthulhushapelegs.SetResult(this);
			eyeofcthulhushapelegs.AddRecipe();
		}
	}
}
