using Access.Primitives.IO;
using Access.Primitives.EFCore;
using Access.Primitives.Extensions.ObjectExtensions;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Question.SendConfirmation;
using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orleans;
using LanguageExt;
using GrainInterfaces;
using StackUnderflow.Domain.Core.Contexts.Reply.CreateReply;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly IClusterClient _client;
        private LanguageExt.Option<User> questionUser;

        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext, IClusterClient client)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _client = client;
        }

        [HttpGet()]
        //public async Task<IActionResult> GetQuestion(int questionId)
        //{
        //    //get ref to question grain
        //    //grain.GetQuestionWithReply();                                                
        //}

        [HttpPost()]
        public async Task<IActionResult> CreateQuestionAsyncAndConfirmation([FromBody] CreateQuestionCmd createQuestionCmd)
        {
            QuestionWriteContext ctx = new QuestionWriteContext(
                new EFList<Post>(_dbContext.Post));

            var dependecies = new QuestionDependencies();
            dependecies.SendConfirmationEmail = (ConfirmationLetter letter) => async () => new ConfirmationAcknowledgement(Guid.NewGuid().ToString());

            var expr = from createQuestionResult in QuestionDomain.CreateQuestion(createQuestionCmd)
                       let post = createQuestionResult.SafeCast<CreateQuestionResult.QuestionCreated>().Select(p => p.Post)
                       let confirmationCmd = new ConfirmationQuestionCmd(questionUser)
                       from confirmationResult in QuestionDomain.ConfirmQuestion(confirmationCmd)
                       select new { createQuestionResult, confirmationResult };
            var r = await _interpreter.Interpret(expr, ctx, dependecies);

            _dbContext.SaveChanges();

            return r.createQuestionResult.Match(
                created => (IActionResult)Ok(created.Post.PostId),
                notCreated => BadRequest("Question could not be created."),
                invalidRequest => BadRequest("Invalid request."));
        }
        private TryAsync<ConfirmationAcknowledgement> SendEmail(ConfirmationLetter letter)
       => async () =>
       {
           var emialSender = _client.GetGrain<IEmailSender>(0);
           await emialSender.SendEmailAsync(letter.Letter);
           return new ConfirmationAcknowledgement(Guid.NewGuid().ToString());
       };
    }

    //[HttpPost("question{questionId}")]
    //public async Task<IActionResult> CreateReply(int questionId, [FromBody] CreateReplyCmd createReplyCmd)
    //{

    //}
}
