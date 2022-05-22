<?php 
	session_start();
	unset($_SESSION["secure-login-lab5-login-hiden"]);
	unset($_SESSION["username"]);
	header("Location: https://jhalasan1.dmitstudent.ca/DMIT2025/lab5/");

?>