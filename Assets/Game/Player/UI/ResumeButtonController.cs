using UnityEngine;

namespace Game.Player.UI
{
    public sealed class ResumeButtonController : MonoBehaviour
    {
        [SerializeField] public PlayerUIController playerUI;

        public void OnClick()
        {
            playerUI.OnEscapePressed();
        }
    }
}