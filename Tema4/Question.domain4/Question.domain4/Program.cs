using Question.domain4.PostedQuestionWorkflow;
using System;
using static Question.domain4.PostedQuestionWorkflow.PostedQuestionResult;
using static Question.domain4.PostedQuestionWorkflow.PostedQuestionCmd;

namespace Question.domain4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new PostedQuestionCmd("Title",  "Body", "Tags");
            var result = PostedQuestion(cmd);

            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static string ProcessQuestionPosted(PostedQuestionResult.QuestionPosted arg)
        {
            return "Question Posted";    
        }

        private static string ProcessQuestionNotPosted(PostedQuestionResult.QuestionNotPosted arg)
        {
            return "Question not Posted";
        }

        private static string ProcessInvalidQuestion(PostedQuestionResult.InvalidQuestion arg)
        {
            return $"Invalid: {arg.Cmd.ToString()}";
        }

        static PostedQuestionResult.IPostedQuestion PostedQuestion(string title, string body, string tags)
        {
            return new PostedQuestionResult.QuestionPosted(1);
        }
    }
}
