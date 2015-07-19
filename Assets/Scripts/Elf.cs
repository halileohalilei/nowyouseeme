using UnityEngine;

namespace Assets.Scripts
{
    public class Elf : Target
    {
        private GameObject _focusMarker;
        private AnimationState _armAnimation;
        [SerializeField] private float _markerSpeed;
        private bool _isUnderGaze;
        private float _lastTimeStep;
        [SerializeField] private float _threshold;
        private bool _pointOfNoReturn;
        [SerializeField] private float _pointOfNoReturnThreshold;

        public GameObject BloodAndGoreParticles;

        void Start ()
        {
            _focusMarker = transform.Find("focus marker").gameObject;
            _armAnimation = GetComponent<Animation>()["elf arm work"];
            _focusMarker.gameObject.SetActive(false);

            _lastTimeStep = Time.time;
        }
	
        void Update ()
        {
            _lastTimeStep += Time.deltaTime;
            if (_lastTimeStep + Time.deltaTime > _threshold)
            {
                _lastTimeStep = _lastTimeStep % _threshold;
                if (_isUnderGaze)
                {
                    OnLookUpdate();
                }
                else
                {
                    _armAnimation.speed = _armAnimation.speed*0.9f;
                }
            }


            _focusMarker.transform.Rotate(Vector3.up * Time.deltaTime * _markerSpeed);

            if (_pointOfNoReturn)
            {
                GameObject bloodAndGoreParticles = Instantiate(BloodAndGoreParticles, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
            }
        }

        public override string GetTargetType()
        {
            return "Elf";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _isUnderGaze = true;
            _focusMarker.gameObject.SetActive(true);
            _armAnimation.speed = Mathf.Max(_armAnimation.speed, 0.5f);
            _lastTimeStep = 0f;
//			GetComponent<Animation>()["elf arm work"].speed = 1;
        }

        public override void OnLookUpdate()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _armAnimation.speed = _armAnimation.speed*1.5f;

            if (_armAnimation.speed > _pointOfNoReturnThreshold)
            {
                _pointOfNoReturn = true;
            }
        }

        public override void OnLookEnd()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _isUnderGaze = false;
            _focusMarker.gameObject.SetActive(false);
        }
    }
}
