namespace Ssiat.Ttangsokeuro.World
{
	class TileMap
	{
        private float[,] _tiles;

        private int _xSize;
        private int _ySize;

        public int XSize
        {
            get
            {
                return _xSize;
            }

            set
            {
                _xSize = value;
            }
        }

        public int YSize
        {
            get
            {
                return _ySize;
            }

            set
            {
                _ySize = value;
            }
        }

        public TileMap(int xSize = 64, int ySize = 64)
        {
            _tiles = new float[xSize, ySize];

            for ( int i = 0; i < xSize; i++ )
            {
                for ( int j = 0; j < ySize; j++ )
                {
                    _tiles[i, j] = 0.0f;
                }
            }

            this.XSize = xSize;
            this.YSize = ySize;

        }

        public float GetTile(int xPos, int yPos)
        {
            if (IsInsidePosition(xPos, yPos))
                return _tiles[xPos, yPos];
            else
                return -1.0f;
        }

        public void SetTile(float tileNum, int xPos, int yPos)
        {
            if ( IsInsidePosition(xPos, yPos) )
                _tiles[xPos, yPos] = tileNum;
        }

        public bool IsInsidePosition(int xPos, int yPos)
        {
            if ( xPos < 0 || yPos < 0 || xPos >= this.XSize || yPos >= this.YSize)
                return false;
            else
                return true;
        }

        // 최대범위 벗어 났을 때 조정해 줄 함수 필요.
    }
}