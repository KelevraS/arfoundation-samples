using Project.SW.AR_House.Scripts.Runtime.Model;

namespace Project.SW.AR_House.Scripts.Runtime
{
    public class HouseAR
    {
        private static HouseAR _instance = null;

        public static HouseAR Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HouseAR();
                }

                return _instance;
            }
        }

        public ApplicationsModels Models = new ApplicationsModels();
    }
}
