using UnityEngine;

namespace Assets.Scripts
{
    public class Gift : Target
    {

        private Rigidbody _rigidbody;
        [SerializeField] private float _force;


        // Use this for initialization
        void Start () {
	        _rigidbody = gameObject.GetComponent<Rigidbody>();
	        transform.rotation = Random.rotation;
        }
	
        // Update is called once per frame
        void Update () {
	        _rigidbody.AddRelativeForce(transform.forward * _force);
        }

        void OnCollisionEnter(Collision collision)
        {
            transform.rotation = Random.rotation;
        }

        public override string GetTargetType()
        {
            return "Gift";
        }

        public override void OnLookStart()
        {
            Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
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
