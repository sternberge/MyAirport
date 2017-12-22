# MyAirport
<b>Description</b><br />
Ce projet réalisé en cours avait pour but de reproduire une version simplifiée d'un service PIM d'un aéroport (Product Information Management).<br /> Nous l'avons réalisé en C#/.Net avec Visual Studio et utilisé Microsoft SQLServer. La base de données utilisée nous a été fournie.<br />
Nous avons au cours de ces différents tp implémenté une interface client réalisant des appels à un service WCF. Nous nous sommes servi du design pattern factory coté serveur afin de choisir le type de base de données (native, SQL, Oracle, ...).<br />
Ce webService offre la possibilité au client de créer un bagage et de chercher des bagages selon le code iata ou l'id.<br />


<b>Gestion des exceptions</b><br />
Différentes exceptions sont levées dans notre service WCF et affichées au client dans un formulaire dédié :<br />
	- si le code iata recherché est inexistant<br />
	- si le code iata recherché correspond à plusieurs bagages<br />
	- si le webservice n'est pas démarré/accessible<br />
	- si l'accès au serveur SQL ne fonctionne pas<br />
Différentes vérifications de format sont réalisées du coté du serveur. Lors de la création d'un bagage, le nom de la compagnie est vérifié.<br />

<b>Installation</b><br />
1) Cloner le projet depuis Github<br />
2) L'importer au sein de VisualStudio en utilisant la solution MyAirport.Pim<br />
L'accès à la base de données peut etre modifié dans le fichier app.config.<br />
Il est nécessaire de démarrer simultanément le client et le serveur host dédié à héberger le service WCF.<br />
