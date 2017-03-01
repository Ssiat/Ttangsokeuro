using UnityEngine;
using System.Collections;

namespace Ssiat.Ttangsokeuro.World
{
    public class WorldGenerator
    {
        public static World CreateWorld(int xSize, int ySize, Vector2 spawnPosition)
        {
            return new World(xSize, ySize, spawnPosition);
        }
    }
}