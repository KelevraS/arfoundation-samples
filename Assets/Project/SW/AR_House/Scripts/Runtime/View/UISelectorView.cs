using UnityEngine;
using UnityEngine.UI;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class UISelectorView : MonoBehaviour
    {
        [SerializeField] private Toggle groundToggle;
        [SerializeField] private Toggle firstFloorToggle;

        public delegate void FloorSelected(Floor floor);

        public event FloorSelected OnFloorSelected;

        private void Start()
        {
            groundToggle.onValueChanged.AddListener(GroundSelectorChangedState);
            firstFloorToggle.onValueChanged.AddListener(FirstSelectorChangedState);
        }

        private void GroundSelectorChangedState(bool state)
        {
            OnFloorSelected?.Invoke(Floor.Ground);
        }

        private void FirstSelectorChangedState(bool state)
        {
            OnFloorSelected?.Invoke(Floor.First);
        }
    }

    public enum Floor
    {
        Ground,
        First
    }
}
