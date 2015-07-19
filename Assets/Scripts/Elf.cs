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
			GetComponent<Animation>()["elf arm work"].speed = GetComponent<Animation>()["elf arm work"].speed * 0.99f;
        }

        public override string GetTargetType()
        {
            return "Elf";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _focusMarker.gameObject.SetActive(true);
			GetComponent<Animation>()["elf arm work"].speed = 1;
        }

        public override void OnLookUpdate()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
			GetComponent<Animation>()["elf arm work"].speed = GetComponent<Animation>()["elf arm work"].speed * 1.1f;
        }

        public override void OnLookEnd()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _focusMarker.gameObject.SetActive(false);
        }
    }
}
