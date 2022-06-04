using UnityEngine;

namespace _Project
{
    public class VisualizerModel
    {
        private readonly VisualizerAudioData[] _visualiserData;
        private readonly float _minValue;

        public VisualizerModel(int visualizerMaxDataCount, float minValue)
        {
            _visualiserData = new VisualizerAudioData[visualizerMaxDataCount];
            for (var index = 0; index < visualizerMaxDataCount; index++)
            {
                _visualiserData[index] = new VisualizerAudioData();
            }

            _minValue = minValue;
        }

        public VisualizerAudioData[] GetVisualizerData()
        {
            return _visualiserData;
        }

        public void UpdateVisualizerData(VisualizerAudioData data)
        {
            if (data.AudioValue <= _minValue) return;
            var angle = Vector2ToAngle(data.AudioVector);

            var oldValue = _visualiserData[VisualizerDataIndex(angle)].AudioValue;
            if (oldValue < data.AudioValue)
            {
                _visualiserData[VisualizerDataIndex(angle)] = data;
            }
        }

        private int VisualizerDataIndex(float angle)
        {
            return Mathf.CeilToInt(angle / (360f / _visualiserData.Length)) - 1;
        }

        public static float Vector2ToAngle(Vector2 vector2)
        {
            var angle = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
            if (0f <= angle) return angle;
            return 360f + angle;
        }
    }
}