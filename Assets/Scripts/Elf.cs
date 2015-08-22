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
        private bool _isUnderJesusGaze;
        private float _jesusGazeStartTime;
        [SerializeField] private float _jesusTolerance;

        private BloodAndGoreFactory _bloodAndGoreFactory;
        private GiftFactory _giftFactory;

		public AudioClip[] hammerSoundArray;
		public AudioClip hammerSound;
		public Transform giftPrefab;
		public int numHammerHits;
		public Transform giftSpawnPos;

		// for turning the Elf to color.black when he's on fire
		[SerializeField] private bool _shouldBurnToBlack = true;
		private bool _isTurnedToBlack = false;
		private Color elfSkinColor = new Color(0.97f, 0.61f, 0.65f);
		private Renderer torsoRenderer;
		private Renderer legLeftRenderer;
		private Renderer legRightRenderer;
		private Renderer armLeftRenderer;
		private Renderer armRightRenderer;
		private Renderer handLeftRenderer;
		private Renderer handRightRenderer;
		private Renderer headRenderer;
		private Renderer hatRenderer;
		private Renderer noseRenderer;
		private Renderer hatBrimRenderer;
		private Renderer hatBallRenderer;

		public Transform HeadJoint;
		public Transform JesusLookTarget;
        public Transform SantaLookTarget;
		private Quaternion originalDirection;
		private bool lookAtSanta = false;

		private Rigidbody _rigidbody;

        private IJesusDelegate _jesusDelegate;

        void Start ()
        {
            _jesusDelegate = GameObject.Find("Jesus").GetComponent<Jesus>();

            _focusMarker = transform.Find("focus marker").gameObject;
            _armAnimation = GetComponent<Animation>()["elf arm work 2"];
			_armAnimation.speed = Random.Range(0.0f,1.0f);
            _focusMarker.gameObject.SetActive(false);

            _lastTimeStep = Time.time;

			_rigidbody = transform.GetComponent<Rigidbody>();

			GetComponent<AudioSource>().clip = hammerSoundArray[Random.Range(0,hammerSoundArray.Length)];

            _giftFactory = GameObject.Find("Gift Factory").GetComponent<GiftFactory>();
            _bloodAndGoreFactory = GameObject.Find("Blood And Gore Factory").GetComponent<BloodAndGoreFactory>();
			numHammerHits = 0;

			// for turning the Elf to color.black when he's on fire
			torsoRenderer = transform.Find("torso").GetComponent<Renderer>();
//			Debug.Log("torsoRenderer = " + torsoRenderer);
			legLeftRenderer = transform.Find("leg - left").GetComponent<Renderer>();
			legRightRenderer = transform.Find("leg - right").GetComponent<Renderer>();
			armLeftRenderer = transform.Find("arm - left").GetComponent<Renderer>();
			armRightRenderer = transform.Find("Arm Right Joint/arm - right").GetComponent<Renderer>();
			handLeftRenderer = transform.Find("hand - left").GetComponent<Renderer>();
			handRightRenderer = transform.Find("Arm Right Joint/hand - right").GetComponent<Renderer>();
			headRenderer = transform.Find("head joint/head").GetComponent<Renderer>();
			hatRenderer = transform.Find("head joint/elf hat").GetComponent<Renderer>();
			noseRenderer = transform.Find("head joint/nose").GetComponent<Renderer>();
			hatBrimRenderer = transform.Find("head joint/brim").GetComponent<Renderer>();
			hatBallRenderer = transform.Find("head joint/ball").GetComponent<Renderer>();

			// The direction the Elf is looking when game starts.  
			// He looks this direction any time when he can't see Jesus.
            HeadJoint = transform.Find("head joint");
			originalDirection = HeadJoint.rotation;
//			jesusLookTarget = GameObject.Find("Jesus/Jesus Parts Container/eye - left").transform;
			SantaLookTarget = GameObject.Find("Characters/Santa/Santa/santa look target").transform;

			//transform.isStatic = false;
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

			_focusMarker.transform.Rotate(Vector3.up * Time.deltaTime * _armAnimation.speed * 150);

			if (numHammerHits >= 10)
			{
				SpawnGift();
			}
            _shouldBurnToBlack = _isUnderJesusGaze && (Time.time - _jesusGazeStartTime > _jesusTolerance);
            if (_shouldBurnToBlack)
            {
                BurnToBlack();
            }
            
            // Elves will look at Jesus if the head rotation is within normal "human" limits.
			Quaternion angleToTarget = Quaternion.LookRotation(JesusLookTarget.transform.position);
			float angleDiff = Quaternion.Angle(angleToTarget, originalDirection);
			if (!lookAtSanta) {
				if (angleDiff < 90) {
					HeadJoint.transform.LookAt(JesusLookTarget.transform);
				} else {
					HeadJoint.transform.rotation = originalDirection;
				}
			}

            if (_pointOfNoReturn)
            {
                _jesusDelegate.OnElfDestroyed(transform);
                _bloodAndGoreFactory.CreateBloodAndGore(transform.position);
                Destroy(gameObject);
            }
		}
		
		public override string GetTargetType()
        {
            return "Elf";
        }

        public override void OnLookStart()
        {
			if (!_isTurnedToBlack) 
			{
//            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
				_isUnderGaze = true;
				_focusMarker.gameObject.SetActive (true);
				_armAnimation.speed = Mathf.Max (_armAnimation.speed, 1.0f);
				_lastTimeStep = 0f;
			}
		}

        public override void OnLookUpdate()
        {
//            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _armAnimation.speed = _armAnimation.speed*1.5f;

            if (_armAnimation.speed > _pointOfNoReturnThreshold)
            {
                _pointOfNoReturn = true;
            }

			lookAtSanta = true;
			HeadJoint.transform.LookAt(SantaLookTarget.transform);
        }

        public override void OnLookEnd()
        {
//            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
            _isUnderGaze = false;
            _focusMarker.gameObject.SetActive(false);

			lookAtSanta = false;
			HeadJoint.transform.rotation = originalDirection;
        }

		void PlayHammerSound()
		{
			GetComponent<AudioSource>().Play();
			numHammerHits += 1;
		}

		void SpawnGift()
        {
            numHammerHits = 0;
            _giftFactory.CreateGift(giftSpawnPos.position);
//			Vector3 loc = Random.insideUnitSphere;
//			loc.y += 2;
//			Quaternion rot = Random.rotation;
//			Transform instance = Instantiate(giftPrefab, giftSpawnPos.transform.position, rot) as Transform;
//			Rigidbody rb = instance.GetComponent<Rigidbody>();
//			rb.AddExplosionForce(500, giftSpawnPos.transform.position + loc, 100, 3.0F);
		}

		public void BurnToBlack()
		{
			  // object not found... can't worry about this right now
			torsoRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			legLeftRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			legRightRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			armLeftRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			armRightRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			handLeftRenderer.material.color = Color.Lerp(elfSkinColor, Color.black, Time.time * 0.1f);
			handRightRenderer.material.color = Color.Lerp(elfSkinColor, Color.black, Time.time * 0.1f);
			headRenderer.material.color = Color.Lerp(elfSkinColor, Color.black, Time.time * 0.1f);
			hatRenderer.material.color = Color.Lerp(Color.green, Color.black, Time.time * 0.1f);
			noseRenderer.material.color = Color.Lerp(elfSkinColor, Color.black, Time.time * 0.1f);
			hatBrimRenderer.material.color = Color.Lerp(Color.white, Color.black, Time.time * 0.1f);
			hatBallRenderer.material.color = Color.Lerp(Color.white, Color.black, Time.time * 0.1f);

			_isTurnedToBlack = true;
			_rigidbody.isKinematic = true;
		}

        void OnTriggerEnter(Collider other)
        {
            _isUnderJesusGaze = true;
            _jesusGazeStartTime = Time.time;
        }

        void OnTriggerExit(Collider other)
        {
            _isUnderJesusGaze = false;
        }

		public void StopWorking()
		{
			_armAnimation.speed = 0f;
		}
	}
}
