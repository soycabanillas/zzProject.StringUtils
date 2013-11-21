using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zzProject.StringUtils;

namespace zzProject.ReportTranslator.Core.Test.Translation.Identifier.Generator {
    [TestClass]
    public class IdentifierGeneratorUtils_Test {
        [TestMethod]
        public void Suffix() {
            IdentifierGeneratorUtils.PreSuffixResult result;
            #region Two parameter tests
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333);
            Assert.IsTrue(result.Result == "abcdefghij333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            #endregion

            #region Three parameters tests
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5);
            Assert.IsTrue(result.Result == "abcdefghij00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 2);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion

            #region Four parameters tests
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 16);
            Assert.IsTrue(result.Result == "abcdefghij00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 14);
            Assert.IsTrue(result.Result == "abcdefghij333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 15);
            Assert.IsTrue(result.Result == "abcdefghij00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 13);
            Assert.IsTrue(result.Result == "abcdefghij333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 14);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 12);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 2, 15);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion

            #region Five parameters tests
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 16, true);
            Assert.IsTrue(result.Result == "abcdefghij00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 14, true);
            Assert.IsTrue(result.Result == "abcdefghij333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 15, true);
            Assert.IsTrue(result.Result == "abcdefghij00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 13, true);
            Assert.IsTrue(result.Result == "abcdefghij333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 14, true);
            Assert.IsTrue(result.Result == "abcdefghi00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.OriginalValueTrimmed && result.PreSuffixLength == 5 && result.ValueLength == 9);
            result = IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 12, true);
            Assert.IsTrue(result.Result == "abcdefghi333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.OriginalValueTrimmed && result.PreSuffixLength == 3 && result.ValueLength == 9);
            result = IdentifierGeneratorUtils.SuffixInt("abcde", 333, 5, 5, true);
            Assert.IsTrue(result.Result == "00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.NoOriginalValueOnResult && result.PreSuffixLength == 5 && result.ValueLength == 0);
            result = IdentifierGeneratorUtils.SuffixInt("abc", 333, 0, 3, true);
            Assert.IsTrue(result.Result == "333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.NoOriginalValueOnResult && result.PreSuffixLength == 3 && result.ValueLength == 0);
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 2, 15, true);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 0, 2, true);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.SuffixInt("abcdefghij", 333, 5, 4, true);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion
        }

        [TestMethod]
        public void Prefix() {
            IdentifierGeneratorUtils.PreSuffixResult result;
            #region Two parameter tests
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333);
            Assert.IsTrue(result.Result == "333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            #endregion

            #region Three parameters tests
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5);
            Assert.IsTrue(result.Result == "00333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 2);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion

            #region Four parameters tests
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 16);
            Assert.IsTrue(result.Result == "00333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 14);
            Assert.IsTrue(result.Result == "333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 15);
            Assert.IsTrue(result.Result == "00333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 13);
            Assert.IsTrue(result.Result == "333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 14);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 12);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 2, 15);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion

            #region Five parameters tests
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 16, true);
            Assert.IsTrue(result.Result == "00333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 14, true);
            Assert.IsTrue(result.Result == "333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 15, true);
            Assert.IsTrue(result.Result == "00333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 5 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 13, true);
            Assert.IsTrue(result.Result == "333abcdefghij" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.MatchSpecifications && result.PreSuffixLength == 3 && result.ValueLength == 10);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 14, true);
            Assert.IsTrue(result.Result == "00333abcdefghi" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.OriginalValueTrimmed && result.PreSuffixLength == 5 && result.ValueLength == 9);
            result = IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 12, true);
            Assert.IsTrue(result.Result == "333abcdefghi" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.OriginalValueTrimmed && result.PreSuffixLength == 3 && result.ValueLength == 9);
            result = IdentifierGeneratorUtils.PrefixInt("abcde", 333, 5, 5, true);
            Assert.IsTrue(result.Result == "00333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.NoOriginalValueOnResult && result.PreSuffixLength == 5 && result.ValueLength == 0);
            result = IdentifierGeneratorUtils.PrefixInt("abc", 333, 0, 3, true);
            Assert.IsTrue(result.Result == "333" && result.State == IdentifierGeneratorUtils.PreSuffixStateEnum.NoOriginalValueOnResult && result.PreSuffixLength == 3 && result.ValueLength == 0);
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 2, 15, true);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 0, 2, true);
                Assert.Fail();
            } catch (Exception) {
            }
            try {
                IdentifierGeneratorUtils.PrefixInt("abcdefghij", 333, 5, 4, true);
                Assert.Fail();
            } catch (Exception) {
            }
            #endregion
        }
    }
}
