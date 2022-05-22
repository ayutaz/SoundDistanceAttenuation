using UnityEngine;

namespace _Project
{
    public class AudioHandler : MonoBehaviour
    {
        private AudioSource _audioSource;
        private float _maxDistance;
        [SerializeField] private AnimationCurve animationCurve;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            animationCurve = GetAnimationCurve();
            _maxDistance = _audioSource.maxDistance;
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