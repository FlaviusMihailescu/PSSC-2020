using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Question.domain4.PostedQuestionWorkflow
{
    [AsChoice]
   public partial class BodyQuestion
    {

        public interface IPostedQuestion { }

        public class UnpostedQuestion : IPostedQuestion
        {
            public bool IsVerified { get; private set; }

            public string Body { get; private set; }
            private UnpostedQuestion(string body)
            {
                Body = body;
            }

            public static Result<UnpostedQuestion> CreateBody(string body)
            {
                if (IsBodyQuestionValid(body))
                {
                    return new UnpostedQuestion(body);
                }
                else
                {
                    return new Result<UnpostedQuestion>(new InvalidBodyException(body));
                }
            }

            public static bool IsBodyQuestionValid(string body)
            {
                if (body.Length > 0 && body.Length <= 1000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }

        public class PostedQuestion : IPostedQuestion
        {
            public string Body { get; private set; }
            internal PostedQuestion(string body)
            {
                Body = body;
            }
        }
    }
}
