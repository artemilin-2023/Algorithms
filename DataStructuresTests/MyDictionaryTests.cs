using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

/*
 * Человек, что смотрит эти тесты, зачем ты тут? В любом случае, держи арт
 * 
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣯⣾⣿⡿⢟⣿⠛⠉⠩⠁⠀⠀⡟⠁⠀⣀⠀⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠈⠢⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣾⡿⠟⠁⣐⡮⠁⠀⡐⠀⠀⠀⠀⢰⣅⠈⠀⠒⠄⡀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠐⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣰⡿⠋⠀⠀⠀⡬⠁⠀⡐⠀⠀⠀⠀⠀⠀⠟⢂⠀⠀⠀⠈⠂⡀⠀⠀⠀⠈⠙⢿⣿⣻⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠈⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣲⠏⠀⠀⠀⠠⡙⠀⠀⢀⠁⠀⠀⠀⠀⠀⠀⠐⡈⠑⡀⠀⠀⠀⠈⠢⡀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⢗⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠬⠁⠀⢀⠈⠀⢠⠁⠀⠀⡈⠀⠀⠀⠀⠀⠀⠀⠀⠐⡀⠈⢄⠀⠀⠀⠀⠀⢄⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠈⠦⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠁⠀⠀⠂⠀⠀⡄⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠈⢂⠀⠀⠀⠀⠀⢂⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣗⡀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⣨⠁⠀⠀⠄⠀⠀⢀⠀⠀⠀⢰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢂⠀⠀⠀⠀⠀⢂⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⡰⠀⠀⠀⠀⠀⠀⢩⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⡘⠀⠀⠀⢸⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⣣⠀⠀⠀⠀⠀⠀⠀⠀⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⡇⢃⠀⠀⠀⠀⠀⠸⢆⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⣨⠀⠀⢀⠁⠀⠀⠀⠀⠀⠀⠀⣼⠀⠀⠀⠀⠀⠀⢁⢀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⡇⠋⡀⠀⠀⠀⠀⠀⣏⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⡈⠀⠀⠀⠀⠀⠀⠰⢰⣿⡆⠀⠀⠀⠀⠀⠀⠄⢂⠀⠐⡀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⠈⢡⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⢨⠀⠀⢀⠁⠀⠀⠀⠀⢀⠀⠆⣿⣿⣧⠀⠠⠀⠐⠀⠀⠘⡀⠠⠀⠐⣀⠀⠀⠀⠀⠘⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⠀⠈⡄⠀⠀⠀⠀⠘⠆⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⣿⠀⠀⠘⠀⠀⠀⠀⠀⠸⠰⢸⣿⣿⣿⣆⠀⢂⠀⠀⠀⠀⠐⡀⠐⠀⠐⠑⠀⠀⠈⠄⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⠀⠀⢁⠀⠀⠀⠀⠀⡆⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⡊⠀⠀⡀⠀⠀⠀⠀⠀⢐⢳⣾⣿⣿⣿⣿⡌⠌⣆⠀⠀⠀⠀⠐⠀⠈⠂⠈⢀⠢⡀⠀⢂⢡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⠀⠀⠘⠀⠀⠀⠀⠀⠣⠀⠀⠀⠀
 *  ⠀⠀⠀⠀⠀⠀⡅⠀⠀⡇⠀⡀⠀⠀⠀⢰⣧⣿⣿⣿⣿⣿⣿⣄⠚⢆⠀⠀⠀⠀⠈⢄⠀⠑⠀⠁⡀⠀⠀⠂⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⡆⠀⠀⡆⡆⡔⠄⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⣿⠀⠃⢸⢀⡇⠀⠀⠠⠈⣻⣿⣿⣿⣿⣿⣿⣿⣦⠙⡧⡀⠀⠀⠀⠀⠀⡀⠀⠀⠈⠀⡀⢀⢲⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⢸⠆⠀⠀⡇⢰⠀⢳⠁⢷⠗⡀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⢹⢰⠀⠈⣸⢰⠀⠀⠀⠒⡹⣿⣿⣿⣿⣿⣿⢿⣿⣷⣜⣮⣦⠀⠀⠀⠀⠈⠊⠀⠀⠀⢄⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⢤⢸⠀⠀⠀⡇⢸⢰⣾⢠⠆⠁⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠸⢸⠆⠀⢡⢀⠃⠀⠀⢀⠱⡹⣿⣿⣿⣿⣯⣿⣼⣹⣻⣮⣿⣿⡦⡀⠐⠄⠀⠈⠢⡢⢀⠀⠠⡣⡀⠀⠀⠀⠀⠀⠀⠀⡿⢸⠀⠀⠀⡇⠸⢘⠙⣾⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⢸⣾⣯⣶⠀⢸⠎⠄⡀⠈⡷⣼⣌⢻⣿⣿⣿⠿⢻⠩⠁⠀⠈⠑⢖⠠⠔⢄⠀⢌⠐⠨⠢⠁⠣⠂⠰⢠⣄⠀⠀⠀⠀⢠⡙⡈⠀⠀⠀⣌⢀⢸⠀⠏⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⢹⣁⠱⡇⢸⢰⡘⢇⢄⢡⠈⢿⣷⠟⠋⠀⠀⠀⢅⠀⠀⠀⠀⠀⠁⠀⠀⠈⠂⡝⡰⢠⠄⣐⡆⠀⢀⠀⠈⠀⠂⢠⢲⢡⠃⠀⠀⣰⠂⣸⡆⠘⠃⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠙⠦⢩⣆⢼⢡⠈⠂⠱⢕⠌⡅⠀⢀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠂⠁⠊⠔⣣⣀⣀⣀⠸⠀⣠⢏⡲⡉⠀⠠⢠⡏⢠⣗⠁⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢧⢯⣛⣥⠀⠀⠂⠈⠩⢊⠀⠀⠀⠀⠀⢀⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⣵⠉⠁⠀⠄⡆⡊⣜⡚⡔⠀⢠⡵⣿⢠⠯⠂⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢊⡎⠙⢓⠄⠀⢆⠀⠑⠱⢄⠀⠀⠀⠁⢃⡀⠀⠉⠀⠀⠀⠀⠀⠀⢀⢐⠚⠹⠀⡀⣨⢰⡀⢨⡣⡞⣠⡰⠉⢀⣭⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢧⠤⠢⠽⠦⢈⠑⢦⢀⠳⡅⡠⡀⠀⠀⠀⠀⠀⠁⠀⠀⠀⡠⣐⠁⡂⢀⢃⣔⣔⣇⢛⢣⡜⣷⠮⡧⠃⠈⢐⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢣⡆⠀⢠⠈⠑⠊⣾⣺⢳⣿⠙⢲⣄⡀⠀⢀⣀⣤⡔⢻⡔⠃⠁⣀⡔⢹⡏⢹⣿⠁⠙⣷⣟⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⠀⠀⠀⡄⣴⠾⠟⣴⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠟⠃⣿⣿⡅⠘⠈⠉⠉⠁⠀⠀⠀⠃⠛⠃⢸⣷⣼⡏⠀⠀⠈⠻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠀⠀⠀⣠⠤⢓⣵⣾⣿⣷⣄⠈⢘⠲⣠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣷⣶⣶⣶⣤⣤⣤⣤⣶⣶⣶⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⢀⡤⠓⠁⣰⡿⣽⢾⣟⣿⣿⣧⡄⡘⠢⡟⣧⣠⡀⠀⠀⢀⡀⣀⣴⣁⠟⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 *   ⠟⠁⢀⣾⢯⣟⣽⣻⣞⡿⣿⣿⣿⣮⣳⣜⣻⣿⣷⠒⠊⠉⠁⣠⣴⣶⣦⣤⣙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣗⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⢤⣤⣠⠀⠀⠀⠀⠀
 *   ⠀⡠⢟⣞⣯⣞⣷⣻⣾⣿⣿⣿⣿⣿⣿⣾⣷⣿⢿⣵⣤⣶⣿⣿⡿⣿⣿⣿⣿⣾⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡴⣠⠀⢀⣠⠠⠒⠒⠒⠒⠋⣰⣿⡿⣿⣷⣴⠀⠀⠀
 *   ⢀⠝⣸⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢯⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⡐⣉⠯⣄⠀⠀⠀⠀⠀⣴⣿⢯⣿⢷⣿⣿⣷⡂⠀
 *   ⢈⢠⣿⣽⣻⣿⢿⣯⣿⣽⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣵⣫⡽⣷⠀⢀⣠⣾⡿⣯⣿⣾⣿⣿⣟⣿⣿⡄
 *   ⠀⣼⣷⣻⣿⣾⣿⣯⣿⣯⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⡽⣧⠛⠿⣿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿
 *   ⢠⣿⡽⣟⣷⣿⣿⣿⣷⣿⡿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣯⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣬⣟⣯⣿⣿⣿⣿⣿⣿⣿⣿
 *
 * 
 * 
 * А теперь иди своей дорогой.
 * 
 */

namespace DataStructures.Tests
{
    [TestClass()]
    public class MyDictionaryTests
    {
        private MyDictionary<string, int> table;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        [TestInitialize]
        public void Initialize()
        {
            table = new MyDictionary<string, int>();
        }

        [TestMethod()]
        public void AddTest()
        {
            table.Add("one", 1);
            table.Add("two", 2);
            table.Add("three", 3);

            Assert.AreEqual(3, table.Count);
        }

        [TestMethod()]
        public void AddTest_KeyAlreadyExist()
        {
            table.Add("one", 1);

            Assert.ThrowsException<ArgumentException>(() => table.Add("one", 1));
        }

        [TestMethod()]
        public void AddTest_ResizingTest()
        {
            var keys = new List<string>();
            var values = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                keys.Add(i.ToString());
                values.Add(i);
                table.Add(i.ToString(), i);
            }

            Assert.AreEqual(100, table.Count);
            CollectionAssert.AreEqual(keys.Order().ToList(), table.Keys.Order().ToList());
            CollectionAssert.AreEqual(values, table.Values.Order().ToList());
        }

        [TestMethod()]
        public void GetSetTest()
        {
            table["one"] = 0;
            table["two"] = 2;

            table["one"]++;

            Assert.AreEqual(1, table["one"]);
            Assert.AreEqual(2, table["two"]);
        }

        [TestMethod()]
        public void GetSetTest_TryGetValue()
        {
            table["one"] = 0;
            table["two"] = 2;

            Assert.ThrowsException<ArgumentException>(() => table["three"]);
        }

        [TestMethod()]
        public void EnumeratorTest()
        {
            table["one"] = 0;
            table["two"] = 1;
            table["three"] = 2;

            foreach (var item in table)
            {
                Assert.AreEqual(table[item.Key], item.Value);
            }
        }

        [TestMethod()]
        public void ContainsTest_True()
        {

            table["one"] = 0;
            table["two"] = 1;
            table["three"] = 2;

            Assert.IsTrue(table.Contains(new KeyValuePair<string, int>("one", 0)));
            Assert.IsTrue(table.Contains(new KeyValuePair<string, int>("two", 1)));
            Assert.IsTrue(table.Contains(new KeyValuePair<string, int>("three", 2)));
        }

        [TestMethod()]
        public void ContainsTest_False()
        {

            table["one"] = 0;
            table["two"] = 1;
            table["three"] = 2;

            Assert.IsFalse(table.Contains(new KeyValuePair<string, int>("one1", 0)));
            Assert.IsFalse(table.Contains(new KeyValuePair<string, int>("two", 2)));
            Assert.IsFalse(table.Contains(new KeyValuePair<string, int>("t", -2)));
        }

        [TestMethod()]
        public void ContainsTest_NullKey()
        {

            table["one"] = 0;
            table["two"] = 1;
            table["three"] = 2;

            Assert.ThrowsException<ArgumentNullException>(() => table.Contains(new KeyValuePair<string, int>(null, 0)));
        }

        [TestMethod()]
        public void CopyToTest_CopyAll()
        {
            table["one"] = 1;
            table.Add("two", 2);
            table.Add("three", 2);

            var array = new KeyValuePair<string, int>[3];
            table.CopyTo(array, 0);

            CollectionAssert.AreEqual(table.Values.Order().ToList(), array.Select(i => i.Value).Order().ToList());
        }

        [TestMethod()]
        public void CopyToTest_ArrayBigger()
        {
            table["one"] = 1;
            table.Add("two", 2);
            table.Add("three", 2);

            var array = new KeyValuePair<string, int>[4];
            table.CopyTo(array, 1);

            CollectionAssert.AreEqual(table.Values.Order().ToList(), array.TakeLast(3).Select(i => i.Value).Order().ToList());
        }

        [TestMethod()]
        public void CopyToTest_ArrayLess()
        {
            table.Add("Что вершит судьбу человечества в этом мире? Некое незримое существо или закон, подобно Длани Господней парящей над миром? По крайне мере истинно то, что человек не властен даже над своей волей.", 2);
            table["one"] = 1;
            table.Add("two", 2);

            var array = new KeyValuePair<string, int>[2];

            Assert.ThrowsException<ArgumentException>(() => table.CopyTo(array, 0));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            table.Add("one", 1);
            table.Add("two", 2);
            table.Add("imposter", -1);

            Assert.AreEqual(3, table.Count);

            table.Remove("imposter");
            Assert.AreEqual(2, table.Count);
            CollectionAssert.AreEqual(new List<int>() { 1, 2 }, table.Values.Order().ToList());
        }

        [TestMethod()]
        public void ClearTest()
        {
            for (int i = 0; i < 100; i++)
                table.Add(i.ToString(), i);

            table.Clear();
            Assert.AreEqual(table.Count, 0);
        }
    }
}