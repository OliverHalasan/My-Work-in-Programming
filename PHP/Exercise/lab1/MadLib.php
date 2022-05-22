<?php 
$FirstName = $LastName = $Time = $Date = $Colour = $Garment = $Gender = $pronoun = $Lastname = $gender = $story = "";
    if (isset($_GET['submit_MadLib'])) {
        $FirstName = $_GET['FirstName'];
        $LastName = $_GET['LastName'];
        $Date = $_GET['Date'];
        $Time = $_GET['Time'];
        $Colour = $_GET['Colour'];
        $Garment = $_GET['Garment'];
        $Gender = $_GET['Gender'];

        if ($Gender == "male")
        {
            $pronoun = "boy";
        }
        else
        {
            $pronoun = "girl";
        }

        $story = "<p>Once upon a time, there was a  $pronoun named $FirstName $LastName. One fine day on the date of $Date around $Time, $FirstName was out and about wearing a $Colour $Garment 
        and looking for something to do. then $FirstName saw a cute girl walking by. \"Hey Cutie\" said $FirstName. The girl looked in the direction of $FirstName, 
        and fell down laughing. \"What are you doing wearing that ridiculous $Colour $Garment?\" said the girl. and $FirstName was laughing too and felt ashamed 
        wearing a $Colour $Garment. They introduced themselves to each other and became friends. the next day they meet again and the girl see the $pronoun wearing a $Colour $Garment again
        and wondering why he was wearing the samething and the girl went to the $pronoun $FirstName ask why he was wearing it again. $FirstName says that \"This is my favourite $Garment
        I wanted to wear them everyday as much as i could\" the girl start laughing again to him because he was so weird</p>";

}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="css/styles.css">

    <title>MadLib</title>
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
    <div class="MadLib">
    <form action="" method="GET">
        <div class="inputdesign">
        <div>
        <label for="FirstName">First Name</label>
        <input type="text" id="FirstName" name="FirstName" value="<?php echo $FirstName; ?>">
        
        <label for="LastName">Last Name</label>
        <input type="text" id="LastName" name="LastName" value="<?php echo $Lastname; ?>">
        </div>
        <div>
        <label for="Date">Date</label>
        <input type="date" id="Date" name="Date" value="<?php echo $Date; ?>">
        </div>
        <div>
            <label for="Time">Time</label>
            <input type="time" id="Time" name="Time" value="<?php echo $Time; ?>">
        </div>
        <div>
        <label for="Colour">Favourite Colour</label>
        <select name="Colour" id="Colour">
            <option value="select">Select...</option>
            <option value="Blue" <?php if ($Colour == "Blue") {echo "selected";} ?> >Blue</option>
            <option value="Green" <?php if ($Colour == "Green") {echo "selected";} ?> >Green</option>
            <option value="Red" <?php if ($Colour == "Red") {echo "selected";} ?> >Red</option>
            <option value="Yellow" <?php if ($Colour == "Yellow") {echo "selected";} ?>>Yellow</option>
            <option value="Purple" <?php if ($Colour == "Purple") {echo "selected";} ?>>Purple</option>
            <option value="Violet" <?php if ($Colour == "Violet") {echo "selected";} ?>>Violet</option>
            <option value="White" <?php if ($Colour == "White") {echo "selected";} ?>>White</option>
            <option value="Black" <?php if ($Colour == "Black") {echo "selected";} ?>>Black</option>
        </select>
        </div>
        <div>
        <label for="Garment">Garment</label>
        <select name="Garment" id="Garment">
            <option value="select">Select...</option>
            <option value="Sunglasses" <?php if ($Garment == "Sunglasses") {echo "selected";} ?>>Sunglasses</option>
            <option value="Baseball Cap" <?php if ($Garment == "Baseball Cap") {echo "selected";} ?>>Baseball Cap</option>
            <option value="Business Suit" <?php if ($Garment == "Business Suit") {echo "selected";} ?>>Business Suit</option>
            <option value="Hoodies" <?php if ($Garment == "Hoodies") {echo "selected";} ?>>Hoodies</option>
            <option value="Bras" <?php if ($Garment == "Bras") {echo "selected";} ?>>Bras</option>
            <option value="Boxers And Briefs" <?php if ($Garment == "Boxers And Briefs") {echo "selected";} ?>>Boxers And Briefs</option>
            <option value="Tank Top" <?php if ($Garment == "Tank Top") {echo "selected";} ?>>Tank Top</option>
            <option value="T-Shirts" <?php if ($Garment == "T-Shirts") {echo "selected";} ?>>T-Shirts</option>
        </select>
        </div>
        <div class="gender">
        <label for="Male">Male</label>
        <input type="radio" id="Male" name="Gender" value="Male" 
        <?php 
        if ($gender == "Male") { echo "checked";}
        ?>>
        <label for="Female">Female</label>
        <input type="radio" id="Female" name="Gender" value="Female"
        <?php 
        if ($gender == "Female") { echo "checked";}
        ?>>
       
        </div>
        <div>
        <input type="submit" name="submit_MadLib" value="Tell me a Story">
        </div>
    </div>
        <?php
   {

       echo "$story";
    }
    ?>
        </div>
        </div>
    </form>
</body>
</html>