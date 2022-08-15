using Game.Item;
using TMPro;
using UnityEngine;

namespace Game.Player.UI
{
    public sealed class ScoreUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;

        private void Awake()
        {
            ItemController.OnItemCollect += OnItemCollect;
        }

        private void OnItemCollect()
        {
            score.text = Global.CollectedItems.ToString();
        }
    }
}