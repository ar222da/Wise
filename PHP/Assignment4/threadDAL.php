<?php
require_once("thread.php");
require_once("post.php");
require_once("db_connection.php");

class threadDAL 
{
    private $db;
    private $dateAndTime;
    private $lastInsertThreadId;
    private $lastInsertPostId;

    public function __construct($db)
    {
        $this->db = $db;
        $this->dateAndTime = date("Y-m-d H:i:s");
    }

    public function getThread($id)
    {
        try
        {
            $statement = $this->db->prepare("SELECT * FROM security_thread WHERE id=? LIMIT 1");
            $statement->bindValue(1, $id);
            $statement->execute();
            $columns = $statement->fetch();
            $thread = new thread();
            $thread->setId($columns[0]);
            $thread->setUserId($columns[1]);
            $thread->setTitle($columns[2]);
            $thread->setRegistration($columns[3]);
            return $thread;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function getThreads()
    {
        $threads = array();
        try
        {
            $statement = $this->db->prepare("SELECT * FROM security_thread ORDER BY id");
            $statement->execute();
            $result = $statement->fetchAll();
            foreach ($result as $row)
            {
                $thread = new thread();
                $thread->setId($row[0]);
                $thread->setUserId($row[1]);
                $thread->setTitle($row[2]);
                $thread->setRegistration($row[3]);
                array_push($threads, $thread);
            }
            return $threads;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function getPosts($threadId)
    {
        $posts = array();
        try
        {
            $statement = $this->db->prepare("SELECT * FROM security_post WHERE threadId=? ORDER BY id");
            $statement->bindValue(1, $threadId);
            $statement->execute();
            $result = $statement->fetchAll();
            foreach ($result as $row)
            {
                $post = new post();
                $post->setId($row[0]);
                $post->setThreadId($row[1]);
                $post->setUserId($row[2]);
                $post->setText($row[3]);
                $post->setRegistration($row[4]);
                array_push($posts, $post);
            }
            return $posts;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function getPostById($postId)
    {
        try
        {
            $statement = $this->db->prepare("SELECT * FROM security_post WHERE id=? LIMIT 1");
            $statement->bindValue(1, $postId);
            $statement->execute();
            $columns = $statement->fetch();
            $post = new post();
            $post->setId($columns[0]);
            $post->setThreadId($columns[1]);
            $post->setUserId($columns[2]);
            $post->setText($columns[3]);
            $post->setRegistration($columns[4]);
            return $post;
        }
        catch(PDOException $e)
        {
            return false;
        }
        
    }

    public function insertThread($thread)
    {
        try
        {
            $statement = $this->db->prepare("INSERT INTO security_thread(userId, title, registration) VALUES(?, ?, ?)");
            $statement->bindValue(1, $thread->getUserId());
            $statement->bindValue(2, $thread->getTitle());
            $statement->bindValue(3, $this->dateAndTime);
            $statement->execute();
            $this->lastInsertThreadId = $this->db->lastInsertId();
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function insertPost($post)
    {
        try
        {
            $statement = $this->db->prepare("INSERT INTO security_post(threadId, userId, text, registration) VALUES(?, ?, ?, ?)");
            $statement->bindValue(1, $post->getThreadId());
            $statement->bindValue(2, $post->getUserId());
            $statement->bindValue(3, $post->getText());
            $statement->bindValue(4, $this->dateAndTime);
            $statement->execute();
            $this->lastInsertPostId = $this->db->lastInsertId();
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    
    public function updatePost($post)
    {
        $postId = $post->getId();
        $text = $post->getText();
        try
        {
            $statement = $this->db->prepare("UPDATE security_post SET text=? WHERE id=?"); 
            $statement->execute(array($text, $postId));
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    public function deletePost($postId)
    {
        try
        {
            $statement = $this->db->prepare("DELETE FROM security_post WHERE id=?"); 
            $statement->execute(array($postId));
            return true;
        }
        catch(PDOException $e)
        {
            return false;
        }
    }
    
    
    public function getLastInsertThreadId()
    {
        return $this->lastInsertThreadId;
    }
    
    public function getLastInsertPostId()
    {
        return $this->lastInsertPostId;
    }
    
   

 
}