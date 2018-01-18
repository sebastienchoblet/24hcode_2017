<?php
class SqlServer
{
    private $_sHost;
    private $_sLogin;
    private $_sPassword;
    private $_sDBName;
    private $_oConnexion;
    
    public function __construct($sHost, $sLogin, $sPassword, $sDBName) {
        $this->setHost($sHost);
        $this->setLogin($sLogin);
        $this->setPassword($sPassword);
        $this->setDBName($sDBName);
    }
    public function setHost($sHost = '') {
        $this->_sHost = $sHost;
    }
    public function setLogin($sLogin = '') {
        $this->_sLogin = $sLogin;
    }
    public function setPassword($sPassword = '') {
        $this->_sPassword = $sPassword;
    }
    public function setDBName($sDBName = '') {
        $this->_sDBName = $sDBName;
    }
    public function connexion() {
        //$this->_oConnexion = new PDO('sqlsrv:Server='.$this->_sHost.';Database='.$this->_sDBName, $this->_sLogin, $this->_sPassword);
        $this->_oConnexion = sqlsrv_connect($this->_sHost, array('UID'          => $this->_sLogin,
                                                                  'PWD'          => $this->_sPassword,
                                                                  'Database'     => $this->_sDBName,
                                                                  'CharacterSet' => 'UTF-8',));

        // Fixe les options d'erreur (ici nous utiliserons les exceptions)
        //$this->_oConnexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }

    public function queryResultToAssocArray($queryResult) {
        $result = array();
        
        while($row = sqlsrv_fetch_array($queryResult, SQLSRV_FETCH_ASSOC)) {
            $result[] = $row;
        }
        return $result;
    }
    
    public function requete($requete) {
        
        //$connexion = new PDO('mysql:host='.$VALEUR_hote.';port='.$VALEUR_port.';dbname='.$VALEUR_nom_bd, $VALEUR_user, $VALEUR_mot_de_passe);
        $queryResult = sqlsrv_query($this->_oConnexion, $requete);
        return $queryResult;
        


    }


}
