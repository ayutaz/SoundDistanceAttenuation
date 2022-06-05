using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace _Project
{
    public class SoundVisualizerController : MonoBehaviour
    {
        [SerializeField] private SoundVisualizerView soundVisualizerView;
        [SerializeField, ReadOnly] private List<AudioHandler> audioHandlers = new List<AudioHandler>();
        [SerializeField] private PlayerMove playerMove;
        private VisualizerModel _visualizerModel;
        [SerializeField] private float minAudioValue = 0.05f;

        private void Awake()
        {
            audioHandlers = FindObjectsOfType<AudioHandler>().ToList();
            _visualizerModel = new VisualizerModel(soundVisualizerView.MaxVisualizerCount, minAudioValue);
        }

        private void Start()
        {
            // Observable.Interval(TimeSpan.FromSeconds(5f))
            //     .Subscribe(_ => { soundVisualizerView.UpdateVisualizerColor(); }).AddTo(this);
        }

        private void Update()
        {
            // soundVisualizerView.RandomVisualizerValue();

            foreach (var audioHandler in audioHandlers)
            {
                var audioValueData = audioHandler.GetVisualizerAudioData(playerMove.GetPosition());
                _visualizerModel.UpdateVisualizerData(audioValueData);
            }

            soundVisualizerView.UpdateVisualizerValue(_visualizerModel.GetVisualizerData());
        }
    }
}