<?php
require_once("user.php");
require_once("userDAL.php");
require_once("session.php");

class userService
{
    private $userDAL;
    private $session;
    
    public function __construct($userDAL)
    {
        $this->userDAL = $userDAL;
    }
    
    public function loginSuccess($userName, $password)
    {
        if ($this->userDAL->userNameExists($userName))
        {
            if (password_verify($password, $this->userDAL->getHashedPassword($userName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    
    public function loginUser($user)
    {
        $userId = $user->getId();
        $userName = $user->getUserName();
        $hashedPassword = $user->getPassword();
       
        $_SESSION['userid'] = $userId;
        $_SESSION['username'] = $userName;
        $_SESSION['hashedPassword'] = $hashedPassword;
       
        
    }
    
    public function userIsLoggedIn()
    {
        if (isset($_SESSION['userid'])) 
        {
            $userId = $_SESSION['userid'];
            $userName = $_SESSION['username'];
            $hashedPassword = $_SESSION['hashedPassword'];
            return true;
        }

        else
        {
            return false;
        }
 
    }
    
    public function logoutUser($userName)
    {
        session_destroy();
        
    }
    
    public function userNameExists($userName)
    {
        return $this->userDAL->userNameExists($userName);
    }
    
    public function getUser($userName)
    {
        return $this->userDAL->getUserByUserName($userName);
    }
    
    public function getUserById($userId)
    {
        return $this->userDAL->getUserById($userId);
    }
    
    public function getUserBySession()
    {
        if (isset($_SESSION['username']))
        {
            $userName = $_SESSION['username'];
            return $this->getUser($userName);
        }
    }
    
    public function registerUser($user)
    {
        return $this->userDAL->insertUser($user);
    }
    
    public function setUser($moderatorId)
    {
        return $this->userDAL->setUser($moderatorId);
    }
    
    public function deleteUser($userId)
    {
        return $this->userDAL->deleteUser($userId);
    }
    
    public function getUsers()
    {
        return $this->userDAL->getUsers();
    }
    
   
}
    