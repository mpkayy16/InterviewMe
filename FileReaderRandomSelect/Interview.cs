namespace FileReaderRandomSelect
{
    public static class Interview
    {
        internal static void PracticeMode(List<string> questions, List<string> answers)
        {
            Random random = new Random();
            while (questions.Count > 0)
            {
                int index = random.Next(questions.Count);
                string randomQuestion = questions[index];
                questions.RemoveAt(index);
                var answersArray = answers[index].Split("~~");
                answers.RemoveAt(index);

                Console.WriteLine(randomQuestion);
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    answersArray?.ToList().ForEach(answer => Console.WriteLine($"==> {answer}"));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        internal static void InterviewMode(List<string> questions, List<string> answers)
        {
            bool isInterviewComplete = false;
            while (!isInterviewComplete)
            {
                Console.Write("Enter a search string:  ");
                string searchString = Console.ReadLine().ToLower();
                Console.WriteLine();
                isInterviewComplete = searchString == ";";
                Console.Clear();
                if (isInterviewComplete)
                {
                    Console.WriteLine("Interview complete...");
                    continue;
                }
                var questionsMatched = questions.Where(a => a.ToLower().Contains(searchString));
                if (questionsMatched.Any())
                {
                    Console.Clear();
                    foreach (var q in questionsMatched)
                    {
                        var indexOfQuestionMatched = questions.IndexOf(q);
                        PrintQuestionAndAnswer(questions[indexOfQuestionMatched], answers[indexOfQuestionMatched]);
                    }
                }
                else
                {
                    SearchByMatchCount(questions, answers, searchString);
                }
            }
        }
        static void SearchByMatchCount(List<string> questions, List<string> answers, string searchString)
        {
            string[] searchTerms = searchString.Split(' ');

            Dictionary<int, int> matchCount = new Dictionary<int, int>();
            for (int i = 0; i < questions.Count; i++)
            {
                int count = searchTerms.Count(term => questions[i].Contains(term));
                if (count > 0)
                {
                    matchCount.Add(i, count);
                }
            }
            var top3matches = matchCount.OrderByDescending(pair => pair.Value).Take(3);
            foreach (var item in top3matches)
            {
                PrintQuestionAndAnswer(questions[item.Key], answers[item.Key]);
            }
        }

        static void PrintQuestionAndAnswer(string question, string answer)
        {
            Console.WriteLine(question);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==> " + answer);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("~~");
        }

        public static void AskInterviewrsQuestions(List<string> myQuestions)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            myQuestions.ForEach(x => Console.WriteLine(x + "\n"));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}