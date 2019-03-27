using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DukeFishronShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron Shapemask");
			Tooltip.SetDefault("'This mask is smelling fishy.' \n7% Increased minion damage and reduced knockback \n[c/00FFFF:1/3 Duke Fishron Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 60000*5;
			item.rare = 9;
			item.defense = 22;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DukeFishronShapeplate") && legs.type == mod.ItemType("DukeFishronShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.07f;
			player.minionKB = -10f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a mutant fish";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(DukeFishronShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DukeFishronMask);
			recipe.AddIngredient(ItemID.SharkFin,3);
			recipe.AddIngredient(ItemID.Bacon);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
