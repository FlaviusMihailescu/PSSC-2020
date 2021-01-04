using Orleans;
using Orleans.Streams;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainImplementation
{
    public class QuestionGrain : Grain
    {
        private StackUnderflowContext _dbContext;
        private QuestionGrain state;

        public QuestionGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task OnActivateAsync()
        {
            var key = this.GetPrimaryKey();
            Post post = new Post();

            

            var returnPostId =
                from postId in post.PostId.ToString()
                where postId.Equals(key.ToString())
                select postId;

            var returnParentPostId =
                from parentPostId in post.ParentPostId.ToString()
                where parentPostId.Equals(key.ToString())
                select parentPostId;


            //subscribe to replys stream
            var streamProvider = GetStreamProvider("SMSProvider");
            var stream = streamProvider.GetStream<Post>(Guid.Empty, "question");
            await stream.SubscribeAsync((IAsyncObserver<Post>)this);


        }
        //public Question GetQuestionWithReply()
        //{
        //    return returnParentPostId;
        //}
    }
}
