using System.Text.Json;
using Emne3.assignments.Assignment344.Model;
namespace Emne3.assignments.Assignment344.Implementations;

public class SubscriptionFileRepository
{
    public void Save(Subscription subscription)
    {
        var json = JsonSerializer.Serialize(subscription);
        var filename = subscription.Email + ".json";
        File.WriteAllText(filename, json);
    }

    public Subscription Load(string email)
    {
        var filename = email + ".json";
        var json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<Subscription>(json);
    }
}