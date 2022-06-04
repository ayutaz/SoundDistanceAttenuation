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

        public void UpdateVisualizerColor()
        {
            foreach (var image in visualizerImageList)
            {
                image.color = RandomColor();
            }
        }

        public void RandomVisualizerValue()
        {
            foreach (var image in visualizerImageList)
            {
                if (image.fillAmount is > 0f and < 1f)
                {
                    image.fillAmount += Random.Range(-0.01f, 0.01f);
                }
                else if (image.fillAmount == 0f)
                {
                    image.fillAmount += 0.01f;
                }
                else if (image.fillAmount <= 1f)
                {
                    image.fillAmount -= 0.01f;
                }
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