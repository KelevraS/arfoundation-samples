using Project.SW.AR_House.Scripts.Runtime.View;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class UISelectorController : MonoBehaviour
    {
        [SerializeField] private UISelectorView view;
        [SerializeField] private HouseController houseController;

        private void Start()
        {
            houseController = GameObject.FindObjectOfType<HouseController>();
            view.OnFloorSelected += SetFloorStatus;
        }

        private void SetFloorStatus(Floor floor)
        {
            houseController.SetFloorStatus(floor);
        }
    }
}
