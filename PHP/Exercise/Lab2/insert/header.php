<?php
    $current_page = basename($_SERVER['PHP_SELF']);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <title><?php echo $page_title;?></title>
</head>
<body>
    <header>
        <div class="container">
            <h1>Pet Fun Run</h1>
        </div>
        <nav>
            <ul>
                <li>
                    <a href="index.php">Public</a>
                </li>
                <li>
                    <a href="insert.php">Insert</a>
                </li>
            </ul>
        </nav>
    </header>
</body>
</html>