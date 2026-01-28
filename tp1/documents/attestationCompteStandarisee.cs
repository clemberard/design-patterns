namespace tp1.banque.documents;
using tp1.banque.documents;
using tp1.banque.clients;

class AttestationCompteStandarisee : AttestationCompte
{
    public override Client titulaire { get; }

    public AttestationCompteStandarisee(Client titulaire)
    {
        this.titulaire = titulaire;
    }
}