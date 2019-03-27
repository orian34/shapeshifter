using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MoonLordShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord Shapelegs");
			Tooltip.SetDefault("30% increased melee speed and movement. Gravity has trouble affecting you. \n[c/99FFCC:3/3 Moon Lord Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 500000*5;
			item.rare = 10;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.3f;
			player.moveSpeed += 0.3f;
			Player.jumpHeight = 20;
			player.noFallDmg = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GravityGlobe);
			recipe.AddIngredient(ItemID.FragmentSolar,15);
			recipe.AddIngredient(ItemID.LunarBar,12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void UpdateVanity(Player player, EquipType type)
		{
			player.shoe = 0;
		}
		public override bool DrawLegs()
		{
			return false;
		}
	}
}
