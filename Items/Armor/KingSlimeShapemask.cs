using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class KingSlimeShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Slime Shapemask");
			Tooltip.SetDefault("'This mask has a slimy aura.' \nIncreased number of Minions \n10% increased magic damage \n[c/0066CC:1/3 King Slime Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 3000*5;
			item.rare = 1;
			item.defense = 3;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("KingSlimeShapeplate") && legs.type == mod.ItemType("KingSlimeShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions++;
			player.magicDamage += 0.1f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a slime";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(KingSlimeShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.KingSlimeMask);
			recipe.AddRecipeGroup("anyCrown");
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
