<?php
require_once("thread.php");
require_once("post.php");
require_once("threadDAL.php");

class threadService
{
    private $threadDAL;

    public function __construct($threadDAL)
    {
        $this->threadDAL = $threadDAL;
    }
    
    public function saveSelectedThreadId($threadId)
    {
        $_SESSION['threadid'] = $threadId;
    }
    
    public function getSelectedThreadId()
    {
        return $_SESSION['threadid'];
    }
    
    public function saveSelectedPostId($postId)
    {
        $_SESSION['postid'] = $postId;
    }
    
    public function getSelectedPostId()
    {
        return $_SESSION['postid'];
    }
    
    
    public function getThread($id)
    {
        return $this->threadDAL->getThread($id);
    }
    
    public function getThreads()
    {
        return $this->threadDAL->getThreads();
        
    }
    
    public function getPosts($threadId)
    {
        return $this->threadDAL->getPosts($threadId);
    }
    
    public function getPostById($postId)
    {
        return $this->threadDAL->getPostById($postId);
    }
    
    public function deletePost($postId)
    {
        return $this->threadDAL->deletePost($postId);
    }
    
    public function getThreadsByUserId($userId)
    {
        
    }
    
    public function insertThread($thread)
    {
        return $this->threadDAL->insertThread($thread);
    }
    
    public function insertPost($post)
    {
        return $this->threadDAL->insertPost($post);
    }
    
    public function getLastInsertThreadId()
    {
        return $this->threadDAL->getLastInsertThreadId();
    }
    
    public function getLastInsertPostId()
    {
        return $this->threadDAL->getLastInsertPostId();
    }

    
}
    