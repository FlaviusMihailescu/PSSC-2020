using LanguageExt;
using LanguageExt.Common;
using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using static Profile.Domain.CreateProfileWorkflow.CreateProfileResult;
using static Profile.Domain.CreateProfileWorkflow.EmailAddress;
using static Profile.Domain.RespndQuestionWorkflow.BodyReplay;
using Profile.Domain.RespndQuestionWorkflow;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailResult = UnverifiedEmail.Create("Flavius@gmail.com");


            emailResult.Match(
                    Succ: email =>
                    {
                        SendResetPasswordLink(email);

                        Console.WriteLine("Email address is valid.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid email address. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );


            var replayResult = UnvalidateReplay.CreateBody("MyRespondForQuestion");


            replayResult.Match(
                    Succ: replay =>
                    {
                        ReplayComplete(replay);
                        Console.WriteLine("Replay address is valid.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid replay address. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );


            Console.ReadLine();
        }

        private static void ReplayComplete(UnvalidateReplay body)
        {
            var validateReplayResult = new VerifyReplayService().VerifyReplay(body);
            validateReplayResult.Match(
                    validateReplay =>
                    {
                        new SendNotify(123, 4, "ReplayMessageForQuestion", "TudorPopescu@gmail.com", 156, "You have a new replay for question");
                        new SendNotify(123, 4, "ReplayMessageForQuestion", "IonelIonescu@gmail.com", 156, "Your Replay has posted");
                        new ReplayPublished(123, "ReplayMessageForQuestion");

                        return Unit.Default;
                    },
                    ex =>
                    {
                        new SendNotify(123, 4, "ReplayMessageForQuestion", "TudorPopescu@gmail.com", 156, "Your Replay cannot be posted. Try again using the help manual");

                        Console.WriteLine(" Replay question could not be verified");
                        return Unit.Default;
                    }
                );
        }


        private static void SendResetPasswordLink(UnverifiedEmail email)
        {
            var verifiedEmailResult = new VerifyEmailService().VerifyEmail(email);
            verifiedEmailResult.Match(
                    verifiedEmail =>
                    {
                        new RestPasswordService().SendRestPasswordLink(verifiedEmail).Wait();
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Email address could not be verified");
                        return Unit.Default;
                    }
                );
        }



    }
}