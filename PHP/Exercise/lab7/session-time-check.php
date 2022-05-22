<?php
if (isset($_SESSION['login-time']))
{
    $current_time = time();

    $expiry = 30 * 60;

    if ($current_time > $_SESSION['login-time'] + $expiry)
    {
        session_destroy();
        header("Location: index.php?m=loggedout");
    }

}

?>