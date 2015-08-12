using UnityEngine;

namespace Assets.Scripts
{
    public class Jesus : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPointTransforms;
        private Transform _jesusParts;
        private Transform _laserBeams;
        private LaserBeams _laserBeamsComponent;

        private float _nextSpawnTime;

        void Start()
        {
            _jesusParts = transform.FindChild("Jesus Parts Container");
            _laserBeams = _jesusParts.FindChild("Laser Beam Base");
            _laserBeamsComponent = _laserBeams.GetComponent<LaserBeams>();
//            _jesusParts.gameObject.SetActive(false);
        }

        private float _timeSinceLastSpawn;
        private void Update()
        {
            if (_timeSinceLastSpawn > 5)
            {
                _timeSinceLastSpawn = 0;
                SpawnAtNewPoint();
            }
            _timeSinceLastSpawn += Time.deltaTime;
        }

        private void SpawnAtNewPoint()
        {
            int randomPointIndex = Random.Range(0, _spawnPointTransforms.Length - 1);
            Transform randomPoint = _spawnPointTransforms[randomPointIndex];
            transform.position = randomPoint.position;
            transform.rotation = randomPoint.rotation;

            _laserBeams.localRotation = Quaternion.Euler(0, 180, 0);
            _laserBeamsComponent.PickNewTarget();
        }
    }
}
