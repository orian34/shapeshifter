using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class QueenBeeShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Shapeplate");
			Tooltip.SetDefault("Increases the strength of friendly bees.");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 16300*5;
			item.rare = 3;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.strongBees = true;
		}
		public override void AddRecipes()
		{
			ModRecipe queenbeeshapeplate = new ModRecipe(mod);
			queenbeeshapeplate.AddIngredient(ItemID.HiveBackpack);
			queenbeeshapeplate.AddIngredient(ItemID.BeeWax, 13);
			queenbeeshapeplate.AddIngredient(ItemID.HoneyBlock, 9);
			queenbeeshapeplate.AddIngredient(ItemID.Stinger, 1);
			queenbeeshapeplate.AddTile(TileID.HoneyDispenser);
			queenbeeshapeplate.SetResult(this);
			queenbeeshapeplate.AddRecipe();
		}
	}
}
