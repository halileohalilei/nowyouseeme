using UnityEngine;

namespace Assets.Scripts
{
    public class Silencer : Target {

        // Use this for initialization
        void Start () {
	
        }
	
        // Update is called once per frame
        void Update () {
	
        }

        public override string GetTargetType()
        {
            return "Silencer";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public override void OnLookUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnLookEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}
