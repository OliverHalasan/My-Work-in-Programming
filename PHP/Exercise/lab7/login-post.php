<?php
$validation = $email = $password = "";
    if (isset($_POST['login-submit']))
    {
        $email = trim($_POST['email']);
        $password = trim($_POST['password']);

        if ($email && $password)
        {
            $login_sql = "SELECT user_id, first_name, password FROM users where (user_names = '$email' OR email = '$email') AND deleted_yn = 'N'";
            $login_result = mysqli_query($conn, $login_sql);

            if (mysqli_num_rows($login_result) > 0)
            {
                $login_row = mysqli_fetch_assoc($login_result);

                $pswd = $login_row['password'];

                if (password_verify($password, $pswd))
                {
                    
                    $_SESSION['first_name'] = $login_row['first_name'];
                    $_SESSION['user_id'] = $login_row['user_id'];

                    $_SESSION['this-is-for-my-lab-7'] = session_id();

                    $_SESSION['login-time'] = time();

                    $update_sql = "UPDATE users SET date_last_login = NOW() WHERE user_id = " . $_SESSION['user_id'];
                    
                    if (mysqli_query($conn, $update_sql)) {
                        $validation = "<p class=\"success\">You have successfully logged in.</p>";
                    }
                    else
                    {
                        $validation = "<p class=\"error\">There was a problem.</p>";
                    }
                }
                else
                {
                    $validation = "<p class=\"error\">Sorry the username or password is incorrect. Please try again. </p>";
                }
            }
            else
            {
                $validation = "<p class=\"error\">Sorry the username or password is incorrect. Please try again.</p>";
            }
        }
    }
?>