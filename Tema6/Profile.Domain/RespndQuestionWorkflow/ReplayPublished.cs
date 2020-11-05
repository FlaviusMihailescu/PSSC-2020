using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Domain.RespndQuestionWorkflow
{
    public class ReplayPublished
    {
        public ReplayPublished(int replayID, string replayBody)
        {
            ReplayID = replayID;
            ReplayBody = replayBody;
        }

        public int ReplayID { get; }
        public string ReplayBody { get; }
    }
}
