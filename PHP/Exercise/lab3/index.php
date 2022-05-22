<?php 
 $WEmail = $Name = $WName = $WSurname = $Surname = $Email = $Company = $Password = $CPassword = $RPassword = 
 $REmail = $day = $year = $month = $form_good = $Wyear = $Wday = $Wmonth = $WPassword =  $CWPassword = "";

if (isset($_POST['create']))
{
    $Name = trim($_POST['Name']);
    $Surname = trim($_POST['Surname']);
    $Email = trim($_POST['Email']);
    $day = trim($_POST['day']);
    $month = trim($_POST['month']);
    $year = trim($_POST['year']);
    $Password = trim($_POST['Password']);
    $CPassword = trim($_POST['CPassword']);
    $day = filter_var($day, FILTER_SANITIZE_NUMBER_INT);
    $month = filter_var($month, FILTER_SANITIZE_NUMBER_INT);
    $year = filter_var($year, FILTER_SANITIZE_NUMBER_INT);
    $form_good = true;
    $Name = filter_var($Name, FILTER_SANITIZE_STRING);
    $Surname = filter_var($Surname, FILTER_SANITIZE_STRING);
    $Company = filter_var($Company, FILTER_SANITIZE_STRING);
    $Password = filter_var($Password, FILTER_SANITIZE_STRING);
    $CPassword = filter_var($CPassword, FILTER_SANITIZE_STRING);
    $Email = filter_var($Email, FILTER_SANITIZE_STRING);

    if (strlen($Name) < 2 || strlen($Name) > 40)
    {
        $WName = "<p class=\"warning\">Min length is 2 and the Max length is 40</p>";
        $form_good = false;
    }

    if (strlen($Surname) < 2 || strlen($Surname) > 40)
    {
        $WSurname = "<p class=\"warning\">Min length is 2 and the Max length is 40</p>";
        $form_good = false;
    }

    $valid_email = filter_var($Email, FILTER_SANITIZE_EMAIL);
    $valid_email = filter_var($valid_email, FILTER_VALIDATE_EMAIL);
    if ($valid_email == False)
    {
        $WEmail = "<p class=\"warning\">Not a valid Email</p>";
        $form_good = false;
    }
    else
    {
        $SEmail = "<p class=\"success\">Your Email is Valid</p>";
    }
      
if (strlen($day) < 1 || strlen($day) > 2)
{
    $Wday = "<p class=\"warning\">Invalid please enter a proper day</p>";
    $form_good = false;
}
if (strlen($month) < 1 || strlen($day) > 2)
{
    $Wmonth = "<p class=\"warning\">Invalid please enter a proper Month</p>";
    $form_good = false;
}
if (strlen($year) < 4 || strlen($day) > 4)
{
    $Wyear = "<p class=\"warning\">Invalid please enter a proper Year</p>";
    $form_good = false;
}
if (empty($day)){
    $Wday = "<p class=\"warning\">Please enter a day</p>";
    $form_good = false;
}
if (empty($month)){
    $Wmonth = "<p class=\"warning\">Please enter a month</p>";
    $form_good = false;
}
if (empty($year)){
    $Wyear = "<p class=\"warning\">Please enter a year</p>";
    $form_good = false;
}

if (strlen($Password) < 8)
{
    $WPassword = "<p class=\"warning\">Cannot be less than 8</p>";
    $form_good = false;
}
if (strlen($CPassword) < 8)
{
    $CWPassword = "<p class=\"warning\">Cannot be less than 8</p>";
    $form_good = false;
}
if (empty($Password)){
    $WPassword = "<p class=\"warning\">Cannot be empty</p>";
    $form_good = false;
}
if (empty($CPassword)){
    $CWPassword = "<p class=\"warning\">Cannot be empty</p>";
    $form_good = false;
}

}
if ($form_good == true)
{
    header('Location: https://jhalasan1.dmitstudent.ca/DMIT2025/lab3/welcome.php');
    echo "<h1>thanks for registering</h1>";
}
?>
<?php
 $REmail = $RPassword = $message = "";
include "/home/jhalasan1/data/Lab3.php";
if (isset($_POST['Login']))
{
    $REmail = $_POST['REmail'];
    $RPassword = $_POST['RPassword'];
    $REmail = filter_var($REmail, FILTER_SANITIZE_STRING);
    $RPassword = filter_var($RPassword, FILTER_SANITIZE_STRING);


    if(($REmail == $valid_user) && (password_verify($RPassword, $encrypted_password) ))
    {
        session_start();
        $_SESSION['secure-login-lab3-done-hiden'] = session_id();
        $_SESSION['REmail'] = $REmail;
        header('Location: https://jhalasan1.dmitstudent.ca/DMIT2025/lab3/welcome.php');
        echo "<h1>Welcome $REmail</h1>";
    }
    else
    {
        $message = "<p class=\"warning\">Incorrect Password or Email</p>";
    }
    /***********************************************/


}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/styles.css">
    <title>Sign up or Login</title>
</head>
<body>
    <header>
        <div class="head">
        <h1>Sign up or Login</h1>
        <p>Sign up login with social and don't worry about your passwords!</p>
        <p>We promise not to share your date and post anything on your behalf</p>
        </div>
        <nav>
        <a href="https://www.Facebook.com">Facebook</a>
        <a href="https://www.Google.com">Google</a>
        </nav>
    </header>
    <main>
    <div class="SignUp">
        <h1>New Customer? Create Account</h1>
        <form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" method="POST">
    <div>
        <?php echo  $WName; 
                echo $Name;
        ?>
    <label for="Name">Name*</label>
    <input type="text" name="Name" id="Name" value="<?php echo $Name; ?>">
    </div>
    <div>
    <?php echo  $WSurname; 
            echo $Surname;
    ?>
    <label for="Surname">Surname*</label>
    <input type="text" name="Surname" id="Surname" value="<?php echo $Surname; ?>">
    </div>
    <div>
        <?php 
            echo $WEmail;
        ?>
    <label for="Email">Email*</label>
    <input type="text" name="Email" id="Email" value="<?php echo $Email; ?>">
    </div>
    <div>
        <?php 
            echo $Company;
        ?>
    <label for="Company">Company</label>
    <input type="text" name="Company" id="Company" value="<?php echo $Company; ?>">
    </div>
    <div class="date">
    <label for="Date">Date of Birth*</label>
    <?php 
    echo $Wday;
    echo $Wmonth;
    echo $Wyear;
    ?>
    <input type="text" name="day" id="day" placeholder="DD*" value="<?php echo $day; ?>">
    <input type="text" name="month" id="month" placeholder="MM*" value="<?php echo $month; ?>">
    <input type="text" name="year" id="year" placeholder="YYYY*" value="<?php echo $year; ?>">
    </div>
    <div>
    <?php 
            echo $WPassword;
        ?>
    <label for="Password">Password*</label>
    <input type="text" name="Password" id="Password" value="<?php echo $Password; ?>">
    </div>
    <div>
    <?php 
            echo $CWPassword;
        ?>
    <label for="CPassword">Confirm Password*</label>
    <input type="text" name="CPassword" id="CPassword" value="<?php echo $CPassword; ?>">
    </div>
    <input type="submit"  name="create" value="Create Account">
    </div>
    <div class="Login">
        <h1>Registred Customer? Sign in!</h1>
        <div>
        <?php echo $message; ?>
        <label for="REmail">Email*</label>
        <input type="text" name="REmail" id="REmail" value="<?php echo $REmail; ?>">
        </div>
        <div>
        <label for="RPassword">Password*</label>
        <input type="text" name="RPassword" id="RPassword" value="<?php echo $RPassword; ?>">
        </div>
        <div>
        <input type="submit" value="Log In" name="Login">
        </div>
        
    </div>
    </main>
</body>
</html>