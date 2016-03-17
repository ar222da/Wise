<?php
require_once("user.php");
require_once("db_connection.php");

class userDAL 
{
    private $db;
    private $dateAndTime;
    
    public function __construct($db)
    {
        $this->db = $db;
        $this->dateAndTime = date("Y-m-d H:i:s");
    }

    public function userNameExists($userName)
    {
        $statement = $this->db->prepare("SELECT * FROM security_user WHERE BINARY username=? LIMIT 1");
        $statement->bindValue(1, $userName);
        $statement->execute();
        $columns = $statement->fetch();
        
        if ($statement->rowCount() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    
    }
    
    public function getHashedPassword($userName)
    {
        $statement = $this->db->prepare("SELECT password FROM security_user WHERE BINARY username=? LIMIT 1");
        $statement->bindValue(1, $userName);
        $statement->execute();
        $value = $statement->fetch();
        return $value[0];
    }
    
    public function getUsers()
    {
        $users = array();
        try
        {
            $statement = $this->db->prepare("SELECT * FROM security_user");
            $statement->execute();
            $result = $statement->fetchAll();
            foreach ($result as $row)
            {
                $user = new user();
                $user->setId($row[0]);
                $user->setUserName($row[1]);
                $user->setRole($row[3]);
                $user->setName($row[4]);
                $user->setMail($row[5]);
                $user->setRegistrationDate($row[6]);
                array_push($users, $user);
            }
            return $users;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }    
    
    

    public function getUserByID($id)
    {
        $statement = $this->db->prepare("SELECT * FROM security_user WHERE id=? LIMIT 1");
        $statement->bindValue(1, $id);
        $statement->execute();
        $columns = $statement->fetch();
        $user = new user();
        $user->setId($columns[0]);
        $user->setUserName($columns[1]);
        $user->setPassword($columns[2]);
        $user->setRole($columns[3]);
        $user->setName($columns[4]);
        $user->setMail($columns[5]);
        $user->setRegistrationDate($columns[6]);
        return $user;
    }
    
    public function getUserByUserName($userName)
    {
        $statement = $this->db->prepare("SELECT * FROM security_user WHERE username=? LIMIT 1");
        $statement->bindValue(1, $userName);
        $statement->execute();
        $columns = $statement->fetch();
        $user = new user();
        $user->setId($columns[0]);
        $user->setUserName($columns[1]);
        $user->setPassword($columns[2]);
        $user->setRole($columns[3]);
        $user->setName($columns[4]);
        $user->setMail($columns[5]);
        $user->setRegistrationDate($columns[6]);
        return $user;
    }
    
    public function getUserByUserNameAndPassword($userName, $password)
    {
        $statement = $this->db->prepare("SELECT * FROM security_user WHERE BINARY username=? AND BINARY password=? LIMIT 1");
        $statement->bindValue(1, $userName);
        $statement->bindValue(2, $password);
        $statement->execute();
        $columns = $statement->fetch();
        $user = new user();
        $user->setId($columns[0]);
        $user->setUserName($columns[1]);
        $user->setPassword($columns[2]);
        $user->setRole($columns[3]);
        $user->setName($columns[4]);
        $user->setMail($columns[5]);
        $user->setRegistrationDate($columns[6]);
        return $user;
    }

    
    
    public function insertUser($user)
    {
        try
        {
            $statement = $this->db->prepare("INSERT INTO security_user(username, password, role, name, mail, registration) VALUES(?, ?, ?, ?, ?, ?             )");
            $statement->bindValue(1, $user->getUserName());
            $statement->bindValue(2, $user->getPassword());
            $statement->bindValue(3, $user->getRole());
            $statement->bindValue(4, $user->getName());
            $statement->bindValue(5, $user->getMail());
            $statement->bindValue(6, $this->dateAndTime);
            $statement->execute();
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function updateUser($user)
    {
        $userId = $user->getId();
        $userName = $user->getUserName();
        $password = $user->getPassword();
        $name = $user->getName();
        $mail = $user->getMail();
        
        try
        {
            $statement = $this->db->prepare("UPDATE security_user SET username=?, password=?, name=?, mail=? WHERE id=?"); 
            $statement->execute(array($userName, $password, $name, $mail, $userId));
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function setUser($moderatorId)
    {
        $roleNumber = 2;
        try
        {
            $statement = $this->db->prepare("UPDATE security_user SET role=? WHERE id=?"); 
            $statement->execute(array($roleNumber, $moderatorId));
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function deleteUser($userId)
    {
        try
        {
            $statement = $this->db->prepare("DELETE FROM security_user WHERE id=?"); 
            $statement->execute(array($userId));
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    
    

 
}