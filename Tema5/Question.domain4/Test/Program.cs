using LanguageExt;
using Question.domain4.PostedQuestionWorkflow;
using System;
using System.Collections.Generic;
using static Question.domain4.PostedQuestionWorkflow.BodyQuestion;
using static Question.domain4.PostedQuestionWorkflow.PostedQuestionResult;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var bodyResult = UnpostedQuestion.CreateBody("MyQuestion");
            var tags = TagsQuestion.CreateTags("Java, Python, C#");

            bodyResult.Match(
                Succ: body =>
                {
                    return NewMethod(body);
                },
                Fail: ex =>
                {
                    Console.WriteLine("Invalid dimension quesion");
                    return Unit.Default;
                }
            );

            tags.Match(
                Succ: tagss =>
                {
                    Console.WriteLine("Tags question is valid");
                    return Unit.Default;
                },
                Fail: ex =>
                {
                    Console.WriteLine("Invalid number the tags of question");
                    return Unit.Default;
                }
            );

            Console.ReadLine();

            /*
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
                    */
        }

        private static Unit NewMethod(UnpostedQuestion body)
        {
            var verifiedQuestionResult = new PostedQuestionService().PostQuestion(body);
            verifiedQuestionResult.Match(
                postedQuestion =>
                {
                    new ResetQuestionService().SendResetQuestionLink(postedQuestion).Wait();
                    return Unit.Default;
                },
                ex =>
                {
                    Console.WriteLine("Quesion could not be verified");
                    return Unit.Default;
                }

                );

            Console.WriteLine("Body question is valid");
            return Unit.Default;
        }
    }
}
