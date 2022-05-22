<?php 
$job_title = $job_ad = $validation = $file_name = $file_type = $tmp_name = $error = $size = $price = "";
if (isset($_POST['job-ad-submit'])) {
    $job_title = trim($_POST['job_title']);
    $job_ad = trim($_POST['job_ad']);
    $price = trim($_POST['price']);
    $file_name = $_FILES['file_to_upload']['name'];
    $file_type = $_FILES['file_to_upload']['type'];
    $tmp_name = $_FILES['file_to_upload']['tmp_name'];
    $error = $_FILES['file_to_upload']['error'];
    $size = $_FILES['file_to_upload']['size'];

    
  

    $form_good = true;
    // VALIDATION!!!!!!!!!
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
    if ($job_title == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">job title is a required field.</p>";
    }
    else
    {
        $job_title = filter_var($job_title, FILTER_SANITIZE_STRING);
        if ($job_title == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
            else
            { 
                if (strlen($job_title) > 40) 
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">Sorry, the maximum job title name is 40 characters.</p>";
                }
                else
                {
                    $job_title = ucwords($job_title);
                }
            } 
    } 

    if ($job_ad == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">ads is a required field.</p>";
    }
    else
    {
        $job_ad = filter_var($job_ad, FILTER_SANITIZE_STRING);
        if ($job_ad == false)
            {
                $form_good = false;
                $validation .= "<p class=\"error\">please try again.</p>";
            }
    }   
    
    if ($price == "")
{
    
    $form_good = false;
    $validation .= "<p class=\"error\">Price cannot be empty</p>";
}
else
{
    $price = filter_var($price, FILTER_SANITIZE_STRING);
    if ($price == false)
            {
                $form_good = false;
                $validation .= "<p>Sorry, there was a problem saving your price. Please try again. </p>";
            }
    
}


    if ($form_good == true)
    {
        $user_id = $_SESSION['user_id'];
        if (isset ($ad_id)){
            $query = "UPDATE job_ads SET title = '$job_title', ad = '$job_ad', file_name = '$file_name', price = '$price' WHERE ad_id = $ad_id";
        }
        else 
        {
            $query = "INSERT INTO job_ads (title,ad,user_id,file_name,price) VALUES ('$job_title', '$job_ad', $user_id, '$file_name','$price')";
        }
            
        if (mysqli_query($conn, $query))
    {
        $validation .= "<p class=\"success\">Your ad was posted successfully. </p>";
        $job_title = $job_ad = "";
    }
    else
    {
        $validation .= "<p>Sorry, there was a problem saving your ad. Please try again. </p>";
    }
}
else
{
    $job_title = $job_ad = "";
}

if (move_uploaded_file($tmp_name, "uploaded_files/$file_name")) {
    
    // resize_image("uploaded_files/$file_name", "images/", $file_type, 200 );
    resize_image("uploaded_files/$file_name", "uploaded_files/", $file_type, 250 );
}
else
{
    $validation .= "<p class=\"error\">There was a problem uploading.</p>";
}


    }
    // echo $insert_sql;
    

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