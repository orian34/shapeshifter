using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class KingSlimeShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Slime Shapelegs");
			Tooltip.SetDefault("9% increased minion damage \n[c/0066CC:3/3 King Slime Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 1100*5;
			item.rare = 1;
			item.defense = 3;
		}
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.09f;
		}
		public override void AddRecipes()
		{
			ModRecipe kingslimeshapelegs = new ModRecipe(mod);
			kingslimeshapelegs.AddIngredient(ItemID.NinjaPants);
			kingslimeshapelegs.AddIngredient(ItemID.Gel, 50);
			kingslimeshapelegs.AddTile(TileID.Solidifier);
			kingslimeshapelegs.SetResult(this);
			kingslimeshapelegs.AddRecipe();
		}
	}
}
