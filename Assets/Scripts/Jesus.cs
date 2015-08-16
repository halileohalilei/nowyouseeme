﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IJesusDelegate
    {
        void OnElfDestroyed(Transform elf);
    }

    public class Jesus : MonoBehaviour, IJesusDelegate
    {
        [SerializeField] private Transform[] _spawnPointTransforms;
        private Transform _jesusParts;
        private Transform _laserBeams;
        private LaserBeams _laserBeamsComponent;

        private ArrayList _targets;

        private float _nextSpawnTime;

        [SerializeField] private float _minSpawnTime;
        [SerializeField] private float _maxSpawnTime;

        private bool _isAnnihilating;

        void Start()
        {
            _jesusParts = transform.FindChild("Jesus Parts Container");
            _laserBeams = _jesusParts.FindChild("Laser Beam Base");
            _laserBeamsComponent = _laserBeams.GetComponent<LaserBeams>();

            Transform tmp = transform.parent.GetChild(1); //bad programming
            _targets = new ArrayList();
            for (int i = 0; i < tmp.childCount; i++)
            {
                _targets.Add(tmp.GetChild(i));
            }

            DetermineNextSpawnTime();
        }

        private float _timeSinceLastMovement;

        private void FixedUpdate()
        {
            if (Time.time > _nextSpawnTime)
            {
                FuckShitUp();
            }

            if (_isAnnihilating)
            {
                if (_timeSinceLastMovement > 5)
                {
                    _timeSinceLastMovement = 0;
                    MoveToNewPoint();
                }
                _timeSinceLastMovement += Time.deltaTime;
            }
        }

        private void MoveToNewPoint()
        {
            int randomPointIndex = Random.Range(0, _spawnPointTransforms.Length - 1);
            Transform randomPoint = _spawnPointTransforms[randomPointIndex];
            transform.position = randomPoint.position;
            transform.rotation = randomPoint.rotation;

            _laserBeams.localRotation = Quaternion.Euler(0, 180, 0);
            _laserBeamsComponent.TargetRotation = PickNewTarget();
        }

        public void OnElfDestroyed(Transform elf)
        {
            _targets.Remove(elf);
        }

        public Quaternion PickNewTarget()
        {
            if (_targets.Count > 0)
            {
                int newTargetIndex = Random.Range(0, _targets.Count);
                return Quaternion.LookRotation(((Transform)_targets[newTargetIndex]).position - _laserBeams.position);
            }

            return Quaternion.identity;
        }

        public void CalmDown()
        {
            if (_isAnnihilating)
            {
                _isAnnihilating = false;
                _timeSinceLastMovement = 0;
                _jesusParts.gameObject.SetActive(false);
                DetermineNextSpawnTime();
                _laserBeamsComponent.SetSpeedBackToMin();
            }
        }

        public void FuckShitUp()
        {
            _nextSpawnTime = Mathf.Infinity;
            _isAnnihilating = true;
            _jesusParts.gameObject.SetActive(true);
        }

        private void DetermineNextSpawnTime()
        {
            _nextSpawnTime = Time.time + Random.Range(_minSpawnTime, _maxSpawnTime);
        }
    }
}
