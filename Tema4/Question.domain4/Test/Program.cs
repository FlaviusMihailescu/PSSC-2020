using Question.domain4.PostedQuestionWorkflow;
using System;
using System.Collections.Generic;
using static Question.domain4.PostedQuestionWorkflow.PostedQuestionResult;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new PostedQuestionCmd("TitleQuestion", "BodyQuestion", "TagsQuestion");
            var result = PostedQuestion(cmd);

            var createQuestionEvent = result.Match(ProcessQuestionPosted, ProcessQuestionNotPosted, ProcessInvalidQuestion);

            Console.ReadLine();
        }

        private static IPostedQuestion ProcessQuestionPosted(QuestionPosted question)
        {
            Console.WriteLine($"Question ID: {question.QuestionId}");
            Console.WriteLine($"Body Question: {question.Body}");
            return question;
        }

        private static IPostedQuestion ProcessQuestionNotPosted(QuestionNotPosted questionNotPosted)
        {
            Console.WriteLine($"Question not posted: {questionNotPosted.Reason}");
            return questionNotPosted;
        }

        private static IPostedQuestion ProcessInvalidQuestion(PostedQuestionResult.InvalidQuestion validationErrors)
        {
            Console.WriteLine("Question is invalid: ");
            foreach (var error in validationErrors.QuestionInvalid)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        static PostedQuestionResult.IPostedQuestion PostedQuestion(PostedQuestionCmd postedQuestion)
        {
            if (string.IsNullOrWhiteSpace(postedQuestion.Body))
            {
                var errors = new List<string>() { "Your question" };
                return new InvalidQuestion(errors);
            }

            if (string.IsNullOrEmpty(postedQuestion.Title))
            {
                return new QuestionNotPosted("Give a title");
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, postedQuestion.Body);

            return result;
        }
    }
}
