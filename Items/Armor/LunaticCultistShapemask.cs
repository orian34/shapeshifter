using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LunaticCultistShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunatic Cultist Shapemask");
		Tooltip.SetDefault("'This mask gives you mystic understanding.' \nGreatly improved mana regeneration. \n[c/4A1FA1:1/2 Lunatic Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 60000*5;
			item.rare = 11;
			item.defense = 10;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LunaticCultistShaperobe");
		}
		public override void UpdateEquip(Player player)
		{
			player.manaRegenDelayBonus++;
			player.manaRegenBonus += 50;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a mystical sorcerer";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(LunaticCultistShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BossMaskCultist);
			recipe.AddIngredient(ItemID.FragmentNebula,10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
