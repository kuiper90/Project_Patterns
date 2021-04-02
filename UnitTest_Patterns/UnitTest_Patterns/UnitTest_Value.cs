using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Value
    {
        [Fact]
        public void JsonArrayMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\": { "
                         + "\"popup\": {"
                         + "\"menuitem\":"
                            + "["
                                + "{\"value\": \"Open\","
                                + "\"onclick\": \"OpenDoc()\"}"
                            + "]"
                         + "}"
                         + "}}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void DoubleEndingJsonDoesNotMatchJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":  "
                         + "\"id\": \"file\","
                         + "\"value\": \"File\","
                         + "\"popup\":"
                            + "{"
                                + "\"menuitem\":"
                                + "["
                                     + "{\"value\": \"New\","
                                     + "\"onclick\": \"CreateNewDoc()\"},"
                                     + "{\"value\": \"Close\","
                                     + "\"onclick\": \"CloseDoc()\"}"
                                + "]"
                            + "}"
                         + "}}";
            Assert.False(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText() == str);
        }

        [Fact]
        public void JsonArrayJsonValueMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":"
                            + "["
                                + "{\"value\": \"Open\","
                                + "\"onclick\": \"OpenDoc()\"}"
                            + "]"
                         + "}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void SimplestJsonMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\": \"file\"}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void CharacterArrayMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "[1, 2, 3]";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void SimpleNestedJsonMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":"
                            + "{\"id\": \"file\"}"
                          + "}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void NestedJsonMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":"
                            + "{\"id\": \"file\","
                            + "\"value\": \"txt\"}"
                          + "}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void IncorrectEndingNestedJsonDoesNotMatchJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":"
                            + "{\"id\": \"file\"}}"
                          + "}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText() == "}");
        }

        [Fact]
        public void DoubleNestedJsonMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "{\"menu\":"
                            + "{\"menuItem\":"
                                + "{\"value\": \"Open\"}"
                            + "}"
                         + "}";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void ArrayJsonMatchesJson()
        {
            IPattern pattern = new Value();
            string str = "["
                            + "{\"menu\": \"id\"},"
                            + "{\"file\": \"fileName\"}"
                         + "]";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }

        [Fact]
        public void ArrayJsonMissingSeparatorDoesNotMatchJson()
        {
            IPattern pattern = new Value();
            string str = "["
                            + "{\"menu\": \"id\"}"
                            + "{\"file\": \"fileName\"}"
                         + "]";
            Assert.False(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText() == str);
        }

        [Fact]
        public void IncorrectEndingJsonInArrayDoesNotMatchJson()
        {
            IPattern pattern = new Value();
            string str = "["
                            + "{\"menu\": \"id\"}"
                            + "},"
                            + "{\"file\": \"fileName\"}"
                          + "]";
            Assert.False(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText() == str);
        }

        [Fact]
        public void EmptyDoesNotMatchJson()
        {
            IPattern pattern = new Value();
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText()?.Length == 0);
        }

        [Fact]
        public void NullMatchesNullJson()
        {
            IPattern pattern = new Value();
            string str = "null";
            Assert.True(pattern.Match(str).Success());
            Assert.True(pattern.Match(str).RemainingText()?.Length == 0);
        }
    }
}
