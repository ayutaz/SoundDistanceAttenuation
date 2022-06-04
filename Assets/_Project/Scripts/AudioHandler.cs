﻿using NaughtyAttributes;
using UnityEngine;

namespace _Project
{
    public class AudioHandler : MonoBehaviour
    {
        private AudioSource _audioSource;
        private float _maxDistance;
        [SerializeField, ReadOnly] private AnimationCurve animationCurve;
        private SpriteRenderer _spriteRenderer;
        [SerializeField, ReadOnly] public string audioColor;
        [SerializeField, ReadOnly] private Color32 audioColor32;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            animationCurve = GetAnimationCurve();
            _maxDistance = _audioSource.maxDistance;
            audioColor = ColorUtility.ToHtmlStringRGB(_spriteRenderer.color);
            audioColor32 = _spriteRenderer.color;
        }

        public float GetAudiValue(Vector3 playerPosition)
        {
            var distance = Vector3.Distance(transform.position, playerPosition);
            return animationCurve.Evaluate(distance / _maxDistance);
        }

        private AnimationCurve GetAnimationCurve()
        {
            return animationCurve = _audioSource.rolloffMode switch
            {
                AudioRolloffMode.Linear => AnimationCurve.Linear(_audioSource.minDistance, 1, 1, 0),
                AudioRolloffMode.Custom => _audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff),
                _ => animationCurve
            };
        }
    }
}