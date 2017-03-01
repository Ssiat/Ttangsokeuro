using UnityEngine;
using System.Collections;

namespace Ssiat.Ttangsokeuro.World
{
	public class World
	{
        private TileMap _tileMap;

        private Vector2 _spawnPosition;

        // 리펙토링 필요.
        public World()
        {
            _tileMap = new TileMap(64, 64);

            _spawnPosition = new Vector2(0.0f, 0.0f);
        }

        public World(int xSize, int ySize, Vector2 spawnPosition)
		{
            _tileMap = new TileMap(xSize, ySize);

            _spawnPosition = spawnPosition;
		}
	}
}