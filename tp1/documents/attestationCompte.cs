namespace tp1.banque.documents;
using tp1.banque.clients;
using tp1.banque.documents;

abstract class AttestationCompte : DocumentBanque
{
    public abstract Client titulaire { get; }
}