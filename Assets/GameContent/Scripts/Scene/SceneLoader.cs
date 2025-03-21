using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameContent.Scripts.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public void ChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}