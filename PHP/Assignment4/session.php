<?php
require_once ("db_connection.php");
    // This class is strongly influenced by and partly borrowed from 
    // http://www.wikihow.com/Create-a-Secure-Session-Managment-System-in-PHP-and-MySQL. 
    // Customization of session managment.
    
    class session
    {
        private $connection;
        private $db;
        
        function __construct()
        {
            session_set_save_handler(array($this, 'open'), array($this, 'close'), array($this, 'read'), 
            array($this, 'write'), array($this, 'destroy'), array($this, 'gc'));
            register_shutdown_function('session_write_close');
        }
        
        function start_session($session_name, $secure) 
        {
            $httponly = true;
            $session_hash = 'sha512';
 
            if (in_array($session_hash, hash_algos())) 
            {
                ini_set('session.hash_function', $session_hash);
            }
       
            ini_set('session.hash_bits_per_character', 5);
            ini_set('session.use_only_cookies', 1);
            $cookieParams = session_get_cookie_params(); 
            session_set_cookie_params($cookieParams["lifetime"], $cookieParams["path"], $cookieParams["domain"], $secure, $httponly); 
            session_name($session_name);
            session_start();
            session_regenerate_id(true); 
        }
        
        function open()
        {
            $this->connection = new db_connection();
            $this->db = $this->connection->getDb();
        }
        
        function close()
        {
            $this->db = null;
            return true;
        }
    
        function read($id) 
        {
            if(!isset($this->read_stmt)) 
            {
                $this->read_stmt = $this->db->prepare("SELECT data FROM security_session WHERE id = ? LIMIT 1");
            }
            
            $this->read_stmt->bindParam(1, $id);
            $this->read_stmt->execute();
            $data = $this->read_stmt->fetchColumn();
            $key = $this->getkey($id);
            $data = $this->decrypt($data, $key);
            return $data;
        }
        
        function write($id, $data) 
        {
            $key = $this->getkey($id);
            $data = $this->encrypt($data, $key);
            $time = time();
            
            if(!isset($this->w_stmt)) 
            {
                $this->w_stmt = $this->db->prepare("REPLACE INTO security_session (id, set_time, data, session_key) VALUES (?, ?, ?, ?)");
            }
         
            $this->w_stmt->bindParam(1, $id);
            $this->w_stmt->bindParam(2, $time);
            $this->w_stmt->bindParam(3, $data);
            $this->w_stmt->bindParam(4, $key);
            
            $this->w_stmt->execute();
            return true;
        }
        
        function destroy($id) 
        {
            if(!isset($this->delete_stmt)) 
            {
                $this->delete_stmt = $this->db->prepare("DELETE FROM security_session WHERE id = ?");
            }
            
            $this->delete_stmt->bindParam(1, $id);
            $this->delete_stmt->execute();
            return true;
        }
        
        function gc($max) 
        {
            if(!isset($this->gc_stmt)) 
            {
                $this->gc_stmt = $this->db->prepare("DELETE FROM security_session WHERE set_time < ?");
            }
            
            $old = time() - $max;
            $this->gc_stmt->bindParam(1, $old);
            $this->gc_stmt->execute();
            return true;
        }
        
        private function getkey($id) 
        {
            if(!isset($this->key_stmt)) 
            {
                $this->key_stmt = $this->db->prepare("SELECT session_key FROM security_session WHERE id = ? LIMIT 1");
            }
            
            $this->key_stmt->bindParam(1, $id);
            $this->key_stmt->execute();
            
            if($this->key_stmt->rowCount() == 1) 
            { 
                $key = $this->key_stmt->fetchColumn();
                return $key;
            }
            
            else 
            {
                $random_key = hash('sha512', uniqid(mt_rand(1, mt_getrandmax()), true));
                return $random_key;
            }
        }
        
        private function encrypt($data, $key) 
        {
            $salt = 'cH!swe!retReGu7W6bEDRup7usuDUh9THeD2CHeGE*ewr4n39=E@rAsp7c-Ph@pH';
            $key = substr(hash('sha256', $salt.$key.$salt), 0, 32);
            $iv_size = mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_ECB);
            $iv = mcrypt_create_iv($iv_size, MCRYPT_RAND);
            $encrypted = base64_encode(mcrypt_encrypt(MCRYPT_RIJNDAEL_256, $key, $data, MCRYPT_MODE_ECB, $iv));
            return $encrypted;
        }
        
        private function decrypt($data, $key) 
        {
            $salt = 'cH!swe!retReGu7W6bEDRup7usuDUh9THeD2CHeGE*ewr4n39=E@rAsp7c-Ph@pH';
            $key = substr(hash('sha256', $salt.$key.$salt), 0, 32);
            $iv_size = mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_ECB);
            $iv = mcrypt_create_iv($iv_size, MCRYPT_RAND);
            $decrypted = mcrypt_decrypt(MCRYPT_RIJNDAEL_256, $key, base64_decode($data), MCRYPT_MODE_ECB, $iv);
            return $decrypted;
        }
        
    }
