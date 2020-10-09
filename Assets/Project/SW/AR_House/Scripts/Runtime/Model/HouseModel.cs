﻿using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.Model
{
    public class HouseModel : MonoBehaviour
    {
        public bool IsRoofOpened
        {
            get => _isRoofOpened;
            set
            {
                _isRoofOpened = value;
                OnRoofStateChanged?.Invoke();
            }
        }

        private bool _isRoofOpened;
        
        public delegate void RoofStateChange();

        public event RoofStateChange OnRoofStateChanged;

        public void ChangeRoofState()
        {
            IsRoofOpened = !IsRoofOpened;
        }
    }
}
