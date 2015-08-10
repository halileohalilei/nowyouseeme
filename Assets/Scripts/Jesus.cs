using UnityEngine;

namespace Assets.Scripts
{
    public class Jesus : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPointTransforms;

        private void SpawnAtNewPoint()
        {
            int randomPointIndex = Random.Range(0, _spawnPointTransforms.Length - 1);
            Transform randomPoint = _spawnPointTransforms[randomPointIndex];
            transform.position = randomPoint.position;
            transform.rotation = randomPoint.rotation;
        }
    }
}
