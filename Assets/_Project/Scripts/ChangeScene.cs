using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown changeSceneDropdown;

        private void Awake()
        {
            SetSceneName();
            changeSceneDropdown.value = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
        {
            changeSceneDropdown.ObserveEveryValueChanged(value => value.value)
                .Skip(1)
                .Subscribe(selectSceneValue => { SceneManager.LoadSceneAsync(selectSceneValue); }).AddTo(this);
        }

        private void SetSceneName()
        {
            for (var sceneIndex = 0; sceneIndex < SceneManager.sceneCountInBuildSettings; sceneIndex++)
            {
                var sceneName = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
                var sceneNameWithoutExtension = sceneName[..sceneName.LastIndexOf('.')];
                var sceneNameWithoutPath = sceneNameWithoutExtension[(sceneNameWithoutExtension.LastIndexOf('/') + 1)..];
                changeSceneDropdown.options.Add(new TMP_Dropdown.OptionData(sceneNameWithoutPath));
            }
        }
    }
}