using Game.Item;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Platforms
{
    public sealed class PlatformController : MonoBehaviour
    {
        private ItemPlaceholderController[] _itemPlaceholders;
        private Material _material;

        private void Awake()
        {
            _itemPlaceholders = GetComponentsInChildren<ItemPlaceholderController>();

            _material = GetComponent<Renderer>().material;
            _material.color = Random.ColorHSV();
        }

        public void MoveForward(Vector3 newPosition)
        {
            transform.position = newPosition;
            _material.color = Random.ColorHSV();

            foreach (var itemPlaceholder in _itemPlaceholders)
                itemPlaceholder.RespawnItem();
        }
    }
}