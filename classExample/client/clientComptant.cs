class ClientComptant : Client
{
    public ClientComptant()
    {
    }
    public override Commande creeCommande(int montant)
    {
        return new CommandeComptant(montant);
    }
}