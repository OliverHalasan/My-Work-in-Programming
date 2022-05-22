<?php
 $username = $password = $message = "";
include "/home/jhalasan1/data/data4.php";
if (isset($_POST['login-submit']))
{
    $username = $_POST['username'];
    $password = $_POST['password'];

    // echo "$username $password";

    if(($username == $valid_user) && (password_verify($password, $encrypted_password) ))
    {
        // $message = "all good!";
        session_start();
        $_SESSION['secure-login-lab4-login-hiden'] = session_id();
        $_SESSION['username'] = $username;
        header("Location: insert.php");
        header("Location: update.php");
    }
    else
    {
        $message = "something is wrong";
    }
    /***********************************************/


}
$page_title = "Login";

include "../include/header.php";
?>
<form action="" method="POST">
    <label for="username">Username</label>
    <input type="text" name="username" value="<?php  $username; ?>">

    <label for="password">Password</label>
    <input type="password" name="password" value="<?php  $password; ?>">

    <input type="submit" name="login-submit" value="Login!">
</form>

<?php if ($message) 
{
    echo "<div class=\"loginError\">$message</div>";
} 

?>
<?php 
    include "../include/footer.php";
?> 