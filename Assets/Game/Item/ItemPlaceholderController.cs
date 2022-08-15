using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Item
{
    public sealed class ItemPlaceholderController : MonoBehaviour
    {
        [SerializeField] private ItemController itemToSpawn;
        [SerializeField] private float itemSpawnRate = 1.0f;
        [SerializeField] private float spawnPositionOffset = 2.75f;

        private ItemController _item;

        private void Start()
        {
            SpawnItem();
        }

        private void SpawnItem()
        {
            if (!RandomBool()) return;

            var spawnPosition = Random.Range(0, 3);
            var position = transform.position;

            position = spawnPosition switch
            {
                1 => new Vector3(spawnPositionOffset, position.y, position.z),
                2 => new Vector3(-spawnPositionOffset, position.y, position.z),
                _ => position
            };

            _item = Instantiate(itemToSpawn, position, Quaternion.identity);
        }

        public void RespawnItem()
        {
            if (_item != null)
                Destroy(_item.gameObject);

            if (RandomBool())
                SpawnItem();
        }

        private bool RandomBool()
        {
            return Random.Range(0.0f, 11 * itemSpawnRate) > 5.0f;
        }
    }
}