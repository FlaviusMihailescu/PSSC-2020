using GrainInterfaces;
using Orleans;
using StackUnderflow.EF.Models;
using System.Threading.Tasks;

namespace FakeSO.API.Rest
{
    public class EmailSenderGrain : Grain, IEmailSender
    {
        private StackUnderflowContext _dbContext;

        public EmailSenderGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> SendEmailAsync(string message)
        {
            //todo send e-mail

            return Task.FromResult(message);
        }
    }
}