public abstract class Commande
{
    protected int prix;
    protected int solde;
    public Commande(int prix, int solde = 0)
    {
        this.prix = prix;
        this.solde = solde;
    }
    public abstract void payer();

    public abstract bool valider();
}