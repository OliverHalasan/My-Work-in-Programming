<?php

include "../include/connect.php";

$id = $_GET['id'];

if (!$id || !is_numeric($id) )
{
    header("Location: update.php?m=error");
}
else
{
    $sql = "UPDATE Movie Set deleted_yn = 'Y' Where MovieId = $id";

    mysqli_query($conn, $sql);

    header("Location:update.php?m=success");
}
?>