using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace _Project
{
    public class AudioDebug : MonoBehaviour
    {
        private TextMeshProUGUI _audioDebugText;
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private void Awake()
        {
            _audioDebugText = GetComponent<TextMeshProUGUI>();
        }

        public void SetDebug(float audioValueRight, float audioValueLeft)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append($"Audio Value Right: {audioValueRight}\n");
            _stringBuilder.Append($"Audio Value Left: {audioValueLeft}");
            _audioDebugText.text = _stringBuilder.ToString();
        }
    }
}