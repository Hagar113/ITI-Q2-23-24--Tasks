namespace TASK4
{
        class Question
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public double Mark { get; set; }

            public override string ToString()
            {
                return $" Header :{Header} \t Body :{Body} \t Mark :{Mark} \n ---------------------------------------------------------------------";
            }

        }
        class Answer
        {
            public int ID { get; set; }
            public string Txt { get; set; }
            public bool boolStatus { get; set; }
            public override string ToString()
            {
                return $" ID :{ID} \t Text :{Txt} \t boolStatus :{boolStatus}";
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Dictionary<Question, List<Answer>> ans = new Dictionary<Question, List<Answer>>();

                Question q = new Question
                {
                    Header = "true/false",
                    Body = "An octopus has seven hearts",
                    Mark = 4
                };
            
            Question q2 = new Question
            {
                Header = "True or False",
                Body = "The Amazon River is the longest river in the world.",
                Mark = 4
            };

            List<Answer> answers2 = new List<Answer>
{
    new Answer { ID = 1, Txt = "True", boolStatus = true },
    new Answer { ID = 2, Txt = "False", boolStatus = false },
};

            ans.Add(q2, answers2);

            
            Question q3 = new Question
            {
                Header = "Matching",
                Body = "Match the countries with their capitals.",
                Mark = 6
            };

            List<Answer> answers5 = new List<Answer>
             {
    new Answer { ID = 1, Txt = "Canada", boolStatus = false },
    new Answer { ID = 2, Txt = "Australia", boolStatus = false },
    new Answer { ID = 3, Txt = "Germany", boolStatus = false },
    new Answer { ID = 4, Txt = "United States", boolStatus = false },
    new Answer { ID = 5, Txt = "Ottawa", boolStatus = true },
    new Answer { ID = 6, Txt = "Canberra", boolStatus = true },
    new Answer { ID = 7, Txt = "Berlin", boolStatus = true },
    new Answer { ID = 8, Txt = "Washington, D.C.", boolStatus = true },
    };

            ans.Add(q3, answers5);

            List<Answer> answers = new List<Answer>
            {
                new Answer { ID = 1, Txt = "true ", boolStatus = false },
                new Answer { ID = 2, Txt = "false", boolStatus = true},
                new Answer { ID = 3, Txt = "true", boolStatus = false },
                new Answer { ID = 4, Txt = "true ", boolStatus = false },
                new Answer { ID = 5, Txt = "false", boolStatus = true},
                new Answer { ID = 6, Txt = "true", boolStatus = false },
            };
            ans.Add(q, answers);
                foreach (KeyValuePair<Question, List<Answer>> item in ans)
                {
                    Console.WriteLine("Question:");
                    Console.WriteLine(item.Key);

                    Console.WriteLine("Answers:");
                    foreach (Answer answer in item.Value)
                    {
                        Console.WriteLine(answer);
                        Console.WriteLine();
                    }
                }
            }
        }
    }


