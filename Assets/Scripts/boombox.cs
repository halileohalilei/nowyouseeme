using UnityEngine;

namespace Assets.Scripts
{
    public class Boombox : Target {

        private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        [SerializeField] private Jesus _jesus;

        void Start ()
        {
//            _jesus = GameObject.Find("Jesus").GetComponent<Jesus>();
            _rigidbody = GetComponent<Rigidbody>();
            transform.rotation = Random.rotation;
        }
	
        // Update is called once per frame
        void Update () {
            _rigidbody.AddRelativeForce(transform.forward * _force);
        }

        void OnCollisionStay(Collision collision)
        {
            transform.rotation = Random.rotation;
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
