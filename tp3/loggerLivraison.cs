namespace tp3.logger;

class LoggerLivraison : Logger
{
    protected override string Type => "Livraison";
    public override void EnvoyerParEmail(string message)
    {
        base.EnvoyerParEmail(message);
    }

    public override void EnvoyerParSMS(string message)
    {
        base.EnvoyerParSMS(message);
    }

    public override void EnvoyerParPush(string message)
    {
        base.EnvoyerParPush(message);
    }
}