namespace FileReaderRandomSelect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var resources = GetResources();

            Console.Write("What are you here for? Search or Practice (s/p): ");
            string task = Console.ReadLine().ToLower();
            bool isHereToPractice = task.StartsWith("p");
            Console.Clear();
            Console.WriteLine();

            if (isHereToPractice)
            {
                Interview.PracticeMode(resources.questions, resources.answers);
            }
            else
            {
                Interview.InterviewMode(resources.questions, resources.answers);
                Interview.AskInterviewrsQuestions(resources.questionsForInterviewrs);
            }
            Console.ReadKey();
        }

        private static dynamic GetResources()
        {
            List<string> questions = File.ReadAllLines("C:\\Users\\menzi.khuzwayo\\source\\repos\\FileReaderRandomSelect\\FileReaderRandomSelect\\Questions.txt").ToList();
            List<string> answers = File.ReadAllLines("C:\\Users\\menzi.khuzwayo\\source\\repos\\FileReaderRandomSelect\\FileReaderRandomSelect\\answers.txt").ToList();
            List<string> questionsForInterviewrs = File.ReadAllLines("C:\\Users\\menzi.khuzwayo\\source\\repos\\FileReaderRandomSelect\\FileReaderRandomSelect\\myQuestions.txt").ToList();

            return new { questions , answers, questionsForInterviewrs };
        }
    }
}