using System;
using Project.SW.AR_House.Scripts.Runtime.View;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputView view;
        
        private void Start()
        {
            //view.OnRaycastHit += RaycastHit;
        }

        public event InputView.RaycastHandler OnRaycastHit;

        private void RaycastHit()
        {
            OnRaycastHit?.Invoke();
            Debug.LogFormat("Raycast hit");
        }
    }
}
