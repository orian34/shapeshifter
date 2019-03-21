using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MechamalgamShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechamalgam Shapemask");
			Tooltip.SetDefault("'This mask is full of potential.' \nIncreases your ranged potential if powered \n[c/8E8E8E:1/3 Mechamalgam Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 30000*5;
			item.rare = 5;
			item.defense = 11;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MechamalgamShapeplate") && legs.type == mod.ItemType("MechamalgamShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a energy-powered amalgam";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(MechamalgamShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofCthulhuShapemask");
			recipe.AddIngredient(ItemID.TwinMask);
			recipe.AddIngredient(ItemID.MechanicalWheelPiece);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
