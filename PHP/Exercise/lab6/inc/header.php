<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="../css/style.css">
    <title><?php echo $page_title; ?></title>
</head>
<body>
    <header>
    <a href="<?php echo BASE_URL; ?>index.php">Help Wanted!</a>
        <nav>
            <ul>
                <li><a href="<?php echo BASE_URL; ?>index.php">Home</a></li>
                <?php if (isset($_SESSION['must-be-unique-per-website-or-the-wrong-people-get-access'])): ?>
                    <li><a href="my-home.php">My Home</a></li>
                    <li><a href="logout.php">Logout</a></li>
                    <!-- <li><a href="Changepass.php">Change Password</a></li> -->
                <?php else: ?>
                    <li><a href="<?php echo BASE_URL; ?>register.php">Register</a></li>
                <?php endif ?>
            </ul>
        </nav>
    </header>
    <main>

