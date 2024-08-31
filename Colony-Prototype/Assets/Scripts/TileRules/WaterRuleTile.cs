using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "2D/Custom Water Rule Tile")]
public class WaterTileRule : RuleTile<WaterTileRule.Neighbor> {
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Wet = 3; // Define un estado adicional para agua profunda
        public const int Sand = 4; // Define un estado adicional para costa
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor)
        {
            case Neighbor.Wet:
                return tile != null && tile.name == "WetZoneTileRule"; // Cambia el nombre según corresponda
            case Neighbor.Sand:
                return tile != null && tile.name == "Sand_Tile_Rule"; // Cambia el nombre según corresponda
        }
        return base.RuleMatch(neighbor, tile);
    }
}
