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

        private BloodAndGoreFactory _factory;

		public AudioClip[] hammerSoundArray;
		public AudioClip hammerSound;
		public Transform giftPrefab;
		public int numHammerHits;
		public Transform giftSpawnPos;

        void Start ()
        {
            _focusMarker = transform.Find("focus marker").gameObject;
            _armAnimation = GetComponent<Animation>()["elf arm work"];
            _focusMarker.gameObject.SetActive(false);

            _lastTimeStep = Time.time;

			//hammerSound = AudioClip[Random.Range(0,hammerSoundArray.Length)];

			GetComponent<AudioSource>().clip = hammerSoundArray[Random.Range(0,hammerSoundArray.Length)];


            _factory = GameObject.Find("Blood And Gore Factory").GetComponent<BloodAndGoreFactory>();
			numHammerHits = 0;
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
                    _armAnimation.speed = _armAnimation.speed*0.95f;
                }
            }


            //_focusMarker.transform.Rotate(Vector3.up * Time.deltaTime * _markerSpeed);
			_focusMarker.transform.Rotate(Vector3.up * Time.deltaTime * _armAnimation.speed * 25);

            if (_pointOfNoReturn)
            {
                _factory.CreateBloodAndGore(transform.position);
                Destroy(gameObject);
            }

			if (numHammerHits >= 10)
			{
				SpawnGift();
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
            _armAnimation.speed = _armAnimation.speed*1.2f;

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

		void PlayHammerSound()
		{
			GetComponent<AudioSource>().Play();
			numHammerHits += 1;
			//Debug.Log("numHammerHits = " + numHammerHits);
		}

		void SpawnGift()
		{
			Vector3 loc = Random.insideUnitSphere;
			loc.y += 2;
			Quaternion rot = Random.rotation;
			Transform instance = Instantiate(giftPrefab, giftSpawnPos.transform.position, rot) as Transform;
			Rigidbody rb = instance.GetComponent<Rigidbody>();
			rb.AddExplosionForce(500, giftSpawnPos.transform.position + loc, 100, 3.0F);
			numHammerHits = 0;
		}
	}
}
