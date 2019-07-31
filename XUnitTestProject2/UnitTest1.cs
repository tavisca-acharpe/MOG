using System;
using merchant_galaxy;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        Program p = new Program();

        [Fact]
        public void checkRoman()
        {
            Assert.Equal(1, p.Convert_Roman_To_Integer("glob is I"));
            Assert.Equal(5, p.Convert_Roman_To_Integer("prok is V"));
            Assert.Equal(10, p.Convert_Roman_To_Integer("pish is X"));
            Assert.Equal(50, p.Convert_Roman_To_Integer("tegj is L"));
            Assert.Equal(100, p.Convert_Roman_To_Integer("tegj is C"));
            Assert.Equal(500, p.Convert_Roman_To_Integer("tegj is D"));
            Assert.Equal(1000, p.Convert_Roman_To_Integer("tegj is M"));
        }

        [Fact]
        public void check_Order_Roman_Addition()
        {
            Assert.Equal(6, p.Extra_Addition_of_Roman("IIIIII"));
            Assert.Equal(56, p.Extra_Addition_of_Roman("LVXI"));
            Assert.Equal(66, p.Extra_Addition_of_Roman("LXVI"));
            Assert.Equal(1944, p.Extra_Addition_of_Roman("MCMXLIV"));
            Assert.Equal(1903, p.Extra_Addition_of_Roman("MCMIII"));
        }

        [Fact]
        public void check_initial_conditions()
        {
            p.pass_statement_to_galaxy("glob is I");
            p.pass_statement_to_galaxy("prok is V");
            p.pass_statement_to_galaxy("pish is X");
            p.pass_statement_to_galaxy("tegj is L");

            Assert.Equal("I", p.get_value_from_galaxy("glob"));
            Assert.Equal("V", p.get_value_from_galaxy("prok"));
            Assert.Equal("X", p.get_value_from_galaxy("pish"));
            Assert.Equal("L", p.get_value_from_galaxy("tegj"));
        }

        [Fact]
        public void check_first_type_of_statement()
        {
            p.pass_statement_to_galaxy("glob is I");
            p.pass_statement_to_galaxy("prok is V");
            p.pass_statement_to_galaxy("pish is X");
            p.pass_statement_to_galaxy("tegj is L");

            p.add_value_of_gsi("glob prok Gold is 57800 Credits");
            p.add_value_of_gsi("glob glob Silver is 34 Credits");
            p.add_value_of_gsi("pish pish Iron is 3910 Credits");

            Assert.Equal(42, p.check_for_typeOf_question("how much is pish tegj glob glob ?"));
            Assert.Equal(68, p.check_for_typeOf_question("how many Credits is glob prok Silver ?"));
            Assert.Equal(57800, p.check_for_typeOf_question("how many Credits is glob prok Gold ?"));
            Assert.Equal(780, p.check_for_typeOf_question("how many Credits is glob prok Iron ?"));
        }
    }
}
