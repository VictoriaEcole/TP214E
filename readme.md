Nom des membres de l'équipe: Victoria Toffoli

Correction du bug:

Pour trouver la source de l'erreur, j'ai copié le message d'erreur et je l'ai recherché sur Google. En lisant sur la page de ma recherche, j'ai trouver d'ou venait l'erreur.
La PageCommande n'est en réalité pas une page, mais un window. Il est impossible de naviger entre les windows.
Pour corriger le probleme, j'ai changé "Window" par "Page" dans la création de la class (public partial class PageCommandes : Page) et dans le layout, j'ai changer les balises "window" pour "Page".
