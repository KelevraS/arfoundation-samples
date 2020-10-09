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
            if (controller)
                controller.OnRaycastHit += ChangeRoofState;

            model.OnRoofStateChanged += RoofAction;
        }

        private void RoofAction()
        {
            view.House.SetBool("RoofOpened", model.IsRoofOpened);
        }

        private void ChangeRoofState()
        {
            model.ChangeRoofState();
        }
    }
}
