namespace tp2.assurance.assurances;

abstract class Assurance
{
    protected Client client;

    public Assurance(Client client)
    {
        this.client = client;
    }
}