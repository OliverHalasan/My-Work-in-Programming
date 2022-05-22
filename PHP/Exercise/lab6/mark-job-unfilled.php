<?php 
session_start();
include 'inc/connect.php';
if (isset($_SERVER['HTTP_REFERER']))
{
    $refer = $_SERVER['HTTP_REFERER'];
    $refer = parse_url($refer, PHP_URL_PATH);
} else
{
    header("Location:index.php?m=illegalaction");
}


if (isset($_SESSION['must-be-unique-per-website-or-the-wrong-people-get-access']))
{
    if (isset($_GET['ad_id']) && is_numeric($_GET['ad_id']))
    {
        $ad_id = $_GET['ad_id'];
        $sql = "SELECT user_id FROM job_ads WHERE ad_id = $ad_id" ;
        $result = mysqli_query($conn,$sql);
        if (mysqli_num_rows($result) == 1)
        {
            $row = mysqli_fetch_row($result);
            $user_id = $row[0];

            if ($_SESSION['user_id'] == $user_id)
            {
              $update_sql = "UPDATE job_ads SET job_filled_yn = 'N' WHERE ad_id = $ad_id;";
              if (mysqli_query($conn, $update_sql)){
                  header("location:$refer?m=markedfilled");
              } else {
                header("location:$refer?m=errorupdating");
              }
            } else {
                header("location:$refer?m=notyourad");
            }
        }else {
            header("location:$refer?m=notrightid");
        }
    } else {
        header("location:$refer?m=notnumber");
    }
}else
{
    header("location:$refer?m=notloggedin");
}
?>