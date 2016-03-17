<?php
//require_once("thread.php");
//require_once("threadlist.php");
//require_once("member.php");
//require_once("memberlist.php");
//require_once("post.php");

    class view
    {

        private $loginFormContent;
        private $loginFormMessages = array();
        private $loginFormValues = array();
        private $loginUserName;
        private $roles = array("Administrator", "Moderator", "Regular user");
        
        
        private $registerFormContent;
        private $registerFormMessages = array();
        private $registerFormValues = array();
        
        private $userFormContent;
        private $threadListFormContent;
        private $newThreadFormContent;
        private $newThreadActivationBoxContent;
        private $threadBoxContent;
        private $postBoxContent;
        
        private $newPostFormContent;
       
         
        private $newPostActivationBoxContent;
        private $newThreadFormMessages = array();
        private $newThreadFormValues = array();
        private $newPostFormMessage;
        
        private $postMessageValue;
        

        public function __construct()
        {
        }
        
        public function registerViewRequest()
        {
            if (isset($_GET["registerView"]))
                return true;
            return false;
        }
        
        public function loginViewRequest()
        {
            if (isset($_GET["loginView"]))
                return true;
            return false;
        }
        
        public function logoutRequest()
        {
            if (isset($_GET["logout"]))
                return true;
            return false;
        }
        
        public function submitLoginRequest()
        {
            if (isset($_POST["loginUser"]))
                return true;
            return false;   
        }
        
        public function submitRegisterRequest()
        {
            if (isset($_POST["registerUser"]))
                return true;
            return false;   
        }
        
        public function changeUserInformationRequest()
        {
            if (isset($_GET["changeInformation"]))
                return true;
            return false;
        }
        
        public function viewUserListRequest()
        {
            if (isset($_GET["viewUserList"]))
                return true;
            return false;
        }
        
        public function deleteUserRequest()
        {
            if (isset($_GET["deleteUser"]))
                return true;
            return false;
        }
        
        public function submitChangedUserInformationRequest()
        {
            if (isset($_POST["registerUser"]))
                return true;
            return false;
        }
        
        public function createNewThreadRequest()
        {
            if (isset($_POST["newThread"]))
                return true;
            return false;
        }
        
        public function submitNewThreadRequest()
        {
            if (isset($_POST["registerThread"]))
                return true;
            return false;
        }
        
        public function viewThreadRequest()
        {
            if (isset($_GET["viewthread"]))
                return true;
            return false;
        }
        
        public function getSelectedThreadId()
        {
            if (isset($_GET["threadid"]))
                return $_GET["threadid"];
        }
        
        public function threadsRequest()
        {
            if (isset($_GET["threadsRequest"]))
                return $_GET["threadsRequest"];
        }
        
        public function createNewPostRequest()
        {
            if (isset($_POST["newPost"]))
                return true;
            return false;
        }
        
        public function submitNewPostRequest()
        {
            if (isset($_POST["registerPost"]))
                return true;
            return false;
        }
        
        public function getSelectedPostId()
        {
            if (isset($_GET["postid"]))
                return $_GET["postid"];
        }
       
        public function deletePostRequest()
        {
            if (isset($_GET["deletePost"]))
                return true;
            return false;
        }
        
        public function getDeleteUserId()
        {
            if (isset($_GET["deleteuserid"]))
                return $_GET["deleteuserid"];
        }
        
        public function moderatorRequest()
        {
            if (isset($_GET["moderator"]))
                return true;
            return false;
        }
        
        public function getModeratorId()
        {
            if (isset($_GET["moderatorid"]))
                return $_GET["moderatorid"];
        }
        
        public function getLoginUserInput()
        {
            $loginUserInput = array_fill(0, 2, "");
            $loginUserInput[0] = $_POST["loginUserName"];
            $loginUserInput[1] = $_POST["loginPassword"];
            return $loginUserInput;
        }
        
        public function getRegisterUserInput()
        {
            $registerUserInput = array_fill(0, 5, "");
            $registerUserInput[0] = $_POST["registerUserName"];
            $registerUserInput[1] = $_POST["registerPassword"];
            $registerUserInput[2] = $_POST["registerPasswordRepeat"];
            $registerUserInput[3] = $_POST["registerName"];
            $registerUserInput[4] = $_POST["registerMail"];
            return $registerUserInput;
        }
        
        public function getNewThreadInput()
        {
            $newThreadInput = array_fill(0, 2, "");
            $newThreadInput[0] = $_POST["threadTitle"];
            $newThreadInput[1] = $_POST["message"];
            return $newThreadInput;
        }
        
        public function getNewPostInput()
        {
            $newPostInput = $_POST["postmessage"];
            return $newPostInput;
        }
        
        
        public function setLoginFormMessages($message)
        {
            array_push($this->loginFormMessages, $message);
        }
        
        public function setLoginFormValues($value)
        {
            array_push($this->loginFormValues, $value);
        }
    
        public function setRegisterFormMessages($message)
        {
            array_push($this->registerFormMessages, $message);
        }
        
        public function setRegisterFormValues($value)
        {
            array_push($this->registerFormValues, $value);
        }

        public function setNewThreadFormMessages($message)
        {
            array_push($this->newThreadFormMessages, $message);
        }
        
        public function setNewThreadFormValues($value)
        {
            array_push($this->newThreadFormValues, $value);
        }
        
        public function setNewPostFormMessage($message)
        {
            $this->newPostFormMessage = $message;
        }
        
        public function setPostMessageValue($value)
        {
            $this->postMessageValue = $value;
        }

        public function setLoginForm()
        {
            $this->loginFormContent =  
            "<form action=?loginUser method=post>
                <fieldset>
                <legend>Login - enter username and password</legend>";
                    
                    if (!empty($this->loginFormMessages))
                    {
                        $this->loginFormContent .="<p>";
                            foreach ($this->loginFormMessages as $message)
                            {
                                $this->loginFormContent .= $message . "<br>";
                            }
                        $this->loginFormContent .="</p>";
                    }
                    
            $this->loginFormContent .="
                Username: <br><input type=text name=loginUserName value=" . $this->loginFormValues[0] . "><br>
                Password: <br><input type=password name=loginPassword><br>
                <br>
                <input type=submit value=Login name=loginUser>
                </fieldset>
            </form>
            <a href='?registerView'>Register user</a>";
            return $this->loginFormContent;
        }
        
        public function setRegisterForm()
        {
            $this->registerFormContent = "
                <form action='?registerUser' method='post'>
			    <fieldset>
				<legend>Register user - enter username and password</legend>";
				
			    if (!empty($this->registerFormMessages))
                {
                    $this->registerFormContent .="<p>";
                        foreach ($this->registerFormMessages as $message)
                        {
                            $this->registerFormContent .= $message . "<br>";
                        }
                    $this->registerFormContent .="</p>";
                }
                    
			$this->registerFormContent .="
		        Username: <br><input type=text name=registerUserName value=" . $this->registerFormValues[0] . ">";
			    $this->registerFormContent .= "<br><br>";
			    $this->registerFormContent .="Password: <br><input type=password name=registerPassword value=" . $this->registerFormValues[1] .
			    ">";
				$this->registerFormContent .="<br><br>";
				$this->registerFormContent .="Repeat password: <br><input type=password name=registerPasswordRepeat 
				value =" . $this->registerFormValues[2] . ">";  
				$this->registerFormContent .="<br><br>";
				$this->registerFormContent .="Name: <br><input type=text name=registerName value=" . $this->registerFormValues[3] . ">";
				$this->registerFormContent .="<br><br>";
				$this->registerFormContent .="Mail: <br><input type=email name=registerMail value =" . $this->registerFormValues[4] . ">";
				$this->registerFormContent .="<br><br>";
				$this->registerFormContent .="Registration: <input type=submit value=Submit name=registerUser>
				</fieldset>
			    </form>
			    <a href='?loginView'>Login</a>";
			    return $this->registerFormContent;
        }
        
        
        
        
        
        public function setUserForm($user)
        {
            $this->userFormContent = "
                <form action='?newThread' method='post'>
                <fieldset>
				<legend>Hello " . $user->getName() . "! You are logged in as " . $user->getUserName() . "</legend> 
				<a href='?threadsRequest'>Threads</a>
				<a href='?changeInformation'>Change my information</a>
				<a href='?logout'>Logout</a>
				</fieldset>
				</form><br>";
		    return $this->userFormContent;
        }
        
        public function setUserFormAdmin($user)
        {
            $this->userFormContent = "
                <form action='?newThread' method='post'>
                <fieldset>
				<legend>Hello " . $user->getName() . "! You are logged in as " . $user->getUserName() . "</legend> 
				<a href='?threadsRequest'>Threads</a>
				<a href='?changeInformation'>Change my information</a>
				<a href='?viewUserList'>View users</a>
				
				<a href='?logout'>Logout</a>
				</fieldset>
				</form><br>";
		    return $this->userFormContent;
        }
        
        public function setThreadHeader($title)
        {
            return "<h2>" . $title . "</h2>";
        }
        
        public function setUserListBox($user)
        {
            $this->userListBoxContent = "<fieldset>" 
            . "<br>Username: "
            . $user->getUserName()
            . "<br>Role: "
            . $this->roles[$user->getRole() - 1]
            . "<br>Name: "
            . $user->getName() 
            . "<br>Mail: "
            . $user->getMail() 
            . "<br>Member since: "
            . $user->getRegistrationDate() 
            . "<br><a href='?deleteUser&deleteuserid=" . $user->getId() . "'>Delete user</a>" 
            . "<br><a href='?moderator&moderatorid=" . $user->getId() . "'>Turn into moderator</a>" .            
            "</fieldset><br>";
            return $this->userListBoxContent;
        }
        
        
        public function setNewThreadActivationBox()
        {
            $this->newThreadActivationBoxContent = "
            <form action='?newThread' method='post'>
                <fieldset>
				<input type=submit value='Create new thread' name=newThread>
				</fieldset>
				</form><br>";
		    return $this->newThreadActivationBoxContent;
        }

        
        
        
        public function setThreadBox($thread)
        {
            $this->threadBoxContent = "<fieldset><a href='?viewthread&threadid="
            . $thread->getId() . "'>" . $thread->getTitle() . "</a></fieldset><br>";
            return $this->threadBoxContent;
        }
        
        
        
        public function setNewPostActivationBox()
        {
            $this->newPostActivationBoxContent = "
            <form action='?newPost' method='post'>
                <fieldset>
				<input type=submit value='Create new post' name=newPost>
				</fieldset>
				</form><br>";
		    return $this->newPostActivationBoxContent;
        }
        
        
        
        
        public function setPostBox($post, $userName)
        {
            $this->postBoxContent = "<fieldset>" . 
            "<br>Message: " . $post->getText() .
            "<br>Posted by: " . $userName .
            "<br>" . $post->getRegistration() .
            "</fieldset><br>";
            return $this->postBoxContent;
        }
        
        
        
        public function setPostBoxDelete($post, $userName)
        {
            $this->postBoxContent = "<fieldset>" . 
            "<br>Message: " . $post->getText() .
            "<br>Posted by: " . $userName .
            "<br>" . $post->getRegistration() .
            "<br><a href='?deletePost&postid=" . $post->getId() . "'>Delete post</a>" .
            "</fieldset><br>";
            return $this->postBoxContent;
        }
        
        
        
        public function setNewThreadForm()
        {
            $this->newThreadFormContent = "
                <form action='?registerThread' method='post'>
			    <fieldset>
				<legend>Create new thread</legend>";
				if (!empty($this->newThreadFormMessages))
                {
                    $this->newThreadFormContent .="<p>";
                        foreach ($this->newThreadFormMessages as $message)
                        {
                            $this->newThreadFormContent .= $message . "<br>";
                        }
                    $this->newThreadFormContent .="</p>";
                }
                $this->newThreadFormContent .= "
		        Title: <br><input type=text name=threadTitle value =" . $this->newThreadFormValues[0] . "><br><br>
		        Message: <br>
		        <textarea rows='10' cols='50' name=message>".$this->newThreadFormValues[1]."</textarea>
				</fieldset>
				<input type=submit value=Create name=registerThread>
			    </form>";
		    return $this->newThreadFormContent;
        }
        
        
        
        
        public function setNewPostForm($title)
        {
            $this->newPostFormContent = "
                <form action='?registerPost' method='post'>
			    <fieldset>
				<legend>" . $title . "</legend>";
				if ($this->newPostFormMessage != "")
                {
                    $this->newPostFormContent .="<p>"
                        . $this->newPostFormMessage . 
                    "</p>";
                }
                $this->newPostFormContent .= "
		        Message: <br>
		        <textarea rows='10' cols='50' name=postmessage>".$this->postMessageValue."</textarea>
				</fieldset>
				<br>
				<input type=submit value=Register name=registerPost>
			    </form>";
		    return $this->newPostFormContent;
        }
        
        
        
        
        
        
        
    }
        