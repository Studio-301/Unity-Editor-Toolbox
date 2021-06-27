using NUnit.Framework;
using UnityEngine;

namespace Toolbox.Tests
{
    public class SerializationTest
    {
        [Test]
        public void TestTypeSerializationPass()
        {
            var serializedType = new SerializedType("UnityEngine.MonoBehaviour, UnityEngine.CoreModule");
            var type = serializedType.Type;
            Assert.AreEqual(type, typeof(MonoBehaviour));
        }
    }
}