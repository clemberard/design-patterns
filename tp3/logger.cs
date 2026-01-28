namespace tp3.logger;

abstract class Logger
{
    protected abstract string Type { get; }

    public Logger()
    {
    }

    public virtual void EnvoyerParEmail(string message)
    {
        Console.WriteLine($"Email - {Type} : {message}");
    }

    public virtual void EnvoyerParSMS(string message)
    {
        Console.WriteLine($"SMS - {Type} : {message}");
    }

    public virtual void EnvoyerParPush(string message)
    {
        Console.WriteLine($"Push - {Type} : {message}");
    }
}