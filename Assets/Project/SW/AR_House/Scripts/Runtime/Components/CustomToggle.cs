using UnityEngine;
using UnityEngine.UI;

namespace Project.SW.AR_House.Scripts.Runtime.Components
{
    public class CustomToggle : Toggle
    {
        protected override void OnEnable()
        {
            Debug.Log("This OnEnable was called from custom toggle protected method");
            base.OnEnable();
        }
    }
}
