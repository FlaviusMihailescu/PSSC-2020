using CSharp.Choices;
using LanguageExt.Common;
using System.Collections.Generic;
using System.Text;

namespace Profile.Domain.RespndQuestionWorkflow
{
    [AsChoice]
    public partial class BodyReplay
    {
        public interface IReplay{}

        public partial class UnvalidateReplay : IReplay
        {
            public bool IsVerified { get; private set; }

            private UnvalidateReplay(string body)
            {
                Body = body;
            }

            public string Body { get; }


            public static Result<UnvalidateReplay> CreateBody(string body)
            {
                if (IsBodyQuestionValid(body))
                {
                    return new UnvalidateReplay(body);
                }
                else
                {
                    return new Result<UnvalidateReplay>(new InvalidBodyException(body));
                }
            }



            public static bool IsBodyQuestionValid(string body)
            {
                if (body.Length > 10  && body.Length <= 500)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        public class ValidateReplay : IReplay
        {
            public string Body { get; private set; }

            internal ValidateReplay(string body)
            {
                Body = body;
            }
        }
        }

    }
}