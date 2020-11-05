using System;

namespace Profile.Domain.RespndQuestionWorkflow
{
    public partial class BodyReplay
    {

        public partial class UnvalidateReplay
        {
            [Serializable]
            private class InvalidBodyException : Exception
            {
                public InvalidBodyException()
                {
                }
                public InvalidBodyException(string body) : base("Dimension is to small or to large")
                {

                }
            }
        }

    }
}
