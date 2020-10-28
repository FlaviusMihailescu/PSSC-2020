using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Question.domain4.PostedQuestionWorkflow
{
    public class TagsQuestion
    {
        public string Tags { get; private set; }
        public static bool IsBodyQuestionValid(string tags)
        {
            int counter=0;
            foreach (char i in tags)
            {
                if(Char.Equals(i, ','))
                    counter++;
            }
            if (tags.Length > 0 && counter <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private TagsQuestion(string body)
        {
            Tags = body;
        }

        public static Result<TagsQuestion> CreateTags(string tags)
        {
            if (IsBodyQuestionValid(tags))
            {
                return new TagsQuestion(tags);
            }
            else
            {
                return new Result<TagsQuestion>(new InvalidTagsException(tags));
            }
        }

        [Serializable]
        private class InvalidTagsException : Exception
        {
            public InvalidTagsException()
            {
            }

            public InvalidTagsException(string tags) : base("Number of tags is to large")
            {
            }
        }
    }
}
