using Project.SW.AR_House.Scripts.Runtime.Model;
using UnityEngine.XR.Interaction.Toolkit.AR;

namespace Project.SW.AR_House.Scripts.Runtime.Controller
{
    public class ARPlacementController : ARPlacementInteractable
    {
        protected override void OnEndManipulation(TapGesture gesture)
        {
            if(HouseAR.Instance.Models.House == null)
                base.OnEndManipulation(gesture);
        }
    }
}
