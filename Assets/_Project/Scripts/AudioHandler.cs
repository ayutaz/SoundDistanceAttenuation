using NaughtyAttributes;
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
        private float AudioDistance { get; set; }
        private readonly VisualizerAudioData _visualizerAudioData = new VisualizerAudioData();

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
            AudioDistance = Vector3.Distance(transform.position, playerPosition);
            return animationCurve.Evaluate(AudioDistance / _maxDistance);
        }

        public VisualizerAudioData GetVisualizerAudioData(Vector3 playerPosition)
        {
            _visualizerAudioData.AudioValue = GetAudiValue(playerPosition);
            _visualizerAudioData.AudioVector = playerPosition - transform.position;
            _visualizerAudioData.AudioColor = audioColor32;
            return _visualizerAudioData;
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