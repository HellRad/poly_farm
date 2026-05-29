using NUnit.Framework;
using System.Linq;
using System.ComponentModel.Design.Serialization;
using System;

public class SimpleTestExample
{
    // A Test behaves as an ordinary method
    [Test]
    public void SayMyName()
    {
        // Use the Assert class to test conditions
        string thisIsMyName = "Joel";
        string thisIsWhatMyFrendsCallMe = "Jol";
        Assert.AreEqual(thisIsMyName, thisIsWhatMyFrendsCallMe, $"My name is pronounced wrong");
    }
}
