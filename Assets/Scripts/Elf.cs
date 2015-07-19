using UnityEngine;

namespace Assets.Scripts
{
    public class Elf : Target
    {
        private GameObject _focusMarker;
        [SerializeField] private float _markerSpeed;
        void Start ()
        {
            _focusMarker = transform.Find("focus marker").gameObject;
            _focusMarker.gameObject.SetActive(false);
        }
	
        void Update () {
            _focusMarker.transform.Rotate(Vector3.up * Time.deltaTime * _markerSpeed);
        }

        public override string GetTargetType()
        {
            return "Elf";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _focusMarker.gameObject.SetActive(true);
        }

        public override void OnLookUpdate()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public override void OnLookEnd()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _focusMarker.gameObject.SetActive(false);
        }
    }
}
