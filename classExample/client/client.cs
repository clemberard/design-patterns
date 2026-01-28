using System.Data;
using System.Collections.Generic;

public abstract class Client
{
    protected List<Commande> commandes = new List<Commande>();
    public Client()
    {
    }
    public virtual Commande nouvelleCommande(int montant)
    {
        Commande commande = creeCommande(montant);
        if (commande.valider())
        {
            commande.payer();
        }
        return commande;
    }

    public abstract Commande creeCommande(int montant);
}