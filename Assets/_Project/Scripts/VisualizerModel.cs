using UnityEngine;

namespace _Project
{
    public class VisualizerModel
    {
        private float[] _visualiserData = new float[16];

        public float[] GetVisualizerData()
        {
            return _visualiserData;
        }

        public void UpdateVisualizerData(VisualizerAudioData data)
        {
        }

        public static float Vector2ToAngle(Vector2 vector2)
        {
            return Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
        }
    }
}