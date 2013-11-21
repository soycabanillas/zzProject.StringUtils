using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zzProject.StringUtils
{
    public enum TruncateWordsOptionsEnum
    {
        Truncate = 1,
        TruncateToEndOfPreviousWord = 2,
        TruncateToEndOfWordOrEndOfPreviousWord = 3,
        TruncateToEndOfWordOrCurrentPosition = 4,
        NotImplemented = 5
    }

    public enum TruncateDirectionEnum { 
        Left = 0,
        Right = 1
    }

    public enum WordPositionEnum {
        Begin = 0,
        End = 1
    }

    public enum StringPositionEnum {
        BeginOfWord = 1,
        EndOfWord = 2,
        MiddleOfWord = 3,
        MiddleOfNonWord = 4
    }

    public class StringExtensions
    {
        public static int GetPositionEndOfPreviousWord(string text, int position)
        {
            string regStartOfLastWholeWordEndOfString = @"(\s*\z)";
            string regStartOfLastWholeWordMiddleOfString = @"(\s+|\s+\S+)\z";
            int positionLastWord;
            if (position == text.Length)
            {
                var matchLastWord = (new Regex(regStartOfLastWholeWordEndOfString, RegexOptions.None)).Match(text);
                positionLastWord = matchLastWord.Groups[0].Index;
            }
            else if (position < text.Length)
            {
                var matchLastWord = (new Regex(regStartOfLastWholeWordMiddleOfString, RegexOptions.None)).Match(text, 0, position + 1);
                positionLastWord = matchLastWord.Groups[0].Index;
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Argument position ({0}) cannot be greater than text length ({1}).", position, text.Length));
            }
            return positionLastWord;
        }

        public static int GetPositionEndOfWordOrCurrentPosition(string text, int position)
        {
            string regEndOfNextWholeWordMiddleOfString = @"\G(\S+)";
            int positionLastWord;
            if (position == text.Length)
            {
                positionLastWord = text.Length;
            }
            else if (position == 0)
            {
                positionLastWord = 0;
            }
            else if (position < text.Length)
            {
                var matchLastWord = (new Regex(regEndOfNextWholeWordMiddleOfString, RegexOptions.None)).Match(text, position - 1);
                positionLastWord = matchLastWord.Success ? matchLastWord.Groups[0].Index + matchLastWord.Groups[0].Length : position;
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Argument preferedLength ({0}) cannot be greater than text length ({1}).", position, text.Length));
            }
            return positionLastWord;
        }

        public static int GetPositionEndOfWordOrEndOfPreviousWord(string text, int position) {
            string regLastWholeWordEndOfString = @"(\s*\z)";
            //string regNextWholeWordBeginOfString = @"\A(\S*)";
            string regLastWholeWordMiddleOfString = @"(\s+)\z";
            string regNextWholeWordMiddleOfString = @"\G(\S+)";
            int result;
            if (position == 0) {
                return 0;
                //var matchLastWord = (new Regex(regNextWholeWordBeginOfString, RegexOptions.None)).Match(text);
                //result = matchLastWord.Length;
            } else if (position == text.Length) {
                var matchLastWord = (new Regex(regLastWholeWordEndOfString, RegexOptions.None)).Match(text);
                result = matchLastWord.Index;
            } else if (position < text.Length) {
                var matchLastWordNext = (new Regex(regNextWholeWordMiddleOfString, RegexOptions.None)).Match(text, position - 1);
                if (matchLastWordNext.Success) {
                    result = matchLastWordNext.Groups[0].Index + matchLastWordNext.Groups[0].Length;
                } else {
                    var matchLastWordPrevious = (new Regex(regLastWholeWordMiddleOfString, RegexOptions.None)).Match(text, 0, position);
                    result = matchLastWordPrevious.Groups[0].Index;
                }
            } else {
                throw new ArgumentOutOfRangeException(String.Format("Argument preferedLength ({0}) cannot be greater than text length ({1}).", position, text.Length));
            }
            return result;
        }

        public static int GetPositionToTruncate(
            string toTruncate, 
            TruncateWordsOptionsEnum truncateWordsOptions, 
            int preferedLength, 
            int maxLength = 0,
            int ellipsisLength = 0)
        {
            if (maxLength != 0)
            {
                if (preferedLength > maxLength) preferedLength = maxLength;
                if (ellipsisLength > 0 && ellipsisLength > maxLength) throw new ArgumentOutOfRangeException(String.Format("The parameter ellipsisLength ({0}), cannot be bigger than the parameter maxLength ({1}).", ellipsisLength, maxLength));
            }
            if (preferedLength > toTruncate.Length) preferedLength = toTruncate.Length;
            int lengthWithoutEllipsis = Math.Max(0, preferedLength - ellipsisLength);

            int result;
            switch (truncateWordsOptions)
            {
                case TruncateWordsOptionsEnum.Truncate:
                    result = lengthWithoutEllipsis;
                    break;
                case TruncateWordsOptionsEnum.TruncateToEndOfWordOrCurrentPosition:
                    result = StringExtensions.GetPositionEndOfWordOrCurrentPosition(toTruncate, lengthWithoutEllipsis);
                    if (maxLength != 0) result = Math.Min(result, maxLength - ellipsisLength);
                    break;
                case TruncateWordsOptionsEnum.TruncateToEndOfPreviousWord:
                    result = StringExtensions.GetPositionEndOfPreviousWord(toTruncate, lengthWithoutEllipsis);
                    break;
                case TruncateWordsOptionsEnum.TruncateToEndOfWordOrEndOfPreviousWord:
                    string regLastWholeWordEndOfString = @"(\s*\z)";
                    //string regNextWholeWordBeginOfString = @"\A(\S*)";
                    string regLastWholeWordMiddleOfString = @"(\s+)\z";
                    string regNextWholeWordMiddleOfString = @"\G(\S+)";
                    if (lengthWithoutEllipsis == 0) {
                        result = 0;
                        //var matchLastWord = (new Regex(regNextWholeWordBeginOfString, RegexOptions.None)).Match(text);
                        //result = matchLastWord.Length;
                    } else if (lengthWithoutEllipsis == preferedLength) {
                        var matchLastWord = (new Regex(regLastWholeWordEndOfString, RegexOptions.None)).Match(toTruncate);
                        result = matchLastWord.Index;
                    } else /*if (lengthWithoutEllipsis < preferedLength)*/ {
                        var matchLastWordNext = (new Regex(regNextWholeWordMiddleOfString, RegexOptions.None)).Match(toTruncate, lengthWithoutEllipsis - 1);
                        if (matchLastWordNext.Success && matchLastWordNext.Groups[0].Index + matchLastWordNext.Groups[0].Length <= preferedLength) {
                            result = matchLastWordNext.Groups[0].Index + matchLastWordNext.Groups[0].Length;
                        } else {
                            var matchLastWordPrevious = (new Regex(regLastWholeWordMiddleOfString, RegexOptions.None)).Match(toTruncate, 0, lengthWithoutEllipsis);
                            result = matchLastWordPrevious.Groups[0].Index;
                        }
                    }
                    break;
                    //int lengthUntilPreviousWord = StringExtensions.GetPositionEndOfWordOrCurrentPosition(toTruncate, lengthWithoutEllipsis);
                    //int lengthUntilEndOfWord = StringExtensions.GetPositionEndOfWordOrCurrentPosition(toTruncate, lengthWithoutEllipsis);
                    //if (lengthUntilPreviousWord != preferedLength && lengthUntilEndOfWord != preferedLength) //We are in the middle of a word
                    //{
                    //    if (lengthUntilEndOfWord <= maxLength) {
                    //        result = lengthUntilEndOfWord;
                    //    } else {
                    //        result = lengthUntilPreviousWord;
                    //    }
                    //} else {
                    //    result = lengthUntilPreviousWord;
                    //}
                    //break;
                default:
                    throw new NotImplementedException(String.Format("Argument truncateWordsOptions has an option ({0}) not implemented.", Enum.GetName(typeof(TruncateWordsOptionsEnum), truncateWordsOptions)));
            }
            return result;
        }
    }
}
