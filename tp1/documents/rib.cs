namespace tp1.banque.documents;
using tp1.banque.clients;
using tp1.banque.documents;

abstract class Rib : DocumentBanque
{
    public abstract Client titulaire { get; }
}