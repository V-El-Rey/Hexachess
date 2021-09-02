using System;
using Controllers.Map.MapGenerator;
using SceneViews.Map;
using Unity.Mathematics;
using UnityEngine;

namespace GameController
{
    public class GameController : MonoBehaviour
    {
        public MapCellView demoPrefab;
        public GameObject demoPlayerPrefab;

        private MapCreationController _mapCreationController;

        public void Start()
        {
            _mapCreationController = new MapCreationController(5,10, demoPrefab);
            //_mapCellSpawnController.SpawnMapCells();
            _mapCreationController.SpawnPlayer_Test();
            Instantiate(demoPlayerPrefab, _mapCreationController.SpawnPlayer_Test(), quaternion.identity);
        }

        public void Update()
        {
            //Почему-то вылазит OutOfRangeException;
            
             
             // if (Input.GetKeyDown(KeyCode.A))
             // {
             //     _mapCreationController.CreateNewRoom(1);
             //     //_mapCreationController.SpawnPlayer_Test();
             //     Instantiate(demoPlayerPrefab, _mapCreationController.SpawnPlayer_Test(), quaternion.identity);
             // }
        }
    }
}
