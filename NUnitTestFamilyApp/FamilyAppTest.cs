using NUnit.Framework;
using Oblig1Modul3;

namespace NUnitTestFamilyApp
{
    public class FamilyAppTest
    {
        [Test]
        public void TestChild()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [Test]
        public void TestNoChild()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            sverreMagnus.Father = haakon;
            var app = new FamilyApp(sverreMagnus);
            var actualResponse = app.HandleCommand("vis 1");
            var expectedResponse = "Sverre Magnus (Id=1) Født: 2005 Far: Haakon Magnus (Id=3) ";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}