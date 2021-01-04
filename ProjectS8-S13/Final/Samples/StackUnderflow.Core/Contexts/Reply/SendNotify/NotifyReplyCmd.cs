using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Reply.SendNotify
{
    public struct NotifyReplyCmd
    {
        [OptionValidator(typeof(RequiredAttribute))]
        public Option<User> QuestionUser { get; }

        public NotifyReplyCmd(Option<User> questionUser)
        {
            QuestionUser = questionUser;
        }
    }

    public enum NotifyReplyCmdInput
    {
        Valid,
        UserIsNone
    }

    public class NotifyReplyInputGen : InputGenerator<NotifyReplyCmd, NotifyReplyCmdInput>
    {
        public NotifyReplyInputGen()
        {
            mappings.Add(NotifyReplyCmdInput.Valid, () =>
            new NotifyReplyCmd(

                Option<User>.Some(new User()
                {
                    DisplayName = Guid.NewGuid().ToString(),
                    Email = $"{Guid.NewGuid()}@mailinator.com"
                }))
            );

            mappings.Add(NotifyReplyCmdInput.UserIsNone, () =>
            new NotifyReplyCmd(
                Option<User>.None
                )
            );
        }
    }
}
