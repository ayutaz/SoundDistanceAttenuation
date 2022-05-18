using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private void Update()
        {
            SceneManager.LoadSceneAsync($"_Project/Scenes/{sceneName}");
        }
    }
}