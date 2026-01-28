# Réponses aux questions

Voici les réponses aux questions posées dans le TP3.

1. Identifiez les problèmes dans le code existant, notamment en termes de :

Duplication de code
Extensibilité
Maintenance
Couplage entre les composants

**Réponse :**

Il y a beaucoup de fois la meme methode pour envoyer via les différents canaux (SMS, Email et Push).

Par conséquent, quand on voudra envoyer une notif via un différent support, il faudra le rajouter de partout dans le code.

Cela rend le code difficile à maintenir.

Le couplage entre les composants est élevé car les classes de notification dépendent directement des classes de service d'envoi spécifiques.

2. Quel pattern de conception ... ?

**Réponse :**

Le pattern de conception approprié pour résoudre ces problèmes est le pattern Factory.

3. UML

![UML](UML.png)

4. Comment votre solution ... ?

**Réponse :**

Pour un nouveau type de notification, il suffit de créer une nouvelle classe de notification.

Pour une nouvelle plateforme d'envoi, il suffit de créer une nouvelle méthode dans la factory.

Pour la modification d'une plateforme d'envoi, il suffit de modifier la méthode correspondante dans la factory.
