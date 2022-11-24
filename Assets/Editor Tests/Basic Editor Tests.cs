using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BasicEditorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BasicEditorTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BasicEditorTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void TwoPlusTwoTest()
    {
        Assert.True(2 + 2 == 4);
    }

    [Test, Explicit]//Crashes when ran with -nographics command line argument
    public void TestCreateRenderTexture()
    {
        RenderTexture rt = new RenderTexture(1024, 1024, 0);
        rt.enableRandomWrite = true;
        rt.Create();
    }
}
