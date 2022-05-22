<?php 
$page_title = "Register";
$first_name = $last_name = $user_names = $email = $password = $validation ="";
include "inc/connect.php"; 


if (isset($_POST['submit']))
{
    $first_name = trim($_POST['first_name']);
    $last_name = trim($_POST['last_name']);
    $user_names = trim($_POST['user_names']);
    $email = trim($_POST['email']);
    $password = trim($_POST['password']);

    
    $form_good = true;
    //validation****************************************************************************************
    if ($first_name == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">First name is required is a required field.</p>";
    }
    else
    {
        $first_name = filter_var($first_name, FILTER_SANITIZE_STRING);
        if ($first_name == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($first_name) > 50) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum First name is 50 characters.</p>";
                }
                else
                {
                    $first_name = ucwords($first_name);
                }
            } 
    } 
    if ($last_name == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Last name is required is a required field.</p>";
    }
    else
    {
        $last_name = filter_var($last_name, FILTER_SANITIZE_STRING);
        if ($last_name == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($last_name) > 50) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum Last name is 50 characters.</p>";
                }
                else
                {
                    $last_name = ucwords($last_name);
                }
            } 
    } 
    if ($user_names == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">User name is required is a required field.</p>";
    }
    else
    {
        $user_names = filter_var($user_names, FILTER_SANITIZE_STRING);
        if ($user_names == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($user_names) > 50) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum User name is 50 characters.</p>";
                }
            } 
    } 
    if ($email == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Email address is required is a required field.</p>";
    }
    else
    {
        $email = filter_var($email, FILTER_SANITIZE_STRING);
        $email = filter_var($email, FILTER_VALIDATE_EMAIL);
        if ($email == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($email) > 50) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum Last name is 50 characters.</p>";
                }
            } 
    } 
    if ($password == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Password is required is a required field.</p>";
    }
    else
    {
        $password = filter_var($password, FILTER_SANITIZE_STRING);
        if ($password == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($password) > 50) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum Last name is 50 characters.</p>";
                }
            } 
    } 
    //if email or username already exist raise an error message

    if ($user_names || $email)
    {
        $check_sql = "SELECT user_id FROM users WHERE (email = '$email' OR user_names = '$user_names') AND deleted_yn = 'N' ";
        $check_res = $conn->query($check_sql);
        if ($check_res->num_rows > 0)
        {
            $form_good = false;
            $validation ="<p class=\"error\"> Sorry that username or email is already exists. Please try again another.</p>";
        }
    }



    if ($form_good == TRUE)
    //inser into db
    {
        $encrypted_password = password_hash($password, PASSWORD_DEFAULT);

        $sql = "INSERT INTO users (first_name, last_name, user_names, password, email) 
        value ('$first_name','$last_name','$user_names','$encrypted_password','$email')";
        if ($conn->query($sql))
        {
            $validation = "<p class=\"success\">You have registered</p>";
            $first_name = $last_name = $user_names = $email = $password;
        }
        else
        {
            $validation = "<p class=\"error\">There was a problem. $conn->error</p>";
        }
    }
}

?>


<?php include "inc/header.php"; ?>
<div class="register">
<h1>Register</h1>


<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST">
<?php 
    if ($validation): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="first_name">First Name</label>
<input type="text" name="first_name" id="first_name" value="<?php echo $first_name ?>">

<label for="last_name">Last Name</label>
<input type="text" name="last_name" id="last_name" value="<?php echo $last_name ?>">

<label for="user_names">User Name</label>
<input type="text" name="user_names" id="user_names" value="<?php echo $user_names ?>">

<label for="email">email</label>
<input type="text" name="email" id="email" value="<?php echo $email ?>">

<label for="password">Passoword</label>
<input type="text" name="password" id="password" value="<?php echo $password ?>">

<input type="submit" name="submit" value="Register!">
</div>

<?php include "inc/footer.php"; ?>