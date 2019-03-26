using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EaterofWorldShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater of Worlds Shapemask");
			Tooltip.SetDefault("'This mask is full of corruption.' \n6% increased summoning damage \n[c/127C12:1/3 Eater of Worlds Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 1300*5;
			item.rare = 2;
			item.defense = 5;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EaterofWorldShapeplate") && legs.type == mod.ItemType("EaterofWorldShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.06f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a corrupted monster";
			player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(EaterofWorldShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe eaterofworldshapemask = new ModRecipe(mod);
			eaterofworldshapemask.AddIngredient(ItemID.EaterMask);
			eaterofworldshapemask.AddIngredient(ItemID.ShadowScale, 12);
			eaterofworldshapemask.AddTile(TileID.DemonAltar);
			eaterofworldshapemask.SetResult(this);
			eaterofworldshapemask.AddRecipe();
		}
	}
}
