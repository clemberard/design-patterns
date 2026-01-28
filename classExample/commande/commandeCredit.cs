class CommandeCredit : Commande
{
    public CommandeCredit(int prix, int solde = 0) : base(prix, solde)
    {
    }
    public override void payer()
    {
        //A FAIRE
    }

    public override bool valider()
    {
        if (solde >= prix)
        {
            return true;
        }
        return false;
    }
}