using UnityEngine;

namespace Assets.Scripts
{
    public class boombox : Target {

        private Rigidbody _rigidbody;
		private Vector3 _explosionPos;
        [SerializeField] private float _force;

        [SerializeField] private Jesus _jesus;

        void Start ()
        {
//            _jesus = GameObject.Find("Jesus").GetComponent<Jesus>();
            _rigidbody = GetComponent<Rigidbody>();
            //transform.rotation = Random.rotation;
			_force = 10;
        }
	
        // Update is called once per frame
        void Update () {
            //_rigidbody.AddRelativeForce(transform.forward * _force);
        }

        void OnCollisionStay(Collision collision)
        {
            //transform.rotation = Random.rotation;
			_explosionPos = transform.position + Random.insideUnitSphere * 0.5f;
			_rigidbody.AddExplosionForce(1000.0f, _explosionPos, 5.0f, 0.0f);
        }

        public override string GetTargetType()
        {
            return "Boombox";
        }

        public override void OnLookStart()
        {
            _jesus.CalmDown();
        }

        public override void OnLookUpdate()
        {

        }

        public override void OnLookEnd()
        {

        }
    }
}
