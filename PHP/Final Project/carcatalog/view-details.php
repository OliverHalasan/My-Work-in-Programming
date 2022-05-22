<?php 

if (isset($_GET['view'])){
    $view = $_GET['view'];
    $viewdetails = "AND (car.carid LIKE '$view')";
    $viewcar = true;
}
else
{
    $view = "";
    $viewdetails = "";
    $viewcar = false;
}

?>