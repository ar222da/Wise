<?php

class db_connection
{
    private $servername = "nalaka.se.mysql";
    private $username = "nalaka_se";
    private $password = "blommprinsen28";
    private $dbname = "nalaka_se";

    private $db;
    
    public function __construct()
    {
        
        $this->db = new PDO("mysql:host=$this->servername;dbname=$this->dbname", $this->username, $this->password);
        $this->db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }
    
    public function getDb()
    {
        return $this->db;
    }
    
    public function closeDb()
    {
        $this->db = null;
    }
    
   
}

