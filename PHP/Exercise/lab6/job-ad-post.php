<?php 
$job_title = $job_ad = $validation = "";
if (isset($_POST['job-ad-submit'])) {
    $job_title = trim($_POST['job_title']);
    $job_ad = trim($_POST['job_ad']);

    $form_good = true;
    // VALIDATION!!!!!!!!!
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

    if ($form_good == true)
    {
        $user_id = $_SESSION['user_id'];
        if (isset ($ad_id)){
            $query = "UPDATE job_ads SET title = '$job_title', ad = '$job_ad' WHERE ad_id = $ad_id";
        }
        else 
        {
            $query = "INSERT INTO job_ads (title,ad,user_id) VALUES ('$job_title', '$job_ad', $user_id)";
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

    }
    // echo $insert_sql;
    
?>