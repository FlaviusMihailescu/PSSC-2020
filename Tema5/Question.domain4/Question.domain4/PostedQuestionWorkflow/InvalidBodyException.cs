using System;

namespace Question.domain4.PostedQuestionWorkflow
{
    public partial class BodyQuestion
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
