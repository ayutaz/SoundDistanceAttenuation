using _Project;
using NUnit.Framework;
using UnityEngine;

public class VisualizerModelTest
{
    [Test]
    public void Vector2ToAngleTest()
    {
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(1.0f, 0.0f)), 0); // 0
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(0.7f, 0.7f)), 45); // 45
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(0.0f, 1.0f)), 90); // 90
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(-1.0f, 0.0f)), 180); // 180
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(0.0f, -1.0f)), -90); // -90
        Assert.AreEqual(VisualizerModel.Vector2ToAngle(new Vector2(1.0f, 0.0f)), 0); // 0
    }
}