using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Item
{
    public sealed class ItemController : MonoBehaviour
    {
        public static event Notify OnItemCollect;

        private void Start()
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        private void OnTriggerEnter(Collider other)
        {
            Global.CollectedItems++;

            OnItemCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}