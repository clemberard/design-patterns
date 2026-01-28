namespace tp1.banque.documents;
using tp1.banque.clients;
using tp1.banque.documents;

class AttestationCompteSpecifique : AttestationCompte
{
    public override Client titulaire { get; }

    public AttestationCompteSpecifique(Client titulaire)
    {
        this.titulaire = titulaire;
    }
}