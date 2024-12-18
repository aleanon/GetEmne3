using Emne3.assignments.Assignment344.Model;

namespace Emne3.assignments.Assignment344.Interfaces;

public interface ISubscriptionRepository
{
    void Save(Subscription subscription);
    Subscription Load(string email);
}