<?php
include "class/Rest.php";
include "class/BugzillaClient.php";
include "class/SqlServer.php";

//phpinfo();

$rest = new RestClient();
$sql  = new SqlServer('149.202.191.207,8889\SQLExpress', 'sa', 'dev', '24h');
// connexion à la bdd
$sql->connexion();

$bugTrackerClient = new BugzillaClient();
$bugTrackerClient->setSqlConnexion($sql);
$bugTrackerClient->setUrl('https://landfill.bugzilla.org/bugzilla-5.0-branch/rest');

// recherche des informations sur le tracker en cours
$bugTrackerClient->searchTrackerInfo();

// récupération de la liste des demandes
$bugTrackerClient->setRawListIssues($rest->setUrl($bugTrackerClient->getUrlListIssues(1))->get());
$bugTrackerClient->convertRemoteIssueToLocalFormat();
$bugTrackerClient->sendIssuesToDatabase();










//            $hote = '192.168.100.20'; // Serveur de votre base de données
//        $nomutilisateur = 'mari'; // Login pour se connecter à la base de données
//        $mdp = 'riina2010'; // Mot de passe associé
//
//        $base = 'carmonitor'; // Le nom de votre base de données


//echo '<pre>';
//var_dump($bugTrakerClient->getListIssues());
//echo '</pre>';

//getListIssues
//$livre = $rest->setUrl('https://landfill.bugzilla.org/bugzilla-5.0-branch/rest/version')->get();
// 
//echo $livre['content'];
// 
//echo '<pre>';
//var_dump(json_decode($livre['content'])->version);
//echo '</pre>';
//
//echo json_decode($livre['content'])->version;
//ecriture d'un livre
//$rest->setUrl('http://bibliotheque/livre')->post($unLivre);
 
//modification d'un livre
//$rest->setUrl('http://bibliotheque/livre/1')->put($unLivre);
 
//supression d'un livre
//$rest->setUrl('http://bibliotheque/livre/1')->delete();