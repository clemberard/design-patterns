namespace tp2.assurance.clients;

abstract class Client
{
    public required string nom { get; set; }
    public required string prenom { get; set; }

    public Client()
    {
    }
}