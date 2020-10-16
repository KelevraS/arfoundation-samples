using System;
using Project.SW.AR_House.Scripts.Runtime.Model;
using Project.SW.AR_House.Scripts.Runtime.View;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class HouseController : MonoBehaviour
    {
        [SerializeField] private HouseView view;
        [SerializeField] private HouseModel model;

        [SerializeField] private InputController controller;

        private void Start()
        {
            controller = FindObjectOfType<InputController>();
            
            
            if (controller)
                controller.OnRaycastHit += ChangeRoofState;

            model.OnRoofStateChanged += RoofAction;
        }

        private void RoofAction()
        {
            Debug.LogFormat("OpenRoof");
            view.House.SetBool("RoofOpened", model.IsRoofOpened);
        }

        public void ChangeRoofState()
        {
            model.ChangeRoofState();
        }

        public void SetFloorStatus(Floor floor)
        {
            view.ActivateCertainFloor(floor);
        }

        public void RoofAct()
        {
            RoofAction();
        }
    }
}
