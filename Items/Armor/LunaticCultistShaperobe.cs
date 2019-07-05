using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LunaticCultistShaperobe : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunatic Cultist Shaperobe");
			Tooltip.SetDefault("Greatly increases your mana pool \n[c/4A1FA1:2/2 Lunatic Cultist Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 48000*5;
			item.rare = 11;
			item.defense = 15;
		}
		public override void UpdateEquip(Player player)
		{
			double x = player.statManaMax2*4f;
			int b = (int)x;
			player.statManaMax2 += b;
		}
		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			equipSlot = mod.GetEquipSlot("LunaticCultistShaperobe_Legs", EquipType.Legs);
		}
		public override void UpdateVanity(Player player, EquipType type)
		{
			player.shoe = 0;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(2859);
			recipe.AddIngredient(ItemID.FragmentNebula,22);
			recipe.AddIngredient(ItemID.LunarBar,16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
