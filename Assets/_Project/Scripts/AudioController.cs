using UnityEngine;

namespace _Project
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioDebug audioDebug;

        [SerializeField] private AudioHandler audioHandlerRight;
        [SerializeField] private AudioHandler audioHandlerLeft;
        [SerializeField] private PlayerMove playerMove;


        private void Update()
        {
            var rightValue = audioHandlerRight.GetAudiValue(playerMove.GetPosition());
            var leftValue = audioHandlerLeft.GetAudiValue(playerMove.GetPosition());
            audioDebug.SetDebug(rightValue, leftValue);
        }
    }
}