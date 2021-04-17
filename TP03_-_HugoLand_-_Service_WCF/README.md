# HUGOLAND TP3

## CORE - TP01_Library

### EDMX

- Hero
- InventaireHero
- Item
- EffetItem
- Classe
- CompteJoueur
- Monde
- ObjetMonde
- Monstre

### Supplémentaire-1

- Tuile (?)
- SavedGame (?)

## SERVICE

### IJoueurService

- Gestion des heros
- Gestion des classes
- Gestion des comptes joueurs

### IMondeService

- Gestion des mondes
- Gestion des objetmondes
- Gestion des monstres

### IItemService

- Gestion des items
- Gestion des effets items
- Gestion des inventaires héros

### Supplémentaire-2

- Intégrer les controllers du TP01_Library dans leurs services respectifs
- Un système d'héritage pour le monde, objetmonde, item, monstre et heros
- Un système d'héritage pour les items, effets items, inventaire héros
- Implémentation d'un design pattern pour faciliter le tout (lequel though, peut-être le Bridge (?) celui que Kevin et Arnaud ont présenter)

## CLIENT

### À faire

#### Ajout au client courant

1. Faire un menu principal ou prendre celui du TP2 offrant plusieurs choix à l'utilisateur; se connecter, créer une nouvelle partie, charger une partie, sauvegarder la partie courante
2. Rendre accessible se menu à partir du formulaire principal (la carte de base qui load depuis le début)
3. Faire en sorte que le menu ouvre et bloque l'accès au jeu dès l'ouverture du jeu, tant que l'utilisateur n'est pas connecté et qu'il n'y est pas de partie télécharger (nouvelle ou chargée)

#### À trouver dans le client courant

1. Trouver où les héros sont instanciés, joindre cet instanciation à un formulaire bloquant (frmMain.Enabled = false)
2. Trouver où la map est instancié et joindre cet instanciation à une partie liée au héro
