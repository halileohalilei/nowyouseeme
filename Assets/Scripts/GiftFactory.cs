using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GiftFactory : MonoBehaviour {

        public Transform GiftPrefab;
        public Transform SmallGiftPrefab;
        public Transform SmallGiftParticleEffect;
        public Transform SmallGiftSpawnPosition;

        public Transform CreateGift(Vector3 pos)
        {
            Vector3 loc = Random.insideUnitSphere;
            loc.y += 2;
            Quaternion rot = Random.rotation;
            Transform gift = Instantiate(GiftPrefab, pos, rot) as Transform;
            if (gift != null)
            {
                Rigidbody rb = gift.GetComponent<Rigidbody>();
                rb.AddExplosionForce(500, pos + loc, 100, 3.0F);
                Gift giftComponent = gift.GetComponent<Gift>();
                giftComponent.GiftFactory = this;
            }
            return gift;
        }

        public Transform CreateSmallGift(Vector3 particlePos)
        {
            Instantiate(SmallGiftParticleEffect, particlePos, Quaternion.identity);
            Vector3 spawnPos = SmallGiftSpawnPosition.position;
            spawnPos.x = spawnPos.x + Random.Range(-2.0f, 2.0f);
            spawnPos.z = spawnPos.z + Random.Range(-2.0f, 2.0f);
            return Instantiate(SmallGiftPrefab, spawnPos, Quaternion.identity) as Transform;

        }
    }
}
