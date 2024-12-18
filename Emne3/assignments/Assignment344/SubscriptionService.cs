using Emne3.assignments.Assignment344.Interfaces;
using Emne3.assignments.Assignment344.Model;

namespace Emne3.assignments.Assignment344;

public class SubscriptionService
{
    private readonly IEmailService _emailService;
    private ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(
        IEmailService emailService, 
        ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _emailService = emailService;
    }

    public void Subscribe(string emailAddress)
    {
        var subscription = new Subscription("", emailAddress);
        _subscriptionRepository.Save(subscription);
        var email = new Email(subscription.Email, "me", "Verification code",
            $"Here is your verification code: {subscription.VerificationCode}");
        _emailService.Send(email);
    }

    public void Verify(string emailAddress, string verificationCode)
    {
        var subscription = _subscriptionRepository.Load(emailAddress);
        if (verificationCode != subscription.VerificationCode) return;
        subscription.IsVerified = true;
        var email = new Email(subscription.Email, "support@here.com", "Subscription started",
            "Your subscription to our newsletter is now active");
        _emailService.Send(email);
    }
}