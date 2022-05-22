<?php 
// var_dump($_SERVER);
$current_page = basename($_SERVER['PHP_SELF']);

// echo $current_page;
?>

<!DOCTYPE html>
<html lang='en'>
  <head>
    <meta charset='utf-8'>
    <title><?php echo $page_title; ?></title>
    <link href='http://fonts.googleapis.com/css?family=Anton' rel='stylesheet' type='text/css'>
	<link href="assets/styles/styles.css" rel="stylesheet" type="text/css">
	<link rel="stylesheet" type="text/css" href="assets/styles/live.css">

</head>
<body>
	<header>
		<div class="container clearfix">
			<div class="span3 column">
				<a href="index.php" class="logo">
					<img src="assets/images/logo.png" alt="EAS Logo">
				</a>
			</div>
			<nav class="span9 column">
				<ul class="navbar">
					<li><a href="index.php" 
                    <?php 
                    if ($current_page == "index.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >Home</a></li>

					<li><a href="about_us.php"
                    <?php 
                    if ($current_page == "about_us.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >About Us</a></li>
					<li><a href="adoptions.php"
                    <?php 
                    if ($current_page == "adoptions.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >Adoptions</a></li>
					<li><a href="events.php"
                    <?php 
                    if ($current_page == "events.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >Special Events</a></li>
					<li><a href="support.php"
                    <?php 
                    if ($current_page == "support.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >Your Support</a></li>
					<li><a href="contact.php"
                    <?php 
                    if ($current_page == "contact.php") {
                        echo 'class="active"';
                    }
                    ?>
                    >Contact Us</a></li>
				</ul>
			</nav>
		</div>
	</header>
	<div class="banner">
		<div class="container clearfix">
			<!-- new -->
			<img src="assets/images/banner.jpg" alt="Cute Dog Image">
			<div class="span4 bannerLink">
				<h1>SAVE A LIFE</h1>
				<p>DONATE TODAY <a class="advance-button" href="support.php"><img src="assets/images/paw_print.png"></a></p>
			</div>
		</div>
	</div>