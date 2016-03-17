<?php
require_once("db_connection.php");
require_once("session.php");
require_once("view.php");
require_once("user.php");
require_once("userDAL.php");
require_once("userService.php");
require_once("thread.php");
require_once("post.php");
require_once("threadDAL.php");
require_once("threadService.php");

class controller
{
    private $view;
    private $db_connection;
    private $userDAL;
    private $userService;
    
    private $messages = array();
    private $registerValues = array("", "", "", "", "");
    private $threadValues = array(); 
    
    private $loginInputFieldNames = array("Username", "Password");
    private $registerInputFieldNames = array("Username", "Password", "Repeated password", "Name", "Mail");
    
    
    
    public function __construct()
    {
        $this->view = new view();
        $this->db_connection = new db_connection();
        $this->userDAL = new userDAL($this->db_connection->getDb());
        $this->userService = new userService($this->userDAL);
        $this->threadDAL = new threadDAL($this->db_connection->getDb());
        $this->threadService = new threadService($this->threadDAL);
    }

    public function sanitizeRegisterInput($input)
    {
        $output = trim($input);
        $output = str_replace(' ', '', $output);
        $output = preg_replace("/\s+/", " ", $output);
        $output = strip_tags($output);
        $output = stripslashes($output);
        $output = htmlspecialchars($output);
        $output = str_replace("'", "", $output);
        return $output;
    }
    
    public function sanitizeThreadInput($input)
    {
        //$output = trim($input);
        //$output = preg_replace("/\s+/", " ", $input);
        $output = strip_tags($input);
        $output = stripslashes($output);
        $output = htmlspecialchars($output);
        //$output = str_replace("'", "", $output);
        return $output;
    }
    
    public function isAlphaNumeric($input)
    {
        $valids = array('-', '_', '@', '.'); 

        if(ctype_alnum(str_replace($valids, '', $input))) 
        { 
            return true; 
        }
        else
        {
            return false;
        }
    }
    
    public function isAlphaNumericThread($input)
    {
        $valids = array('-', '_', '@', '.', '!', '?', '$' ,'&', '%', ' ', '(', ')', '/\s+/', "'", 'å', 'ä', 'ö', "\n", "\r", ','); 

        if(ctype_alnum(str_replace($valids, '', $input))) 
        { 
            return true; 
        }
        else
        {
            return false;
        }
    }
    
    public function validateRegisterInput($input)
    {
        if (($input != $this->sanitizeRegisterInput($input)) === false &&
        $this->isAlphaNumeric($input))
        {
            if (strlen($input) >= 5 && strlen($input) <= 30)
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
    
    public function validateThreadTitlesInput($input)
    {
        if (($input != $this->sanitizeThreadInput($input)) === false &&
        $this->isAlphaNumericThread($input))
        
        {
            if (strlen($input) >= 5 && strlen($input) <= 30)
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
    
    public function validateThreadContentInput($input)
    {
        if (($input != $this->sanitizeThreadInput($input)) === false &&
        $this->isAlphaNumericThread($input))
        
        {
            if (strlen($input) >= 5 && strlen($input) <= 900)
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
    public function invalidInputMessage($fieldName)
    {
        $message = $fieldName . " contains illegal characters and/or is empty.";
        array_push($this->messages, $message);
    }
    
    
    public function addThreadValue($value)
    {
        array_push($this->threadValues, $value);
    }
    
    public function registerInputValidation($inputs, $fields)
    {
        $counter = 0;
        $nonValidFound = 0;
        
        foreach ($inputs as $input)
        {
            if ($this->validateRegisterInput($input))
            {
                $this->registerValues[$counter] = $input;
            }
            else
            {
                $nonValidFound++;
                $this->invalidInputMessage($fields[$counter]);
            }
            $counter++;
        }
        
        if ($nonValidFound === 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
    // used both by a user not logged in and user who is logged in and who wants to change user information
    public function registerUser($userId, $userRole)
    {
    
        $inputValues = $this->view->getRegisterUserInput();
        if ($this->registerInputValidation($inputValues, $this->registerInputFieldNames))
        {
            
            if ($inputValues[1] === $inputValues[2])
            {
                $user = new user();
                $user->setUserName($inputValues[0]);
                $user->setPassword(password_hash($inputValues[1], PASSWORD_DEFAULT));
                $user->setRole($userRole);
                $user->setName($inputValues[3]);
                $user->setMail($inputValues[4]);

                if ($userId === 0 && $this->userService->userNameExists($inputValues[0]) === false )
                {
                    if ($this->userService->registerUser($user))
                    {
                        $this->view->setLoginFormMessages("Registration succeeded!");
                        $ret = $this->view->setLoginForm();
                    }
                    else
                    {
                        $this->view->setLoginFormMessages("Registration failed!");
                        $ret = $this->view->setLoginForm();
                    }
                }
                
                else if ($userId != 0)
                {
                    $user->setId($userId);
                    if ($this->userService->updateUser($user))
                    {
                        $ret = $this->view->setLoginForm();   
                    }
                    else
                    {
                        $ret = $this->view->setRegisterForm();
                    }
                }
                
                else if ($this->userService->userNameExists($inputValues[0]) && $userId === 0)
                {
                    $this->view->setRegisterFormMessages("Username is already in use.");
                    foreach ($this->registerValues as $value)
                        { $this->view->setRegisterFormValues($value); }

                    $ret = $this->view->setRegisterForm();
                }
            } // password match end

            else if ($inputValues[1] != $inputValues[2])
            {
                $this->view->setRegisterFormMessages("Password and repeated password do not match.");
                foreach ($this->registerValues as $value)
                    { $this->view->setRegisterFormValues($value); }

                $ret = $this->view->setRegisterForm();
            }

        } //input valid end

        else
        {
            foreach($this->messages as $message) 
                { $this->view->setRegisterFormMessages($message); }
    
            foreach ($this->registerValues as $value)
                { $this->view->setRegisterFormValues($value); }

            $ret .= $this->view->setRegisterForm();    
        }
        
        return $ret;
    } // register user end
    
    
    public function userWindow($user)
    {
        if ($user->getRole() == 1)
        {
            $ret = $this->view->setUserFormAdmin($user);    
        }
        else
        {
            $ret = $this->view->setUserForm($user);
        }
        return $ret;
    }
    
    
    public function threadList()
    {
        $ret .= $this->view->setNewThreadActivationBox();
        $threads = $this->threadService->getThreads();
        foreach ($threads as $thread)
        {
            $ret .= $this->view->setThreadBox($thread);
        }
        
        return $ret;
    }
    
    public function postList($threadId, $userRole)
    {
        $ret .= $this->view->setNewPostActivationBox();
        $threadTitle = $this->threadService->getThread($threadId)->getTitle();
        $ret .= $this->view->setThreadHeader($threadTitle);
        $posts = $this->threadService->getPosts($threadId);
        foreach ($posts as $post)
        {
           $userName = $this->userService->getUserById($post->getUserId())->getUserName();
           
           if ($userRole == 1 || $userRole == 2)
           {
               $ret .= $this->view->setPostBoxDelete($post, $userName);
           }
           
           else
           {
               $ret .= $this->view->setPostBox($post, $userName);
           }

        }
        return $ret;
    }
    
    public function userList($userRole)
    {
        $users = $this->userService->getUsers();

        foreach ($users as $user)
        {

           if ($userRole == 1)
           {
               $ret .= $this->view->setUserListBox($user);
           }
           else
           {
               
           }
          
        }
        
        return $ret;
             
    }
    
    
    
    public function doIt()
    {
        ini_set('display_errors', 'Off');
     
        // user is logged in
        // possible to start new threads, reply on posts and change user information
        if ($this->userService->userIsLoggedIn())
        {
            $user = $this->userService->getUserBySession();
            $userRole = $user->getRole();
            $ret = $this->userWindow($user);
            
            
            
            // new thread request
            if ($this->view->createNewThreadRequest())
            {
                $ret .= $this->view->setNewThreadForm();
            }

            // submit the new thread request        
            else if ($this->view->submitNewThreadRequest())
            {
                $title = $this->view->getNewThreadInput()[0];
                $message = $this->view->getNewThreadInput()[1];
                
                
                // validate the thread input
                if ($this->validateThreadTitlesInput($title) && $this->validateThreadContentInput($message))
                {
                    $userId = $user->getId();
                    $thread = new thread();
                    $thread->setUserId($userId);
                    $title = preg_replace("/\s+/", " ", $title);
                    $title = trim($title);
                    $thread->setTitle($title);
                    
                    // insert the thread title in thread table and check if it works
                    if ($this->threadService->insertThread($thread))
                    {
                        $threadId = $this->threadService->getLastInsertThreadId();
                        $post = new post();
                        $post->setThreadId($threadId);
                        $post->setUserId($userId);
                        $message = preg_replace("/\s+/", " ", $message);
                        $message = trim($message);
                        $post->setText($message);
                        
                        if (!$this->threadService->insertPost($post))
                        {
                            $this->view->setNewThreadFormMessages("Creation of new thread failed!");
                            $ret .= $this->view->setNewThreadForm();
                        }
                        else
                        {
                            $ret .= $this->postList($threadId, $userRole);
                        }
                    }
                    
                    // thread title failed and therefore whole thread failed
                    else
                    {
                        $this->view->setNewThreadFormMessages("Creation of new thread failed!");
                        $ret .= $this->view->setNewThreadForm();
                    }
 
                } // validate the thread input end 

                // If the new thread request input does NOT pass validation
                else
                {
                    if ($this->validateThreadTitlesInput($title)) { $this->addThreadValue($title); }
                        else { $this->invalidInputMessage("Title"); $this->addThreadValue(""); }
                    
                    if ($this->validateThreadContentInput($message)) { $this->addThreadValue($message); }
                        else { $this->invalidInputMessage("Message"); $this->addThreadValue(""); }
                    
                    // Send the messages to the message array in the view, which is presented in the new thread form
                    $messes = $this->messages;
                    foreach($messes as $mess)
                    {
                        $this->view->setNewThreadFormMessages($mess);
                    }
                    
                    // Send the values to the value array in the view
                    foreach ($this->threadValues as $value)
                    {
                        $this->view->setNewThreadFormValues($value);
                    }                
                    
                    $ret .= $this->view->setNewThreadForm();
                }

                
            } // the new thread submit request end
            

            // second request scenario in loggedin mode
            // View posts in selected thread
            else if ($this->view->viewThreadRequest())
            {
                $threadId = $this->view->getSelectedThreadId();
                
                // The selected thread ID will be stored in session
                $this->threadService->saveSelectedThreadId($threadId);
                $ret .= $this->postList($threadId, $userRole);
                
            } // view posts in selected thread end
            
            
            // third request scenario in logged in mode
            // Create new post in existing thread
            else if ($this->view->createNewPostRequest())
            {
                $threadId = $this->threadService->getSelectedThreadId($threadId);
                $thread = $this->threadService->getThread($threadId);
                $title = $thread->getTitle();
                $ret .= $this->view->setNewPostForm($title);
            }
            
            
            // fourth request scenario in logged in mode
            // Submit the new post in existing thread
            else if ($this->view->submitNewPostRequest())
            {
                $userId = $user->getId();
                $threadId = $this->threadService->getSelectedThreadId();
                $message = $this->view->getNewPostInput();
                
                // input validation of new post
                if ($this->validateThreadContentInput($message))
                {
                    $post = new post();
                    $post->setThreadId($threadId);
                    $post->setUserId($userId);
                    $message = preg_replace("/\s+/", " ", $message);
                    $message = trim($message);
                
                    $post->setText(trim($message));
                
                    if ($this->threadService->insertPost($post))
                    {
                        $this->threadService->saveSelectedThreadId($threadId);
                        $ret .= $this->postList($threadId, $userRole);
                    }
                    /*else
                    {
                        
                    }*/
                } // input validation of new post end
                
                // if input validation of new post did not pass
                else if ($this->validateThreadContentInput($message) === false)
                {
                    $this->view->setNewPostFormMessage("Post might be too short, and/or contains illegal characters and/or is empty!");
                    $threadId = $this->threadService->getSelectedThreadId($threadId);
                    $thread = $this->threadService->getThread($threadId);
                    $title = $thread->getTitle();
                    $ret .= $this->view->setNewPostForm($title);
                }
                else
                {
                    $ret .= $this->postList($threadId, $userRole);
                }
                    
            } // Submit new post in existing thread end


            // Admin or moderator deleting post
            else if ($this->view->deletePostRequest())
            {
                $postId = $this->view->getSelectedPostId();
                $this->threadService->deletePost($postId);
                
                
                $threadId = $this->threadService->getSelectedThreadId();
                $role = $user->getRole();
                $ret .= $this->postList($threadId, $role);
            }
            
            
            // fifth request scenario in loggedin mode
            // user want to change user information
            else if ($this->view->changeUserInformationRequest())
            {
                $this->view->setRegisterFormValues($user->getUserName());
                $this->view->setRegisterFormValues("");
                $this->view->setRegisterFormValues("");
                $this->view->setRegisterFormValues($user->getName());
                $this->view->setRegisterFormValues($user->getMail());
                $ret .= $this->view->setRegisterForm();
            }
            
            // sixth request scenario in loggedin mode
            else if ($this->view->submitChangedUserInformationRequest())
            {
                $userId = $user->getId();
                $userRole = $user->getRole();
                $ret .= $this->registerUser($userId, $userRole);   
            }
            
            // Admin able to delete user
            else if ($this->view->viewUserListRequest())
            {
                $ret .= $this->userList($userRole);
            }
            
            else if ($this->view->deleteUserRequest() && ($user->getRole() == 1))
            {
                $deleteUserId = $this->view->getDeleteUserId();
                $this->userService->deleteUser($deleteUserId);
                $ret .= $this->userList($userRole);
            }
            
            else if ($this->view->moderatorRequest() && ($user->getRole() == 1))
            {
                $moderatorId = $this->view->getModeratorId();
                $this->userService->setUser($moderatorId);
                $ret .= $this->userList($userRole);
            }
            
            
            else if ($this->view->logoutRequest())
            {
                $this->userService->logoutUser($user->getUserName());
                $ret = $this->view->setLoginForm();
            }
            
            else if ($this->view->threadsRequest())
            {
                $ret .= $this->threadList();
            }
            
            // if none of the above scenarios in loggedin mode
            else
            {
                $ret .= $this->threadList();
            }

        }// loggedin mode end

        // notloggedin mode
        else if ($this->userService->userIsLoggedIn() === false)
        {
            // first request scenario in notloggedin mode
            // Login form requested
            if ($this->view->loginViewRequest())
            {
                $ret = $this->view->setLoginForm();
            }
        
            // second request scenario in notloggedin mode
            // Register form requested
            else if ($this->view->registerViewRequest())
            {
                $ret = $this->view->setRegisterForm();
            }


            // third request scenario notloggedinmode
            // Login user
            else if ($this->view->submitLoginRequest())
            {
                $inputValues = $this->view->getLoginUserInput();
                //input validation
                if ($this->registerInputValidation($inputValues, $this->loginInputFieldNames))
                {
              
                    // Successfull login
                    if ($this->userService->loginSuccess($inputValues[0], $inputValues[1]) === true)
                    {
                        $user = $this->userService->getUser($inputValues[0]);                        
                        
                        $this->userService->loginUser($user);
                        if ($user->getRole() == 1)
                        {
                            $ret .= $this->view->setUserFormAdmin($user);
                            $ret .= $this->threadList();
                        }
                        else
                        {
                            $ret .= $this->view->setUserForm($user);
                            $ret .= $this->threadList();
                        }
                    }
                    
                    // Failed login
                    else
                    {
                        $this->view->setLoginFormMessages("Login failed!");
                        $ret = $this->view->setLoginForm();
                    }
                } // input validation end
                
                // input did not pass validation
                else
                {
                    foreach($this->messages as $message) 
                        { $this->view->setLoginFormMessages($message); }
            
                    foreach ($this->registerValues as $value)
                        { $this->view->setLoginFormValues($value); }

                    $ret = $this->view->setLoginForm();    
                }
                
            } // login user end (third request scenario end)
 
            
            // fourth request scenario in notloggedin mode            
            // Register user
            else if ($this->view->submitRegisterRequest())
            {
                $ret = $this->registerUser(0, 3);        
            }
            
            // if none of the above scenarios in notloggedinmode
            else
            {
                $ret = $this->view->setLoginForm();
            }    

        } // not loggedinmode end    
        
        $this->db_connection->closeDb();
        
        return $ret;
    } // doIt end
    
 }// class end
?>