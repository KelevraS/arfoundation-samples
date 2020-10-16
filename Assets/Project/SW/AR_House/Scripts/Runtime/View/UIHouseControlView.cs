using UnityEngine;
using UnityEngine.UI;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class UIHouseControlView : MonoBehaviour
    {
        [SerializeField] private Button roofAction;
        [SerializeField] private Button resetModel;

        public delegate void RoofActing();

        public event RoofActing OnRoofActing;

        public delegate void ResettingModel();

        public event ResettingModel OnModelResetting;

        private void Start()
        {
            roofAction.onClick.AddListener(RoofAct);
            resetModel.onClick.AddListener(ResetModel);
        }

        private void RoofAct()
        {
            OnRoofActing?.Invoke();
        }

        private void ResetModel()
        {
            OnModelResetting?.Invoke();
        }
    }
}
