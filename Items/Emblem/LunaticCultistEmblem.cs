using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class LunaticCultistEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunatic Cultist Emblem");
			Tooltip.SetDefault("'This emblem shows your mystical sorcerer mastery.' \nGreatly improved mana regeneration \nGreatly increases your mana pool \n[c/4A1FA1:Lunatic Cultist Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 128000*5;
			item.rare = 11;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.manaRegenDelayBonus++;
			player.manaRegenBonus += 50;
			double x = player.statManaMax2*4f;
			int b = (int)x;
			player.statManaMax2 += b;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(LunaticCultistShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LunaticCultistShapemask");
			recipe.AddIngredient(null, "LunaticCultistShaperobe");
			recipe.AddIngredient(ItemID.AncientCultistTrophy);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
