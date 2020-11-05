using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Profile.Domain.RespndQuestionWorkflow.BodyReplay;
using static Profile.Domain.RespndQuestionWorkflow.BodyReplay.UnvalidateReplay;
using static Profile.Domain.RespndQuestionWorkflow.BodyReplay.UnvalidateReplay;

namespace Profile.Domain.CreateProfileWorkflow
{
    public class VerifyReplayService
    {
        public Result<ValidateReplay> VerifyReplay(UnvalidateReplay body)
        {
            return new ValidateReplay(body.Body);
        }
    }
}
