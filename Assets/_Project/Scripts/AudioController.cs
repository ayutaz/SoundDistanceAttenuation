using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace _Project
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioDebug audioDebug;
        [SerializeField] private List<AudioHandler> audioHandlerList;
        [SerializeField] private PlayerMove playerMove;
        private readonly StringBuilder _stringBuilder = new StringBuilder();


        private void Update()
        {
            _stringBuilder.Clear();
            foreach (var audioHandler in audioHandlerList)
            {
                var audioValue = audioHandler.GetAudiValue(playerMove.GetPosition());
                _stringBuilder.Append($"{AudioColorStr(audioHandler.audioColor)}Value:{audioValue}\n");
            }

            audioDebug.SetDebug(_stringBuilder.ToString());
        }

        private static string AudioColorStr(string audioColor)
        {
            return $"<color=#{audioColor}>";
        }
    }
}