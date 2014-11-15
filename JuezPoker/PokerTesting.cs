using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CasinoPoker;

namespace JuezPoker
{
    [TestFixture]
    public class PokerTesting
    {

        private PokerGame pokerGame { get; set; }

        [SetUp]
        public void InstaciasAntesDeCadaTest()
        {
            // Arrange
            pokerGame = new PokerGame();
        }

        [Test]
        public void TestCartaAlta()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");

            // Assert
            Assert.AreEqual("Carta Alta", result);
        }

        [Test]
        public void TestUnPar()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("ARC-ANT-8NP-6RC-2RD");

            // Assert
            Assert.AreEqual("Un Par", result);
        }

        [Test]
        public void TestUnPar1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("4RC-5NT-4NP-8RC-9RD");

            // Assert
            Assert.AreEqual("Un Par", result);
        }

        [Test]
        public void TestUnPar2()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("KRC-7NT-2NP-KRC-JRD");

            // Assert
            Assert.AreEqual("Un Par", result);
        }

        [Test]
        public void TestDosPares()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("4RC-5NT-4NP-8RC-8RD");

            // Assert
            Assert.AreEqual("Dos Pares", result);
        }

        [Test]
        public void TestDosPares1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("3RC-2NT-3NP-5RC-5RD");

            // Assert
            Assert.AreEqual("Dos Pares", result);
        }


        [Test]
        public void TestTrio()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("3RC-2NT-3NP-3RC-5RD");

            // Assert
            Assert.AreEqual("Trio", result);
        }

        [Test]
        public void TestEscalera()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("7RC-6NT-9NP-8RC-IRD");

            // Assert
            Assert.AreEqual("Escalera", result);
        }

        [Test]
        public void TestEscalera1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("ARC-INT-JNP-QRC-KRD");

            // Assert
            Assert.AreEqual("Escalera", result);
        }

        [Test]
        public void TestEscalera2()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("5RC-4NT-3NP-2RC-ARD");

            // Assert
            Assert.AreEqual("Escalera", result);
        }

        [Test]
        public void TestEscalera3()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("2RC-4NT-3NP-6RC-5RD");

            // Assert
            Assert.AreEqual("Escalera", result);
        }

        [Test]
        public void TestColor()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("KRC-JNP-INT-6RC-3RD");
            var result = pokerGame.GetGanadorPoker("2NT-5NT-3NT-6NT-5NT");

            // Assert
            Assert.AreEqual("Color", result);
        }

        [Test]
        public void TestColor1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("4RE-6RE-JRE-ARE-9RE");

            // Assert
            Assert.AreEqual("Color", result);
        }

        [Test]
        public void TestFull()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("3RE-3NE-3RE-ANE-ARE");

            // Assert
            Assert.AreEqual("Full", result);
        }

        [Test]
        public void TestFull1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("QRT-ARP-QRE-ARC-QRC");

            // Assert
            Assert.AreEqual("Full", result);
        }


        [Test]
        public void TestPoker()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("ART-8RP-ARE-ARC-ARC");

            // Assert
            Assert.AreEqual("Poker", result);
        }

        [Test]
        public void TestPoker1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("2RT-6RP-2RE-2RC-2RC");

            // Assert
            Assert.AreEqual("Poker", result);
        }

        [Test]
        public void TestEscaleraColor()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("7RD-8RD-9RD-IRD-JRD");

            // Assert
            Assert.AreEqual("Escalera de Color", result);
        }

        [Test]
        public void TestEscaleraColor1()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("ARD-2RD-3RD-5RD-4RD");

            // Assert
            Assert.AreEqual("Escalera de Color", result);
        }

        [Test]
        public void TestEscaleraColor2()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("9NT-QNT-KNT-INT-JNT");

            // Assert
            Assert.AreEqual("Escalera de Color", result);
        }

        [Test]
        public void TestEscaleraReal()
        {
            // Act
            //var result = pokerGame.GetGanadorPoker("4E, 6E, JE, AE, 9E");
            var result = pokerGame.GetGanadorPoker("ARC-KRC-QRC-IRC-JRC");

            // Assert
            Assert.AreEqual("Escalera Real", result);
        }

    }
}