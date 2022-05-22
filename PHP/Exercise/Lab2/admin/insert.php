<?php 
$owner_name = $phone = $pets = $pet_Name = $message = "";
session_start();
if (!isset($_SESSION['secure-login-lab2-done-hiden']))
{
    header("Location: login.php");
}

if (isset($_POST['insert-submit']))
{
    $owner_name = $_POST['owner_name'];
    $phone = $_POST['phone'];
    $pet_Name = $_POST['pet_Name'];
    $pets = $_POST['pets'];

    $handle = fopen("fopen/data.txt","a");

    fwrite($handle, "<p class=\"owner\">$owner_name</p>");
    fwrite($handle, "<p class=\"phone\">$phone</p>");
    fwrite($handle, "<p class=\"pets\">$pets</p>");
    fwrite($handle, "<p class=\"petname\">$pet_Name</p><hr>");


    fclose($handle);

    $owner_name = $phone = "";

    $message = "Information Saved!";
}

/***********************************************/
$page_title = "Insert";

include "include/header.php"
?>
<?php echo $message; ?>
<form action="" method="POST">
    <label for="owner_name">Owner Name</label>
    <input type="text" id="owner_name" name="owner_name" value="<?php echo $owner_name;?>">

    <label for="phone">Phone Number</label>
    <input type="text" id="phone" name="phone" value="<?php echo $phone; ?>">

    <label for="pet_Name">Pet Name</label>
    <input type="text" id="pet_Name" name="pet_Name" value="<?php echo $pet_Name;?>">

    <label for="pets">Select...</label>
    <select name="pets" id="pets">
        <option value="select">Select</option>
        <option value="Dog">Dog</option>
        <option value="Cats">Cats</option>
        <option value="Bird">Bird</option>
        <option value="Rabbit">Rabbit</option>
        <option value="Ferrit">Ferrit</option>
        <option value="Other">Other</option>
    </select>
    
    <input type="submit" name="insert-submit" value="Register">
</form>
<?php
include "include/footer.php"
?>