using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "2D/Custom Wet Zone Rule Tile")]
public class WetZoneTileRule : RuleTile<WetZoneTileRule.Neighbor> {
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Sand = 3; // Define un estado adicional para Playa
        public const int Water = 4; // Define un estado adicional para Agua
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor)
        {
            case Neighbor.Sand:
                return tile != null && tile.name == "Sand_Tile_Rule"; // Cambia el nombre según corresponda
            case Neighbor.Water:
                return tile != null && tile.name == "RuleWater"; // Cambia el nombre según corresponda
        }
        return base.RuleMatch(neighbor, tile);
    }
}
