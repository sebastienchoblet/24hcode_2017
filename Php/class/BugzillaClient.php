<?php
include "TrackerClient.php";

class BugzillaClient extends TrackerClient {
    private $_aRawListIssues;
    private $_aCleanListIssues;
    private $_sTrackerId; // l'id unique du tracker en BDD
    private $_iTypeTracker = 1; // 1 (bugzilla), 2 (flyspray), 3 (redmine)

    // construction de l'url pour la récupération des demandes
    public function getRemoteIssues($iIssueNumber = '') {
        $sReturnUrl = '/bug'.($iIssueNumber != '' ? '/'.$iIssueNumber : '');
        return $sReturnUrl;
    }
    
    // convertion des demandes vers notre format local
    public function convertRemoteIssueToLocalFormat() {
        $this->_aCleanListIssues = array();
        foreach($this->getRawListIssues()->bugs AS $aInfoOneIssue) {
            // info créateur
            $sCreatorEmail = $aInfoOneIssue->creator_detail->email;
            $iCreatorId    = $aInfoOneIssue->creator_detail->id;
            $sCreatorName  = $aInfoOneIssue->creator_detail->name;
            // info demande
            $iIssueId                   = $aInfoOneIssue->id;
            $dIssueCreationDate         = $aInfoOneIssue->creation_time;
            $sIssueDescriptif           = $aInfoOneIssue->summary;
            $sIssueSeverity             = $aInfoOneIssue->severity;
            $sIssuePriority             = $aInfoOneIssue->priority;
            $dIssueLastModificationDate = $aInfoOneIssue->last_change_time;
            $sIssueStatus               = $aInfoOneIssue->status;
            $sIssueComponent            = $aInfoOneIssue->component;
            $sIssueProduct              = $aInfoOneIssue->product;
            
            $this->_aCleanListIssues[] = array('CreatorEmail'              => $sCreatorEmail,
                                              'CreatorId'                  => $iCreatorId,
                                              'CreatorName'                => $sCreatorName,
                                              'CreatorLogin'               => '',
                                              'IssueId'                    => $iIssueId,
                                              'IssueCreationDate'          => $dIssueCreationDate,
                                              'IssueDescriptif'            => $sIssueDescriptif,
                                              'IssueSeverity'              => $sIssueSeverity,
                                              'IssuePriority'              => $sIssuePriority,
                                              'IssueLastModificationDate'  => $dIssueLastModificationDate,
                                              'IssueStatus'                => $sIssueStatus,
                                              'IssueProduct'               => $sIssueComponent,
                                              'IssueComposant'             => $sIssueProduct,);
        }
    }
    
    // recherche des informations du tracker et insert si besoin
    public function searchTrackerInfo($itypeTracker=1) {
        $this->_sTrackerId = parent::searchTrackerInfo($this->_iTypeTracker);
//        echo $this->_sTrackerId;
    }
    
    public function sendIssuesToDatabase($aVide = array()) {
        // appel de la méthode parente
        parent::sendIssuesToDatabase($this->_aCleanListIssues);
    }
    
//    public function saveIssuesInDatabase() {
//        $hote = '192.168.100.20'; // Serveur de votre base de données
//        $nomutilisateur = 'mari'; // Login pour se connecter à la base de données
//        $mdp = 'riina2010'; // Mot de passe associé
//
//        $base = 'carmonitor'; // Le nom de votre base de données
//
//        $connection=mssql_connect($hote,$nomutilisateur,$mdp)or die ('connexion impossible au serveur');
//
//        mssql_select_db($base)or die ('accès impossible a la base de donnees'); // On sélectionne la base de données
//    }
    
}
