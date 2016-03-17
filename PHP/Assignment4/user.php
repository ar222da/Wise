<?php

    class user 
    {
        private $id = null;
        private $userName = null;
        private $password = null;
        private $role = null;
        private $name = null;
        private $mail = null;
        private $registrationDate = null;
        
        private $isLoggedIn = false;
        
        public function __construct()
        {
            
        }

        public function setId($id) { $this->id = $id; }
        public function getId() { return $this->id; }
        
        public function setUserName($userName) { $this->userName = $userName; }
        public function getUserName() { return $this->userName; }
        
        public function setPassword($password) { $this->password = $password; }
        public function getPassword() { return $this->password; }
        
        public function setRole($role) { $this->role = $role; }
        public function getRole() { return $this->role; }
        
        public function setName($name) { $this->name = $name; }
        public function getName() { return $this->name; }
        
        public function setMail($mail) { $this->mail = $mail; }
        public function getMail() { return $this->mail; }
        
        public function setRegistrationDate($registrationDate) { $this->registrationDate = $registrationDate; }
        public function getRegistrationDate() { return $this->registrationDate; }
        
        public function setIsLoggedIn($status) { $this->isLoggedIn = $status; }
        public function getIsLoggedIn() { return $this->isLoggedIn; }
        
        
        
        
        
        
        
        
        
    
    
    }