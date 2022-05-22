using TMPro;
using UnityEngine;

namespace _Project
{
    public class AudioDebug : MonoBehaviour
    {
        private TextMeshProUGUI _audioDebugText;

        private void Awake()
        {
            _audioDebugText = GetComponent<TextMeshProUGUI>();
        }

        public void SetDebug(string audioValueData)
        {
            _audioDebugText.text = audioValueData;
        }
    }
}