
<?php 
if (!defined("BASE_URL"))
{
    define("BASE_URL","https://jhalasan1.dmitstudent.ca/DMIT2025/lab6/");
}
if (!defined("THIS_PAGE")){
    define("THIS_PAGE", $_SERVER['PHP_SELF']);
}
$db_server = "localhost";
$db_username = "jhalasan1";
$db_password = "Blessor30";
$db_database = "jhalasan1";

$conn = new mysqli($db_server, $db_username, $db_password, $db_database);

if ($conn->connect_error) {
    die("Connection failed: " . $connect_error);
}
foreach ($_POST as $key => $value)
{
    $_POST[$key] = mysqli_real_escape_string($conn,$value);
}
foreach ($_GET as $key => $value) {
    $_GET[$key] = mysqli_real_escape_string($conn,$value);
}
?>