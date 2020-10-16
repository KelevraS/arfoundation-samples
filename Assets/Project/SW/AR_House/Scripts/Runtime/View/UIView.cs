using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject selector;
        [SerializeField] private GameObject houseControlUI;
        public void SetSelectorState(bool state)
        {
            selector.SetActive(state);
        }

        public void SetHouseControlUI(bool state)
        {
            houseControlUI.SetActive(state);
        }
    }
}
