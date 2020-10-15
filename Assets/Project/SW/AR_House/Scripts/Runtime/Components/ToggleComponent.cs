using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.SW.AR_House.Scripts.Runtime.Components
{
    public class ToggleComponent : MonoBehaviour
    {
        private readonly Color ActiveColor = Color.white;
        private readonly Color InactiveColor = Color.gray;
        
        private Toggle _toggle;
        private Image _image;

        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _image = GetComponent<Image>();
            
            _toggle.onValueChanged.AddListener(SetToggleColor);
            
            SetToggleColor(_toggle.isOn);
        }

        private void SetToggleColor(bool isOn)
        {
            _image.color = isOn ? ActiveColor : InactiveColor;
        }
    }
}
