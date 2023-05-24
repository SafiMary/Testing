using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Testing
{

    internal class Program
    {



        static void Main(string[] args)
        {
            string path = "task.txt";
            if (args.Length > 0)
            {
                path = args[0];
            }

            else
            {
                Console.WriteLine("аргументы не переданны");
            }

          
            var streamReader = new StreamReader(path);
            string strArithmetic = string.Empty;

            for (int i = 0; !streamReader.EndOfStream; i++)
            {
                strArithmetic = streamReader.ReadToEnd();
                Console.WriteLine($"Считали файл \n{strArithmetic}");
            }
            //streamReader.Close();
            var regexleft = new Regex(@"\d+\s*(\+|\-|\*|\/)");
                var regexrigth = new Regex(@"(\+|\-|\*|\/)\s*\d+");
                var regNum = new Regex(@"\d+");
                var regexOperator = new Regex(@"(\+|\-|\*|\/)");
                MatchCollection matchesleft = regexleft.Matches(strArithmetic);
                MatchCollection numLeft = regNum.Matches(matchesleft[0].ToString());
                MatchCollection matchesrigth = regexrigth.Matches(strArithmetic);
                MatchCollection numrigth = regNum.Matches(matchesrigth[0].ToString());
                MatchCollection operat = regexOperator.Matches(matchesleft[0].ToString());
                List<int> _OperandLeft = new List<int>();
                List<int> _OperandRight = new List<int>();
                List<char> _operat = new List<char>();

                _OperandLeft.Add(int.Parse(numLeft[0].ToString()));
                _OperandRight.Add(int.Parse(numrigth[0].ToString()));
                _operat.Add(char.Parse(operat[0].ToString()));
                var streamWriter = new StreamWriter("solution.txt");
                int resault;
                for (int j = 0; j < _operat.Count; j++)
                {
                    switch (_operat[j])
                    {
                        case '+': resault = _OperandLeft[j] + _OperandRight[j]; break;
                        case '-': resault = _OperandLeft[j] - _OperandRight[j]; break;
                        case '*': resault = _OperandLeft[j] * _OperandRight[j]; break;
                        case '/':
                            if (_OperandRight[j] != 0)
                            {
                                resault = _OperandLeft[j] / _OperandRight[j];
                            }
                            else
                            {
                                Console.WriteLine("Ошибка:на ноль нельзя делить");
                                resault = -1;
                            }; break;
                        default: resault = -1; break;
                    }
                 streamWriter.WriteLine($"{_OperandLeft[j]} {_operat[j]} {_OperandRight[j]} = {resault}");
                    Console.WriteLine($"Записали результат в файл {_OperandLeft[j]} {_operat[j]} {_OperandRight[j]} = {resault}");

                }
                streamWriter.Close();
            }
                
                
           


           

            


        }
    }




    