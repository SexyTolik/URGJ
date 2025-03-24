using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameContent.Scripts.Scene
{
    public class SceneLoader
    {
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}