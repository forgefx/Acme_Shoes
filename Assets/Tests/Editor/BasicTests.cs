using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BasicTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BasicTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BasicTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void TestCreateObject()
    {
        var name = "New Object";

        GameObject.Instantiate(new GameObject(name));

        Assert.IsNotNull(GameObject.Find(name));
    }
}
