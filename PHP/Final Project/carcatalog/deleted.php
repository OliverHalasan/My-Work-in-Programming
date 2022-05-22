<?php

include "inc/connect.php";

$carid = $_GET['carid'];

if (!$carid || !is_numeric($carid) )
{
    header("Location: index.php?m=error");
}
else
{
    $sql = "UPDATE car Set deleted_yn = 'Y' Where carid = $carid";

    mysqli_query($conn, $sql);

    header("Location:index.php?m=success");
}
?>