<?php

include "inc/connect.php";

$ad_id = $_GET['ad_id'];

if (!$ad_id || !is_numeric($ad_id) )
{
    header("Location: index.php?m=error");
}
else
{
    $sql = "UPDATE job_ads Set deleted_yn = 'Y' Where ad_id = $ad_id";

    mysqli_query($conn, $sql);

    header("Location:index.php?m=success");
}
?>