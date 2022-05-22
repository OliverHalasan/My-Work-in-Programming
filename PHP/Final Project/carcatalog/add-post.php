<?php 
$car_name = $Manufacturer = $Years = $Type_of_car = $Made = $Base_engine_type = $Engine_size = $Drive_type = $Total_seating = 
$Estimated_Price = $Cylinders = $Description = $image = $size = $file_type = $validation = $error = $ad_id = $tmp_name ="";
if (isset($_POST['NewCar'])) {
    $car_name = trim($_POST['car_name']);
    $Manufacturer = trim($_POST['Manufacturer']);
    $Years = trim($_POST['Years']);
    $Type_of_car = trim($_POST['Type_of_car']);
    $Made = trim($_POST['Made']);
    $Base_engine_type = trim($_POST['Base_engine_type']);
    $Engine_size = trim($_POST['Engine_size']);
    $Drive_type = trim($_POST['Drive_type']);
    $Total_seating = trim($_POST['Total_seating']);
    $Estimated_Price = trim($_POST['Estimated_Price']);
    $Cylinders = trim($_POST['Cylinders']);
    $Description = trim($_POST['Descriptions']);
    $image = $_FILES['images']['name'];
    $file_type = $_FILES['images']['type'];
    $tmp_name = $_FILES['images']['tmp_name'];
    $error = $_FILES['images']['error'];
    $size = $_FILES['images']['size'];


//if the form is good
$form_good = true;
//image validation
if ($size > 1000000) {
    $form_good = FALSE;
    $validation .= "<p class=\"error\">Sorry, maximum size allowed is 1Mb</p>";
}

$allowed_file_types = array("image/jpeg", "image/pjpeg", "image/png", "image/webp");

if (!in_array($file_type, $allowed_file_types)) {
    $form_good = false;
    $validation .= "<p class=\"error\">Sorry, that file type is not allowed</p>";
}

if ($error > 0) {
    $form_good = false;
    $validation .= "<p class=\"error\">Sorry, there was a problem with the file</p>";
}
// name validation
if ($car_name == "")
{
    $form_good = false;
    $validation .= "<p class=\"error\">car name cannot be empty</p>";
}
else
{
    $car_name = filter_var($car_name, FILTER_SANITIZE_STRING);
    if ($car_name == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($car_name) > 100)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max car name is only 100 characters</p>";
        }
        else {
            $car_name = ucwords(($car_name));
        }
    }

}
//end name
// Manufacturer Validation
if ($Manufacturer == "") 
{
    $validation .= "<p class=\"error\">Manufacturer cannot be empty</p>";
    $form_good = false;
}
else
{
    $Manufacturer = filter_var($Manufacturer, FILTER_SANITIZE_STRING);
    if ($Manufacturer == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Manufacturer) > 50)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Manufacturer is only 50 characters</p>";
        }
        else {
            $Manufacturer = ucwords(($Manufacturer));
        }
    }
}
//end manufacturer
//Date
if ($Years == "")
{
    $form_good = false;
    $validation .= "<p class=\"error\">Year is a required field.</p>";
}
$Years = filter_var($Years, FILTER_SANITIZE_STRING);
//end date
//car type
if ($Type_of_car == "") 
{
    $validation .= "<p class=\"error\">Type of car cannot be empty</p>";
    $form_good = false;
}
else
{
    $Type_of_car = filter_var($Type_of_car, FILTER_SANITIZE_STRING);
    if ($Type_of_car == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Type_of_car) > 50)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Type of car is only 50 characters</p>";
        }
        else {
            $Type_of_car = ucwords(($Type_of_car));
        }
    }
}
//end of type of car
// made
if ($Made == "") 
{
    $validation .= "<p class=\"error\">Assembled cannot be empty</p>";
    $form_good = false;
}
else
{
    $Made = filter_var($Made, FILTER_SANITIZE_STRING);
    if ($Made == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Made) > 100)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Made is only 100 characters</p>";
        }
        else {
            $Made = ucwords(($Made));
        }
    }
}
//end made
//base engine type
if ($Base_engine_type == "") 
{
    $validation .= "<p class=\"error\">Base engine type cannot be empty</p>";
    $form_good = false;
}
else
{
    $Base_engine_type = filter_var($Base_engine_type, FILTER_SANITIZE_STRING);
    if ($Base_engine_type == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Base_engine_type) > 50)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Base engine type is only 50 characters</p>";
        }
        else {
            $Base_engine_type = ucwords(($Base_engine_type));
        }
    }
}
//end of base engine type
//engine size 
if ($Engine_size == "") 
{
    $validation .= "<p class=\"error\">Engine size cannot be empty</p>";
    $form_good = false;
}
else
{
    $Engine_size = filter_var($Engine_size, FILTER_SANITIZE_STRING);
    if ($Engine_size == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Engine_size) > 10)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Engine_size is only 10 characters</p>";
        }
        else {
            $Engine_size = ucwords(($Engine_size));
        }
    }
}
//end of engine size
//cylinder
if ($Cylinders == "") 
{
    $validation .= "<p class=\"error\">Cylinders cannot be empty</p>";
    $form_good = false;
}
else
{
    $Cylinders = filter_var($Cylinders, FILTER_SANITIZE_STRING);
    if ($Cylinders == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Cylinders) > 10)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Cylinders is only 10 characters</p>";
        }
        else {
            $Cylinders = ucwords(($Cylinders));
        }
    }
}
//end of cylinders
//description
$Description = filter_var($Description, FILTER_SANITIZE_STRING);
//END OF DESCRIPTION
//DRIVE TYPE
if ($Drive_type == "") 
{
    $validation .= "<p class=\"error\">Drive type cannot be empty</p>";
    $form_good = false;
}
else
{
    $Drive_type = filter_var($Drive_type, FILTER_SANITIZE_STRING);
    if ($Drive_type == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Drive_type) > 50)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Drive type is only 50 characters</p>";
        }
        else {
            $Drive_type = ucwords(($Drive_type));
        }
    }
}
//end of drive type
//price
if ($Estimated_Price == "") 
{
    $validation .= "<p class=\"error\">Estimated Price cannot be empty</p>";
    $form_good = false;
}
else
{
    $Estimated_Price = filter_var($Estimated_Price, FILTER_SANITIZE_STRING);
    if ($Estimated_Price == false)
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please try again</p>";
    }
    else
    {
        if (strlen($Estimated_Price) > 10)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">The max Estimated Price is only 10 characters</p>";
        }
        else {
            $Estimated_Price = ucwords(($Estimated_Price));
        }
    }
}
if ($form_good == true)
{
     $user_id = $_SESSION['user_id'];
     if (isset ($carid))
     {
         $query = "UPDATE car SET Name = '$Name', Manufacturer = '$Manufacturer', Years = '$Years', Type_of_car = '$Type_of_car', Made = '$Made', 
         Base_engine_type = '$Base_engine_type', Engine_size = '$Engine_size', Drive_type = '$Drive_type', Total_seating = '$Total_seating', 
         Estimated_Price = '$Estimated_Price', Cylinders = '$Cylinders', Descriptions = '$Description', images = '$image' WHERE carid = $carid";
     }
     else
     {
        $query = "INSERT INTO car (car_name, Manufacturer, Years, Type_of_car, Made, Base_engine_type, Engine_size, Drive_type, Total_seating, Estimated_Price, Cylinders, Descriptions, images, user_id) 
        Value ('$car_name','$Manufacturer','$Years','$Type_of_car','$Made','$Base_engine_type','$Engine_size','$Drive_type','$Total_seating','$Estimated_Price','$Cylinders','$Description','$image', $user_id)";
     }
     if (mysqli_query($conn, $query))
     {
         $validation .= "<p class=\"success\">Your ad was posted successfully. </p>";
     }
     else
     {
         $validation .= "<p>Sorry, there was a problem saving your ad. Please try again.$conn->error </p>";
     }
}
   


    if (move_uploaded_file($tmp_name, "img_files/$image")) {
    
        // resize_image("img_files/$image", "images/", $file_type, 200 );
        resize_image("img_files/$image", "img_files/", $file_type, 250 );
    }
    else
    {
        $validation .= "<p class=\"error\">There was a problem uploading.</p>";
    }
}

    function resize_image($file,$folder,$file_type,$new_width)
{
    list($width,$height) = getimagesize($file);
    $img_ratio = $width/$height;
    $new_height = $new_width/$img_ratio;

    $new_file = imagecreatetruecolor($new_width, $new_height);
    $source = imagecreatefromjpeg($file);

    imagecopyresampled($new_file, $source, 0, 0, 0, 0, $new_width, $new_height, $width, $height);

    $new_fileName = $folder . basename($file);
    imagejpeg($new_file, $new_fileName, 80);

    imagedestroy($new_file);
    imagedestroy($source);
}
?>