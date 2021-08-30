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

        public MapCellFabric(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public MapCell[,] CreateMapCells(MapCellView prefab)
        {
            _mapCellsArray = new MapCell[_width, _height];
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _mapCellsArray[i, j] = new MapCell {mapCellPrefab = prefab};
                    Debug.Log($"{prefab.name}");
                    //заполнить клеточку тута
                }
            }
            return _mapCellsArray;
        }
        
    }
}
