using System;
using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class InputView : MonoBehaviour
    {
        private const float MaxDistance = 100f;
        private const int LayerMask = 1 << 10;

        private RaycastHit _hit;
        private Ray _ray;

        private Camera _camera;

        public delegate void RaycastHandler();

        public event RaycastHandler OnRaycastHit;

        private void Start()
        {
            _camera = GetComponent<Camera>();

            if (!_camera)
                enabled = false;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, MaxDistance, ~LayerMask))
            {
                OnRaycastHit?.Invoke();
            }
        }
    }
}
