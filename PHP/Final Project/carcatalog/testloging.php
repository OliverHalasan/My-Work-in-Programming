<?php 
session_start();
$page_title = "home";
include "inc/connect.php";

 include 'login-post.php';
?>

<?php 
include "inc/header.php";

include "login-form.php";
?>


<?php 
include "inc/footer.php";
?>