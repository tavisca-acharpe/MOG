using System;
using System.Collections.Generic;

namespace merchant_galaxy
{
   public class Program
    {
      public  IDictionary<string,int> dict = new Dictionary<string,int>()
        {
            {"I" , 1 },
            {"V", 5 },
            {"X", 10 },
            {"L" ,50 },
            {"C" , 100 },
            {"D" , 500 },
            {"M", 1000 }                                        
        };

        public IDictionary<string, string> galaxy = new Dictionary<string, string>();

        public IDictionary<string, int> gsi = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.pass_statement_to_galaxy("glob is I");
            p.pass_statement_to_galaxy("prok is V");
            p.pass_statement_to_galaxy("pish is X");
            p.pass_statement_to_galaxy("tegj is L");

            int v1 = p.check_for_typeOf_question("how much is pish tegj glob glob ?");
            Console.WriteLine(v1);

            p.add_value_of_gsi("glob prok Gold is 57800 Credits");
            p.add_value_of_gsi("glob glob Silver is 34 Credits");
            p.add_value_of_gsi("pish pish Iron is 3910 Credits");

            int v = p.check_for_typeOf_question("how many Credits is glob prok Silver ?");
            Console.WriteLine(v);

            v = p.check_for_typeOf_question("how many Credits is glob prok Gold ?");
            Console.WriteLine(v);

            v = p.check_for_typeOf_question("how many Credits is glob prok Iron ?");
            Console.WriteLine(v);
        }

        public void add_value_of_gsi(string statement)
        {
            if (statement.Contains("Gold"))
            {
                string[] temp = statement.Split(' ');
                string[] statement1 = statement.Split(" Gold ");
                string[] st2 = statement1[0].Split(' ');
                int value = get_addition_from_word(st2);
                int gvalue =int.Parse(temp[temp.Length - 2])/value;
                gsi.Add("Gold",gvalue);
            }
            if (statement.Contains("Silver"))
            {
                string[] temp = statement.Split(' ');
                string[] statement1 = statement.Split(" Silver ");
                string[] st2 = statement1[0].Split(' ');
                int value = get_addition_from_word(st2);
                int gvalue = int.Parse(temp[temp.Length - 2]) / value;
                gsi.Add("Silver", gvalue);
            }
            if (statement.Contains("Iron"))
            {
                string[] temp = statement.Split(' ');
                string[] statement1 = statement.Split(" Iron ");
                string[] st2 = statement1[0].Split(' ');
                int value = get_addition_from_word(st2);
                int gvalue = int.Parse(temp[temp.Length - 2]) / value;
                gsi.Add("Iron", gvalue);
            }

        }

        public int get_addition_from_word(string[] words)
        {
            string romanstat = "";
            foreach (string word in words)
            {
                romanstat = romanstat + get_value_from_galaxy(word);
            } 
            int value = Extra_Addition_of_Roman(romanstat);
            return value;
        }

        public int check_for_typeOf_question(string statement)
        {
            if(statement.Contains("how much"))
            {
                string[] statement1 = statement.Split("how much is ");
                statement1 = statement1[1].Split(" ?");
                string[] words = statement1[0].Split(' ');

                int value = get_addition_from_word(words);
                return value;
            }
            if (statement.Contains("how many"))
            {
                string[] statement1 = statement.Split("how many Credits is ");     
                statement1 = statement1[1].Split(" ?");     
                string[] words = statement1[0].Split(' ');
                string glsWord = words[2];
                Array.Resize(ref words, words.Length - 1);      
                int value = get_addition_from_word(words);
                value = value *gsi[glsWord];
                return value;
            }
            return 0;
        }

        public string get_value_from_galaxy(string word)
        {
            string romanWord = galaxy[word];
            return romanWord;
        }

        public void pass_statement_to_galaxy(string statement)
        {
            string[] parts = statement.Split(' ');
            string firstWord = parts[0];
            string lastWord = parts[parts.Length - 1];
            galaxy.Add(firstWord,lastWord);
        }

        public void Add_to_galaxy(string s1,string s2)
        {
            galaxy.Add(s1,s2);
        }

        public int Return_Roman_To_Integer(string roman)
        {
            int value = dict[roman];
            return value;
        }

        public int Convert_Roman_To_Integer(string input)
        {
            string[] parts = input.Split(' ');
            string lastWord = parts[parts.Length - 1];
            int value;
            return  value = Return_Roman_To_Integer(lastWord);        
        }


        public int Extra_Addition_of_Roman(string input)
        {
            int result = 0,temp1=0, temp2=0;
            
            for (int i=0;i<input.Length;i++)
            {
                temp1 = Return_Roman_To_Integer(input[i].ToString());

                if (i != input.Length - 1)
                {
                    temp2 = Return_Roman_To_Integer(input[i + 1].ToString());
                }
                else
                {
                    temp2 = temp1 - 1;
                }


                if (temp2>temp1)
                {
                    result = result + (temp2-temp1);
                    i = i + 1;
                }
                else
                {
                    result = result +temp1;
                }
            }
            return result;
        }


    }
}
