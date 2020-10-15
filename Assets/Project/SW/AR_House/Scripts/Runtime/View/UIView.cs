using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject selector;
        public void SetSelectorState(bool state)
        {
            selector.SetActive(state);
        }
    }
}
