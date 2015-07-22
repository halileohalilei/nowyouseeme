using UnityEngine;

namespace Assets.Scripts
{
    public class Gift : Target
    {

        private Rigidbody _rigidbody;
        [SerializeField] private float _force;
		public Transform particleEffect;
		public Transform smallGift;
		public Transform giftToSleighLocation;


        // Use this for initialization
        void Start () {
	        //_rigidbody = gameObject.GetComponent<Rigidbody>();
	        //transform.rotation = Random.rotation;
        }
	
        // Update is called once per frame
        void Update () {
	        //_rigidbody.AddRelativeForce(transform.forward * _force);
        }

        void OnCollisionEnter(Collision collision)
        {
            //transform.rotation = Random.rotation;
        }

        public override string GetTargetType()
        {
            return "Gift";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
			Instantiate(particleEffect, transform.position, Quaternion.identity);
			Vector3 smallGiftSpawnPos;
			smallGiftSpawnPos.x = 1.78f + Random.Range(-0.5f,0.5f);
			smallGiftSpawnPos.y = 6.0f;
			smallGiftSpawnPos.z = -27.07f + Random.Range(-0.5f,0.5f);
			Instantiate(smallGift, smallGiftSpawnPos, Quaternion.identity);
			Destroy(gameObject);
        }

        public override void OnLookUpdate()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public override void OnLookEnd()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
