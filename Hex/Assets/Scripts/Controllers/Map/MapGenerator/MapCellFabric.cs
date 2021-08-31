using SceneViews.Map;
using Struct.MapCellStruct;
using UnityEngine;

namespace Controllers.Map.MapGenerator
{
    public class MapCellFabric
    {
        private int _width;
        private int _height;
        

        private MapCell[,] _mapCellsArray;

        public MapCellFabric(int width)
        {
            _width = width;
        }

        public MapCell[,] CreateMapCells(MapCellView prefab)
        {
            _mapCellsArray = new MapCell[_width, _width];
            for (int i = 0; i < _width -1; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _mapCellsArray[i, j] = new MapCell {mapCellPrefab = prefab};
                    // Debug.Log($"{prefab.name}");
                    // заполнить клеточку тута

                    if ((j < 2 && (i < 1)) ^ (j > _width - 3) && (i < 1))
                    {
                        _mapCellsArray[i, j].waterBorder = true;
                    }

                    if ((j < 1 && i == 2) ^ (j == _width -1) && (i == 2))
                    {
                        _mapCellsArray[i, j].waterBorder = true;
                    }

                    if ((j < 1 && i == 1) ^ (j > _width - 3) && (i == 1))
                    {
                        _mapCellsArray[i, j].waterBorder = true;
                    }

                    if (i == 3 && j == _width - 1)
                    {
                        _mapCellsArray[i, j].waterBorder = true;
                    }

                    // if (i != _width / 2 - 1 && ((j < 1) ^ (j > _width - 2)))
                    // {
                    //     _mapCellsArray[i, j].waterBorder = true;
                    // }
                }
            }
            return _mapCellsArray;
        }
        
    }
}
