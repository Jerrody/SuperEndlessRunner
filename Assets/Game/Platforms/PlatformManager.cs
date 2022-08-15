using System.Collections.Generic;
using UnityEngine;

namespace Game.Platforms
{
    public sealed class PlatformManager : MonoBehaviour
    {
        [SerializeField] private uint platformsToSpawn;
        [SerializeField] private PlatformController platform;
        [SerializeField] private Transform player;

        private List<PlatformController> _platforms;
        private float _newPlatformPosition;
        private float _platformZAxisLength;
        private int _currentLastPlatform;

        private void Awake()
        {
            _platformZAxisLength = platform.transform.localScale.z;
            _platforms = new List<PlatformController>((int)platformsToSpawn);
            Global.CollectedItems = 0;
        }

        private void Start()
        {
            for (var i = 0; i < platformsToSpawn; i++)
            {
                var spawnedPlatform = Instantiate(platform, Vector3.forward * _newPlatformPosition,
                    Quaternion.identity);
                _platforms.Add(spawnedPlatform);
                _newPlatformPosition += _platformZAxisLength;
            }
        }

        private void Update()
        {
            if (player.position.z - (_platformZAxisLength / 1.5f) >
                _newPlatformPosition - (_platforms.Count * _platformZAxisLength))
            {
                MoveForwardLast(_currentLastPlatform);
                _currentLastPlatform = (_currentLastPlatform + 1) % _platforms.Count;
            }
        }

        private void MoveForwardLast(int platformIndex)
        {
            _platforms[platformIndex].MoveForward(Vector3.forward * _newPlatformPosition);
            _newPlatformPosition += _platformZAxisLength;
        }
    }
}