using UnityEngine;

namespace _Project
{
    public class VisualizerModel
    {
        private readonly float[] _visualiserData;
        private readonly float _minValue;

        public VisualizerModel(int visualizerMaxDataCount, float minValue)
        {
            _visualiserData = new float[visualizerMaxDataCount];
            this._minValue = minValue;
        }

        public float[] GetVisualizerData()
        {
            return _visualiserData;
        }

        public void UpdateVisualizerData(VisualizerAudioData data)
        {
            if (data.AudioValue <= _minValue) return;
            var angle = Vector2ToAngle(data.AudioVector);
            Debug.Log($"value:{data.AudioValue}, angle:{angle}");
            _visualiserData[VisualizerDataIndex(angle)] = data.AudioValue;
        }

        private static int VisualizerDataIndex(float angle)
        {
            var i = Mathf.CeilToInt(360f / angle);
            Debug.Log("i: " + i);
            return i;
        }

        public static float Vector2ToAngle(Vector2 vector2)
        {
            var angle = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
            if (0f <= angle) return angle;
            return 360f + angle;
        }
    }
}