using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidtermTuringTest
{
    public class StartGame : MonoBehaviour
    {
        public void OpenGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
