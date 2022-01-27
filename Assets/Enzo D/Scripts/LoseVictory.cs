using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Enzo_D.Scripts
{
    public class LoseVictory : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("mainmenu");
        }

    
        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("quit");
        }
    }
}
