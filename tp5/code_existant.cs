public interface IMessage
{
    void Send(string message);
}

public class BasicMessage : IMessage
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending: {message}");
    }
}

public abstract class MessageDecorator : IMessage
{
    protected readonly IMessage _message;

    public MessageDecorator(IMessage message)
    {
        _message = message;
    }

    public virtual void Send(string message)
    {
        _message.Send(message);
    }
}

public class CompressionDecorator : MessageDecorator
{
    public CompressionDecorator(IMessage message) : base(message) { }

    public override void Send(string message)
    {
        string compressedMessage = Compress(message);
        base.Send(compressedMessage);
    }

    private string Compress(string message)
    {
        // Simuler la compression
        return $"[COMPRESSED]{message}[/COMPRESSED]";
    }
}

public class ChiffrementDecorator : MessageDecorator
{
    public ChiffrementDecorator(IMessage message) : base(message) { }

    public override void Send(string message)
    {
        string encryptedMessage = Encrypt(message);
        base.Send(encryptedMessage);
    }

    private string Encrypt(string message)
    {
        // Simuler le chiffrement
        return $"[ENCRYPTED]{message}[/ENCRYPTED]";
    }
}

public class SignatureDecorator : MessageDecorator
{
    public SignatureDecorator(IMessage message) : base(message) { }

    public override void Send(string message)
    {
        string signedMessage = Sign(message);
        base.Send(signedMessage);
    }

    private string Sign(string message)
    {
        // Simuler la signature
        return $"{message}[SIGNED]";
    }
}

public class LoggingDecorator : MessageDecorator
{
    public LoggingDecorator(IMessage message) : base(message) { }

    public override void Send(string message)
    {
        Log(message); // On log le message avant de l'envoyer
        base.Send(message);
    }

    private void Log(string message)
    {
        Console.WriteLine($"Logging message: {message}");
    }
}

namespace Tp5
{
    public class DecoratorDemo
    {
        public static void Run(string[] args)
        {
            IMessage message = new BasicMessage();
            message = new CompressionDecorator(message);
            message = new ChiffrementDecorator(message);
            message = new SignatureDecorator(message);
            message = new LoggingDecorator(message);

            message.Send("Hello !");
        }
    }
}
