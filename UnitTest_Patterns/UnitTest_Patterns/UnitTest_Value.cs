using System;
using Patterns;
using Xunit;

namespace UnitTest_Patterns
{
    public class UnitTest_Value
    {
        [Fact]
        public void ShouldBe_True_ValidJson()
        {
            IPattern str = new Value();
            string tmp = "{\"menu\": { "                                           
                        + "\"popup\": {"
                        + "\"menuitem\": ["                       
                        + "{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"}"                      
                        + "]"
                        + "}"
                        + "}}";
            Assert.True(str.Match(tmp).Success());
            Assert.True(str.Match(tmp).RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_InvalidJson_Missing_SecondLeftBracket()
        {
            IPattern str = new Value();
            string tmp = "{\"menu\":  "
                        + "\"id\": \"file\","
                        + "\"value\": \"File\","
                        + "\"popup\": {"
                        + "\"menuitem\": ["
                        + "{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"},"                      
                        + "{\"value\": \"Close\", \"onclick\": \"CloseDoc()\"}"
                        + "]"
                        + "}"
                        + "}}";
            Assert.False(str.Match(tmp).Success());
            Assert.True(str.Match(tmp).RemainingText() == tmp);
        }

        [Fact]
        public void ShouldBe_True_ValidJson_ListInObject()
        {
            IPattern str = new Value();
            string tmp = "{\"menu\":"
                        + "["
                        + "{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"}"
                        + "]"                      
                        + "}";
            Assert.True(str.Match(tmp).Success());
            Assert.True(str.Match(tmp).RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_ValidSimpleJson_Object()
        {
            IPattern str = new Value();
            Assert.True(str.Match("{\"menu\": \"casper\"}").Success());
            Assert.True(str.Match("{\"menu\": \"casper\"}").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_ValidSimpleJson_Array()
        {
            IPattern str = new Value();
            Assert.True(str.Match("[1, 2, 3]").Success());
            Assert.True(str.Match("[1, 2, 3]").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_ValidJson_DoubleNestedObject()
        {
            IPattern str = new Value();
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\"}}").Success());
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\"}}").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_ValidJson_DoubleObject()
        {
            IPattern str = new Value();
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\", \"value\": \"casper\"} }").Success());
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\", \"value\": \"casper\"} }").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_InvalidJson_DoubleNestedObject()
        {
            IPattern str = new Value();
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\"}}}").Success());
            Assert.True(str.Match("{\"menu\": {\"id\": \"file\"}}}").RemainingText() == "}");
        }

        [Fact]
        public void ShouldBe_True_ValidJson_TripleNestedObject()
        {
            IPattern str = new Value();
            string tmp = "{\"menu\":"
                        + "{\"menuItem\":"
                        + "{\"value\": \"Open\"}"
                        + "}"
                        + "}";
            Assert.True(str.Match(tmp).Success());
            Assert.True(str.Match(tmp).RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_ValidJson_DoubleNestedArray()
        {
            IPattern str = new Value();
            Assert.True(str.Match("[{\"menu\": \"menuId\"}, {\"file\": \"fileName\"}]").Success());
            Assert.True(str.Match("[{\"menu\": \"menuId\"}, {\"file\": \"fileName\"}]").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_False_InvalidJson_DoubleNestedArray()
        {
            IPattern str = new Value();
            Assert.False(str.Match("[{\"menu\": \"menuId\"}}, {\"file\": \"fileName\"}]").Success());
            Assert.True(str.Match("[{\"menu\": \"menuId\"}}, {\"file\": \"fileName\"}]").RemainingText() == "[{\"menu\": \"menuId\"}}, {\"file\": \"fileName\"}]");
        }

        [Fact]
        public void ShouldBe_False_EmptyJson()
        {
            IPattern str = new Value();
            Assert.False(str.Match("").Success());
            Assert.True(str.Match("").RemainingText() == "");
        }

        [Fact]
        public void ShouldBe_True_NullJson()
        {
            IPattern str = new Value();
            Assert.True(str.Match("null").Success());
            Assert.True(str.Match("null").RemainingText() == "");
        }
    }
}
