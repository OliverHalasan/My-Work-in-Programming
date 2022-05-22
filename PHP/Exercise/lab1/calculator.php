<?php
$firstNumber = $equation = $secondNumber = $result = "";
    if (isset($_GET['form_submit'])) {
        $firstNumber = $_GET['firstNumber'];
        $equation = $_GET['equation'];
        $secondNumber = $_GET['secondNumber'];

        switch ($equation) {
            case '+':
                $result = $firstNumber + $secondNumber;
                break;
            case '-':
                $result = $firstNumber - $secondNumber;
                break;
            case '*':
                $result = $firstNumber * $secondNumber;
                break;
            case '/':
                $result = $firstNumber / $secondNumber;
                break;
                
            default:
                echo "Error";
                break;
        }
    }
    ?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="css/styles.css">

    <title>Calculator</title>
</head>
<body>
<header>
        <h1>Calculator</h1>
        <nav>
					<div class="menu">
						<hr>
						<a href="https://jhalasan1.dmitstudent.ca/DMIT2025/lab1/">Home</a>
						<hr>
						<a href="https://jhalasan1.dmitstudent.ca/DMIT2025/lab1/MadLib.php">MadLib</a>
						<hr>
						<a href="https://jhalasan1.dmitstudent.ca/DMIT2025/lab1/calculator.php">Calculator</a>
						<hr>
						<a href="https://jhalasan1.dmitstudent.ca/DMIT2025/php-intro.php">Php-Intro</a>
						<hr>
					</div>
				</nav>			
    </header>
    <form action="" method="GET">
        <label for="firstNumber">First Number</label>
        <input type="number" id="firstNumber" name="firstNumber" value="<?php echo $firstNumber?>">
        <select name="equation" id="equation">
            <option value="select">Select...</option>
            <option value="+" <?php if ($equation == "+") {echo "selected";} ?>>Add</option>
            <option value="-" <?php if ($equation == "-") {echo "selected";} ?>>Subtract</option>
            <option value="*" <?php if ($equation == "*") {echo "selected";} ?>>Multiply</option>
            <option value="/" <?php if ($equation == "/") {echo "selected";} ?>>divide</option>
        </select>
        <div> 
        <label for="secondNumber">Second Number</label>
        <input type="number" id="secondNumber" name="secondNumber" value="<?php echo $secondNumber?>"></div>
       
        <input type="submit" name="form_submit" value="Submit">
    </form>

    <?php 
        echo "The Answer for $firstNumber$equation$secondNumber is  $result";
    ?>

</body>
</html>

 <!-- if the button has been pressed -->
