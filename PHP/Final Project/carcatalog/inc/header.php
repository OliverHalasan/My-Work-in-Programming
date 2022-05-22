<?php 
 include "search-post.php";

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
        
    <h1><a href="<?php echo BASE_URL; ?>index.php">Car Catalog</a></h1>
     <button class="toggle-btn">      
            <svg viewBox="0 0 100 80">
                <rect rx="8"></rect>
                <rect y="30" rx="8"></rect>
                <rect y="60" rx="8"></rect>
            </svg>
            </button> 
        <nav>
            <ul class="menu">
                <li><a href="<?php echo BASE_URL; ?>list.php">List</a></li>
                <li><a href="<?php echo BASE_URL; ?>cartype.php">Sedan</a></li>
                <li><a href="<?php echo BASE_URL; ?>year.php">90s Car</a></li>
                <li><a href="<?php echo BASE_URL; ?>honda.php">Honda</a></li>
                <?php if (isset($_SESSION['this-is-the-final-project-dmit-2025'])): ?>
                
                    <li><a href="<?php echo BASE_URL; ?>logout.php">logout</a></li>
                
                <?php endif ?>
                   
            </ul>
            <div class="search">
            <?php 
                     include "search-form.php";

                    ?>
                    </div>
        </nav>
    </header>
    <main>

