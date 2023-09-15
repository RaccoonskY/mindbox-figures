using figures_lib;

namespace figures_lib.Test
{
    public class CircleTestSuit
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CirlceShould_ThrowArgException_OnNegativeValue()
        {
            var stubRadius = -5; 

            Assert.Catch(typeof(ArgumentException),()=> new Circle(stubRadius));
        }

        [Test]
        public void CircleShould_CalcAreaRight_OnPiValue()
        {
            var stubRadius = 1;
            var mockCircle = new Circle(stubRadius);

            var res = mockCircle.GetArea() == Math.PI;

            Assert.IsTrue(res);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5.0)]
        [TestCase(5.5)]
        [TestCase(1.95)]
        [TestCase(100.9506)]
        public void CircleShould_CalcAreaRight_OnValues(double radius)
        {
            var mockCircle = new Circle(radius);

            var res = mockCircle.GetArea() == Math.PI * Math.Pow(radius,2);

            Assert.IsTrue(res);
        }


    }
}