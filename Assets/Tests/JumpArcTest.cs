using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class JumpArcTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Calculate_Initial_Velocity_Test()
        {
            float expected = 10.95445f;
            float actual = 420;
            float _finalVelocity = 0;
            float _displacement = 3;
            float _acceleration = -20;
            actual = JumpArc.CalculateInitialVelocity(_finalVelocity, _displacement, _acceleration);

            //actual = JumpArc
            // Use the Assert class to test conditions
            //Assert.AreEqual(expected, actual);
            float tolerance = 0.00001f;
            //int magnitude = 1 + (expected == 0.0 ? -1 : Convert.ToInt32(Math.Floor(Math.Log10(expected))));
            //int precision = 15 - magnitude;

            //double tolerance = 1.0 / Math.Pow(10, precision);)

            Assert.That(actual, Is.EqualTo(expected).Within(tolerance));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
       /* [UnityTest]
        public IEnumerator JumpArcTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        } */
    }
}
