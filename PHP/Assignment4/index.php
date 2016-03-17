<?php
	require_once("session.php");
	require_once("controller.php");
	require_once("HTMLview.php");
	ini_set('display_errors', 'Off');
        
	$session = new session();
    $session->start_session('_s', false);
	
	$c = new controller();
    $h = new HTMLview();
    $body = $c->doIt();
    $h->echoHTML($body);
?>