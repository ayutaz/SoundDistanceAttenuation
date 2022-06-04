using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class SoundVisualizerView : MonoBehaviour
    {
        [SerializeField] private List<Image> visualizerImageList;

        private void Awake()
        {
            foreach (var (image, index) in visualizerImageList.Select((item, index) => (item, index)))
            {
                image.transform.rotation = Quaternion.Euler(0f, 0f, index * 360f / visualizerImageList.Count);
                image.color = RandomColor();
            }
        }

        private static Color32 RandomColor()
        {
            return new Color32(
                (byte)Random.Range(0, 255),
                (byte)Random.Range(0, 255),
                (byte)Random.Range(0, 255),
                255
            );
        }
    }
}