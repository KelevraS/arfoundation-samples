using System;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class HouseView : MonoBehaviour
    {
        [SerializeField]
        private Animator house;
        
        public Animator House => house;

        private GameObject[] groundFloorObjects;
        private GameObject[] firstFloorObjects;
        private GameObject[] groundFloorFurnitureObjects;
        private GameObject[] firstFloorFurnitureObjects;

        private const string groundFloorTag = "f1";
        private const string firstFloorTag = "f2";
        private const string groundFloorFurnitureTag = "props_1f";
        private const string firstFloorFurnitureTag = "props_2f";

        private void Start()
        {
            groundFloorObjects = FindFloorObject(groundFloorTag);
            firstFloorObjects = FindFloorObject(firstFloorTag);

            groundFloorFurnitureObjects = FindFloorObject(groundFloorFurnitureTag);
            firstFloorFurnitureObjects = FindFloorObject(firstFloorFurnitureTag); 
        }

        public void ActivateCertainFloor(Floor floor)
        {
            switch (floor)
            {
                case Floor.Ground:
                    //SetStatusOfFloorObjects(groundFloorObjects, groundFloorFurnitureObjects,true);
                    SetStatusOfFloorObjects(firstFloorObjects, firstFloorFurnitureObjects,false);
                    break;
                    
                case Floor.First:
                    //SetStatusOfFloorObjects(groundFloorObjects, groundFloorFurnitureObjects,false);
                    SetStatusOfFloorObjects(firstFloorObjects, firstFloorFurnitureObjects, true);
                    break;
            }
        }

        private GameObject[] FindFloorObject(string _tag)
        {
            GameObject[] floorObjects = GameObject.FindGameObjectsWithTag(_tag);

            return floorObjects;
        }

        private void SetStatusOfFloorObjects(GameObject[] objects, GameObject[] furnitures, bool status)
        {
            foreach (var item in objects)
            {
                item.SetActive(status);
            }

            foreach (var item in furnitures)
            {
                item.SetActive(status);
            }
        }
    }
}
