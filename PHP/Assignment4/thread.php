<?php

    class thread
    {
        private $id = null;
        private $userId = null;
        private $title = null;
        private $registration = null;
        
        public function __construct()
        {
            
        }

        public function setId($id) { $this->id = $id; }
        public function getId() { return $this->id; }
        
        public function setUserId($userId) { $this->userId = $userId; }
        public function getUserId() { return $this->userId; }
        
        public function setTitle($title) { $this->title = $title; }
        public function getTitle() { return $this->title; }
        
        public function setRegistration($registration) { $this->registration = $registration; }
        public function getRegistration() { return $this->registration; }

    }