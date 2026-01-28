class ClientCredit : Client
{
    public ClientCredit()
    {
    }
    public override Commande creeCommande(int montant)
    {
        return new CommandeCredit(montant);
    }
}