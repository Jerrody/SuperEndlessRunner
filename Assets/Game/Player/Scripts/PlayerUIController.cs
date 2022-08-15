using System;
using TMPro;
using UnityEngine;

namespace Game.Player
{
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private Canvas hud;
        [SerializeField] private Canvas escape;

        [SerializeField] private TextMeshProUGUI score;

        [SerializeField] private Camera playerCamera;
        [SerializeField] private PlayerController player;

        public void OnEscapePressed()
        {
            hud.gameObject.SetActive(!hud.gameObject.activeSelf);

            var escapeCanvas = escape.gameObject;
            escapeCanvas.SetActive(!escapeCanvas.activeSelf);
            if (escapeCanvas.gameObject.activeSelf)
                score.text = "Scores: " + Global.CollectedItems;

            playerCamera.gameObject.SetActive(hud.gameObject.activeSelf);
            player.StopPlayer(hud.gameObject.activeSelf);
            Cursor.visible = escapeCanvas.activeSelf;
        }
    }
}