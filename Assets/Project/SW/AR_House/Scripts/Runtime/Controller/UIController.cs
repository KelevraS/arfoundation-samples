using System.Collections.Generic;
using Project.SW.AR_House.Scripts.Runtime.View;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIView view;

        public UIView View => view;
        
        public void ObjectPlaced(bool state)
        {
            view.SetSelectorState(state);
        }
        
        
    }
}
