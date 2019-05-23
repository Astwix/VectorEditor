using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SDK;
using VectorEditorProject.Core;

namespace VectorEditorTest
{
    class DocumentTest
    {
        [Test]
        [TestCase(5, 5)]
        [TestCase(int.MaxValue, int.MaxValue)]
        public void ConstructorTest1(int a, int b)
        {
            var doc = new Document("Test", Color.Aqua, new Size(a, b));

            Assert.AreEqual("Test", doc.Name);
            Assert.AreEqual(Color.Aqua, doc.Color);
            Assert.IsNotNull(doc.Size);
            Assert.AreEqual(new Size(a, b), doc.Size);
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(int.MinValue, int.MinValue)]
        public void ConstructorTest2(int a, int b)
        {
            var doc = new Document("Test", Color.Aqua, new Size(a, b));

            Assert.AreEqual("Test", doc.Name);
            Assert.AreEqual(Color.Aqua, doc.Color);
            Assert.IsNotNull(doc.Size);
            Assert.AreNotEqual(new Size(a, b), doc.Size);
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(int.MaxValue, int.MaxValue)]
        public void SizeTest1(int a, int b)
        {
            var doc = new Document("", Color.AliceBlue, new Size(0, 0));

            doc.Size = new Size(a, b);

            Assert.IsNotNull(doc.Size);
            Assert.AreEqual(new Size(a, b), doc.Size);
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(int.MinValue, int.MinValue)]
        public void SizeTest2(int a, int b)
        {
            var doc = new Document("", Color.AliceBlue, new Size(0, 0));

            doc.Size = new Size(a, b);

            Assert.IsNotNull(doc.Size);
            Assert.AreNotEqual(new Size(a, b), doc.Size);
        }

        [Test]
        [TestCase("Test")]
        [TestCase(" ")]
        public void NameTest(string a)
        {
            var doc = new Document("", Color.AliceBlue, new Size(0, 0));

            doc.Name = a;

            Assert.AreEqual(a, doc.Name);
        }

        [Test]
        public void ClearCanvasTest()
        {
            var doc = new Document("", Color.AliceBlue, new Size(0, 0));
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            int countBeforeAdd = doc.GetFigures().Count;
            doc.AddFigure(figureMock.Object);
            int countAfterAdd = doc.GetFigures().Count;
            doc.ClearCanvas();

            Assert.AreEqual(0, countBeforeAdd);
            Assert.AreEqual(1, countAfterAdd);
            Assert.AreEqual(0, doc.GetFigures().Count);
        }

        [Test]
        public void GetFigureTest()
        {
            var doc = new Document("", Color.AliceBlue, new Size(0, 0));
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            FigureBase shouldBeNull =
                doc.GetFigure(figureMock.Object.guid);
            doc.AddFigure(figureMock.Object);
            FigureBase shouldBeFigureMock =
                doc.GetFigure(figureMock.Object.guid);

            Assert.IsNull(shouldBeNull);
            Assert.AreEqual(figureMock.Object, shouldBeFigureMock);
        }

        [Test]
        public void GetFiguresTest()
        {
            var doc =
                new Document("", Color.AliceBlue, new Size(0, 0));
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            int shouldBeZero = doc.GetFigures().Count;
            doc.AddFigure(figureMock.Object);
            int shouldBeOne = doc.GetFigures().Count;
            var shouldBeFigureMock = doc.GetFigures()[0];

            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(1, shouldBeOne);
            Assert.AreSame(figureMock.Object, shouldBeFigureMock);
        }


        [Test]
        public void AddFigureTest()
        {
            var doc =
                new Document("", Color.AliceBlue, new Size(0, 0));
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            int shouldBeZero = doc.GetFigures().Count;
            doc.AddFigure(figureMock.Object);
            int shouldBeOne = doc.GetFigures().Count;
            var shouldBeFigureMock = doc.GetFigures()[0];

            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(1, shouldBeOne);
            Assert.AreSame(figureMock.Object, shouldBeFigureMock);
        }

        [Test]
        public void DeleteFigureTest()
        {
            var doc =
                new Document("", Color.AliceBlue, new Size(0, 0));
            Mock<FigureBase> figureMock1 = new Mock<FigureBase>();
            Mock<FigureBase> figureMock2 = new Mock<FigureBase>();

            doc.AddFigure(figureMock1.Object);
            doc.AddFigure(figureMock2.Object);
            int shouldBeTwo = doc.GetFigures().Count;
            doc.DeleteFigure(figureMock1.Object); //by figure
            int shouldBeOne = doc.GetFigures().Count;
            doc.DeleteFigure(figureMock2.Object.guid); //by Guid
            int shouldBeZero = doc.GetFigures().Count;

            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(1, shouldBeOne);
            Assert.AreEqual(2, shouldBeTwo);
        }
    }
}
