using figures_lib;

namespace figures_lib.Test
{
    public class TriangleTestSuit
    {
        

        [Test]
        public void TriangleConstructorNoArrayShould_ThrowArgException_OnNegativeValue()
        {
            var stubSide = -5.0; 

            Assert.Catch(typeof(ArgumentException),()=> new Triangle(stubSide, stubSide , stubSide));
        }

        [Test]
        public void TriangleConstructorArrayShould_ThrowArgException_OnNegativeValue()
        {
            var stubSide = -5.0;

            Assert.Catch(typeof(ArgumentException), () => new Triangle(new[] { stubSide, stubSide, stubSide }));
        }

        [Test]
        public void TriangleExistingCheck_ShouldReturnFalse()
        {
            var stubWrongSides = new[] { 1.0,2.0,1};

            var res = Triangle.IfTriangleExists(stubWrongSides);

            Assert.IsFalse(res);
        }


        [Test]
        public void TriangleExistingCheck_ShouldReturnTrue()
        {
            var stubRightSides = new[] { 5.0, 5.0, 1 };

            var res = Triangle.IfTriangleExists(stubRightSides);

            Assert.IsTrue(res);
        }

        [Test]
        public void TriangleRightnessCheck_ShouldReturnTrue()
        {
            var stubRightSides = new[] { 3.0, 4.0, 5.0 };
            var mockTriangle = new Triangle(stubRightSides);

            var res = mockTriangle.IfTriangleIsRight();

            Assert.IsTrue(res);
        }

        [Test]
        public void TriangleRightnessCheck_ShouldReturnFalse()
        {
            var stubWrongSides = new[] { 5.0, 5.0, 1 };
            var mockTriangle = new Triangle(stubWrongSides);

            var res = mockTriangle.IfTriangleIsRight();

            Assert.IsFalse(res);
        }

        [Test]
        public void TriangleRightnessCheck_Static_ShouldReturnTrue()
        {
            var stubRightSides = new[] { 3.0, 4.0, 5.0 };

            var res = Triangle.IfTriangleIsRight(stubRightSides);

            Assert.IsTrue(res);
        }

        [Test]
        public void TriangleRightnessCheck_Static_ShouldReturnFalse()
        {
            var stubWrongSides = new[] { 5.0, 5.0, 1 };

            var res = Triangle.IfTriangleIsRight(stubWrongSides);

            Assert.IsFalse(res);
        }



        [TestCase(7.0, 5, 9)]
        [TestCase(4.0, 8.0, 9.0)]
        [TestCase(100.9506, 99.0, 70.907)]
        public void TriangleShould_CalcAreaRight_OnValues(params double[] values)
        {
            var mockTriangle = new Triangle(values);

            var res = mockTriangle.GetArea() == GetArea(values);

            Assert.IsTrue(res);
        }

        public double GetArea(params double[] values)
        {
            var halfPerimeter = values.Sum() / 2;
            // area = (halfPerimeter * (hp - a) * (hp - b) * (hp - c) )^0.5
            var area = Math.Sqrt(
                halfPerimeter * values.
                Select(side => halfPerimeter - side).
                Aggregate((a, b) => a * b)
                );
            return area;
        }

    }
}