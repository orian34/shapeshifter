using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SkeletronShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron Shapelegs");
			Tooltip.SetDefault("4% increased throwing damage");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 25000;
			item.rare = 3;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.04f;
		}
		public override void AddRecipes()
		{
			ModRecipe skeletronshapelegs = new ModRecipe(mod);
			skeletronshapelegs.AddIngredient(ItemID.Bone, 38);
			skeletronshapelegs.AddTile(TileID.BoneWelder);
			skeletronshapelegs.SetResult(this);
			skeletronshapelegs.AddRecipe();
		}
	}
}
