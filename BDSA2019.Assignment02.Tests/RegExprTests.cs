using System.Collections.Generic;
using Xunit;

namespace BDSA2019.Assignment02.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void splitline_given_lines_returns_words()
        {
            // Arrange
            var lines = new List<string>{"Hej med dig", "jeg hedder John"};

            // Act
            var output = RegExpr.SplitLine(lines);

            // Assert
            var expected = new List<string>{"Hej", "med", "dig", "jeg", "hedder", "John"};
            Assert.Equal(expected, output);
        }
        
        [Fact]
        public void resolutions_given_stream_of_resolutions_returns_tuples_of_width_and_height()
        {
            // Arrange
            var input = "1440x690, 1020x1080, 360x2400, 360x640";
            
            // Act

            var output = new List<(int, int)>(RegExpr.Resolution(input));

            // Assert
            var expected = new List<(int,int)>{(1440,690),(1020,1080),(360,2400),(360,640)};

            Assert.Equal(expected, output);
        }
        
        [Fact]
        public void innertext_given_html_and_tag_returns_content()
        {
            // Arrange
            var input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p></div>";

            // Act
            var output = RegExpr.InnerText(input, "a");

            // Assert
            var expected = new List<string>{"theoretical computer science","formal language","characters","pattern","string searching algorithms","strings"};

            Assert.Equal(expected, output);
        }

        [Fact]
        public void innertext_given_html_with_nested_tags_and_tag_returns_content()
        {
            // Arrange
            var input = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";

            // Act
            var output = new List<string>(RegExpr.InnerText(input, "p"));

            // Assert
            var expected = new List<string>{"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

            Assert.Equal(expected, output);
        }   
    }
}
