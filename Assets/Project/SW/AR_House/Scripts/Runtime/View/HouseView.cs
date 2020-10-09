using UnityEngine;

namespace Project.SW.AR_House.Scripts.Runtime.View
{
    public class HouseView : MonoBehaviour
    {
        [SerializeField]
        private Animator house;
        
        public Animator House => house;
    }
}
