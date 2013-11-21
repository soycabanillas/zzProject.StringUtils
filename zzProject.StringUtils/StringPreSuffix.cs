using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace zzProject.StringUtils
{
    public class StringPreSuffix
    {
        public enum PreSuffixStateEnum
        {
            MatchSpecifications = 0,
            OriginalValueTrimmed = 1, //The original value has been trimmed to fit the max length
            NoOriginalValueOnResult = 2, //Only the prefix or suffix fits on the result. Neither the original value or part of it fits into the result. It can occur when (numPads = maxLength) || (numPads != maxLength && suffix's length = maxLength)
            MaxLengthTooShort = 3, //Specified max length is too short to create a new identifier
        }

        public class PreSuffixResult
        {
            public string Result { get; private set; }
            public PreSuffixStateEnum State { get; private set; }
            public int PreSuffixLength { get; private set; }
            public int ValueLength { get; private set; }

            public PreSuffixResult(string result, PreSuffixStateEnum state, int preSuffixLength, int valueLength)
            {
                this.Result = result;
                this.State = state;
                this.PreSuffixLength = preSuffixLength;
                this.ValueLength = valueLength;
            }
        }

        public static PreSuffixResult SuffixInt(string value, int suffix, int numPads = 0, int maxLength = 0, bool suffixOverValue = false)
        {
            int valueLength = value.Length;
            string suffixValue = suffix.ToString();
            int suffixLength = suffixValue.Length;

            if (numPads > 0)
            {
                if (suffixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on suffix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on suffix must be equal or bigger than numPads.", suffixLength, suffix, numPads));
                suffixValue = suffixValue.PadLeft(numPads, '0');
                suffixLength = suffixValue.Length;
            }

            if (maxLength == 0 || valueLength + suffixLength <= maxLength)
            {
                return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MatchSpecifications, suffixLength, valueLength);
            }
            else
            {
                if (suffixOverValue)
                {
                    if (suffixLength < maxLength)
                    {
                        int varNewValueLength = maxLength - suffixLength;
                        return new PreSuffixResult(value.Substring(0, varNewValueLength) + suffixValue, PreSuffixStateEnum.OriginalValueTrimmed, suffixLength, varNewValueLength);
                    }
                    else if (suffixLength == maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.NoOriginalValueOnResult, suffixLength, valueLength);
                    }
                    else //if (suffixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                    }
                }
                else
                {
                    return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult SuffixLong(string value, long suffix, int numPads = 0, int maxLength = 0, bool suffixOverValue = false) {
            int valueLength = value.Length;
            string suffixValue = suffix.ToString();
            int suffixLength = suffixValue.Length;

            if (numPads > 0) {
                if (suffixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on suffix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on suffix must be equal or bigger than numPads.", suffixLength, suffix, numPads));
                suffixValue = suffixValue.PadLeft(numPads, '0');
                suffixLength = suffixValue.Length;
            }

            if (maxLength == 0 || valueLength + suffixLength <= maxLength) {
                return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MatchSpecifications, suffixLength, valueLength);
            } else {
                if (suffixOverValue) {
                    if (suffixLength < maxLength) {
                        int varNewValueLength = maxLength - suffixLength;
                        return new PreSuffixResult(value.Substring(0, varNewValueLength) + suffixValue, PreSuffixStateEnum.OriginalValueTrimmed, suffixLength, varNewValueLength);
                    } else if (suffixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.NoOriginalValueOnResult, suffixLength, valueLength);
                    } else //if (suffixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult SuffixDecimal(string value, decimal suffix, int numPads = 0, int maxLength = 0, bool suffixOverValue = false) {
            int valueLength = value.Length;
            string suffixValue = suffix.ToString();
            int suffixLength = suffixValue.Length;

            if (numPads > 0) {
                if (suffixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on suffix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on suffix must be equal or bigger than numPads.", suffixLength, suffix, numPads));
                suffixValue = suffixValue.PadLeft(numPads, '0');
                suffixLength = suffixValue.Length;
            }

            if (maxLength == 0 || valueLength + suffixLength <= maxLength) {
                return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MatchSpecifications, suffixLength, valueLength);
            } else {
                if (suffixOverValue) {
                    if (suffixLength < maxLength) {
                        int varNewValueLength = maxLength - suffixLength;
                        return new PreSuffixResult(value.Substring(0, varNewValueLength) + suffixValue, PreSuffixStateEnum.OriginalValueTrimmed, suffixLength, varNewValueLength);
                    } else if (suffixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.NoOriginalValueOnResult, suffixLength, valueLength);
                    } else //if (suffixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult SuffixBigInt(string value, BigInteger suffix, int numPads = 0, int maxLength = 0, bool suffixOverValue = false) {
            int valueLength = value.Length;
            string suffixValue = suffix.ToString();
            int suffixLength = suffixValue.Length;

            if (numPads > 0) {
                if (suffixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on suffix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on suffix must be equal or bigger than numPads.", suffixLength, suffix, numPads));
                suffixValue = suffixValue.PadLeft(numPads, '0');
                suffixLength = suffixValue.Length;
            }

            if (maxLength == 0 || valueLength + suffixLength <= maxLength) {
                return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MatchSpecifications, suffixLength, valueLength);
            } else {
                if (suffixOverValue) {
                    if (suffixLength < maxLength) {
                        int varNewValueLength = maxLength - suffixLength;
                        return new PreSuffixResult(value.Substring(0, varNewValueLength) + suffixValue, PreSuffixStateEnum.OriginalValueTrimmed, suffixLength, varNewValueLength);
                    } else if (suffixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.NoOriginalValueOnResult, suffixLength, valueLength);
                    } else //if (suffixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(value + suffixValue, PreSuffixStateEnum.MaxLengthTooShort, suffixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult PrefixInt(string value, int prefix, int numPads = 0, int maxLength = 0, bool prefixOverValue = false) {
            int valueLength = value.Length;
            string prefixValue = prefix.ToString();
            int prefixLength = prefixValue.Length;

            if (numPads > 0) {
                if (prefixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on prefix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on prefix must be equal or bigger than numPads.", prefixLength, prefix, numPads));
                prefixValue = prefixValue.PadLeft(numPads, '0');
                prefixLength = prefixValue.Length;
            }

            if (maxLength == 0 || prefixLength + valueLength <= maxLength) {
                return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MatchSpecifications, prefixLength, valueLength);
            } else {
                if (prefixOverValue) {
                    if (prefixLength < maxLength) {
                        int varNewValueLength = maxLength - prefixLength;
                        return new PreSuffixResult(prefixValue + value.Substring(0, varNewValueLength), PreSuffixStateEnum.OriginalValueTrimmed, prefixLength, varNewValueLength);
                    } else if (prefixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.NoOriginalValueOnResult, prefixLength, valueLength);
                    } else //if (prefixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult PrefixLong(string value, long prefix, int numPads = 0, int maxLength = 0, bool prefixOverValue = false) {
            int valueLength = value.Length;
            string prefixValue = prefix.ToString();
            int prefixLength = prefixValue.Length;

            if (numPads > 0) {
                if (prefixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on prefix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on prefix must be equal or bigger than numPads.", prefixLength, prefix, numPads));
                prefixValue = prefixValue.PadLeft(numPads, '0');
                prefixLength = prefixValue.Length;
            }

            if (maxLength == 0 || prefixLength + valueLength <= maxLength) {
                return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MatchSpecifications, prefixLength, valueLength);
            } else {
                if (prefixOverValue) {
                    if (prefixLength < maxLength) {
                        int varNewValueLength = maxLength - prefixLength;
                        return new PreSuffixResult(prefixValue + value.Substring(0, varNewValueLength), PreSuffixStateEnum.OriginalValueTrimmed, prefixLength, varNewValueLength);
                    } else if (prefixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.NoOriginalValueOnResult, prefixLength, valueLength);
                    } else //if (prefixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult PrefixDecimal(string value, decimal prefix, int numPads = 0, int maxLength = 0, bool prefixOverValue = false) {
            int valueLength = value.Length;
            string prefixValue = prefix.ToString();
            int prefixLength = prefixValue.Length;

            if (numPads > 0) {
                if (prefixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on prefix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on prefix must be equal or bigger than numPads.", prefixLength, prefix, numPads));
                prefixValue = prefixValue.PadLeft(numPads, '0');
                prefixLength = prefixValue.Length;
            }

            if (maxLength == 0 || prefixLength + valueLength <= maxLength) {
                return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MatchSpecifications, prefixLength, valueLength);
            } else {
                if (prefixOverValue) {
                    if (prefixLength < maxLength) {
                        int varNewValueLength = maxLength - prefixLength;
                        return new PreSuffixResult(prefixValue + value.Substring(0, varNewValueLength), PreSuffixStateEnum.OriginalValueTrimmed, prefixLength, varNewValueLength);
                    } else if (prefixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.NoOriginalValueOnResult, prefixLength, valueLength);
                    } else //if (prefixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                }
            }
        }

        public static PreSuffixResult PrefixBigInt(string value, BigInteger prefix, int numPads = 0, int maxLength = 0, bool prefixOverValue = false) {
            int valueLength = value.Length;
            string prefixValue = prefix.ToString();
            int prefixLength = prefixValue.Length;

            if (numPads > 0) {
                if (prefixLength > numPads) throw new ArgumentException(String.Format("The number of digits ({0}) on prefix ({1})  is bigger than numPads ({2}) value. If numPads != 0, the number of digits on prefix must be equal or bigger than numPads.", prefixLength, prefix, numPads));
                prefixValue = prefixValue.PadLeft(numPads, '0');
                prefixLength = prefixValue.Length;
            }

            if (maxLength == 0 || prefixLength + valueLength <= maxLength) {
                return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MatchSpecifications, prefixLength, valueLength);
            } else {
                if (prefixOverValue) {
                    if (prefixLength < maxLength) {
                        int varNewValueLength = maxLength - prefixLength;
                        return new PreSuffixResult(prefixValue + value.Substring(0, varNewValueLength), PreSuffixStateEnum.OriginalValueTrimmed, prefixLength, varNewValueLength);
                    } else if (prefixLength == maxLength) {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.NoOriginalValueOnResult, prefixLength, valueLength);
                    } else //if (prefixLength > maxLength)
                    {
                        valueLength = 0;
                        return new PreSuffixResult(prefixValue, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                    }
                } else {
                    return new PreSuffixResult(prefixValue + value, PreSuffixStateEnum.MaxLengthTooShort, prefixLength, valueLength);
                }
            }
        }
    }
}
