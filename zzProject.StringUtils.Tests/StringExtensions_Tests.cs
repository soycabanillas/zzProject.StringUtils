using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zzProject.StringUtils.Tests
{
    [TestClass]
    public class StringExtensions_Tests
    {
        [TestMethod]
        public void GetPositionEndOfPreviousWord()
        {
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("", 0), 0);
            try { StringExtensions.GetPositionEndOfPreviousWord("", 1); Assert.Fail(); }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
            try { StringExtensions.GetPositionEndOfPreviousWord("", 2); Assert.Fail(); }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" ", 1), 0);
            try { StringExtensions.GetPositionEndOfPreviousWord(" ", 2); Assert.Fail(); }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  ", 2), 0);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" t ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" t ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" t ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" t ", 3), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t  ", 2), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t  ", 3), 1);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  t", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  t", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  t", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t   ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t   ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t   ", 2), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t   ", 3), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("t   ", 4), 1);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("   t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("   t", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("   t", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("   t", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("   t", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to ", 3), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to ", 4), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to  ", 3), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to  ", 4), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 4), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 5), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 6), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 7), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 8), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord(" to from ", 9), 8);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 3), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 4), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 5), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 6), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 7), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 8), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("to from  ", 9), 7);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 6), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 7), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 8), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to from", 9), 9);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 6), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 7), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 8), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 9), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 10), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 11), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to  from  ", 12), 10);

            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 6), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 7), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 8), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 9), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 10), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 11), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 12), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfPreviousWord("  to   from  ", 13), 11);
        }

        [TestMethod]
        public void GetPositionEndOfWordOrCurrentPosition() {
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("", 0), 0);
            try { StringExtensions.GetPositionEndOfWordOrCurrentPosition("", 1); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            try { StringExtensions.GetPositionEndOfWordOrCurrentPosition("", 2); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" ", 1), 1);
            try { StringExtensions.GetPositionEndOfWordOrCurrentPosition(" ", 2); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  ", 2), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" t ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" t ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" t ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" t ", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t  ", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  t", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  t", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  t", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t   ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t   ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t   ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t   ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("t   ", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("   t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("   t", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("   t", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("   t", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("   t", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to ", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to ", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to ", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to  ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to  ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to  ", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 5), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 6), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 7), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 8), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition(" to from ", 9), 9);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 4), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 5), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 6), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 7), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 8), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("to from  ", 9), 9);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 5), 5);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 6), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 7), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 8), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to from", 9), 9);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 5), 5);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 6), 6);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 7), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 8), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 9), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 10), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 11), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to  from  ", 12), 12);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 5), 5);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 6), 6);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 7), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 8), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 9), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 10), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 11), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 12), 12);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrCurrentPosition("  to   from  ", 13), 13);
        }

        [TestMethod]
        public void GetPositionEndOfWordOrEndOfPreviousWord() {
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("", 0), 0);
            try { StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("", 1); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            try { StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("", 2); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" ", 1), 0);
            try { StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" ", 2); Assert.Fail(); } catch (ArgumentException) { } catch (Exception) { Assert.Fail(); }
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  ", 2), 0);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" t ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" t ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" t ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" t ", 3), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t  ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t  ", 2), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t  ", 3), 1);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  t", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  t", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  t", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t   ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t   ", 1), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t   ", 2), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t   ", 3), 1);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("t   ", 4), 1);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("   t", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("   t", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("   t", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("   t", 3), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("   t", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to", 3), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to ", 3), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to ", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to ", 4), 3);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to  ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to  ", 3), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to  ", 4), 2);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to", 4), 4);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 2), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 3), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 4), 3);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 5), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 6), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 7), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 8), 8);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord(" to from ", 9), 8);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 1), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 2), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 3), 2);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 4), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 5), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 6), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 7), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 8), 7);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("to from  ", 9), 7);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 6), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 7), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 8), 9);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to from", 9), 9);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 6), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 7), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 8), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 9), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 10), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 11), 10);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to  from  ", 12), 10);

            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 0), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 1), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 2), 0);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 3), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 4), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 5), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 6), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 7), 4);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 8), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 9), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 10), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 11), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 12), 11);
            Assert.AreEqual(StringExtensions.GetPositionEndOfWordOrEndOfPreviousWord("  to   from  ", 13), 11);
        }

        [TestMethod]
        public void GetPositionToTruncate()
        {
            try { StringExtensions.GetPositionToTruncate("", TruncateWordsOptionsEnum.NotImplemented, 0); Assert.Fail(); }
            catch (NotImplementedException) { }
            catch (Exception) { Assert.Fail(); }
            //string testText1 = "This is a very simple test.";
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 0, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 1, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 2, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 3, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 4, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 5, TruncateWordsOptionsEnum.TruncateToNextWord), "This");
            //Assert.AreEqual(StringExtensions.TruncateToWord(testText1, 6, TruncateWordsOptionsEnum.TruncateToNextWord), "This is");
        }
    }
}
