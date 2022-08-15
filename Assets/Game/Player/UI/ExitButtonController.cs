using UnityEngine;

namespace Game.Player.UI
{
    public class ExitButtonController : MonoBehaviour
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}