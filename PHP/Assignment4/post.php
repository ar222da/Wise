<?php

    class post
    {
        private $id = null;
        private $threadId = null;
        private $userId = null;
        private $text = null;
        private $registration = null;
        
        public function __construct()
        {
            
        }

        public function setId($id) { $this->id = $id; }
        public function getId() { return $this->id; }
        
        public function setThreadId($threadId) { $this->threadId = $threadId; }
        public function getThreadId() { return $this->threadId; }
        
        public function setUserId($userId) { $this->userId = $userId; }
        public function getUserId() { return $this->userId; }
        
        public function setText($text) { $this->text = $text; }
        public function getText() { return $this->text; }
        
        public function setRegistration($registration) { $this->registration = $registration; }
        public function getRegistration() { return $this->registration; }
        
        
        
        
        
        
        
    
    
    }