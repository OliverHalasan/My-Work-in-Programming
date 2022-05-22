<?php
 $username = $password = $message = "";
include "/home/jhalasan1/data/data.php";
if (isset($_POST['login-submit']))
{
    $username = $_POST['username'];
    $password = $_POST['password'];

    // echo "$username $password";

    if(($username == $valid_user) && (password_verify($password, $encrypted_password) ))
    {
        // $message = "all good!";
        session_start();
        $_SESSION['secure-login-lab2-done-hiden'] = session_id();
        $_SESSION['username'] = $username;
        $_SESSION['login-date'] = date("M d Y, g:i a");
        header("Location: insert.php");
    }
    else
    {
        $message = "something is wrong";
    }
    /***********************************************/


}
$page_title = "Login";

include "include/header.php";
?>
<form action="" method="POST">
    <label for="username">Username</label>
    <input type="text" name="username" value="<?php echo $username; ?>">

    <label for="password">Password</label>
    <input type="password" name="password" value="<?php echo $password; ?>">

    <input type="submit" name="login-submit" value="Login!">
</form>

<?php if ($message) 
{
    echo "<div> class=\"valdiation\">$message</div>";
} 

?>
<?php 
    include "include/footer.php";
?> 