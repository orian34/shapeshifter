using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class QueenBeeShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen Bee Shapemask");
			Tooltip.SetDefault("'This mask breaks your mind.' \n4% increased ranged damage");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 300*5;
			item.rare = 3;
			item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("QueenBeeShapeplate") && legs.type == mod.ItemType("QueenBeeShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.04f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a swarm queen";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(QueenBeeShapeshift));

		}
		public override void AddRecipes()
		{
			ModRecipe queenbeeshapemask = new ModRecipe(mod);
			queenbeeshapemask.AddIngredient(ItemID.BeeMask);
			queenbeeshapemask.AddIngredient(ItemID.BeeWax, 6);
			queenbeeshapemask.AddIngredient(ItemID.HoneyBlock, 4);
			queenbeeshapemask.AddTile(TileID.HoneyDispenser);
			queenbeeshapemask.SetResult(this);
			queenbeeshapemask.AddRecipe();
		}
	}
}
