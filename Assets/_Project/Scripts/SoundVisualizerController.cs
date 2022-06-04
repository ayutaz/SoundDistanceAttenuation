using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace _Project
{
    public class SoundVisualizerController : MonoBehaviour
    {
        [SerializeField] private SoundVisualizerView soundVisualizerView;
        [SerializeField, Min(0)] private float minAudioValue = 0.1f;
        [SerializeField, ReadOnly] private List<AudioHandler> audioHandlers = new List<AudioHandler>();
        [SerializeField] private PlayerMove playerMove;

        private void Awake()
        {
            audioHandlers = FindObjectsOfType<AudioHandler>().ToList();
        }

        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(5f))
                .Subscribe(_ => { soundVisualizerView.UpdateVisualizerColor(); }).AddTo(this);
        }


        private void Update()
        {
        }
    }
}