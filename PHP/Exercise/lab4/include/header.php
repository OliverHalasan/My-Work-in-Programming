<?php 
    include "connect.php"
?>

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
    <a href="<?php echo BASE_URL; ?>index.php">Course Management</a>
        <nav>
            <ul>
                <li><a href="<?php echo BASE_URL; ?>index.php">Index</a></li>
                <li><a href="<?php echo BASE_URL; ?>list.php">List</a></li>
                <li><a href="<?php echo BASE_URL; ?>search.php">Search</a></li>
                <li><a href="<?php echo BASE_URL; ?>admin/insert.php">Insert</a></li>
                <li><a href="<?php echo BASE_URL; ?>admin/update.php">Update</a></li>
            </ul>
        </nav>
    </header>
    <main>

