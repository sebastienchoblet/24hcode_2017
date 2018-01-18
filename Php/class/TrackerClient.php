<?php
class TrackerClient {
    private $_aRawListIssues;
    private $_url;
    private $_oSql;
    private $_sTrackerId; // l'id unique du tracker en BDD
    private $_iTypeTracker; // 1 (bugzilla), 2 (flyspray), 3 (redmine)

    public function setUrl ($pUrl) {
        $this->_url = $pUrl;
        return $this;
    }
    
    public function setRawListIssues($alistIssues = array()) {
        $this->_aRawListIssues = json_decode($alistIssues['content']);
    }

    public function getRawListIssues() {
        return $this->_aRawListIssues;
    }
    
    public function getUrlListIssues($iIssueNumber = '') {
        return $this->_url.$this->getRemoteIssues($iIssueNumber);
    }
    
    public function setSqlConnexion($oSql) {
        $this->_oSql = $oSql;
    }
    // vérification du tracker et enregistrement si besoin
    public function searchTrackerInfo($iTypeTracker) {
        $this->_sTrackerId = '';
        
        $sql=<<<SQL
                EXEC [dbo].[SyncTracker]
                @adresse = '$this->_url',
		@typeTracker = $iTypeTracker
SQL;
        $result = $this->_oSql->requete($sql);
        
        if($result !== false) {
            $result = $this->_oSql->queryResultToAssocArray($result);
            $this->_sTrackerId = $result[0]['return_value'];
        }

        return $this->_sTrackerId;
    }
    
    // enregistrement des demandes avec les utilisateurs
    public function sendIssuesToDatabase($aIssueList = array()) {
        // on vérifie que le tracker est trouvé pour éviter tout problème
        if($this->_sTrackerId != '') {
            // on parse l'ensemble des demandes retournées via API
            foreach($aIssueList AS $aOneIssue) {
                // enregistrement de l'utilisateur (si inexistant)
                $this->sendUsersToDatabase($aOneIssue);
                $sOneUserId = $this->sendGetLastUsersInDatabase($aOneIssue);
                // on vérifie la présence de l'id client
                if($sOneUserId != '') {
                    // ajout de la liaison utilisateur Master (commun) au travers des différents tracker
                    $this->sendMasterUsersToDatabase(array('trackerId' => $this->_sTrackerId,
                                                           'userId'    => $sOneUserId,
                                                           'login'     => 'NULL',));
                    $sOneMasterUserId = $this->sendMasterGetLastUsersInDatabase(array('trackerId' => $this->_sTrackerId,
                                                                                      'userId'    => $sOneUserId,
                                                                                      'login'     => 'NULL',));
                    // on vérifie la présence du masterUserId pour la suite (ajout de l'applicatif)
                    echo '<pre>';
                    var_dump($sOneMasterUserId);
                    echo '</pre>';
                    if($sOneMasterUserId != '') {
                        // ajout de l'applicatif
                        $this->sendApplicatifToDatabase($aOneIssue);
                        $sOneApplicatifId = $this->sendGetLastApplicatifInDatabase($aOneIssue);
                        // on vérifie la présence de l'applicatifId pour la suite (ajout du composant)
                        echo '<pre>';
                        var_dump($sOneApplicatifId);
                        echo '</pre>';
                        if($sOneApplicatifId != '') {
                            echo 'coucou';
                            // ajout du composant
                            $this->sendComposantToDatabase(array('nomComposant' => $aOneIssue['IssueComposant'],
                                                                 'applicatif'   => $sOneApplicatifId,));
                            $sOneComposantId = $this->sendGetLastComposantInDatabase(array('nomComposant' => $aOneIssue['IssueComposant'],
                                                                                           'applicatif'   => $sOneApplicatifId,));

                        }
                    }
                }
            }
        }

        
    }
    // vérification de l'utilisateur et enregistrement si besoin
    public function sendUsersToDatabase($aOneIssue = array()) {
        $sLocalCreatorEmail = $aOneIssue['CreatorEmail'];
        $sLocalCreatorLogin = $aOneIssue['CreatorLogin'];
        $sLocalCreatorNom   = $aOneIssue['CreatorName'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncUser]
		@email = '$sLocalCreatorEmail',
		@login = '$sLocalCreatorLogin',
		@nom = '$sLocalCreatorNom'
SQL;
        
        $result = $this->_oSql->requete($sql);
    }
    // vérification de l'utilisateur et enregistrement si besoin
    public function sendGetLastUsersInDatabase($aOneIssue = array()) {
        $sOneUserId         = '';
        $sLocalCreatorEmail = $aOneIssue['CreatorEmail'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncUserGetId]
		@email = '$sLocalCreatorEmail'
SQL;
        
        $result = $this->_oSql->requete($sql);
        if($result !== false) {
            $result = $this->_oSql->queryResultToAssocArray($result);
            $sOneUserId = $result[0]['return_value'];
        }
        
        return $sOneUserId;
    }
    // vérification de l'utilisateur dans la base unifiée et enregistrement si besoin
    public function sendMasterUsersToDatabase($aOneIssue = array()) {
        $sLocalCreatorTrackerId = $aOneIssue['trackerId'];
        $sLocalCreatorUserId    = $aOneIssue['userId'];
        $sLocalCreatorLogin     = $aOneIssue['login'];
      
        $sql=<<<SQL
                EXEC [dbo].[SyncMasterUser]
                @trackerId = '$sLocalCreatorTrackerId',
                @iduser = '$sLocalCreatorUserId',
                @login = '$sLocalCreatorLogin'
SQL;
        
        $result = $this->_oSql->requete($sql);
    }
    // vérification de l'utilisateur dans la base unifiée et enregistrement si besoin
    public function sendMasterGetLastUsersInDatabase($aOneIssue = array()) {
        $sOneMasterUserId       = '';
        $sLocalCreatorTrackerId = $aOneIssue['trackerId'];
        $sLocalCreatorUserId    = $aOneIssue['userId'];
      
        $sql=<<<SQL
                EXEC [dbo].[SyncMasterUserGetId]
                @trackerId = '$sLocalCreatorTrackerId',
                @iduser = '$sLocalCreatorUserId'
SQL;
        
        $result = $this->_oSql->requete($sql);
        if($result !== false) {
            $result = $this->_oSql->queryResultToAssocArray($result);
            $sOneMasterUserId = $result[0]['return_value'];
        }
        
        return $sOneMasterUserId;
    }
    // ajout de l'applicatif
    public function sendApplicatifToDatabase($aOneIssue = array()) {
        $sLocalApplicatifNom = $aOneIssue['IssueProduct'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncApplicatif]
		@nom = '$sLocalApplicatifNom'
SQL;
        
        $result = $this->_oSql->requete($sql);
    }
    // récupération du dernier applicatif
    public function sendGetLastApplicatifInDatabase($aOneIssue = array()) {
        $sOneApplicatifId    = '';
        $sLocalApplicatifNom = $aOneIssue['IssueProduct'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncApplicatifGetId]
		@nom = '$sLocalApplicatifNom'
SQL;
        
        $result = $this->_oSql->requete($sql);
        if($result !== false) {
            $result = $this->_oSql->queryResultToAssocArray($result);
            $sOneApplicatifId = $result[0]['return_value'];
        }
        
        return $sOneApplicatifId;
    }
    // ajout du composant
    public function sendComposantToDatabase($aOneIssue = array()) {
        $sLocalComposantNom = $aOneIssue['IssueComposant'];
        $sLocalApplicatifId = $aOneIssue['applicatif'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncComposant]
                @applicatif = '$sLocalApplicatifId',
                @nom = '$sLocalComposantNom'
SQL;
        
        $result = $this->_oSql->requete($sql);
    }
    // récupération du dernier applicatif
    public function sendGetLastComposantInDatabase($aOneIssue = array()) {
        $sOneComposantId    = '';
        $sLocalComposantNom = $aOneIssue['IssueComposant'];
        $sLocalApplicatifId = $aOneIssue['applicatif'];
       
        $sql=<<<SQL
                EXEC [dbo].[SyncComposantGetId]
                @applicatif = '$sLocalApplicatifId',
                @nom = '$sLocalComposantNom'
SQL;
        
        $result = $this->_oSql->requete($sql);
        if($result !== false) {
            $result = $this->_oSql->queryResultToAssocArray($result);
            $sOneComposantId = $result[0]['return_value'];
        }
        
        return $sOneComposantId;
    }
}
