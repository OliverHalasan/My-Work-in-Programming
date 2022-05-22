<?php 
session_start();
$page_title = "home";
include "inc/connect.php";
if (isset($_GET))
{
    extract($_GET);
}
// include "admin/login-post.php";
include "admin/add-post.php";
// $user_id = $_SESSION['userid'];
?>

<?php 
include "inc/header.php";
?>


<?php 
// include "admin/login-form.php";
?>


<?php 
include "admin/add-form.php";
?>


<?php 
include "inc/footer.php";
?>