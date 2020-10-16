using System;
using Project.SW.AR_House.Scripts.Runtime.View;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class UIHouseController : MonoBehaviour
    {
        [SerializeField] private UIHouseControlView houseControlView;

        [SerializeField] private HouseController houseController;

        private void Start()
        {
            houseControlView.OnRoofActing += RoofAct;
            houseControlView.OnModelResetting += ModelReset;
        }

        private void OnEnable()
        {
            houseController = FindObjectOfType<HouseController>();
        }

        private void OnDisable()
        {
            houseController = null;
        }

        private void RoofAct()
        {
            //houseController.RoofAct();
            houseController.ChangeRoofState();
        }

        private void ModelReset()
        {
            HouseAR.Instance.Models.House = null;
            Destroy(houseController.gameObject);
        }
    }
}
