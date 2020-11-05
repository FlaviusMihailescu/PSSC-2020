using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Domain.RespndQuestionWorkflow
{
    public class SendNotify
    {
        public SendNotify(int questionID, int replayID, string replayBody, string Email, int autorID, string messageNotifier)
        {
            QuestionID = questionID;
            ReplayID = replayID;
            ReplayBody = replayBody;
            Email = Email;
            AutorID = autorID;
            MessageNotifier = messageNotifier;
        }

        public int QuestionID { get; }
        public int ReplayID { get; }
        public string ReplayBody { get; }
        public string Email { get; }
        public int AutorID { get; }
        public string MessageNotifier { get; }
    }
}
